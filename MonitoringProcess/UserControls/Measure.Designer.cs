﻿namespace MonitorigProcess
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
        private void InitializeComponent()
        {
            this.freeDiskSpaceViewer1 = new MonitoringProcess.UserControls.FreeDiskSpaceViewer();
            this.commonPanel2 = new MonitorigProcess.UserControls.resources.CommonPanel();
            this.totalViewButton = new MonitorigProcess.UserControls.resources.NormalButton();
            this.subtitleLabel3 = new MonitorigProcess.UserControls.resources.SubtitleLabel();
            this.processMonitoredList = new System.Windows.Forms.ListBox();
            this.commonPanel1 = new MonitorigProcess.UserControls.resources.CommonPanel();
            this.lblEndDateInfo = new System.Windows.Forms.Label();
            this.subtitleLabel2 = new MonitorigProcess.UserControls.resources.SubtitleLabel();
            this.lblStartDateInfo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnMonitorStart = new MonitorigProcess.UserControls.resources.ColoredButton();
            this.BtnMonitorEnd = new MonitorigProcess.UserControls.resources.ColoredButton();
            this.panel1 = new MonitorigProcess.UserControls.resources.CommonPanel();
            this.buttonFavorites = new MonitorigProcess.UserControls.resources.ColoredButton();
            this.subtitleLabel1 = new MonitorigProcess.UserControls.resources.SubtitleLabel();
            this.BtnListClear = new MonitorigProcess.UserControls.resources.NormalButton();
            this.BtnRefresh = new MonitorigProcess.UserControls.resources.NormalButton();
            this.listViewSelectedProcess = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnProcessName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BtnRemove = new MonitorigProcess.UserControls.resources.NormalButton();
            this.BtnApply = new MonitorigProcess.UserControls.resources.NormalButton();
            this.commonPanel3 = new MonitorigProcess.UserControls.resources.CommonPanel();
            this.guna2ContainerControl1 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.totalResourceView = new MonitorigProcess.UserControls.uscRealTimeProcessView();
            this.processDetailView = new MonitorigProcess.UserControls.uscRealTimeProcessView();
            this.commonPanel2.SuspendLayout();
            this.commonPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.commonPanel3.SuspendLayout();
            this.guna2ContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // freeDiskSpaceViewer1
            // 
            this.freeDiskSpaceViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.freeDiskSpaceViewer1.Location = new System.Drawing.Point(0, 600);
            this.freeDiskSpaceViewer1.Margin = new System.Windows.Forms.Padding(1);
            this.freeDiskSpaceViewer1.Name = "freeDiskSpaceViewer1";
            this.freeDiskSpaceViewer1.Size = new System.Drawing.Size(1100, 149);
            this.freeDiskSpaceViewer1.TabIndex = 18;
            // 
            // commonPanel2
            // 
            this.commonPanel2.Controls.Add(this.totalViewButton);
            this.commonPanel2.Controls.Add(this.subtitleLabel3);
            this.commonPanel2.Controls.Add(this.processMonitoredList);
            this.commonPanel2.Location = new System.Drawing.Point(0, 180);
            this.commonPanel2.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.commonPanel2.Name = "commonPanel2";
            this.commonPanel2.Size = new System.Drawing.Size(182, 418);
            this.commonPanel2.TabIndex = 0;
            // 
            // totalViewButton
            // 
            this.totalViewButton.FlatAppearance.BorderSize = 0;
            this.totalViewButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.totalViewButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.totalViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.totalViewButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.totalViewButton.Location = new System.Drawing.Point(124, 3);
            this.totalViewButton.Name = "totalViewButton";
            this.totalViewButton.Size = new System.Drawing.Size(53, 30);
            this.totalViewButton.TabIndex = 19;
            this.totalViewButton.Text = "Total";
            this.totalViewButton.UseVisualStyleBackColor = true;
            this.totalViewButton.Click += new System.EventHandler(this.totalViewButton_Click);
            // 
            // subtitleLabel3
            // 
            this.subtitleLabel3.AutoSize = true;
            this.subtitleLabel3.Location = new System.Drawing.Point(2, 6);
            this.subtitleLabel3.Margin = new System.Windows.Forms.Padding(1);
            this.subtitleLabel3.Name = "subtitleLabel3";
            this.subtitleLabel3.Size = new System.Drawing.Size(61, 21);
            this.subtitleLabel3.TabIndex = 18;
            this.subtitleLabel3.Text = "Details";
            // 
            // processMonitoredList
            // 
            this.processMonitoredList.FormattingEnabled = true;
            this.processMonitoredList.ItemHeight = 12;
            this.processMonitoredList.Location = new System.Drawing.Point(4, 34);
            this.processMonitoredList.Margin = new System.Windows.Forms.Padding(1);
            this.processMonitoredList.Name = "processMonitoredList";
            this.processMonitoredList.Size = new System.Drawing.Size(174, 376);
            this.processMonitoredList.TabIndex = 17;
            this.processMonitoredList.SelectedIndexChanged += new System.EventHandler(this.processMonitoredList_SelectedIndexChanged);
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
            this.commonPanel1.Location = new System.Drawing.Point(601, 0);
            this.commonPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.commonPanel1.Name = "commonPanel1";
            this.commonPanel1.Size = new System.Drawing.Size(498, 178);
            this.commonPanel1.TabIndex = 15;
            // 
            // lblEndDateInfo
            // 
            this.lblEndDateInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEndDateInfo.BackColor = System.Drawing.Color.White;
            this.lblEndDateInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEndDateInfo.Location = new System.Drawing.Point(108, 83);
            this.lblEndDateInfo.Name = "lblEndDateInfo";
            this.lblEndDateInfo.Size = new System.Drawing.Size(371, 21);
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
            this.lblStartDateInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStartDateInfo.BackColor = System.Drawing.Color.White;
            this.lblStartDateInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStartDateInfo.Location = new System.Drawing.Point(108, 58);
            this.lblStartDateInfo.Name = "lblStartDateInfo";
            this.lblStartDateInfo.Size = new System.Drawing.Size(371, 21);
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
            this.dateTimePickerEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerEndDate.CustomFormat = "yyyy-MM-dd HH시 mm분";
            this.dateTimePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEndDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(108, 31);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(371, 21);
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
            this.BtnMonitorStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMonitorStart.FlatAppearance.BorderSize = 0;
            this.BtnMonitorStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.BtnMonitorStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.BtnMonitorStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMonitorStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BtnMonitorStart.Location = new System.Drawing.Point(252, 130);
            this.BtnMonitorStart.Name = "BtnMonitorStart";
            this.BtnMonitorStart.Size = new System.Drawing.Size(110, 23);
            this.BtnMonitorStart.TabIndex = 8;
            this.BtnMonitorStart.Text = "Monitor Start";
            this.BtnMonitorStart.UseVisualStyleBackColor = true;
            this.BtnMonitorStart.Click += new System.EventHandler(this.BtnMonitorStart_Click);
            // 
            // BtnMonitorEnd
            // 
            this.BtnMonitorEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMonitorEnd.FlatAppearance.BorderSize = 0;
            this.BtnMonitorEnd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.BtnMonitorEnd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.BtnMonitorEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMonitorEnd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BtnMonitorEnd.Location = new System.Drawing.Point(368, 130);
            this.BtnMonitorEnd.Name = "BtnMonitorEnd";
            this.BtnMonitorEnd.Size = new System.Drawing.Size(111, 23);
            this.BtnMonitorEnd.TabIndex = 9;
            this.BtnMonitorEnd.Text = "Monitor Stop";
            this.BtnMonitorEnd.UseVisualStyleBackColor = true;
            this.BtnMonitorEnd.Click += new System.EventHandler(this.BtnMonitorEnd_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonFavorites);
            this.panel1.Controls.Add(this.subtitleLabel1);
            this.panel1.Controls.Add(this.BtnListClear);
            this.panel1.Controls.Add(this.BtnRefresh);
            this.panel1.Controls.Add(this.listViewSelectedProcess);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.BtnRemove);
            this.panel1.Controls.Add(this.BtnApply);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(598, 178);
            this.panel1.TabIndex = 14;
            // 
            // buttonFavorites
            // 
            this.buttonFavorites.FlatAppearance.BorderSize = 0;
            this.buttonFavorites.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.buttonFavorites.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.buttonFavorites.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFavorites.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonFavorites.Location = new System.Drawing.Point(503, 23);
            this.buttonFavorites.Name = "buttonFavorites";
            this.buttonFavorites.Size = new System.Drawing.Size(76, 23);
            this.buttonFavorites.TabIndex = 10;
            this.buttonFavorites.Text = "Favorite";
            this.buttonFavorites.UseVisualStyleBackColor = true;
            this.buttonFavorites.Click += new System.EventHandler(this.buttonFavorite_Click);
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
            // listViewSelectedProcess
            // 
            this.listViewSelectedProcess.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.listViewSelectedProcess.FullRowSelect = true;
            this.listViewSelectedProcess.GridLines = true;
            this.listViewSelectedProcess.HideSelection = false;
            this.listViewSelectedProcess.Location = new System.Drawing.Point(364, 53);
            this.listViewSelectedProcess.Name = "listViewSelectedProcess";
            this.listViewSelectedProcess.Size = new System.Drawing.Size(215, 110);
            this.listViewSelectedProcess.TabIndex = 7;
            this.listViewSelectedProcess.UseCompatibleStateImageBehavior = false;
            this.listViewSelectedProcess.View = System.Windows.Forms.View.Details;
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
            this.columnPid,
            this.columnProcessName});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(16, 53);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(292, 110);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No";
            this.columnHeader1.Width = 30;
            // 
            // columnPid
            // 
            this.columnPid.Text = "Pid";
            // 
            // columnProcessName
            // 
            this.columnProcessName.Text = "ProcessName";
            this.columnProcessName.Width = 180;
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
            this.BtnRemove.Location = new System.Drawing.Point(311, 105);
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
            this.BtnApply.Location = new System.Drawing.Point(311, 74);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(50, 30);
            this.BtnApply.TabIndex = 4;
            this.BtnApply.Text = "▶";
            this.BtnApply.UseVisualStyleBackColor = true;
            this.BtnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // commonPanel3
            // 
            this.commonPanel3.Controls.Add(this.guna2ContainerControl1);
            this.commonPanel3.Location = new System.Drawing.Point(186, 180);
            this.commonPanel3.Margin = new System.Windows.Forms.Padding(1);
            this.commonPanel3.Name = "commonPanel3";
            this.commonPanel3.Size = new System.Drawing.Size(913, 418);
            this.commonPanel3.TabIndex = 17;
            // 
            // guna2ContainerControl1
            // 
            this.guna2ContainerControl1.Controls.Add(this.totalResourceView);
            this.guna2ContainerControl1.Controls.Add(this.processDetailView);
            this.guna2ContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2ContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.guna2ContainerControl1.Margin = new System.Windows.Forms.Padding(0);
            this.guna2ContainerControl1.Name = "guna2ContainerControl1";
            this.guna2ContainerControl1.Size = new System.Drawing.Size(913, 418);
            this.guna2ContainerControl1.TabIndex = 1;
            this.guna2ContainerControl1.Text = "guna2ContainerControl1";
            // 
            // totalResourceView
            // 
            this.totalResourceView.AutoSize = true;
            this.totalResourceView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalResourceView.Location = new System.Drawing.Point(0, 0);
            this.totalResourceView.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.totalResourceView.Name = "totalResourceView";
            this.totalResourceView.Size = new System.Drawing.Size(913, 418);
            this.totalResourceView.TabIndex = 1;
            // 
            // processDetailView
            // 
            this.processDetailView.AutoSize = true;
            this.processDetailView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processDetailView.Location = new System.Drawing.Point(0, 0);
            this.processDetailView.Margin = new System.Windows.Forms.Padding(1);
            this.processDetailView.Name = "processDetailView";
            this.processDetailView.Size = new System.Drawing.Size(913, 418);
            this.processDetailView.TabIndex = 0;
            // 
            // Measure
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.freeDiskSpaceViewer1);
            this.Controls.Add(this.commonPanel2);
            this.Controls.Add(this.commonPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.commonPanel3);
            this.Name = "Measure";
            this.Size = new System.Drawing.Size(1100, 750);
            this.commonPanel2.ResumeLayout(false);
            this.commonPanel2.PerformLayout();
            this.commonPanel1.ResumeLayout(false);
            this.commonPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.commonPanel3.ResumeLayout(false);
            this.guna2ContainerControl1.ResumeLayout(false);
            this.guna2ContainerControl1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private UserControls.uscRealTimeProcessView processDetailView;
        private UserControls.resources.NormalButton BtnRefresh;
        private System.Windows.Forms.TextBox textBox1;
        private UserControls.resources.NormalButton BtnApply;
        private UserControls.resources.NormalButton BtnRemove;
        private UserControls.resources.ColoredButton BtnMonitorStart;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnPid;
        private System.Windows.Forms.ColumnHeader columnProcessName;
        private System.Windows.Forms.ListView listViewSelectedProcess;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private UserControls.resources.NormalButton BtnListClear;
        private UserControls.resources.ColoredButton BtnMonitorEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEndDateInfo;
        private System.Windows.Forms.Label lblStartDateInfo;
        private UserControls.resources.CommonPanel panel1;
        private UserControls.resources.SubtitleLabel subtitleLabel1;
        private UserControls.resources.CommonPanel commonPanel1;
        private UserControls.resources.SubtitleLabel subtitleLabel2;
        private UserControls.resources.CommonPanel commonPanel2;
        private System.Windows.Forms.ListBox processMonitoredList;
        private UserControls.resources.SubtitleLabel subtitleLabel3;
        private UserControls.resources.CommonPanel commonPanel3;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl1;
        private UserControls.uscRealTimeProcessView totalResourceView;
        private UserControls.resources.NormalButton totalViewButton;
        private UserControls.resources.ColoredButton buttonFavorites;
        private MonitoringProcess.UserControls.FreeDiskSpaceViewer freeDiskSpaceViewer1;
    }
}

