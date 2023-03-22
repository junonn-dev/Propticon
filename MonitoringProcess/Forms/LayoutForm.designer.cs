using System.Windows.Forms;

namespace MonitorigProcess.Forms
{
    partial class LayoutForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayoutForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2ImageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.label3 = new MonitorigProcess.UserControls.resources.TitleLabel();
            this.label2 = new MonitorigProcess.UserControls.resources.TitleLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2ContainerControl1 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.measure1 = new MonitorigProcess.Measure();
            this.dataViewer1 = new MonitorigProcess.UserControls.GraphViewer();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.guna2ContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 49);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.guna2ImageButton1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(942, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel2.Size = new System.Drawing.Size(58, 49);
            this.flowLayoutPanel2.TabIndex = 7;
            // 
            // guna2ImageButton1
            // 
            this.guna2ImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ImageButton1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.HoverState.Image = global::MonitoringProcess.Properties.Resources.close_real_final_hover;
            this.guna2ImageButton1.HoverState.ImageSize = new System.Drawing.Size(50, 50);
            this.guna2ImageButton1.Image = global::MonitoringProcess.Properties.Resources.close_real_final;
            this.guna2ImageButton1.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton1.ImageRotate = 0F;
            this.guna2ImageButton1.ImageSize = new System.Drawing.Size(50, 50);
            this.guna2ImageButton1.Location = new System.Drawing.Point(8, 0);
            this.guna2ImageButton1.Margin = new System.Windows.Forms.Padding(0);
            this.guna2ImageButton1.Name = "guna2ImageButton1";
            this.guna2ImageButton1.PressedState.Image = global::MonitoringProcess.Properties.Resources.close_real_final_hover;
            this.guna2ImageButton1.PressedState.ImageSize = new System.Drawing.Size(50, 50);
            this.guna2ImageButton1.Size = new System.Drawing.Size(50, 50);
            this.guna2ImageButton1.TabIndex = 1;
            this.guna2ImageButton1.UseTransparentBackground = true;
            this.guna2ImageButton1.Click += new System.EventHandler(this.guna2ImageButton1_Click);
            this.guna2ImageButton1.MouseEnter += new System.EventHandler(this.guna2ImageButton1_MouseEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 9);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5);
            this.label3.Size = new System.Drawing.Size(56, 31);
            this.label3.TabIndex = 6;
            this.label3.Text = "Data";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 9);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5);
            this.label2.Size = new System.Drawing.Size(85, 31);
            this.label2.TabIndex = 5;
            this.label2.Text = "Measure";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.guna2ContainerControl1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1000, 800);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // guna2ContainerControl1
            // 
            this.guna2ContainerControl1.Controls.Add(this.measure1);
            this.guna2ContainerControl1.Controls.Add(this.dataViewer1);
            this.guna2ContainerControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2ContainerControl1.Location = new System.Drawing.Point(1, 51);
            this.guna2ContainerControl1.Margin = new System.Windows.Forms.Padding(1);
            this.guna2ContainerControl1.Name = "guna2ContainerControl1";
            this.guna2ContainerControl1.Size = new System.Drawing.Size(1000, 748);
            this.guna2ContainerControl1.TabIndex = 3;
            this.guna2ContainerControl1.Text = "guna2ContainerControl1";
            // 
            // measure1
            // 
            this.measure1.bLoopState = false;
            this.measure1.Dock = System.Windows.Forms.DockStyle.Top;
            this.measure1.Location = new System.Drawing.Point(0, 0);
            this.measure1.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.measure1.Name = "measure1";
            this.measure1.Size = new System.Drawing.Size(1000, 749);
            this.measure1.TabIndex = 2;
            // 
            // dataViewer1
            // 
            this.dataViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataViewer1.Location = new System.Drawing.Point(0, 0);
            this.dataViewer1.Name = "dataViewer1";
            this.dataViewer1.Size = new System.Drawing.Size(1000, 748);
            this.dataViewer1.TabIndex = 3;
            // 
            // LayoutForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1000, 800);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "LayoutForm";
            this.Text = "Monitoring Process";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.guna2ContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private MonitorigProcess.UserControls.resources.TitleLabel label3;
        private MonitorigProcess.UserControls.resources.TitleLabel label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Measure measure1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton1;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl1;
        private UserControls.GraphViewer dataViewer1;
    }
}

