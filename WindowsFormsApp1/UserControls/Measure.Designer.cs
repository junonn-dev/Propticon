namespace WindowsFormsApp1
{
    partial class Measure
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
            this.lblEndDateInfo = new System.Windows.Forms.Label();
            this.lblStartDateInfo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnMonitorEnd = new WindowsFormsApp1.UserControls.resources.ColoredButton();
            this.BtnMonitorStart = new WindowsFormsApp1.UserControls.resources.ColoredButton();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnRefresh = new WindowsFormsApp1.UserControls.resources.NormalButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BtnApply = new WindowsFormsApp1.UserControls.resources.NormalButton();
            this.BtnRemove = new WindowsFormsApp1.UserControls.resources.NormalButton();
            this.BtnListClear = new WindowsFormsApp1.UserControls.resources.NormalButton();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tconProcessTab = new System.Windows.Forms.TabControl();
            this.btnGraphViewer = new System.Windows.Forms.Button();
            this.panel1 = new WindowsFormsApp1.UserControls.resources.CommonPanel();
            this.subtitleLabel1 = new WindowsFormsApp1.UserControls.resources.SubtitleLabel();
            this.commonPanel1 = new WindowsFormsApp1.UserControls.resources.CommonPanel();
            this.subtitleLabel2 = new WindowsFormsApp1.UserControls.resources.SubtitleLabel();
            this.panel1.SuspendLayout();
            this.commonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEndDateInfo
            // 
            this.lblEndDateInfo.BackColor = System.Drawing.Color.White;
            this.lblEndDateInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEndDateInfo.Location = new System.Drawing.Point(108, 109);
            this.lblEndDateInfo.Name = "lblEndDateInfo";
            this.lblEndDateInfo.Size = new System.Drawing.Size(271, 21);
            this.lblEndDateInfo.TabIndex = 13;
            this.lblEndDateInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStartDateInfo
            // 
            this.lblStartDateInfo.BackColor = System.Drawing.Color.White;
            this.lblStartDateInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStartDateInfo.Location = new System.Drawing.Point(108, 84);
            this.lblStartDateInfo.Name = "lblStartDateInfo";
            this.lblStartDateInfo.Size = new System.Drawing.Size(271, 21);
            this.lblStartDateInfo.TabIndex = 12;
            this.lblStartDateInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "End Date Info";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "Start Date Info";
            // 
            // BtnMonitorEnd
            // 
            this.BtnMonitorEnd.FlatAppearance.BorderSize = 0;
            this.BtnMonitorEnd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.BtnMonitorEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMonitorEnd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BtnMonitorEnd.Location = new System.Drawing.Point(268, 252);
            this.BtnMonitorEnd.Name = "BtnMonitorEnd";
            this.BtnMonitorEnd.Size = new System.Drawing.Size(111, 23);
            this.BtnMonitorEnd.TabIndex = 9;
            this.BtnMonitorEnd.Text = "Monitor Stop";
            this.BtnMonitorEnd.UseVisualStyleBackColor = true;
            this.BtnMonitorEnd.Click += new System.EventHandler(this.BtnMonitorEnd_Click);
            // 
            // BtnMonitorStart
            // 
            this.BtnMonitorStart.FlatAppearance.BorderSize = 0;
            this.BtnMonitorStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.BtnMonitorStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMonitorStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BtnMonitorStart.Location = new System.Drawing.Point(152, 252);
            this.BtnMonitorStart.Name = "BtnMonitorStart";
            this.BtnMonitorStart.Size = new System.Drawing.Size(110, 23);
            this.BtnMonitorStart.TabIndex = 8;
            this.BtnMonitorStart.Text = "Monitor Start";
            this.BtnMonitorStart.UseVisualStyleBackColor = true;
            this.BtnMonitorStart.Click += new System.EventHandler(this.BtnMonitorStart_Click);
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.CustomFormat = "yyyy-MM-dd HH시 mm분";
            this.dateTimePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEndDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(108, 57);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(271, 21);
            this.dateTimePickerEndDate.TabIndex = 4;
            this.dateTimePickerEndDate.Value = new System.DateTime(2022, 12, 13, 15, 25, 11, 674);
            this.dateTimePickerEndDate.ValueChanged += new System.EventHandler(this.dateTimePickerEndDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "End Date Set";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.FlatAppearance.BorderSize = 0;
            this.BtnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.BtnRefresh.Location = new System.Drawing.Point(155, 54);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(72, 23);
            this.BtnRefresh.TabIndex = 1;
            this.BtnRefresh.Text = "Refresh";
            this.BtnRefresh.UseVisualStyleBackColor = true;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(63, 55);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(86, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // BtnApply
            // 
            this.BtnApply.FlatAppearance.BorderSize = 0;
            this.BtnApply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnApply.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.BtnApply.Location = new System.Drawing.Point(311, 149);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(50, 30);
            this.BtnApply.TabIndex = 4;
            this.BtnApply.Text = "▶";
            this.BtnApply.UseVisualStyleBackColor = true;
            this.BtnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // BtnRemove
            // 
            this.BtnRemove.FlatAppearance.BorderSize = 0;
            this.BtnRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.BtnRemove.Location = new System.Drawing.Point(311, 180);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(50, 30);
            this.BtnRemove.TabIndex = 5;
            this.BtnRemove.Text = "◀";
            this.BtnRemove.UseVisualStyleBackColor = true;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnListClear
            // 
            this.BtnListClear.FlatAppearance.BorderSize = 0;
            this.BtnListClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtnListClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnListClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.BtnListClear.Location = new System.Drawing.Point(363, 56);
            this.BtnListClear.Name = "BtnListClear";
            this.BtnListClear.Size = new System.Drawing.Size(87, 23);
            this.BtnListClear.TabIndex = 8;
            this.BtnListClear.Text = "List Clear";
            this.BtnListClear.UseVisualStyleBackColor = true;
            this.BtnListClear.Click += new System.EventHandler(this.BtnListClear_Click);
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(364, 83);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(215, 192);
            this.listView2.TabIndex = 7;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Pid";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ProcessName";
            this.columnHeader5.Width = 150;
            // 
            // listView1
            // 
            this.listView1.AccessibleRole = System.Windows.Forms.AccessibleRole.Border;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(16, 83);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(292, 192);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No";
            this.columnHeader1.Width = 30;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Pid";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ProcessName";
            this.columnHeader3.Width = 180;
            // 
            // tconProcessTab
            // 
            this.tconProcessTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tconProcessTab.Location = new System.Drawing.Point(13, 312);
            this.tconProcessTab.Name = "tconProcessTab";
            this.tconProcessTab.SelectedIndex = 0;
            this.tconProcessTab.Size = new System.Drawing.Size(995, 385);
            this.tconProcessTab.TabIndex = 4;
            // 
            // btnGraphViewer
            // 
            this.btnGraphViewer.Location = new System.Drawing.Point(847, 649);
            this.btnGraphViewer.Name = "btnGraphViewer";
            this.btnGraphViewer.Size = new System.Drawing.Size(100, 23);
            this.btnGraphViewer.TabIndex = 5;
            this.btnGraphViewer.Text = "Graph Viewer";
            this.btnGraphViewer.UseVisualStyleBackColor = true;
            this.btnGraphViewer.Click += new System.EventHandler(this.btnGraphViewer_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.subtitleLabel1);
            this.panel1.Controls.Add(this.BtnListClear);
            this.panel1.Controls.Add(this.BtnRefresh);
            this.panel1.Controls.Add(this.listView2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.BtnRemove);
            this.panel1.Controls.Add(this.BtnApply);
            this.panel1.Location = new System.Drawing.Point(13, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 295);
            this.panel1.TabIndex = 14;
            // 
            // subtitleLabel1
            // 
            this.subtitleLabel1.AutoSize = true;
            this.subtitleLabel1.Location = new System.Drawing.Point(8, 9);
            this.subtitleLabel1.Name = "subtitleLabel1";
            this.subtitleLabel1.Size = new System.Drawing.Size(131, 30);
            this.subtitleLabel1.TabIndex = 9;
            this.subtitleLabel1.Text = "Process List";
            // 
            // commonPanel1
            // 
            this.commonPanel1.Controls.Add(this.lblEndDateInfo);
            this.commonPanel1.Controls.Add(this.subtitleLabel2);
            this.commonPanel1.Controls.Add(this.lblStartDateInfo);
            this.commonPanel1.Controls.Add(this.label3);
            this.commonPanel1.Controls.Add(this.label4);
            this.commonPanel1.Controls.Add(this.dateTimePickerEndDate);
            this.commonPanel1.Controls.Add(this.label2);
            this.commonPanel1.Controls.Add(this.BtnMonitorStart);
            this.commonPanel1.Controls.Add(this.BtnMonitorEnd);
            this.commonPanel1.Location = new System.Drawing.Point(613, 11);
            this.commonPanel1.Name = "commonPanel1";
            this.commonPanel1.Size = new System.Drawing.Size(395, 295);
            this.commonPanel1.TabIndex = 15;
            // 
            // subtitleLabel2
            // 
            this.subtitleLabel2.AutoSize = true;
            this.subtitleLabel2.Location = new System.Drawing.Point(8, 9);
            this.subtitleLabel2.Name = "subtitleLabel2";
            this.subtitleLabel2.Size = new System.Drawing.Size(151, 30);
            this.subtitleLabel2.TabIndex = 0;
            this.subtitleLabel2.Text = "Period Config";
            // 
            // Measure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.commonPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGraphViewer);
            this.Controls.Add(this.tconProcessTab);
            this.Name = "Measure";
            this.Size = new System.Drawing.Size(1021, 711);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.commonPanel1.ResumeLayout(false);
            this.commonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private UserControls.resources.NormalButton BtnRefresh;
        private System.Windows.Forms.TextBox textBox1;
        private UserControls.resources.NormalButton BtnApply;
        private UserControls.resources.NormalButton BtnRemove;
        private UserControls.resources.ColoredButton BtnMonitorStart;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private UserControls.resources.NormalButton BtnListClear;
        private UserControls.resources.ColoredButton BtnMonitorEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEndDateInfo;
        private System.Windows.Forms.Label lblStartDateInfo;
        private System.Windows.Forms.TabControl tconProcessTab;
        private System.Windows.Forms.Button btnGraphViewer;
        private UserControls.resources.CommonPanel panel1;
        private UserControls.resources.SubtitleLabel subtitleLabel1;
        private UserControls.resources.CommonPanel commonPanel1;
        private UserControls.resources.SubtitleLabel subtitleLabel2;
    }
}

