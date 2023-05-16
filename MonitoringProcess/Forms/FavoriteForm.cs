using MonitorigProcess.Config;
using MonitorigProcess.Helper;
using MonitoringProcess.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static MonitorigProcess.Program;

namespace MonitoringProcess.Forms
{
    public partial class FavoriteForm : FormBorderShadow
    {
        private bool mouseDown;
        private Point lastLocation;
        private bool isChanged = false;
        private IniFile ini = new IniFile();
        private readonly string iniFavoriteSection = "favorite";
        private readonly string iniConfigSection = "Config";
        private readonly string iniConfigPidSection = "Config-pid";
        private List<ListViewItem> allFavoriteProcess = new List<ListViewItem>();

        public event EventHandler<EventArgs> selectedProcessSaveEvent;

        private void OnRaiseSelectedProcessSaveEvent(EventArgs e)
        {
            selectedProcessSaveEvent?.BeginInvoke(this, e, null, null);
        }

        public FavoriteForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            listViewSelectedProcess.Items.AddRange(Bindings.selectedProcesses
                .Select(process => new ListViewItem(new string[] { process.Name, process.Id.ToString() })).ToArray());
            UpdateLabelProcessCount();
        }

        private void RefreshFavoriteProcess()
        {
            ini = new IniFile();
            ini.Load(AppConfiguration.iniPath);

            IEnumerable<string> favoriteProcessNames = ini[iniFavoriteSection]
                .Values.Select(ival=>ival.ToString())
                .OrderBy(str=>str);

            Process[] runningFavoriteProcess = Process.GetProcesses()
                .Where(runningProc => favoriteProcessNames.Contains(runningProc.ProcessName))
                .OrderBy(proc=>proc.ProcessName).ToArray();

            listViewFavoriteProcess.Items.Clear();
            listViewFavoriteProcess.Items.AddRange(
                Array.ConvertAll(runningFavoriteProcess,
                    new Converter<Process, ListViewItem>(proc =>
                        new ListViewItem(new string[] { proc.ProcessName, proc.Id.ToString() }))));

            allFavoriteProcess.Clear();
            foreach (ListViewItem item in listViewFavoriteProcess.Items)
            {
                allFavoriteProcess.Add(item);
            }
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            if (isChanged)
            {
                var result = MessageBox.Show("즐겨찾는 프로세스가 반영되지 않습니다. 닫으시겠습니까?", "", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void buttonFavoriteManager_Click(object sender, EventArgs e)
        {
            FavoriteManagerForm form = new FavoriteManagerForm();
            form.ShowDialog();
            RefreshFavoriteProcess();
        }

        private void FavoriteForm_Load(object sender, EventArgs e)
        {
            RefreshFavoriteProcess();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = "";
            RefreshFavoriteProcess();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            listViewFavoriteProcess.Items.Clear();

            listViewFavoriteProcess.Items.AddRange(allFavoriteProcess
                .Where(item => item.Text.Contains(textBoxSearch.Text))
                .ToArray());
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //PID로 중복 체크
            //1. Favorite Process에서 선택된 프로세스의 PID로 HashSet에 담음
            //2. Selected Process 리스트에서 
            HashSet<int> selectedSet = new HashSet<int>();
            foreach (ListViewItem item in listViewFavoriteProcess.SelectedItems)
            {
                //PID 가져오기위해서 Subitem으로 하는데 더 나은 방법?
                selectedSet.Add(Int32.Parse(item.SubItems[1].Text));
            }

            HashSet<int> resultSet = new HashSet<int>(selectedSet);
            foreach (ListViewItem item in listViewSelectedProcess.Items)
            {
                resultSet.Add(Int32.Parse(item.SubItems[1].Text));
            }

            if (resultSet.Count > Constants.maxconfig)
            {
                MessageBox.Show($"최대 등록 가능한 프로세스는 {Constants.maxconfig}개 입니다.");
                return;
            }
            else
            {
                HashSet<int> currentSelectedProcesSet = new HashSet<int>();
                foreach (ListViewItem item in listViewSelectedProcess.Items)
                {
                    currentSelectedProcesSet.Add(Int32.Parse(item.SubItems[1].Text));
                }

                foreach (ListViewItem item in listViewFavoriteProcess.SelectedItems)
                {
                    if (!currentSelectedProcesSet.Contains(Int32.Parse(item.SubItems[1].Text)))
                    {
                        listViewSelectedProcess.Items.Add(new ListViewItem(new string[] { item.SubItems[0].Text, item.SubItems[1].Text }));
                    }
                }
            }
            UpdateLabelProcessCount();
        }

        private void UpdateLabelProcessCount()
        {
            labelProcessCount.Text = $"{listViewSelectedProcess.Items.Count} / {Constants.maxconfig}";
        }


        #region Mouse Drag
        private void FavoriteForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void FavoriteForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void FavoriteForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        #endregion

        private void buttonDeleteProcess_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewSelectedProcess.SelectedItems)
            {
                listViewSelectedProcess.Items.Remove(item);
            }
            UpdateLabelProcessCount();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ini.Load(AppConfiguration.iniPath);
            ini[iniConfigSection].Clear();
            ini[iniConfigPidSection].Clear();
            for (int i = 0; i < listViewSelectedProcess.Items.Count; i++)
            {
                ini[iniConfigSection][i.ToString()] = listViewSelectedProcess.Items[i].Text;
                ini[iniConfigPidSection][i.ToString()] = listViewSelectedProcess.Items[i].SubItems[1].Text;
            }
            ini.Save(AppConfiguration.iniPath);

            Bindings.selectedProcesses.Clear();
            foreach (ListViewItem item in listViewSelectedProcess.Items)
            {
                int pid = Int32.Parse(item.SubItems[1].Text);
                string processName = item.SubItems[0].Text;
                Bindings.selectedProcesses.Add(new SelectedProcess(pid, processName, InstanceNameConvertor.GetProcessInstanceName(pid, processName)));
            }

            OnRaiseSelectedProcessSaveEvent(new EventArgs());

            MessageBox.Show("저장되었습니다.");
        }
    }
}
