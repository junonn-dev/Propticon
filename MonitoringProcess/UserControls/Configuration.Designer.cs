
namespace MonitoringProcess.UserControls
{
    partial class Configuration
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.commonPanel1 = new MonitorigProcess.UserControls.resources.CommonPanel();
            this.buttonReset = new MonitorigProcess.UserControls.resources.NormalButton();
            this.buttonSave = new MonitorigProcess.UserControls.resources.ColoredButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxProcessGDILimit = new System.Windows.Forms.TextBox();
            this.checkBoxDetectionMode = new System.Windows.Forms.CheckBox();
            this.contentHeaderLabel8 = new MonitorigProcess.UserControls.resources.ContentHeaderLabel();
            this.textBoxProcessHandleLimit = new System.Windows.Forms.TextBox();
            this.contentHeaderLabel7 = new MonitorigProcess.UserControls.resources.ContentHeaderLabel();
            this.contentHeaderLabel6 = new MonitorigProcess.UserControls.resources.ContentHeaderLabel();
            this.textBoxProcessThreadLimit = new System.Windows.Forms.TextBox();
            this.contentHeaderLabel5 = new MonitorigProcess.UserControls.resources.ContentHeaderLabel();
            this.contentHeaderLabel4 = new MonitorigProcess.UserControls.resources.ContentHeaderLabel();
            this.textBoxProcessMemoryLimit = new System.Windows.Forms.TextBox();
            this.contentHeaderLabel3 = new MonitorigProcess.UserControls.resources.ContentHeaderLabel();
            this.contentHeaderLabel2 = new MonitorigProcess.UserControls.resources.ContentHeaderLabel();
            this.textBoxProcessCPULimit = new System.Windows.Forms.TextBox();
            this.contentHeaderLabel1 = new MonitorigProcess.UserControls.resources.ContentHeaderLabel();
            this.textBoxTotalCpuLimit = new System.Windows.Forms.TextBox();
            this.textBoxDiskSpace = new System.Windows.Forms.TextBox();
            this.textBoxTotalMemoryLimit = new System.Windows.Forms.TextBox();
            this.subtitleLabel1 = new MonitorigProcess.UserControls.resources.SubtitleLabel();
            this.commonPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // commonPanel1
            // 
            this.commonPanel1.Controls.Add(this.buttonReset);
            this.commonPanel1.Controls.Add(this.buttonSave);
            this.commonPanel1.Controls.Add(this.groupBox1);
            this.commonPanel1.Controls.Add(this.subtitleLabel1);
            this.commonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commonPanel1.Location = new System.Drawing.Point(0, 0);
            this.commonPanel1.Name = "commonPanel1";
            this.commonPanel1.Size = new System.Drawing.Size(632, 406);
            this.commonPanel1.TabIndex = 0;
            // 
            // buttonReset
            // 
            this.buttonReset.FlatAppearance.BorderSize = 0;
            this.buttonReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.buttonReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.buttonReset.Location = new System.Drawing.Point(111, 41);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(80, 30);
            this.buttonReset.TabIndex = 3;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.buttonSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonSave.Location = new System.Drawing.Point(18, 41);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(80, 30);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxProcessGDILimit);
            this.groupBox1.Controls.Add(this.checkBoxDetectionMode);
            this.groupBox1.Controls.Add(this.contentHeaderLabel8);
            this.groupBox1.Controls.Add(this.textBoxProcessHandleLimit);
            this.groupBox1.Controls.Add(this.contentHeaderLabel7);
            this.groupBox1.Controls.Add(this.contentHeaderLabel6);
            this.groupBox1.Controls.Add(this.textBoxProcessThreadLimit);
            this.groupBox1.Controls.Add(this.contentHeaderLabel5);
            this.groupBox1.Controls.Add(this.contentHeaderLabel4);
            this.groupBox1.Controls.Add(this.textBoxProcessMemoryLimit);
            this.groupBox1.Controls.Add(this.contentHeaderLabel3);
            this.groupBox1.Controls.Add(this.contentHeaderLabel2);
            this.groupBox1.Controls.Add(this.textBoxProcessCPULimit);
            this.groupBox1.Controls.Add(this.contentHeaderLabel1);
            this.groupBox1.Controls.Add(this.textBoxTotalCpuLimit);
            this.groupBox1.Controls.Add(this.textBoxDiskSpace);
            this.groupBox1.Controls.Add(this.textBoxTotalMemoryLimit);
            this.groupBox1.Location = new System.Drawing.Point(18, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 294);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Warn Limit";
            // 
            // textBoxProcessGDILimit
            // 
            this.textBoxProcessGDILimit.Location = new System.Drawing.Point(230, 258);
            this.textBoxProcessGDILimit.Name = "textBoxProcessGDILimit";
            this.textBoxProcessGDILimit.Size = new System.Drawing.Size(115, 21);
            this.textBoxProcessGDILimit.TabIndex = 8;
            this.textBoxProcessGDILimit.Tag = "8";
            this.textBoxProcessGDILimit.TextChanged += new System.EventHandler(this.textBoxes_TextChanged);
            // 
            // checkBoxDetectionMode
            // 
            this.checkBoxDetectionMode.AutoSize = true;
            this.checkBoxDetectionMode.Location = new System.Drawing.Point(18, 32);
            this.checkBoxDetectionMode.Name = "checkBoxDetectionMode";
            this.checkBoxDetectionMode.Size = new System.Drawing.Size(116, 16);
            this.checkBoxDetectionMode.TabIndex = 8;
            this.checkBoxDetectionMode.Text = "이상치 탐지 모드";
            this.checkBoxDetectionMode.UseVisualStyleBackColor = true;
            // 
            // contentHeaderLabel8
            // 
            this.contentHeaderLabel8.AutoSize = true;
            this.contentHeaderLabel8.Location = new System.Drawing.Point(15, 259);
            this.contentHeaderLabel8.Name = "contentHeaderLabel8";
            this.contentHeaderLabel8.Size = new System.Drawing.Size(139, 15);
            this.contentHeaderLabel8.TabIndex = 7;
            this.contentHeaderLabel8.Text = "Process GDI Limit (cnt)";
            // 
            // textBoxProcessHandleLimit
            // 
            this.textBoxProcessHandleLimit.Location = new System.Drawing.Point(230, 231);
            this.textBoxProcessHandleLimit.Name = "textBoxProcessHandleLimit";
            this.textBoxProcessHandleLimit.Size = new System.Drawing.Size(115, 21);
            this.textBoxProcessHandleLimit.TabIndex = 7;
            this.textBoxProcessHandleLimit.Tag = "7";
            this.textBoxProcessHandleLimit.TextChanged += new System.EventHandler(this.textBoxes_TextChanged);
            // 
            // contentHeaderLabel7
            // 
            this.contentHeaderLabel7.AutoSize = true;
            this.contentHeaderLabel7.Location = new System.Drawing.Point(15, 232);
            this.contentHeaderLabel7.Name = "contentHeaderLabel7";
            this.contentHeaderLabel7.Size = new System.Drawing.Size(158, 15);
            this.contentHeaderLabel7.TabIndex = 6;
            this.contentHeaderLabel7.Text = "Process Handle Limit (cnt)";
            // 
            // contentHeaderLabel6
            // 
            this.contentHeaderLabel6.AutoSize = true;
            this.contentHeaderLabel6.Location = new System.Drawing.Point(15, 205);
            this.contentHeaderLabel6.Name = "contentHeaderLabel6";
            this.contentHeaderLabel6.Size = new System.Drawing.Size(158, 15);
            this.contentHeaderLabel6.TabIndex = 5;
            this.contentHeaderLabel6.Text = "Process Thread Limit (cnt)";
            // 
            // textBoxProcessThreadLimit
            // 
            this.textBoxProcessThreadLimit.Location = new System.Drawing.Point(230, 204);
            this.textBoxProcessThreadLimit.Name = "textBoxProcessThreadLimit";
            this.textBoxProcessThreadLimit.Size = new System.Drawing.Size(115, 21);
            this.textBoxProcessThreadLimit.TabIndex = 6;
            this.textBoxProcessThreadLimit.Tag = "6";
            this.textBoxProcessThreadLimit.TextChanged += new System.EventHandler(this.textBoxes_TextChanged);
            // 
            // contentHeaderLabel5
            // 
            this.contentHeaderLabel5.AutoSize = true;
            this.contentHeaderLabel5.Location = new System.Drawing.Point(15, 178);
            this.contentHeaderLabel5.Name = "contentHeaderLabel5";
            this.contentHeaderLabel5.Size = new System.Drawing.Size(167, 15);
            this.contentHeaderLabel5.TabIndex = 4;
            this.contentHeaderLabel5.Text = "Process Memory Limit (MB)";
            // 
            // contentHeaderLabel4
            // 
            this.contentHeaderLabel4.AutoSize = true;
            this.contentHeaderLabel4.Location = new System.Drawing.Point(15, 151);
            this.contentHeaderLabel4.Name = "contentHeaderLabel4";
            this.contentHeaderLabel4.Size = new System.Drawing.Size(134, 15);
            this.contentHeaderLabel4.TabIndex = 3;
            this.contentHeaderLabel4.Text = "Process CPU Limit (%)";
            // 
            // textBoxProcessMemoryLimit
            // 
            this.textBoxProcessMemoryLimit.Location = new System.Drawing.Point(230, 177);
            this.textBoxProcessMemoryLimit.Name = "textBoxProcessMemoryLimit";
            this.textBoxProcessMemoryLimit.Size = new System.Drawing.Size(115, 21);
            this.textBoxProcessMemoryLimit.TabIndex = 5;
            this.textBoxProcessMemoryLimit.Tag = "5";
            this.textBoxProcessMemoryLimit.TextChanged += new System.EventHandler(this.textBoxes_TextChanged);
            // 
            // contentHeaderLabel3
            // 
            this.contentHeaderLabel3.AutoSize = true;
            this.contentHeaderLabel3.Location = new System.Drawing.Point(15, 124);
            this.contentHeaderLabel3.Name = "contentHeaderLabel3";
            this.contentHeaderLabel3.Size = new System.Drawing.Size(126, 15);
            this.contentHeaderLabel3.TabIndex = 2;
            this.contentHeaderLabel3.Text = "Disk Space Limit (%)";
            // 
            // contentHeaderLabel2
            // 
            this.contentHeaderLabel2.AutoSize = true;
            this.contentHeaderLabel2.Location = new System.Drawing.Point(15, 97);
            this.contentHeaderLabel2.Name = "contentHeaderLabel2";
            this.contentHeaderLabel2.Size = new System.Drawing.Size(184, 15);
            this.contentHeaderLabel2.TabIndex = 1;
            this.contentHeaderLabel2.Text = "Total Memory Usage Limit (%)";
            // 
            // textBoxProcessCPULimit
            // 
            this.textBoxProcessCPULimit.Location = new System.Drawing.Point(230, 150);
            this.textBoxProcessCPULimit.Name = "textBoxProcessCPULimit";
            this.textBoxProcessCPULimit.Size = new System.Drawing.Size(115, 21);
            this.textBoxProcessCPULimit.TabIndex = 4;
            this.textBoxProcessCPULimit.Tag = "4";
            this.textBoxProcessCPULimit.TextChanged += new System.EventHandler(this.textBoxes_TextChanged);
            // 
            // contentHeaderLabel1
            // 
            this.contentHeaderLabel1.AutoSize = true;
            this.contentHeaderLabel1.Location = new System.Drawing.Point(15, 70);
            this.contentHeaderLabel1.Name = "contentHeaderLabel1";
            this.contentHeaderLabel1.Size = new System.Drawing.Size(160, 15);
            this.contentHeaderLabel1.TabIndex = 0;
            this.contentHeaderLabel1.Text = "Total CPU Usage Limit (%)";
            // 
            // textBoxTotalCpuLimit
            // 
            this.textBoxTotalCpuLimit.Location = new System.Drawing.Point(230, 69);
            this.textBoxTotalCpuLimit.Name = "textBoxTotalCpuLimit";
            this.textBoxTotalCpuLimit.Size = new System.Drawing.Size(115, 21);
            this.textBoxTotalCpuLimit.TabIndex = 1;
            this.textBoxTotalCpuLimit.Tag = "1";
            this.textBoxTotalCpuLimit.TextChanged += new System.EventHandler(this.textBoxes_TextChanged);
            // 
            // textBoxDiskSpace
            // 
            this.textBoxDiskSpace.Location = new System.Drawing.Point(230, 123);
            this.textBoxDiskSpace.Name = "textBoxDiskSpace";
            this.textBoxDiskSpace.Size = new System.Drawing.Size(115, 21);
            this.textBoxDiskSpace.TabIndex = 3;
            this.textBoxDiskSpace.Tag = "3";
            this.textBoxDiskSpace.TextChanged += new System.EventHandler(this.textBoxes_TextChanged);
            // 
            // textBoxTotalMemoryLimit
            // 
            this.textBoxTotalMemoryLimit.Location = new System.Drawing.Point(230, 96);
            this.textBoxTotalMemoryLimit.Name = "textBoxTotalMemoryLimit";
            this.textBoxTotalMemoryLimit.Size = new System.Drawing.Size(115, 21);
            this.textBoxTotalMemoryLimit.TabIndex = 2;
            this.textBoxTotalMemoryLimit.Tag = "2";
            this.textBoxTotalMemoryLimit.TextChanged += new System.EventHandler(this.textBoxes_TextChanged);
            // 
            // subtitleLabel1
            // 
            this.subtitleLabel1.AutoSize = true;
            this.subtitleLabel1.Location = new System.Drawing.Point(4, 6);
            this.subtitleLabel1.Name = "subtitleLabel1";
            this.subtitleLabel1.Size = new System.Drawing.Size(115, 21);
            this.subtitleLabel1.TabIndex = 0;
            this.subtitleLabel1.Text = "Configuration";
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.commonPanel1);
            this.Name = "Configuration";
            this.Size = new System.Drawing.Size(632, 406);
            this.commonPanel1.ResumeLayout(false);
            this.commonPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MonitorigProcess.UserControls.resources.CommonPanel commonPanel1;
        private MonitorigProcess.UserControls.resources.NormalButton buttonReset;
        private MonitorigProcess.UserControls.resources.ColoredButton buttonSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private MonitorigProcess.UserControls.resources.ContentHeaderLabel contentHeaderLabel8;
        private MonitorigProcess.UserControls.resources.ContentHeaderLabel contentHeaderLabel7;
        private MonitorigProcess.UserControls.resources.ContentHeaderLabel contentHeaderLabel6;
        private MonitorigProcess.UserControls.resources.ContentHeaderLabel contentHeaderLabel5;
        private MonitorigProcess.UserControls.resources.ContentHeaderLabel contentHeaderLabel4;
        private MonitorigProcess.UserControls.resources.ContentHeaderLabel contentHeaderLabel3;
        private MonitorigProcess.UserControls.resources.ContentHeaderLabel contentHeaderLabel2;
        private MonitorigProcess.UserControls.resources.ContentHeaderLabel contentHeaderLabel1;
        private MonitorigProcess.UserControls.resources.SubtitleLabel subtitleLabel1;
        private System.Windows.Forms.CheckBox checkBoxDetectionMode;
        private System.Windows.Forms.TextBox textBoxTotalCpuLimit;
        private System.Windows.Forms.TextBox textBoxProcessGDILimit;
        private System.Windows.Forms.TextBox textBoxProcessHandleLimit;
        private System.Windows.Forms.TextBox textBoxProcessThreadLimit;
        private System.Windows.Forms.TextBox textBoxProcessMemoryLimit;
        private System.Windows.Forms.TextBox textBoxProcessCPULimit;
        private System.Windows.Forms.TextBox textBoxDiskSpace;
        private System.Windows.Forms.TextBox textBoxTotalMemoryLimit;
    }
}
