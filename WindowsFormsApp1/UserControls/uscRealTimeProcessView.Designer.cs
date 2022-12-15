namespace WindowsFormsApp1.UserControls
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "item1",
            "sub1",
            "sub2",
            "sub3"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("item2");
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gboxWorstList = new System.Windows.Forms.GroupBox();
            this.lviewWorstList = new System.Windows.Forms.ListView();
            this.chNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chWorstValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gboxRealTimeLog = new System.Windows.Forms.GroupBox();
            this.lboxRealTimeLog = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gboxWorstList.SuspendLayout();
            this.gboxRealTimeLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gboxWorstList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gboxRealTimeLog);
            this.splitContainer1.Size = new System.Drawing.Size(790, 550);
            this.splitContainer1.SplitterDistance = 263;
            this.splitContainer1.TabIndex = 0;
            // 
            // gboxWorstList
            // 
            this.gboxWorstList.Controls.Add(this.lviewWorstList);
            this.gboxWorstList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboxWorstList.Location = new System.Drawing.Point(0, 0);
            this.gboxWorstList.Name = "gboxWorstList";
            this.gboxWorstList.Size = new System.Drawing.Size(790, 263);
            this.gboxWorstList.TabIndex = 0;
            this.gboxWorstList.TabStop = false;
            this.gboxWorstList.Text = "Worst List";
            // 
            // lviewWorstList
            // 
            this.lviewWorstList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lviewWorstList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNumber,
            this.chWorstValue,
            this.chTime});
            listViewGroup1.Header = "CPU Usage";
            listViewGroup1.Name = "CPU Usage";
            listViewGroup1.Tag = "1";
            listViewGroup2.Header = "Memory Usage";
            listViewGroup2.Name = "Memory Usage";
            listViewGroup2.Tag = "2";
            this.lviewWorstList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.lviewWorstList.HideSelection = false;
            this.lviewWorstList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.lviewWorstList.Location = new System.Drawing.Point(6, 20);
            this.lviewWorstList.Name = "lviewWorstList";
            this.lviewWorstList.Size = new System.Drawing.Size(778, 237);
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
            this.chTime.Width = 142;
            // 
            // gboxRealTimeLog
            // 
            this.gboxRealTimeLog.Controls.Add(this.lboxRealTimeLog);
            this.gboxRealTimeLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboxRealTimeLog.Location = new System.Drawing.Point(0, 0);
            this.gboxRealTimeLog.Name = "gboxRealTimeLog";
            this.gboxRealTimeLog.Size = new System.Drawing.Size(790, 283);
            this.gboxRealTimeLog.TabIndex = 0;
            this.gboxRealTimeLog.TabStop = false;
            this.gboxRealTimeLog.Text = "Real Time Log";
            // 
            // lboxRealTimeLog
            // 
            this.lboxRealTimeLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lboxRealTimeLog.FormattingEnabled = true;
            this.lboxRealTimeLog.ItemHeight = 12;
            this.lboxRealTimeLog.Location = new System.Drawing.Point(6, 20);
            this.lboxRealTimeLog.Name = "lboxRealTimeLog";
            this.lboxRealTimeLog.Size = new System.Drawing.Size(778, 256);
            this.lboxRealTimeLog.TabIndex = 0;
            // 
            // uscRealTimeProcessView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "uscRealTimeProcessView";
            this.Size = new System.Drawing.Size(790, 550);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gboxWorstList.ResumeLayout(false);
            this.gboxRealTimeLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gboxWorstList;
        private System.Windows.Forms.GroupBox gboxRealTimeLog;
        private System.Windows.Forms.ListView lviewWorstList;
        private System.Windows.Forms.ColumnHeader chNumber;
        private System.Windows.Forms.ColumnHeader chWorstValue;
        private System.Windows.Forms.ColumnHeader chTime;
        private System.Windows.Forms.ListBox lboxRealTimeLog;
    }
}
