
using MonitorigProcess.UserControls.resources;

namespace MonitoringProcess.Forms
{
    partial class FavoriteForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.commonPanel1 = new MonitorigProcess.UserControls.resources.CommonPanel();
            this.contentHeaderLabel3 = new MonitorigProcess.UserControls.resources.ContentHeaderLabel();
            this.contentHeaderLabel2 = new MonitorigProcess.UserControls.resources.ContentHeaderLabel();
            this.ButtonDeleteProcess = new MonitorigProcess.UserControls.resources.NormalButton();
            this.buttonFavoriteManager = new MonitorigProcess.UserControls.resources.NormalButton();
            this.listViewFavoriteProcess = new System.Windows.Forms.ListView();
            this.ColumnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnPid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.normalButton1 = new MonitorigProcess.UserControls.resources.NormalButton();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.contentHeaderLabel1 = new MonitorigProcess.UserControls.resources.ContentHeaderLabel();
            this.buttonRefresh = new MonitorigProcess.UserControls.resources.NormalButton();
            this.coloredButton1 = new MonitorigProcess.UserControls.resources.ColoredButton();
            this.ListViewAllProcess = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ButtonClose = new MonitorigProcess.UserControls.resources.NormalButton();
            this.subtitleLabel1 = new MonitorigProcess.UserControls.resources.SubtitleLabel();
            this.commonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // commonPanel1
            // 
            this.commonPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commonPanel1.Controls.Add(this.contentHeaderLabel3);
            this.commonPanel1.Controls.Add(this.contentHeaderLabel2);
            this.commonPanel1.Controls.Add(this.ButtonDeleteProcess);
            this.commonPanel1.Controls.Add(this.buttonFavoriteManager);
            this.commonPanel1.Controls.Add(this.listViewFavoriteProcess);
            this.commonPanel1.Controls.Add(this.normalButton1);
            this.commonPanel1.Controls.Add(this.textBoxSearch);
            this.commonPanel1.Controls.Add(this.contentHeaderLabel1);
            this.commonPanel1.Controls.Add(this.buttonRefresh);
            this.commonPanel1.Controls.Add(this.coloredButton1);
            this.commonPanel1.Controls.Add(this.ListViewAllProcess);
            this.commonPanel1.Controls.Add(this.ButtonClose);
            this.commonPanel1.Location = new System.Drawing.Point(-1, 39);
            this.commonPanel1.Name = "commonPanel1";
            this.commonPanel1.Size = new System.Drawing.Size(600, 407);
            this.commonPanel1.TabIndex = 0;
            // 
            // contentHeaderLabel3
            // 
            this.contentHeaderLabel3.AutoSize = true;
            this.contentHeaderLabel3.Location = new System.Drawing.Point(332, 33);
            this.contentHeaderLabel3.Name = "contentHeaderLabel3";
            this.contentHeaderLabel3.Size = new System.Drawing.Size(83, 15);
            this.contentHeaderLabel3.TabIndex = 12;
            this.contentHeaderLabel3.Text = "프로세스 담기";
            // 
            // contentHeaderLabel2
            // 
            this.contentHeaderLabel2.AutoSize = true;
            this.contentHeaderLabel2.Location = new System.Drawing.Point(15, 12);
            this.contentHeaderLabel2.Name = "contentHeaderLabel2";
            this.contentHeaderLabel2.Size = new System.Drawing.Size(55, 15);
            this.contentHeaderLabel2.TabIndex = 11;
            this.contentHeaderLabel2.Text = "즐겨찾기";
            // 
            // ButtonDeleteProcess
            // 
            this.ButtonDeleteProcess.FlatAppearance.BorderSize = 0;
            this.ButtonDeleteProcess.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.ButtonDeleteProcess.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ButtonDeleteProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonDeleteProcess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.ButtonDeleteProcess.Location = new System.Drawing.Point(277, 221);
            this.ButtonDeleteProcess.Name = "ButtonDeleteProcess";
            this.ButtonDeleteProcess.Size = new System.Drawing.Size(50, 30);
            this.ButtonDeleteProcess.TabIndex = 10;
            this.ButtonDeleteProcess.Text = "◀";
            this.ButtonDeleteProcess.UseVisualStyleBackColor = true;
            // 
            // buttonFavoriteManager
            // 
            this.buttonFavoriteManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonFavoriteManager.FlatAppearance.BorderSize = 0;
            this.buttonFavoriteManager.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.buttonFavoriteManager.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonFavoriteManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFavoriteManager.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.buttonFavoriteManager.Location = new System.Drawing.Point(17, 366);
            this.buttonFavoriteManager.Name = "buttonFavoriteManager";
            this.buttonFavoriteManager.Size = new System.Drawing.Size(111, 30);
            this.buttonFavoriteManager.TabIndex = 9;
            this.buttonFavoriteManager.Text = "즐겨찾기 관리..";
            this.buttonFavoriteManager.UseVisualStyleBackColor = true;
            this.buttonFavoriteManager.Click += new System.EventHandler(this.buttonFavoriteManager_Click);
            // 
            // listViewFavoriteProcess
            // 
            this.listViewFavoriteProcess.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnName,
            this.ColumnPid});
            this.listViewFavoriteProcess.HideSelection = false;
            this.listViewFavoriteProcess.Location = new System.Drawing.Point(19, 58);
            this.listViewFavoriteProcess.Name = "listViewFavoriteProcess";
            this.listViewFavoriteProcess.Size = new System.Drawing.Size(252, 299);
            this.listViewFavoriteProcess.TabIndex = 8;
            this.listViewFavoriteProcess.UseCompatibleStateImageBehavior = false;
            this.listViewFavoriteProcess.View = System.Windows.Forms.View.Details;
            // 
            // ColumnName
            // 
            this.ColumnName.Text = "Name";
            this.ColumnName.Width = 134;
            // 
            // ColumnPid
            // 
            this.ColumnPid.Text = "PID";
            this.ColumnPid.Width = 77;
            // 
            // normalButton1
            // 
            this.normalButton1.FlatAppearance.BorderSize = 0;
            this.normalButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.normalButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.normalButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.normalButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.normalButton1.Location = new System.Drawing.Point(277, 185);
            this.normalButton1.Name = "normalButton1";
            this.normalButton1.Size = new System.Drawing.Size(50, 30);
            this.normalButton1.TabIndex = 7;
            this.normalButton1.Text = "▶";
            this.normalButton1.UseVisualStyleBackColor = true;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(68, 31);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(137, 21);
            this.textBoxSearch.TabIndex = 6;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // contentHeaderLabel1
            // 
            this.contentHeaderLabel1.AutoSize = true;
            this.contentHeaderLabel1.Location = new System.Drawing.Point(16, 33);
            this.contentHeaderLabel1.Name = "contentHeaderLabel1";
            this.contentHeaderLabel1.Size = new System.Drawing.Size(46, 15);
            this.contentHeaderLabel1.TabIndex = 5;
            this.contentHeaderLabel1.Text = "Search";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.FlatAppearance.BorderSize = 0;
            this.buttonRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.buttonRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.buttonRefresh.Location = new System.Drawing.Point(211, 28);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(60, 24);
            this.buttonRefresh.TabIndex = 4;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // coloredButton1
            // 
            this.coloredButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.coloredButton1.FlatAppearance.BorderSize = 0;
            this.coloredButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.coloredButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.coloredButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.coloredButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.coloredButton1.Location = new System.Drawing.Point(386, 366);
            this.coloredButton1.Name = "coloredButton1";
            this.coloredButton1.Size = new System.Drawing.Size(100, 30);
            this.coloredButton1.TabIndex = 2;
            this.coloredButton1.Text = "저장(&S)";
            this.coloredButton1.UseVisualStyleBackColor = true;
            // 
            // ListViewAllProcess
            // 
            this.ListViewAllProcess.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2});
            this.ListViewAllProcess.HideSelection = false;
            this.ListViewAllProcess.Location = new System.Drawing.Point(335, 58);
            this.ListViewAllProcess.Name = "ListViewAllProcess";
            this.ListViewAllProcess.Size = new System.Drawing.Size(252, 299);
            this.ListViewAllProcess.TabIndex = 1;
            this.ListViewAllProcess.UseCompatibleStateImageBehavior = false;
            this.ListViewAllProcess.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No";
            this.columnHeader1.Width = 35;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 133;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "PID";
            this.columnHeader2.Width = 78;
            // 
            // ButtonClose
            // 
            this.ButtonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonClose.FlatAppearance.BorderSize = 0;
            this.ButtonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.ButtonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.ButtonClose.Location = new System.Drawing.Point(492, 366);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(100, 30);
            this.ButtonClose.TabIndex = 0;
            this.ButtonClose.Text = "닫기";
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // subtitleLabel1
            // 
            this.subtitleLabel1.AutoSize = true;
            this.subtitleLabel1.Location = new System.Drawing.Point(12, 9);
            this.subtitleLabel1.Name = "subtitleLabel1";
            this.subtitleLabel1.Size = new System.Drawing.Size(134, 21);
            this.subtitleLabel1.TabIndex = 2;
            this.subtitleLabel1.Text = "Favorite Process";
            // 
            // FavoriteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 445);
            this.Controls.Add(this.subtitleLabel1);
            this.Controls.Add(this.commonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FavoriteForm";
            this.Text = "Favorite";
            this.Load += new System.EventHandler(this.FavoriteForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FavoriteForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FavoriteForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FavoriteForm_MouseUp);
            this.commonPanel1.ResumeLayout(false);
            this.commonPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MonitorigProcess.UserControls.resources.CommonPanel commonPanel1;
        private MonitorigProcess.UserControls.resources.NormalButton ButtonClose;
        private System.Windows.Forms.ListView ListViewAllProcess;
        private System.Windows.Forms.ListView listViewFavoriteProcess;
        private MonitorigProcess.UserControls.resources.NormalButton normalButton1;
        private System.Windows.Forms.TextBox textBoxSearch;
        private MonitorigProcess.UserControls.resources.ContentHeaderLabel contentHeaderLabel1;
        private MonitorigProcess.UserControls.resources.NormalButton buttonRefresh;
        private MonitorigProcess.UserControls.resources.ColoredButton coloredButton1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private MonitorigProcess.UserControls.resources.NormalButton ButtonDeleteProcess;
        private MonitorigProcess.UserControls.resources.NormalButton buttonFavoriteManager;
        private System.Windows.Forms.ColumnHeader ColumnName;
        private System.Windows.Forms.ColumnHeader ColumnPid;
        private SubtitleLabel subtitleLabel1;
        private ContentHeaderLabel contentHeaderLabel3;
        private ContentHeaderLabel contentHeaderLabel2;
    }
}