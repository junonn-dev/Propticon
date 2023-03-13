
namespace MonitorigProcess.UserControls
{
    partial class GraphOverview
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.contentLabel1 = new MonitorigProcess.UserControls.resources.ContentLabel();
            this.contentLabel2 = new MonitorigProcess.UserControls.resources.ContentLabel();
            this.contentLabel3 = new MonitorigProcess.UserControls.resources.ContentLabel();
            this.contentLabel4 = new MonitorigProcess.UserControls.resources.ContentLabel();
            this.lblTotalTime = new MonitorigProcess.UserControls.resources.ContentHeaderLabel();
            this.lblProcess = new MonitorigProcess.UserControls.resources.ContentHeaderLabel();
            this.lblMostCpuUsed = new MonitorigProcess.UserControls.resources.ContentHeaderLabel();
            this.lblMostMemoryUsed = new MonitorigProcess.UserControls.resources.ContentHeaderLabel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.contentLabel1);
            this.flowLayoutPanel1.Controls.Add(this.contentLabel2);
            this.flowLayoutPanel1.Controls.Add(this.contentLabel3);
            this.flowLayoutPanel1.Controls.Add(this.contentLabel4);
            this.flowLayoutPanel1.Controls.Add(this.lblTotalTime);
            this.flowLayoutPanel1.Controls.Add(this.lblProcess);
            this.flowLayoutPanel1.Controls.Add(this.lblMostCpuUsed);
            this.flowLayoutPanel1.Controls.Add(this.lblMostMemoryUsed);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(739, 535);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 10, 0, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(709, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Performance Result";
            // 
            // contentLabel1
            // 
            this.contentLabel1.Location = new System.Drawing.Point(10, 43);
            this.contentLabel1.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.contentLabel1.Name = "contentLabel1";
            this.contentLabel1.Size = new System.Drawing.Size(150, 20);
            this.contentLabel1.TabIndex = 2;
            this.contentLabel1.Text = "Total Time";
            // 
            // contentLabel2
            // 
            this.contentLabel2.Location = new System.Drawing.Point(173, 43);
            this.contentLabel2.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.contentLabel2.Name = "contentLabel2";
            this.contentLabel2.Size = new System.Drawing.Size(150, 20);
            this.contentLabel2.TabIndex = 3;
            this.contentLabel2.Text = "Process";
            // 
            // contentLabel3
            // 
            this.contentLabel3.Location = new System.Drawing.Point(336, 43);
            this.contentLabel3.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.contentLabel3.Name = "contentLabel3";
            this.contentLabel3.Size = new System.Drawing.Size(150, 20);
            this.contentLabel3.TabIndex = 4;
            this.contentLabel3.Text = "Most CPU Used";
            // 
            // contentLabel4
            // 
            this.contentLabel4.Location = new System.Drawing.Point(499, 43);
            this.contentLabel4.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.contentLabel4.Name = "contentLabel4";
            this.contentLabel4.Size = new System.Drawing.Size(150, 20);
            this.contentLabel4.TabIndex = 5;
            this.contentLabel4.Text = "Most Memory Used";
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.Location = new System.Drawing.Point(10, 63);
            this.lblTotalTime.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.lblTotalTime.Name = "lblTotalTime";
            this.lblTotalTime.Size = new System.Drawing.Size(150, 30);
            this.lblTotalTime.TabIndex = 6;
            this.lblTotalTime.Text = "lblTotalTime";
            // 
            // lblProcess
            // 
            this.lblProcess.Location = new System.Drawing.Point(173, 63);
            this.lblProcess.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(150, 30);
            this.lblProcess.TabIndex = 9;
            this.lblProcess.Text = "lblProcess";
            // 
            // lblMostCpuUsed
            // 
            this.lblMostCpuUsed.Location = new System.Drawing.Point(336, 63);
            this.lblMostCpuUsed.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.lblMostCpuUsed.Name = "lblMostCpuUsed";
            this.lblMostCpuUsed.Size = new System.Drawing.Size(150, 30);
            this.lblMostCpuUsed.TabIndex = 7;
            this.lblMostCpuUsed.Text = "lblMostCpuUsed";
            // 
            // lblMostMemoryUsed
            // 
            this.lblMostMemoryUsed.Location = new System.Drawing.Point(499, 63);
            this.lblMostMemoryUsed.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.lblMostMemoryUsed.Name = "lblMostMemoryUsed";
            this.lblMostMemoryUsed.Size = new System.Drawing.Size(150, 30);
            this.lblMostMemoryUsed.TabIndex = 8;
            this.lblMostMemoryUsed.Text = "lblMostMemoryUsed";
            // 
            // DataOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DataOverview";
            this.Size = new System.Drawing.Size(739, 535);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private resources.ContentLabel contentLabel1;
        private resources.ContentLabel contentLabel3;
        private resources.ContentLabel contentLabel4;
        private resources.ContentLabel contentLabel2;
        private resources.ContentHeaderLabel lblTotalTime;
        private resources.ContentHeaderLabel lblMostCpuUsed;
        private resources.ContentHeaderLabel lblMostMemoryUsed;
        private resources.ContentHeaderLabel lblProcess;
    }
}
