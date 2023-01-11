﻿namespace WindowsFormsApp1.UserControls
{
    partial class uscRealTimeProcessView
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("CPU Usage", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Memory Usage", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Min", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Max", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Average", System.Windows.Forms.HorizontalAlignment.Left);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbxInfo = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblProcessName = new System.Windows.Forms.Label();
            this.lblPid = new System.Windows.Forms.Label();
            this.dgvStatistics = new System.Windows.Forms.DataGridView();
            this.colAverage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaxValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCounter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gboxRealTimeLog = new System.Windows.Forms.GroupBox();
            this.lboxRealTimeLog = new System.Windows.Forms.ListBox();
            this.gboxWorstList = new System.Windows.Forms.GroupBox();
            this.lviewWorstList = new System.Windows.Forms.ListView();
            this.chNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chWorstValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbxInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistics)).BeginInit();
            this.gboxRealTimeLog.SuspendLayout();
            this.gboxWorstList.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gboxWorstList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.gboxRealTimeLog, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.gbxInfo, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(790, 600);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // gbxInfo
            // 
            this.gbxInfo.Controls.Add(this.dgvStatistics);
            this.gbxInfo.Controls.Add(this.lblPid);
            this.gbxInfo.Controls.Add(this.lblProcessName);
            this.gbxInfo.Controls.Add(this.label2);
            this.gbxInfo.Controls.Add(this.label1);
            this.gbxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxInfo.Location = new System.Drawing.Point(3, 3);
            this.gbxInfo.Name = "gbxInfo";
            this.gbxInfo.Size = new System.Drawing.Size(784, 194);
            this.gbxInfo.TabIndex = 1;
            this.gbxInfo.TabStop = false;
            this.gbxInfo.Text = "Information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Process Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "PID :";
            // 
            // lblProcessName
            // 
            this.lblProcessName.AutoSize = true;
            this.lblProcessName.Location = new System.Drawing.Point(124, 17);
            this.lblProcessName.Name = "lblProcessName";
            this.lblProcessName.Size = new System.Drawing.Size(99, 12);
            this.lblProcessName.TabIndex = 2;
            this.lblProcessName.Text = "lblProcessName";
            // 
            // lblPid
            // 
            this.lblPid.AutoSize = true;
            this.lblPid.Location = new System.Drawing.Point(49, 38);
            this.lblPid.Name = "lblPid";
            this.lblPid.Size = new System.Drawing.Size(36, 12);
            this.lblPid.TabIndex = 3;
            this.lblPid.Text = "lblPid";
            // 
            // dgvStatistics
            // 
            this.dgvStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatistics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCounter,
            this.colMinValue,
            this.colMaxValue,
            this.colAverage});
            this.dgvStatistics.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvStatistics.Location = new System.Drawing.Point(6, 53);
            this.dgvStatistics.Name = "dgvStatistics";
            this.dgvStatistics.RowTemplate.Height = 23;
            this.dgvStatistics.Size = new System.Drawing.Size(772, 135);
            this.dgvStatistics.TabIndex = 4;
            // 
            // colAverage
            // 
            this.colAverage.HeaderText = "평균";
            this.colAverage.Name = "colAverage";
            // 
            // colMaxValue
            // 
            this.colMaxValue.HeaderText = "최댓값";
            this.colMaxValue.Name = "colMaxValue";
            // 
            // colMinValue
            // 
            this.colMinValue.HeaderText = "최솟값";
            this.colMinValue.Name = "colMinValue";
            // 
            // colCounter
            // 
            this.colCounter.HeaderText = "측정 항목";
            this.colCounter.Name = "colCounter";
            // 
            // gboxRealTimeLog
            // 
            this.gboxRealTimeLog.Controls.Add(this.lboxRealTimeLog);
            this.gboxRealTimeLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboxRealTimeLog.Location = new System.Drawing.Point(3, 403);
            this.gboxRealTimeLog.Name = "gboxRealTimeLog";
            this.gboxRealTimeLog.Size = new System.Drawing.Size(784, 194);
            this.gboxRealTimeLog.TabIndex = 0;
            this.gboxRealTimeLog.TabStop = false;
            this.gboxRealTimeLog.Text = "Real Time Log";
            // 
            // lboxRealTimeLog
            // 
            this.lboxRealTimeLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lboxRealTimeLog.FormattingEnabled = true;
            this.lboxRealTimeLog.HorizontalScrollbar = true;
            this.lboxRealTimeLog.ItemHeight = 12;
            this.lboxRealTimeLog.Location = new System.Drawing.Point(3, 17);
            this.lboxRealTimeLog.Name = "lboxRealTimeLog";
            this.lboxRealTimeLog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lboxRealTimeLog.Size = new System.Drawing.Size(778, 174);
            this.lboxRealTimeLog.TabIndex = 0;
            // 
            // gboxWorstList
            // 
            this.gboxWorstList.AutoSize = true;
            this.gboxWorstList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gboxWorstList.Controls.Add(this.lviewWorstList);
            this.gboxWorstList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboxWorstList.Location = new System.Drawing.Point(3, 203);
            this.gboxWorstList.Name = "gboxWorstList";
            this.gboxWorstList.Size = new System.Drawing.Size(784, 194);
            this.gboxWorstList.TabIndex = 0;
            this.gboxWorstList.TabStop = false;
            this.gboxWorstList.Text = "Worst List";
            // 
            // lviewWorstList
            // 
            this.lviewWorstList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNumber,
            this.chWorstValue,
            this.chTime,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lviewWorstList.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup1.Header = "CPU Usage";
            listViewGroup1.Name = "CPU Usage";
            listViewGroup1.Tag = "1";
            listViewGroup2.Header = "Memory Usage";
            listViewGroup2.Name = "Memory Usage";
            listViewGroup2.Tag = "2";
            listViewGroup3.Header = "Min";
            listViewGroup3.Name = "Min";
            listViewGroup4.Header = "Max";
            listViewGroup4.Name = "Max";
            listViewGroup5.Header = "Average";
            listViewGroup5.Name = "Average";
            this.lviewWorstList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5});
            this.lviewWorstList.HideSelection = false;
            this.lviewWorstList.Location = new System.Drawing.Point(3, 17);
            this.lviewWorstList.Name = "lviewWorstList";
            this.lviewWorstList.Size = new System.Drawing.Size(778, 174);
            this.lviewWorstList.TabIndex = 0;
            this.lviewWorstList.UseCompatibleStateImageBehavior = false;
            this.lviewWorstList.View = System.Windows.Forms.View.Details;
            // 
            // chNumber
            // 
            this.chNumber.Text = "No";
            // 
            // chWorstValue
            // 
            this.chWorstValue.Text = "Worst Value";
            this.chWorstValue.Width = 142;
            // 
            // chTime
            // 
            this.chTime.Text = "Time";
            this.chTime.Width = 192;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(790, 825);
            this.panel1.TabIndex = 5;
            // 
            // uscRealTimeProcessView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panel1);
            this.Name = "uscRealTimeProcessView";
            this.Size = new System.Drawing.Size(790, 825);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.gbxInfo.ResumeLayout(false);
            this.gbxInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistics)).EndInit();
            this.gboxRealTimeLog.ResumeLayout(false);
            this.gboxWorstList.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gboxWorstList;
        private System.Windows.Forms.ListView lviewWorstList;
        private System.Windows.Forms.ColumnHeader chNumber;
        private System.Windows.Forms.ColumnHeader chWorstValue;
        private System.Windows.Forms.ColumnHeader chTime;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.GroupBox gboxRealTimeLog;
        private System.Windows.Forms.ListBox lboxRealTimeLog;
        private System.Windows.Forms.GroupBox gbxInfo;
        private System.Windows.Forms.DataGridView dgvStatistics;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCounter;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaxValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAverage;
        private System.Windows.Forms.Label lblPid;
        private System.Windows.Forms.Label lblProcessName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}