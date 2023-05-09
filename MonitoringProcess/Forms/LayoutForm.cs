using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MonitorigProcess.UserControls.resources;
using MonitoringProcess.Forms;

namespace MonitorigProcess.Forms
{
    public partial class LayoutForm : FormBorderShadow
    {
        private bool mouseDown;
        private Point lastLocation;
        private Dictionary<string, Control> screenControls;

        public LayoutForm()
        {
            InitializeComponent();
            screenControls = new Dictionary<string, Control>();
            //상단 버튼 이름으로 키 생성
            screenControls.Add(label2.Name, measure1);
            screenControls.Add(label3.Name, dataViewer1);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DisableAllControls();
            EnableOneControl(label2.Name);

        }

        private void DisableAllControls()
        {
            foreach (var control in screenControls)
            {
                control.Value.Visible = false;
                control.Value.Enabled = false;
            }
        }
        private void EnableOneControl(string controlName)
        {
            DisableAllControls();
            screenControls[controlName].Enabled = true;
            screenControls[controlName].Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            Environment.Exit(Environment.ExitCode);
        }

        private void measure1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            EnableOneControl(label2.Name);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            EnableOneControl(label3.Name);
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            Environment.Exit(Environment.ExitCode);
        }

        private void guna2ImageButton1_MouseEnter(object sender, EventArgs e)
        {
            guna2ImageButton1.BackColor = Color.Red;
        }
    }
}
