namespace WindowsFormsApp1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblEndDateInfo = new System.Windows.Forms.Label();
            this.lblStartDateInfo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnMonitorEnd = new System.Windows.Forms.Button();
            this.BtnMonitorStart = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BtnApply = new System.Windows.Forms.Button();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnListClear = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lboxLog = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lboxProcessLog = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tconProcessTab = new System.Windows.Forms.TabControl();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblEndDateInfo);
            this.groupBox2.Controls.Add(this.lblStartDateInfo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.BtnMonitorEnd);
            this.groupBox2.Controls.Add(this.BtnMonitorStart);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.dateTimePickerEndDate);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(13, 267);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(584, 102);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Period Config";
            // 
            // lblEndDateInfo
            // 
            this.lblEndDateInfo.BackColor = System.Drawing.Color.White;
            this.lblEndDateInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEndDateInfo.Location = new System.Drawing.Point(110, 73);
            this.lblEndDateInfo.Name = "lblEndDateInfo";
            this.lblEndDateInfo.Size = new System.Drawing.Size(171, 21);
            this.lblEndDateInfo.TabIndex = 13;
            this.lblEndDateInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStartDateInfo
            // 
            this.lblStartDateInfo.BackColor = System.Drawing.Color.White;
            this.lblStartDateInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStartDateInfo.Location = new System.Drawing.Point(110, 48);
            this.lblStartDateInfo.Name = "lblStartDateInfo";
            this.lblStartDateInfo.Size = new System.Drawing.Size(171, 21);
            this.lblStartDateInfo.TabIndex = 12;
            this.lblStartDateInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "End Date Info";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "Start Date Info";
            // 
            // BtnMonitorEnd
            // 
            this.BtnMonitorEnd.Location = new System.Drawing.Point(287, 72);
            this.BtnMonitorEnd.Name = "BtnMonitorEnd";
            this.BtnMonitorEnd.Size = new System.Drawing.Size(84, 23);
            this.BtnMonitorEnd.TabIndex = 9;
            this.BtnMonitorEnd.Text = "Monitor Stop";
            this.BtnMonitorEnd.UseVisualStyleBackColor = true;
            this.BtnMonitorEnd.Click += new System.EventHandler(this.BtnMonitorEnd_Click);
            // 
            // BtnMonitorStart
            // 
            this.BtnMonitorStart.Location = new System.Drawing.Point(287, 47);
            this.BtnMonitorStart.Name = "BtnMonitorStart";
            this.BtnMonitorStart.Size = new System.Drawing.Size(84, 23);
            this.BtnMonitorStart.TabIndex = 8;
            this.BtnMonitorStart.Text = "Monitor Start";
            this.BtnMonitorStart.UseVisualStyleBackColor = true;
            this.BtnMonitorStart.Click += new System.EventHandler(this.BtnMonitorStart_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(393, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "Select Unit";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(386, 72);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(86, 21);
            this.textBox2.TabIndex = 6;
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.CustomFormat = "yyyy-MM-dd HH시 mm분";
            this.dateTimePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEndDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(110, 21);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(171, 21);
            this.dateTimePickerEndDate.TabIndex = 4;
            this.dateTimePickerEndDate.Value = new System.DateTime(2022, 12, 13, 15, 25, 11, 674);
            this.dateTimePickerEndDate.ValueChanged += new System.EventHandler(this.dateTimePickerEndDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "End Date Set";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Location = new System.Drawing.Point(152, 20);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(72, 23);
            this.BtnRefresh.TabIndex = 1;
            this.BtnRefresh.Text = "Refresh";
            this.BtnRefresh.UseVisualStyleBackColor = true;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(60, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(86, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // BtnApply
            // 
            this.BtnApply.Location = new System.Drawing.Point(308, 115);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(50, 30);
            this.BtnApply.TabIndex = 4;
            this.BtnApply.Text = "▶";
            this.BtnApply.UseVisualStyleBackColor = true;
            this.BtnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // BtnRemove
            // 
            this.BtnRemove.Location = new System.Drawing.Point(308, 146);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(50, 30);
            this.BtnRemove.TabIndex = 5;
            this.BtnRemove.Text = "◀";
            this.BtnRemove.UseVisualStyleBackColor = true;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnListClear);
            this.groupBox1.Controls.Add(this.listView2);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.BtnRemove);
            this.groupBox1.Controls.Add(this.BtnApply);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.BtnRefresh);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 247);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Process List";
            // 
            // BtnListClear
            // 
            this.BtnListClear.Location = new System.Drawing.Point(360, 22);
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
            this.listView2.Location = new System.Drawing.Point(361, 49);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(215, 189);
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
            this.listView1.Location = new System.Drawing.Point(13, 49);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(292, 189);
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
            // lboxLog
            // 
            this.lboxLog.FormattingEnabled = true;
            this.lboxLog.ItemHeight = 12;
            this.lboxLog.Location = new System.Drawing.Point(13, 375);
            this.lboxLog.Name = "lboxLog";
            this.lboxLog.Size = new System.Drawing.Size(713, 100);
            this.lboxLog.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 481);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(718, 180);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lboxProcessLog);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(710, 154);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lboxProcessLog
            // 
            this.lboxProcessLog.FormattingEnabled = true;
            this.lboxProcessLog.ItemHeight = 12;
            this.lboxProcessLog.Location = new System.Drawing.Point(3, 6);
            this.lboxProcessLog.Name = "lboxProcessLog";
            this.lboxProcessLog.Size = new System.Drawing.Size(701, 148);
            this.lboxProcessLog.TabIndex = 4;
            // 
            // tconProcessTab
            // 
            this.tconProcessTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tconProcessTab.Location = new System.Drawing.Point(752, 375);
            this.tconProcessTab.Name = "tconProcessTab";
            this.tconProcessTab.SelectedIndex = 0;
            this.tconProcessTab.Size = new System.Drawing.Size(592, 286);
            this.tconProcessTab.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 716);
            this.Controls.Add(this.tconProcessTab);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lboxLog);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Monitoring Process Tool";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BtnApply;
        private System.Windows.Forms.Button BtnRemove;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnMonitorStart;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button BtnListClear;
        private System.Windows.Forms.ListBox lboxLog;
        private System.Windows.Forms.Button BtnMonitorEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEndDateInfo;
        private System.Windows.Forms.Label lblStartDateInfo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox lboxProcessLog;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabControl tconProcessTab;
    }
}

