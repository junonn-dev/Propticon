
namespace WindowsFormsApp1.UserControls
{
    partial class GraphViewer
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
            this.commonPanel1 = new WindowsFormsApp1.UserControls.resources.CommonPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.subtitleLabel1 = new WindowsFormsApp1.UserControls.resources.SubtitleLabel();
            this.normalButton1 = new WindowsFormsApp1.UserControls.resources.NormalButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.normalButton2 = new WindowsFormsApp1.UserControls.resources.NormalButton();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.commonPanel2 = new WindowsFormsApp1.UserControls.resources.CommonPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.subtitleLabel2 = new WindowsFormsApp1.UserControls.resources.SubtitleLabel();
            this.tconGraph = new Guna.UI2.WinForms.Guna2TabControl();
            this.tpOverview = new System.Windows.Forms.TabPage();
            this.tpProcess = new System.Windows.Forms.TabPage();
            this.tpMetrics = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1.SuspendLayout();
            this.commonPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.commonPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.tconGraph.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.commonPanel1);
            this.flowLayoutPanel1.Controls.Add(this.commonPanel2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1000, 600);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // commonPanel1
            // 
            this.commonPanel1.Controls.Add(this.flowLayoutPanel2);
            this.commonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.commonPanel1.Location = new System.Drawing.Point(0, 1);
            this.commonPanel1.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.commonPanel1.Name = "commonPanel1";
            this.commonPanel1.Size = new System.Drawing.Size(249, 599);
            this.commonPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.subtitleLabel1);
            this.flowLayoutPanel2.Controls.Add(this.normalButton1);
            this.flowLayoutPanel2.Controls.Add(this.panel1);
            this.flowLayoutPanel2.Controls.Add(this.normalButton2);
            this.flowLayoutPanel2.Controls.Add(this.treeView1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(249, 599);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // subtitleLabel1
            // 
            this.subtitleLabel1.Location = new System.Drawing.Point(3, 3);
            this.subtitleLabel1.Margin = new System.Windows.Forms.Padding(3);
            this.subtitleLabel1.Name = "subtitleLabel1";
            this.subtitleLabel1.Size = new System.Drawing.Size(234, 21);
            this.subtitleLabel1.TabIndex = 1;
            this.subtitleLabel1.Text = "Reports";
            // 
            // normalButton1
            // 
            this.normalButton1.FlatAppearance.BorderSize = 0;
            this.normalButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.normalButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.normalButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.normalButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.normalButton1.Location = new System.Drawing.Point(3, 30);
            this.normalButton1.Name = "normalButton1";
            this.normalButton1.Size = new System.Drawing.Size(74, 23);
            this.normalButton1.TabIndex = 2;
            this.normalButton1.Text = "Refresh";
            this.normalButton1.UseVisualStyleBackColor = true;
            this.normalButton1.Click += new System.EventHandler(this.normalButton1_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(83, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(82, 25);
            this.panel1.TabIndex = 4;
            // 
            // normalButton2
            // 
            this.normalButton2.FlatAppearance.BorderSize = 0;
            this.normalButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.normalButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.normalButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.normalButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.normalButton2.Location = new System.Drawing.Point(171, 30);
            this.normalButton2.Name = "normalButton2";
            this.normalButton2.Size = new System.Drawing.Size(74, 23);
            this.normalButton2.TabIndex = 3;
            this.normalButton2.Text = "Delete";
            this.normalButton2.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(3, 61);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(244, 535);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // commonPanel2
            // 
            this.commonPanel2.Controls.Add(this.flowLayoutPanel3);
            this.commonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.commonPanel2.Location = new System.Drawing.Point(251, 1);
            this.commonPanel2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.commonPanel2.Name = "commonPanel2";
            this.commonPanel2.Size = new System.Drawing.Size(749, 599);
            this.commonPanel2.TabIndex = 2;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.subtitleLabel2);
            this.flowLayoutPanel3.Controls.Add(this.tconGraph);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(749, 599);
            this.flowLayoutPanel3.TabIndex = 1;
            // 
            // subtitleLabel2
            // 
            this.subtitleLabel2.Location = new System.Drawing.Point(3, 3);
            this.subtitleLabel2.Margin = new System.Windows.Forms.Padding(3);
            this.subtitleLabel2.Name = "subtitleLabel2";
            this.subtitleLabel2.Size = new System.Drawing.Size(743, 21);
            this.subtitleLabel2.TabIndex = 0;
            this.subtitleLabel2.Text = "Graph";
            // 
            // tconGraph
            // 
            this.tconGraph.Controls.Add(this.tpOverview);
            this.tconGraph.Controls.Add(this.tpProcess);
            this.tconGraph.Controls.Add(this.tpMetrics);
            this.tconGraph.ItemSize = new System.Drawing.Size(95, 27);
            this.tconGraph.Location = new System.Drawing.Point(1, 28);
            this.tconGraph.Margin = new System.Windows.Forms.Padding(1);
            this.tconGraph.Name = "tconGraph";
            this.tconGraph.SelectedIndex = 0;
            this.tconGraph.Size = new System.Drawing.Size(747, 570);
            this.tconGraph.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tconGraph.TabButtonHoverState.FillColor = System.Drawing.Color.White;
            this.tconGraph.TabButtonHoverState.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tconGraph.TabButtonHoverState.ForeColor = System.Drawing.Color.Black;
            this.tconGraph.TabButtonHoverState.InnerColor = System.Drawing.Color.Transparent;
            this.tconGraph.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tconGraph.TabButtonIdleState.FillColor = System.Drawing.Color.White;
            this.tconGraph.TabButtonIdleState.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tconGraph.TabButtonIdleState.ForeColor = System.Drawing.Color.Gray;
            this.tconGraph.TabButtonIdleState.InnerColor = System.Drawing.Color.Transparent;
            this.tconGraph.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tconGraph.TabButtonSelectedState.FillColor = System.Drawing.Color.White;
            this.tconGraph.TabButtonSelectedState.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tconGraph.TabButtonSelectedState.ForeColor = System.Drawing.Color.Black;
            this.tconGraph.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.tconGraph.TabButtonSize = new System.Drawing.Size(95, 27);
            this.tconGraph.TabIndex = 2;
            this.tconGraph.TabMenuBackColor = System.Drawing.Color.White;
            this.tconGraph.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // tpOverview
            // 
            this.tpOverview.Location = new System.Drawing.Point(4, 31);
            this.tpOverview.Name = "tpOverview";
            this.tpOverview.Padding = new System.Windows.Forms.Padding(3);
            this.tpOverview.Size = new System.Drawing.Size(739, 535);
            this.tpOverview.TabIndex = 0;
            this.tpOverview.Text = "Overview";
            this.tpOverview.UseVisualStyleBackColor = true;
            // 
            // tpProcess
            // 
            this.tpProcess.Location = new System.Drawing.Point(4, 31);
            this.tpProcess.Name = "tpProcess";
            this.tpProcess.Padding = new System.Windows.Forms.Padding(3);
            this.tpProcess.Size = new System.Drawing.Size(739, 535);
            this.tpProcess.TabIndex = 1;
            this.tpProcess.Text = "Process";
            this.tpProcess.UseVisualStyleBackColor = true;
            // 
            // tpMetrics
            // 
            this.tpMetrics.Location = new System.Drawing.Point(4, 31);
            this.tpMetrics.Name = "tpMetrics";
            this.tpMetrics.Padding = new System.Windows.Forms.Padding(3);
            this.tpMetrics.Size = new System.Drawing.Size(739, 535);
            this.tpMetrics.TabIndex = 2;
            this.tpMetrics.Text = "Metrics";
            this.tpMetrics.UseVisualStyleBackColor = true;
            // 
            // GraphViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "GraphViewer";
            this.Size = new System.Drawing.Size(1000, 600);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.commonPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.commonPanel2.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.tconGraph.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private resources.CommonPanel commonPanel1;
        private resources.SubtitleLabel subtitleLabel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private resources.CommonPanel commonPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private resources.SubtitleLabel subtitleLabel2;
        private Guna.UI2.WinForms.Guna2TabControl tconGraph;
        private System.Windows.Forms.TabPage tpOverview;
        private System.Windows.Forms.TabPage tpProcess;
        private System.Windows.Forms.TabPage tpMetrics;
        private resources.NormalButton normalButton1;
        private System.Windows.Forms.Panel panel1;
        private resources.NormalButton normalButton2;
    }
}
