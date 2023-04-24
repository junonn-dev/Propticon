using MonitorigProcess.UserControls.resources;

namespace MonitorigProcess.UserControls
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.commonPanel2 = new MonitorigProcess.UserControls.resources.CommonPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.subtitleLabel2 = new MonitorigProcess.UserControls.resources.SubtitleLabel();
            this.lviewWorstList = new System.Windows.Forms.ListView();
            this.chNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chWorstValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.commonPanel1 = new MonitorigProcess.UserControls.resources.CommonPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.subtitleLabel1 = new MonitorigProcess.UserControls.resources.SubtitleLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPid = new System.Windows.Forms.Label();
            this.dgvStatistics = new MonitorigProcess.UserControls.resources.CommonDataGrid();
            this.colCounter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaxValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAverage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commonPanel3 = new MonitorigProcess.UserControls.resources.CommonPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.subtitleLabel3 = new MonitorigProcess.UserControls.resources.SubtitleLabel();
            this.lboxRealTimeLog = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.commonPanel2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.commonPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistics)).BeginInit();
            this.commonPanel3.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tableLayoutPanel1.Controls.Add(this.commonPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.commonPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.commonPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1100, 391);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // commonPanel2
            // 
            this.commonPanel2.Controls.Add(this.flowLayoutPanel2);
            this.commonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commonPanel2.Location = new System.Drawing.Point(550, 1);
            this.commonPanel2.Margin = new System.Windows.Forms.Padding(1);
            this.commonPanel2.Name = "commonPanel2";
            this.commonPanel2.Size = new System.Drawing.Size(549, 232);
            this.commonPanel2.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.subtitleLabel2);
            this.flowLayoutPanel2.Controls.Add(this.lviewWorstList);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(549, 232);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // subtitleLabel2
            // 
            this.subtitleLabel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.subtitleLabel2.Location = new System.Drawing.Point(4, 4);
            this.subtitleLabel2.Margin = new System.Windows.Forms.Padding(4);
            this.subtitleLabel2.Name = "subtitleLabel2";
            this.subtitleLabel2.Size = new System.Drawing.Size(475, 21);
            this.subtitleLabel2.TabIndex = 1;
            this.subtitleLabel2.Text = "Worst List";
            // 
            // lviewWorstList
            // 
            this.lviewWorstList.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.lviewWorstList.BorderStyle = System.Windows.Forms.BorderStyle.None;
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
            this.lviewWorstList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lviewWorstList.HideSelection = false;
            this.lviewWorstList.LabelWrap = false;
            this.lviewWorstList.Location = new System.Drawing.Point(3, 32);
            this.lviewWorstList.MultiSelect = false;
            this.lviewWorstList.Name = "lviewWorstList";
            this.lviewWorstList.Size = new System.Drawing.Size(536, 196);
            this.lviewWorstList.TabIndex = 0;
            this.lviewWorstList.UseCompatibleStateImageBehavior = false;
            this.lviewWorstList.View = System.Windows.Forms.View.Details;
            // 
            // chNumber
            // 
            this.chNumber.Text = "No";
            this.chNumber.Width = 41;
            // 
            // chWorstValue
            // 
            this.chWorstValue.Text = "Worst Value";
            this.chWorstValue.Width = 95;
            // 
            // chTime
            // 
            this.chTime.Text = "Time";
            this.chTime.Width = 179;
            // 
            // commonPanel1
            // 
            this.commonPanel1.Controls.Add(this.flowLayoutPanel1);
            this.commonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commonPanel1.Location = new System.Drawing.Point(1, 1);
            this.commonPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.commonPanel1.Name = "commonPanel1";
            this.commonPanel1.Size = new System.Drawing.Size(547, 232);
            this.commonPanel1.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.subtitleLabel1);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.lblPid);
            this.flowLayoutPanel1.Controls.Add(this.dgvStatistics);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(547, 232);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // subtitleLabel1
            // 
            this.subtitleLabel1.Location = new System.Drawing.Point(4, 4);
            this.subtitleLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.subtitleLabel1.Name = "subtitleLabel1";
            this.subtitleLabel1.Size = new System.Drawing.Size(397, 25);
            this.subtitleLabel1.TabIndex = 0;
            this.subtitleLabel1.Text = "Information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(408, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "PID :";
            // 
            // lblPid
            // 
            this.lblPid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPid.AutoSize = true;
            this.lblPid.Location = new System.Drawing.Point(451, 5);
            this.lblPid.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblPid.Name = "lblPid";
            this.lblPid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPid.Size = new System.Drawing.Size(36, 12);
            this.lblPid.TabIndex = 3;
            this.lblPid.Text = "lblPid";
            // 
            // dgvStatistics
            // 
            this.dgvStatistics.AllowUserToAddRows = false;
            this.dgvStatistics.AllowUserToDeleteRows = false;
            this.dgvStatistics.AllowUserToResizeColumns = false;
            this.dgvStatistics.AllowUserToResizeRows = false;
            this.dgvStatistics.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dgvStatistics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStatistics.BackgroundColor = System.Drawing.Color.White;
            this.dgvStatistics.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStatistics.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvStatistics.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStatistics.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatistics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCounter,
            this.colMinValue,
            this.colMaxValue,
            this.colAverage});
            this.dgvStatistics.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStatistics.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStatistics.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvStatistics.Location = new System.Drawing.Point(0, 33);
            this.dgvStatistics.Margin = new System.Windows.Forms.Padding(0);
            this.dgvStatistics.Name = "dgvStatistics";
            this.dgvStatistics.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvStatistics.RowHeadersVisible = false;
            this.dgvStatistics.RowTemplate.Height = 23;
            this.dgvStatistics.Size = new System.Drawing.Size(546, 195);
            this.dgvStatistics.TabIndex = 4;
            // 
            // colCounter
            // 
            this.colCounter.HeaderText = "측정 항목";
            this.colCounter.Name = "colCounter";
            // 
            // colMinValue
            // 
            this.colMinValue.HeaderText = "최솟값";
            this.colMinValue.Name = "colMinValue";
            // 
            // colMaxValue
            // 
            this.colMaxValue.HeaderText = "최댓값";
            this.colMaxValue.Name = "colMaxValue";
            // 
            // colAverage
            // 
            this.colAverage.HeaderText = "평균";
            this.colAverage.Name = "colAverage";
            // 
            // commonPanel3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.commonPanel3, 2);
            this.commonPanel3.Controls.Add(this.flowLayoutPanel3);
            this.commonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commonPanel3.Location = new System.Drawing.Point(1, 235);
            this.commonPanel3.Margin = new System.Windows.Forms.Padding(1);
            this.commonPanel3.Name = "commonPanel3";
            this.commonPanel3.Size = new System.Drawing.Size(1098, 155);
            this.commonPanel3.TabIndex = 1;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.subtitleLabel3);
            this.flowLayoutPanel3.Controls.Add(this.lboxRealTimeLog);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(1098, 155);
            this.flowLayoutPanel3.TabIndex = 1;
            // 
            // subtitleLabel3
            // 
            this.subtitleLabel3.Location = new System.Drawing.Point(4, 4);
            this.subtitleLabel3.Margin = new System.Windows.Forms.Padding(4);
            this.subtitleLabel3.Name = "subtitleLabel3";
            this.subtitleLabel3.Size = new System.Drawing.Size(974, 21);
            this.subtitleLabel3.TabIndex = 0;
            this.subtitleLabel3.Text = "Real Time Log";
            // 
            // lboxRealTimeLog
            // 
            this.lboxRealTimeLog.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lboxRealTimeLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lboxRealTimeLog.FormattingEnabled = true;
            this.lboxRealTimeLog.HorizontalScrollbar = true;
            this.lboxRealTimeLog.ItemHeight = 12;
            this.lboxRealTimeLog.Location = new System.Drawing.Point(3, 32);
            this.lboxRealTimeLog.Name = "lboxRealTimeLog";
            this.lboxRealTimeLog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lboxRealTimeLog.Size = new System.Drawing.Size(1085, 120);
            this.lboxRealTimeLog.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 391);
            this.panel1.TabIndex = 5;
            // 
            // uscRealTimeProcessView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "uscRealTimeProcessView";
            this.Size = new System.Drawing.Size(1100, 391);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.commonPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.commonPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistics)).EndInit();
            this.commonPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView lviewWorstList;
        private System.Windows.Forms.ColumnHeader chNumber;
        private System.Windows.Forms.ColumnHeader chWorstValue;
        private System.Windows.Forms.ColumnHeader chTime;
        private System.Windows.Forms.ListBox lboxRealTimeLog;
        private CommonDataGrid dgvStatistics;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCounter;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaxValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAverage;
        private System.Windows.Forms.Label lblPid;
        private System.Windows.Forms.Label label2;
        private CommonPanel commonPanel1;
        private SubtitleLabel subtitleLabel1;
        private CommonPanel commonPanel2;
        private SubtitleLabel subtitleLabel2;
        private CommonPanel commonPanel3;
        private SubtitleLabel subtitleLabel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
    }
}
