﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
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
            screenControls.Add(titleLableConfig.Name, configuration1);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DisableAllControls();
            EnableOneControl(label2.Name);

            //configuration에서 measure의 모니터링 상태를 알려주기 위해 만든 인터페이스 같은 것
            //종속성이 생기기 때문에 바람직하지 않다.
            configuration1.setMonitorCheckReference(measure1);
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

        private void titleLableConfig_Click(object sender, EventArgs e)
        {
            EnableOneControl(titleLableConfig.Name);
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if (measure1.bLoopState == true)
            {
                MessageBox.Show("모니터링 종료 후 닫을 수 있습니다.");
                return;
            }
            //monitor stop 직후 프로그램을 종료하면 측정 결과 xml파일이 안생길 수 있다.
            //닫을 시 창 안보이게 하고, 그동안 측정 결과 xml 파일 생기도록 대기하기 위해 sleep 추가
            this.Visible = false;
            Thread.Sleep(7777);
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
