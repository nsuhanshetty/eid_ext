namespace eid
{
    partial class WinformUsermaster
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
            this.pnlUsrView = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.GrbxSrch = new System.Windows.Forms.GroupBox();
            this.txtSrchUserName = new System.Windows.Forms.TextBox();
            this.lblSrchUserName = new System.Windows.Forms.Label();
            this.pnlUsrNew = new System.Windows.Forms.Panel();
            this.lblFunction = new System.Windows.Forms.Label();
            this.GrbxNewUser = new System.Windows.Forms.GroupBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtConPass = new System.Windows.Forms.TextBox();
            this.lblConPass = new System.Windows.Forms.Label();
            this.txtUsrname = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.chklstbx = new System.Windows.Forms.CheckedListBox();
            this.pnlUsrView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.GrbxSrch.SuspendLayout();
            this.pnlUsrNew.SuspendLayout();
            this.GrbxNewUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlUsrView
            // 
            this.pnlUsrView.Controls.Add(this.lblMessage);
            this.pnlUsrView.Controls.Add(this.dgvView);
            this.pnlUsrView.Controls.Add(this.GrbxSrch);
            this.pnlUsrView.Location = new System.Drawing.Point(330, 81);
            this.pnlUsrView.Name = "pnlUsrView";
            this.pnlUsrView.Size = new System.Drawing.Size(308, 379);
            this.pnlUsrView.TabIndex = 10;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(9, 62);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 13;
            // 
            // dgvView
            // 
            this.dgvView.AllowUserToAddRows = false;
            this.dgvView.AllowUserToDeleteRows = false;
            this.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvView.Location = new System.Drawing.Point(4, 84);
            this.dgvView.Name = "dgvView";
            this.dgvView.ReadOnly = true;
            this.dgvView.Size = new System.Drawing.Size(301, 292);
            this.dgvView.TabIndex = 12;
            this.dgvView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvView_CellContentClick);
            // 
            // GrbxSrch
            // 
            this.GrbxSrch.Controls.Add(this.txtSrchUserName);
            this.GrbxSrch.Controls.Add(this.lblSrchUserName);
            this.GrbxSrch.Location = new System.Drawing.Point(3, 6);
            this.GrbxSrch.Name = "GrbxSrch";
            this.GrbxSrch.Size = new System.Drawing.Size(302, 49);
            this.GrbxSrch.TabIndex = 11;
            this.GrbxSrch.TabStop = false;
            this.GrbxSrch.Text = "Search";
            // 
            // txtSrchUserName
            // 
            this.txtSrchUserName.Location = new System.Drawing.Point(80, 18);
            this.txtSrchUserName.Name = "txtSrchUserName";
            this.txtSrchUserName.Size = new System.Drawing.Size(156, 20);
            this.txtSrchUserName.TabIndex = 0;
            this.txtSrchUserName.TextChanged += new System.EventHandler(this.txtlSrchUserName_TextChanged);
            // 
            // lblSrchUserName
            // 
            this.lblSrchUserName.AutoSize = true;
            this.lblSrchUserName.Location = new System.Drawing.Point(6, 21);
            this.lblSrchUserName.Name = "lblSrchUserName";
            this.lblSrchUserName.Size = new System.Drawing.Size(55, 13);
            this.lblSrchUserName.TabIndex = 16;
            this.lblSrchUserName.Text = "Username";
            // 
            // pnlUsrNew
            // 
            this.pnlUsrNew.Controls.Add(this.lblFunction);
            this.pnlUsrNew.Controls.Add(this.GrbxNewUser);
            this.pnlUsrNew.Controls.Add(this.chklstbx);
            this.pnlUsrNew.Location = new System.Drawing.Point(12, 81);
            this.pnlUsrNew.Name = "pnlUsrNew";
            this.pnlUsrNew.Size = new System.Drawing.Size(312, 379);
            this.pnlUsrNew.TabIndex = 11;
            // 
            // lblFunction
            // 
            this.lblFunction.AutoSize = true;
            this.lblFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFunction.Location = new System.Drawing.Point(3, 120);
            this.lblFunction.Name = "lblFunction";
            this.lblFunction.Size = new System.Drawing.Size(285, 13);
            this.lblFunction.TabIndex = 12;
            this.lblFunction.Text = "Select checkbox to assign respective  privilege to the user.";
            // 
            // GrbxNewUser
            // 
            this.GrbxNewUser.Controls.Add(this.txtPass);
            this.GrbxNewUser.Controls.Add(this.lblPass);
            this.GrbxNewUser.Controls.Add(this.txtConPass);
            this.GrbxNewUser.Controls.Add(this.lblConPass);
            this.GrbxNewUser.Controls.Add(this.txtUsrname);
            this.GrbxNewUser.Controls.Add(this.lblUsername);
            this.GrbxNewUser.Location = new System.Drawing.Point(3, 6);
            this.GrbxNewUser.Name = "GrbxNewUser";
            this.GrbxNewUser.Size = new System.Drawing.Size(296, 104);
            this.GrbxNewUser.TabIndex = 11;
            this.GrbxNewUser.TabStop = false;
            this.GrbxNewUser.Text = "New User";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(118, 49);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(156, 20);
            this.txtPass.TabIndex = 1;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(44, 52);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(53, 13);
            this.lblPass.TabIndex = 13;
            this.lblPass.Text = "Password";
            // 
            // txtConPass
            // 
            this.txtConPass.Location = new System.Drawing.Point(118, 75);
            this.txtConPass.Name = "txtConPass";
            this.txtConPass.PasswordChar = '*';
            this.txtConPass.Size = new System.Drawing.Size(156, 20);
            this.txtConPass.TabIndex = 2;
            // 
            // lblConPass
            // 
            this.lblConPass.AutoSize = true;
            this.lblConPass.Location = new System.Drawing.Point(6, 78);
            this.lblConPass.Name = "lblConPass";
            this.lblConPass.Size = new System.Drawing.Size(91, 13);
            this.lblConPass.TabIndex = 11;
            this.lblConPass.Text = "Confirm Password";
            // 
            // txtUsrname
            // 
            this.txtUsrname.Location = new System.Drawing.Point(118, 23);
            this.txtUsrname.Name = "txtUsrname";
            this.txtUsrname.Size = new System.Drawing.Size(156, 20);
            this.txtUsrname.TabIndex = 0;
            this.txtUsrname.TextChanged += new System.EventHandler(this.txtUsrname_TextChanged);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(44, 26);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 9;
            this.lblUsername.Text = "Username";
            // 
            // chklstbx
            // 
            this.chklstbx.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chklstbx.FormattingEnabled = true;
            this.chklstbx.Location = new System.Drawing.Point(3, 139);
            this.chklstbx.Name = "chklstbx";
            this.chklstbx.Size = new System.Drawing.Size(296, 228);
            this.chklstbx.TabIndex = 3;
            this.chklstbx.Leave += new System.EventHandler(this.chklstbx_leave);
            // 
            // WinformUsermaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 485);
            this.Controls.Add(this.pnlUsrNew);
            this.Controls.Add(this.pnlUsrView);
            this.Name = "WinformUsermaster";
            this.Text = "User Master";
            this.Load += new System.EventHandler(this.WinformUsermaster_Load);
            this.Controls.SetChildIndex(this.pnlUsrView, 0);
            this.Controls.SetChildIndex(this.pnlUsrNew, 0);
            this.pnlUsrView.ResumeLayout(false);
            this.pnlUsrView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.GrbxSrch.ResumeLayout(false);
            this.GrbxSrch.PerformLayout();
            this.pnlUsrNew.ResumeLayout(false);
            this.pnlUsrNew.PerformLayout();
            this.GrbxNewUser.ResumeLayout(false);
            this.GrbxNewUser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlUsrView;
        private System.Windows.Forms.GroupBox GrbxSrch;
        private System.Windows.Forms.TextBox txtSrchUserName;
        private System.Windows.Forms.Label lblSrchUserName;
        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.Panel pnlUsrNew;
        private System.Windows.Forms.GroupBox GrbxNewUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtConPass;
        private System.Windows.Forms.Label lblConPass;
        private System.Windows.Forms.TextBox txtUsrname;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.CheckedListBox chklstbx;
        private System.Windows.Forms.Label lblFunction;
        private System.Windows.Forms.Label lblMessage;
    }
}