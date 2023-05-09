
namespace MonitoringProcess.Forms
{
    partial class FavoriteManagerForm
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
            this.buttonSave = new MonitorigProcess.UserControls.resources.ColoredButton();
            this.buttonClose = new MonitorigProcess.UserControls.resources.NormalButton();
            this.buttonRemove = new MonitorigProcess.UserControls.resources.NormalButton();
            this.buttonAdd = new MonitorigProcess.UserControls.resources.NormalButton();
            this.contentHeaderLabel2 = new MonitorigProcess.UserControls.resources.ContentHeaderLabel();
            this.listViewMyFavorite = new System.Windows.Forms.ListView();
            this.contentHeaderLabel1 = new MonitorigProcess.UserControls.resources.ContentHeaderLabel();
            this.listViewAllProcess = new System.Windows.Forms.ListView();
            this.subtitleLabel1 = new MonitorigProcess.UserControls.resources.SubtitleLabel();
            this.commonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // commonPanel1
            // 
            this.commonPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commonPanel1.Controls.Add(this.buttonSave);
            this.commonPanel1.Controls.Add(this.buttonClose);
            this.commonPanel1.Controls.Add(this.buttonRemove);
            this.commonPanel1.Controls.Add(this.buttonAdd);
            this.commonPanel1.Controls.Add(this.contentHeaderLabel2);
            this.commonPanel1.Controls.Add(this.listViewMyFavorite);
            this.commonPanel1.Controls.Add(this.contentHeaderLabel1);
            this.commonPanel1.Controls.Add(this.listViewAllProcess);
            this.commonPanel1.Location = new System.Drawing.Point(-1, 45);
            this.commonPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.commonPanel1.Name = "commonPanel1";
            this.commonPanel1.Size = new System.Drawing.Size(442, 367);
            this.commonPanel1.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.buttonSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonSave.Location = new System.Drawing.Point(255, 325);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(80, 30);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "저장(&S)";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.buttonClose.Location = new System.Drawing.Point(341, 325);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(80, 30);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "닫기(&C)";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.FlatAppearance.BorderSize = 0;
            this.buttonRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.buttonRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.buttonRemove.Location = new System.Drawing.Point(195, 194);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(50, 30);
            this.buttonRemove.TabIndex = 5;
            this.buttonRemove.Text = "◀";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.buttonAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.buttonAdd.Location = new System.Drawing.Point(195, 161);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(50, 30);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "▶";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // contentHeaderLabel2
            // 
            this.contentHeaderLabel2.AutoSize = true;
            this.contentHeaderLabel2.Location = new System.Drawing.Point(243, 16);
            this.contentHeaderLabel2.Name = "contentHeaderLabel2";
            this.contentHeaderLabel2.Size = new System.Drawing.Size(75, 15);
            this.contentHeaderLabel2.TabIndex = 3;
            this.contentHeaderLabel2.Text = "My Favorite";
            // 
            // listViewMyFavorite
            // 
            this.listViewMyFavorite.HideSelection = false;
            this.listViewMyFavorite.Location = new System.Drawing.Point(251, 39);
            this.listViewMyFavorite.Name = "listViewMyFavorite";
            this.listViewMyFavorite.Size = new System.Drawing.Size(170, 280);
            this.listViewMyFavorite.TabIndex = 2;
            this.listViewMyFavorite.UseCompatibleStateImageBehavior = false;
            this.listViewMyFavorite.View = System.Windows.Forms.View.SmallIcon;
            // 
            // contentHeaderLabel1
            // 
            this.contentHeaderLabel1.AutoSize = true;
            this.contentHeaderLabel1.Location = new System.Drawing.Point(11, 16);
            this.contentHeaderLabel1.Name = "contentHeaderLabel1";
            this.contentHeaderLabel1.Size = new System.Drawing.Size(69, 15);
            this.contentHeaderLabel1.TabIndex = 1;
            this.contentHeaderLabel1.Text = "All Process";
            // 
            // listViewAllProcess
            // 
            this.listViewAllProcess.HideSelection = false;
            this.listViewAllProcess.Location = new System.Drawing.Point(19, 39);
            this.listViewAllProcess.Name = "listViewAllProcess";
            this.listViewAllProcess.Size = new System.Drawing.Size(170, 280);
            this.listViewAllProcess.TabIndex = 0;
            this.listViewAllProcess.UseCompatibleStateImageBehavior = false;
            this.listViewAllProcess.View = System.Windows.Forms.View.SmallIcon;
            // 
            // subtitleLabel1
            // 
            this.subtitleLabel1.AutoSize = true;
            this.subtitleLabel1.Location = new System.Drawing.Point(14, 13);
            this.subtitleLabel1.Name = "subtitleLabel1";
            this.subtitleLabel1.Size = new System.Drawing.Size(274, 21);
            this.subtitleLabel1.TabIndex = 1;
            this.subtitleLabel1.Text = "Add and Remove Favorite Process";
            // 
            // FavoriteManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 410);
            this.Controls.Add(this.subtitleLabel1);
            this.Controls.Add(this.commonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FavoriteManagerForm";
            this.Text = "FavoriteManagerForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FavoriteManagerForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FavoriteManagerForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FavoriteManagerForm_MouseUp);
            this.commonPanel1.ResumeLayout(false);
            this.commonPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MonitorigProcess.UserControls.resources.CommonPanel commonPanel1;
        private MonitorigProcess.UserControls.resources.SubtitleLabel subtitleLabel1;
        private System.Windows.Forms.ListView listViewAllProcess;
        private MonitorigProcess.UserControls.resources.NormalButton buttonClose;
        private MonitorigProcess.UserControls.resources.NormalButton buttonRemove;
        private MonitorigProcess.UserControls.resources.NormalButton buttonAdd;
        private MonitorigProcess.UserControls.resources.ContentHeaderLabel contentHeaderLabel2;
        private System.Windows.Forms.ListView listViewMyFavorite;
        private MonitorigProcess.UserControls.resources.ContentHeaderLabel contentHeaderLabel1;
        private MonitorigProcess.UserControls.resources.ColoredButton buttonSave;
    }
}