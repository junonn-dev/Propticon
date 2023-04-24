namespace MonitoringProcess.UserControls
{
    partial class FreeDiskSpaceViewer
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.commonPanel1 = new MonitorigProcess.UserControls.resources.CommonPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.titleLabel1 = new MonitorigProcess.UserControls.resources.SubtitleLabel();
            this.commonPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // commonPanel1
            // 
            this.commonPanel1.Controls.Add(this.flowLayoutPanel1);
            this.commonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commonPanel1.Location = new System.Drawing.Point(0, 0);
            this.commonPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.commonPanel1.Name = "commonPanel1";
            this.commonPanel1.Size = new System.Drawing.Size(1100, 150);
            this.commonPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.titleLabel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1100, 150);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // titleLabel1
            // 
            this.titleLabel1.Location = new System.Drawing.Point(3, 0);
            this.titleLabel1.Name = "titleLabel1";
            this.titleLabel1.Size = new System.Drawing.Size(1094, 25);
            this.titleLabel1.TabIndex = 0;
            this.titleLabel1.Text = "Disk Space";
            // 
            // FreeDiskSpaceViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.commonPanel1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "FreeDiskSpaceViewer";
            this.Size = new System.Drawing.Size(1100, 150);
            this.commonPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MonitorigProcess.UserControls.resources.CommonPanel commonPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MonitorigProcess.UserControls.resources.SubtitleLabel titleLabel1;
    }
}
