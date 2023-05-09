using MonitorigProcess.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitoringProcess.Forms
{
    public partial class FavoriteManagerForm : FormBorderShadow
    {
        private IniFile ini = new IniFile();
        private readonly string iniFavoriteSection = "favorite";
        public FavoriteManagerForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            listViewAllProcess.Items.AddRange(
                Array.ConvertAll(Process.GetProcesses(),
                    new Converter<Process, ListViewItem>(proc => new ListViewItem(proc.ProcessName))).OrderBy(item => item.Text).ToArray());

            ini.Load(AppConfiguration.iniPath);

            listViewMyFavorite.Items.AddRange(
                ini[iniFavoriteSection].Values.Select(ival => new ListViewItem(ival.ToString())).OrderBy(item => item.Text).ToArray());
        }

        #region Form Drag Move
        private bool mouseDown;
        private Point lastLocation;

        private void FavoriteManagerForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void FavoriteManagerForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void FavoriteManagerForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        #endregion

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            HashSet<string> selectedSet = new HashSet<string>();
            foreach (ListViewItem item in listViewAllProcess.SelectedItems)
            {
                selectedSet.Add(item.Text);
            }

            HashSet<string> resultSet = new HashSet<string>(selectedSet);
            foreach (ListViewItem item in listViewMyFavorite.Items)
            {
                resultSet.Add(item.Text);
            }

            listViewMyFavorite.Items.Clear();
            listViewMyFavorite.Items.AddRange(resultSet.Select(str => new ListViewItem(str)).ToArray());
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewMyFavorite.SelectedItems)
            {
                listViewMyFavorite.Items.Remove(item);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ini.Load(AppConfiguration.iniPath);
            ini[iniFavoriteSection].Clear();/* .Values.Select(ival=>ival.ToString());*/
            
            for(int i=0;i< listViewMyFavorite.Items.Count; i++)
            {
                ini[iniFavoriteSection][i.ToString()] = listViewMyFavorite.Items[i].Text;
            }
            ini.Save(AppConfiguration.iniPath);
        }
    }
}
