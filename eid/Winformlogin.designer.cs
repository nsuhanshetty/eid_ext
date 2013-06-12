namespace eid
{
    partial class Winformlogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Winformlogin));
            this.pcbkey = new System.Windows.Forms.PictureBox();
            this.LBLCAPSLCK = new System.Windows.Forms.Label();
            this.txtpasswd = new System.Windows.Forms.TextBox();
            this.txtusernm = new System.Windows.Forms.TextBox();
            this.lblusernm = new System.Windows.Forms.Label();
            this.lblpasswd = new System.Windows.Forms.Label();
            this.btncncl = new System.Windows.Forms.Button();
            this.btnsubmit = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolstrplbl = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pcbkey)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pcbkey
            // 
            this.pcbkey.BackColor = System.Drawing.Color.Transparent;
            this.pcbkey.Image = ((System.Drawing.Image)(resources.GetObject("pcbkey.Image")));
            this.pcbkey.Location = new System.Drawing.Point(460, 56);
            this.pcbkey.Name = "pcbkey";
            this.pcbkey.Size = new System.Drawing.Size(66, 65);
            this.pcbkey.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbkey.TabIndex = 51;
            this.pcbkey.TabStop = false;
            // 
            // LBLCAPSLCK
            // 
            this.LBLCAPSLCK.AutoSize = true;
            this.LBLCAPSLCK.BackColor = System.Drawing.Color.ForestGreen;
            this.LBLCAPSLCK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLCAPSLCK.ForeColor = System.Drawing.Color.White;
            this.LBLCAPSLCK.Location = new System.Drawing.Point(122, 37);
            this.LBLCAPSLCK.Name = "LBLCAPSLCK";
            this.LBLCAPSLCK.Size = new System.Drawing.Size(98, 13);
            this.LBLCAPSLCK.TabIndex = 49;
            this.LBLCAPSLCK.Text = "CAPS LOCK IS ON";
            this.LBLCAPSLCK.Visible = false;
            // 
            // txtpasswd
            // 
            this.txtpasswd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpasswd.Location = new System.Drawing.Point(121, 91);
            this.txtpasswd.Name = "txtpasswd";
            this.txtpasswd.PasswordChar = '*';
            this.txtpasswd.Size = new System.Drawing.Size(333, 30);
            this.txtpasswd.TabIndex = 43;
            // 
            // txtusernm
            // 
            this.txtusernm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusernm.Location = new System.Drawing.Point(121, 56);
            this.txtusernm.Name = "txtusernm";
            this.txtusernm.Size = new System.Drawing.Size(333, 30);
            this.txtusernm.TabIndex = 42;
            // 
            // lblusernm
            // 
            this.lblusernm.AutoSize = true;
            this.lblusernm.BackColor = System.Drawing.Color.Transparent;
            this.lblusernm.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusernm.ForeColor = System.Drawing.Color.Purple;
            this.lblusernm.Location = new System.Drawing.Point(11, 58);
            this.lblusernm.Name = "lblusernm";
            this.lblusernm.Size = new System.Drawing.Size(97, 21);
            this.lblusernm.TabIndex = 47;
            this.lblusernm.Text = "USERNAME";
            // 
            // lblpasswd
            // 
            this.lblpasswd.AutoSize = true;
            this.lblpasswd.BackColor = System.Drawing.Color.Transparent;
            this.lblpasswd.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpasswd.ForeColor = System.Drawing.Color.Purple;
            this.lblpasswd.Location = new System.Drawing.Point(11, 93);
            this.lblpasswd.Name = "lblpasswd";
            this.lblpasswd.Size = new System.Drawing.Size(99, 21);
            this.lblpasswd.TabIndex = 48;
            this.lblpasswd.Text = "PASSWORD";
            // 
            // btncncl
            // 
            this.btncncl.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btncncl.Location = new System.Drawing.Point(305, 126);
            this.btncncl.Name = "btncncl";
            this.btncncl.Size = new System.Drawing.Size(149, 43);
            this.btncncl.TabIndex = 45;
            this.btncncl.Text = "Cancel";
            this.btncncl.UseVisualStyleBackColor = true;
            this.btncncl.Click += new System.EventHandler(this.btncncl_Click);
            // 
            // btnsubmit
            // 
            this.btnsubmit.Location = new System.Drawing.Point(121, 127);
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.Size = new System.Drawing.Size(156, 42);
            this.btnsubmit.TabIndex = 44;
            this.btnsubmit.Text = "Submit ";
            this.btnsubmit.UseVisualStyleBackColor = true;
            this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstrplbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 176);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(533, 22);
            this.statusStrip1.TabIndex = 52;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolstrplbl
            // 
            this.toolstrplbl.Name = "toolstrplbl";
            this.toolstrplbl.Size = new System.Drawing.Size(104, 17);
            this.toolstrplbl.Text = "Waiting for User....";
            // 
            // Winformlogin
            // 
            this.AcceptButton = this.btnsubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btncncl;
            this.ClientSize = new System.Drawing.Size(533, 198);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pcbkey);
            this.Controls.Add(this.LBLCAPSLCK);
            this.Controls.Add(this.txtpasswd);
            this.Controls.Add(this.txtusernm);
            this.Controls.Add(this.lblusernm);
            this.Controls.Add(this.lblpasswd);
            this.Controls.Add(this.btncncl);
            this.Controls.Add(this.btnsubmit);
            this.Name = "Winformlogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EMPLOYEE IDENTIFICATION SYSTEM";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pcbkey)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox pcbkey;
        internal System.Windows.Forms.Label LBLCAPSLCK;
        internal System.Windows.Forms.TextBox txtpasswd;
        internal System.Windows.Forms.TextBox txtusernm;
        internal System.Windows.Forms.Label lblusernm;
        internal System.Windows.Forms.Label lblpasswd;
        internal System.Windows.Forms.Button btncncl;
        internal System.Windows.Forms.Button btnsubmit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolstrplbl;
    }
}