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
            this.tconProcessTab = new Guna.UI2.WinForms.Guna2TabControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new WindowsFormsApp1.UserControls.resources.CommonPanel();
            this.subtitleLabel1 = new WindowsFormsApp1.UserControls.resources.SubtitleLabel();
            this.BtnListClear = new WindowsFormsApp1.UserControls.resources.NormalButton();
            this.BtnRefresh = new WindowsFormsApp1.UserControls.resources.NormalButton();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BtnRemove = new WindowsFormsApp1.UserControls.resources.NormalButton();
            this.BtnApply = new WindowsFormsApp1.UserControls.resources.NormalButton();
            this.commonPanel1 = new WindowsFormsApp1.UserControls.resources.CommonPanel();
            this.lblEndDateInfo = new System.Windows.Forms.Label();
            this.subtitleLabel2 = new WindowsFormsApp1.UserControls.resources.SubtitleLabel();
            this.lblStartDateInfo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnMonitorStart = new WindowsFormsApp1.UserControls.resources.ColoredButton();
            this.BtnMonitorEnd = new WindowsFormsApp1.UserControls.resources.ColoredButton();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.commonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tconProcessTab
            // 
            this.tconProcessTab.Dock = System.Windows.Forms.DockStyle.Top;
            this.tconProcessTab.ItemSize = new System.Drawing.Size(95, 27);
            this.tconProcessTab.Location = new System.Drawing.Point(1, 261);
            this.tconProcessTab.Margin = new System.Windows.Forms.Padding(1);
            this.tconProcessTab.Name = "tconProcessTab";
            this.tconProcessTab.SelectedIndex = 0;
            this.tconProcessTab.Size = new System.Drawing.Size(998, 338);
            this.tconProcessTab.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tconProcessTab.TabButtonHoverState.FillColor = System.Drawing.Color.White;
            this.tconProcessTab.TabButtonHoverState.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tconProcessTab.TabButtonHoverState.ForeColor = System.Drawing.Color.Black;
            this.tconProcessTab.TabButtonHoverState.InnerColor = System.Drawing.Color.Transparent;
            this.tconProcessTab.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tconProcessTab.TabButtonIdleState.FillColor = System.Drawing.Color.White;
            this.tconProcessTab.TabButtonIdleState.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tconProcessTab.TabButtonIdleState.ForeColor = System.Drawing.Color.Gray;
            this.tconProcessTab.TabButtonIdleState.InnerColor = System.Drawing.Color.Transparent;
            this.tconProcessTab.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tconProcessTab.TabButtonSelectedState.FillColor = System.Drawing.Color.White;
            this.tconProcessTab.TabButtonSelectedState.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tconProcessTab.TabButtonSelectedState.ForeColor = System.Drawing.Color.Black;
            this.tconProcessTab.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.tconProcessTab.TabButtonSize = new System.Drawing.Size(95, 27);
            this.tconProcessTab.TabIndex = 4;
            this.tconProcessTab.TabMenuBackColor = System.Drawing.Color.White;
            this.tconProcessTab.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.commonPanel1);
            this.flowLayoutPanel1.Controls.Add(this.tconProcessTab);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1000, 600);
            this.flowLayoutPanel1.TabIndex = 16;
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
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(598, 258);
            this.panel1.TabIndex = 14;
            // 
            // subtitleLabel1
            // 
            this.subtitleLabel1.AutoSize = true;
            this.subtitleLabel1.Location = new System.Drawing.Point(2, 2);
            this.subtitleLabel1.Name = "subtitleLabel1";
            this.subtitleLabel1.Size = new System.Drawing.Size(98, 21);
            this.subtitleLabel1.TabIndex = 9;
            this.subtitleLabel1.Text = "Process List";
            // 
            // BtnListClear
            // 
            this.BtnListClear.FlatAppearance.BorderSize = 0;
            this.BtnListClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.BtnListClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtnListClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnListClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.BtnListClear.Location = new System.Drawing.Point(364, 23);
            this.BtnListClear.Name = "BtnListClear";
            this.BtnListClear.Size = new System.Drawing.Size(87, 23);
            this.BtnListClear.TabIndex = 8;
            this.BtnListClear.Text = "List Clear";
            this.BtnListClear.UseVisualStyleBackColor = true;
            this.BtnListClear.Click += new System.EventHandler(this.BtnListClear_Click);
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.FlatAppearance.BorderSize = 0;
            this.BtnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.BtnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.BtnRefresh.Location = new System.Drawing.Point(151, 25);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(72, 23);
            this.BtnRefresh.TabIndex = 1;
            this.BtnRefresh.Text = "Refresh";
            this.BtnRefresh.UseVisualStyleBackColor = true;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(364, 53);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
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
            this.listView1.Location = new System.Drawing.Point(16, 53);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(59, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(86, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // BtnRemove
            // 
            this.BtnRemove.FlatAppearance.BorderSize = 0;
            this.BtnRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.BtnRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.BtnRemove.Location = new System.Drawing.Point(311, 150);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(50, 30);
            this.BtnRemove.TabIndex = 5;
            this.BtnRemove.Text = "◀";
            this.BtnRemove.UseVisualStyleBackColor = true;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnApply
            // 
            this.BtnApply.FlatAppearance.BorderSize = 0;
            this.BtnApply.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.BtnApply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnApply.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.BtnApply.Location = new System.Drawing.Point(311, 119);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(50, 30);
            this.BtnApply.TabIndex = 4;
            this.BtnApply.Text = "▶";
            this.BtnApply.UseVisualStyleBackColor = true;
            this.BtnApply.Click += new System.EventHandler(this.BtnApply_Click);
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
            this.commonPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.commonPanel1.Location = new System.Drawing.Point(601, 1);
            this.commonPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.commonPanel1.Name = "commonPanel1";
            this.commonPanel1.Size = new System.Drawing.Size(398, 258);
            this.commonPanel1.TabIndex = 15;
            // 
            // lblEndDateInfo
            // 
            this.lblEndDateInfo.BackColor = System.Drawing.Color.White;
            this.lblEndDateInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEndDateInfo.Location = new System.Drawing.Point(108, 83);
            this.lblEndDateInfo.Name = "lblEndDateInfo";
            this.lblEndDateInfo.Size = new System.Drawing.Size(271, 21);
            this.lblEndDateInfo.TabIndex = 13;
            this.lblEndDateInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // subtitleLabel2
            // 
            this.subtitleLabel2.AutoSize = true;
            this.subtitleLabel2.Location = new System.Drawing.Point(2, 2);
            this.subtitleLabel2.Name = "subtitleLabel2";
            this.subtitleLabel2.Size = new System.Drawing.Size(151, 21);
            this.subtitleLabel2.TabIndex = 0;
            this.subtitleLabel2.Text = "Monitoring Config";
            // 
            // lblStartDateInfo
            // 
            this.lblStartDateInfo.BackColor = System.Drawing.Color.White;
            this.lblStartDateInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStartDateInfo.Location = new System.Drawing.Point(108, 58);
            this.lblStartDateInfo.Name = "lblStartDateInfo";
            this.lblStartDateInfo.Size = new System.Drawing.Size(271, 21);
            this.lblStartDateInfo.TabIndex = 12;
            this.lblStartDateInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "End Date Set";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "End Date Info";
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.CustomFormat = "yyyy-MM-dd HH시 mm분";
            this.dateTimePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEndDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(108, 31);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(271, 21);
            this.dateTimePickerEndDate.TabIndex = 4;
            this.dateTimePickerEndDate.Value = new System.DateTime(2022, 12, 13, 15, 25, 11, 674);
            this.dateTimePickerEndDate.ValueChanged += new System.EventHandler(this.dateTimePickerEndDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "Start Date Info";
            // 
            // BtnMonitorStart
            // 
            this.BtnMonitorStart.FlatAppearance.BorderSize = 0;
            this.BtnMonitorStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.BtnMonitorStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.BtnMonitorStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMonitorStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BtnMonitorStart.Location = new System.Drawing.Point(151, 222);
            this.BtnMonitorStart.Name = "BtnMonitorStart";
            this.BtnMonitorStart.Size = new System.Drawing.Size(110, 23);
            this.BtnMonitorStart.TabIndex = 8;
            this.BtnMonitorStart.Text = "Monitor Start";
            this.BtnMonitorStart.UseVisualStyleBackColor = true;
            this.BtnMonitorStart.Click += new System.EventHandler(this.BtnMonitorStart_Click);
            // 
            // BtnMonitorEnd
            // 
            this.BtnMonitorEnd.FlatAppearance.BorderSize = 0;
            this.BtnMonitorEnd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.BtnMonitorEnd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.BtnMonitorEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMonitorEnd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BtnMonitorEnd.Location = new System.Drawing.Point(267, 222);
            this.BtnMonitorEnd.Name = "BtnMonitorEnd";
            this.BtnMonitorEnd.Size = new System.Drawing.Size(111, 23);
            this.BtnMonitorEnd.TabIndex = 9;
            this.BtnMonitorEnd.Text = "Monitor Stop";
            this.BtnMonitorEnd.UseVisualStyleBackColor = true;
            this.BtnMonitorEnd.Click += new System.EventHandler(this.BtnMonitorEnd_Click);
            // 
            // Measure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Measure";
            this.Size = new System.Drawing.Size(1000, 600);
            this.flowLayoutPanel1.ResumeLayout(false);
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
        private Guna.UI2.WinForms.Guna2TabControl tconProcessTab;
        private UserControls.resources.CommonPanel panel1;
        private UserControls.resources.SubtitleLabel subtitleLabel1;
        private UserControls.resources.CommonPanel commonPanel1;
        private UserControls.resources.SubtitleLabel subtitleLabel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

