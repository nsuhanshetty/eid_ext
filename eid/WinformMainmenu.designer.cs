namespace eid
{
    partial class WinformMainmenu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinformMainmenu));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.Mainmenustrip = new System.Windows.Forms.MenuStrip();
            this.Master = new System.Windows.Forms.ToolStripMenuItem();
            this.Staffdetails = new System.Windows.Forms.ToolStripMenuItem();
            this.Utilities = new System.Windows.Forms.ToolStripMenuItem();
            this.OfficeDetailsAccess = new System.Windows.Forms.ToolStripMenuItem();
            this.CalculatorAccess = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.UserMasterAccess = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangePasswordAccess = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.BackupDataAccess = new System.Windows.Forms.ToolStripMenuItem();
            this.HelptoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdatetoolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.AbouttoolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.Exitmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Loginbtn = new System.Windows.Forms.ToolStripButton();
            this.Mainmenustrip.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(200, 22);
            this.statusStrip.TabIndex = 0;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(23, 23);
            // 
            // Mainmenustrip
            // 
            this.Mainmenustrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Master,
            this.Utilities,
            this.HelptoolStripMenuItem1,
            this.Exitmenu});
            this.Mainmenustrip.Location = new System.Drawing.Point(0, 0);
            this.Mainmenustrip.Name = "Mainmenustrip";
            this.Mainmenustrip.Size = new System.Drawing.Size(817, 24);
            this.Mainmenustrip.TabIndex = 4;
            this.Mainmenustrip.Text = "MenuStrip1";
            // 
            // Master
            // 
            this.Master.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Staffdetails});
            this.Master.Enabled = false;
            this.Master.Name = "Master";
            this.Master.Size = new System.Drawing.Size(55, 20);
            this.Master.Text = "&Master";
            // 
            // Staffdetails
            // 
            this.Staffdetails.Image = ((System.Drawing.Image)(resources.GetObject("Staffdetails.Image")));
            this.Staffdetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Staffdetails.Name = "Staffdetails";
            this.Staffdetails.Size = new System.Drawing.Size(187, 38);
            this.Staffdetails.Text = "&Employee Registry";
            this.Staffdetails.Click += new System.EventHandler(this.Staffdetails_Click);
            // 
            // Utilities
            // 
            this.Utilities.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OfficeDetailsAccess,
            this.CalculatorAccess,
            this.toolStripSeparator9,
            this.UserMasterAccess,
            this.ChangePasswordAccess,
            this.toolStripSeparator10,
            this.BackupDataAccess});
            this.Utilities.Enabled = false;
            this.Utilities.Name = "Utilities";
            this.Utilities.Size = new System.Drawing.Size(58, 20);
            this.Utilities.Text = "&Utilities";
            // 
            // OfficeDetailsAccess
            // 
            this.OfficeDetailsAccess.Image = ((System.Drawing.Image)(resources.GetObject("OfficeDetailsAccess.Image")));
            this.OfficeDetailsAccess.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.OfficeDetailsAccess.Name = "OfficeDetailsAccess";
            this.OfficeDetailsAccess.Size = new System.Drawing.Size(188, 38);
            this.OfficeDetailsAccess.Text = "&Office Details";
            // 
            // CalculatorAccess
            // 
            this.CalculatorAccess.Image = ((System.Drawing.Image)(resources.GetObject("CalculatorAccess.Image")));
            this.CalculatorAccess.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CalculatorAccess.Name = "CalculatorAccess";
            this.CalculatorAccess.Size = new System.Drawing.Size(188, 38);
            this.CalculatorAccess.Text = "&Calculator";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(185, 6);
            // 
            // UserMasterAccess
            // 
            this.UserMasterAccess.Image = ((System.Drawing.Image)(resources.GetObject("UserMasterAccess.Image")));
            this.UserMasterAccess.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.UserMasterAccess.Name = "UserMasterAccess";
            this.UserMasterAccess.Size = new System.Drawing.Size(188, 38);
            this.UserMasterAccess.Text = "&User Master";
            this.UserMasterAccess.Click += new System.EventHandler(this.UserMasterAccess_Click);
            // 
            // ChangePasswordAccess
            // 
            this.ChangePasswordAccess.Image = ((System.Drawing.Image)(resources.GetObject("ChangePasswordAccess.Image")));
            this.ChangePasswordAccess.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ChangePasswordAccess.Name = "ChangePasswordAccess";
            this.ChangePasswordAccess.Size = new System.Drawing.Size(188, 38);
            this.ChangePasswordAccess.Text = "&Change Password";
            this.ChangePasswordAccess.Click += new System.EventHandler(this.ChangePasswordAccess_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(185, 6);
            // 
            // BackupDataAccess
            // 
            this.BackupDataAccess.Image = ((System.Drawing.Image)(resources.GetObject("BackupDataAccess.Image")));
            this.BackupDataAccess.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BackupDataAccess.Name = "BackupDataAccess";
            this.BackupDataAccess.Size = new System.Drawing.Size(188, 38);
            this.BackupDataAccess.Text = "&Backup Data";
            // 
            // HelptoolStripMenuItem1
            // 
            this.HelptoolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdatetoolStripMenuItem2,
            this.toolStripSeparator12,
            this.AbouttoolStripMenuItem3});
            this.HelptoolStripMenuItem1.Name = "HelptoolStripMenuItem1";
            this.HelptoolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.HelptoolStripMenuItem1.Text = "&Help";
            // 
            // UpdatetoolStripMenuItem2
            // 
            this.UpdatetoolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("UpdatetoolStripMenuItem2.Image")));
            this.UpdatetoolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.UpdatetoolStripMenuItem2.Name = "UpdatetoolStripMenuItem2";
            this.UpdatetoolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.UpdatetoolStripMenuItem2.Size = new System.Drawing.Size(174, 38);
            this.UpdatetoolStripMenuItem2.Text = "&Update";
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(171, 6);
            // 
            // AbouttoolStripMenuItem3
            // 
            this.AbouttoolStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("AbouttoolStripMenuItem3.Image")));
            this.AbouttoolStripMenuItem3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AbouttoolStripMenuItem3.Name = "AbouttoolStripMenuItem3";
            this.AbouttoolStripMenuItem3.Size = new System.Drawing.Size(174, 38);
            this.AbouttoolStripMenuItem3.Text = "&About...";
            this.AbouttoolStripMenuItem3.Click += new System.EventHandler(this.AboutustoolStripMenuItem3_Click);
            // 
            // Exitmenu
            // 
            this.Exitmenu.Name = "Exitmenu";
            this.Exitmenu.Size = new System.Drawing.Size(37, 20);
            this.Exitmenu.Text = "&Exit";
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Loginbtn});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 24);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(817, 42);
            this.ToolStrip1.TabIndex = 6;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // Loginbtn
            // 
            this.Loginbtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Loginbtn.Image = ((System.Drawing.Image)(resources.GetObject("Loginbtn.Image")));
            this.Loginbtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Loginbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Loginbtn.Name = "Loginbtn";
            this.Loginbtn.Size = new System.Drawing.Size(39, 39);
            this.Loginbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Loginbtn.ToolTipText = "UnLock";
            this.Loginbtn.Click += new System.EventHandler(this.Loginbtn_Click);
            // 
            // WinformMainmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 461);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.Mainmenustrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.Mainmenustrip;
            this.Name = "WinformMainmenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.WinformMainmenu_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.Mainmenustrip.ResumeLayout(false);
            this.Mainmenustrip.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        internal System.Windows.Forms.MenuStrip Mainmenustrip;
        internal System.Windows.Forms.ToolStripMenuItem Master;
        internal System.Windows.Forms.ToolStripMenuItem Staffdetails;
        internal System.Windows.Forms.ToolStripMenuItem Utilities;
        internal System.Windows.Forms.ToolStripMenuItem OfficeDetailsAccess;
        internal System.Windows.Forms.ToolStripMenuItem CalculatorAccess;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        internal System.Windows.Forms.ToolStripMenuItem UserMasterAccess;
        internal System.Windows.Forms.ToolStripMenuItem ChangePasswordAccess;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        internal System.Windows.Forms.ToolStripMenuItem BackupDataAccess;
        internal System.Windows.Forms.ToolStripMenuItem HelptoolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem UpdatetoolStripMenuItem2;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        internal System.Windows.Forms.ToolStripMenuItem AbouttoolStripMenuItem3;
        internal System.Windows.Forms.ToolStripMenuItem Exitmenu;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton Loginbtn;

    }
}



