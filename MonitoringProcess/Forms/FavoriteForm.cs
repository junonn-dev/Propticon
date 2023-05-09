using MonitorigProcess.Config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MonitoringProcess.Forms
{
    public partial class FavoriteForm : FormBorderShadow
    {
        private bool mouseDown;
        private Point lastLocation;
        private bool isChanged = false;
        private IniFile ini = new IniFile();
        private readonly string iniFavoriteSection = "favorite";
        private List<ListViewItem> allFavoriteProcess = new List<ListViewItem>();

        public FavoriteForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void RefreshFavoriteProcess()
        {
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
    }
}
