namespace eid
{
    partial class WinformPdfViewer
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.grbMaritalStatus = new System.Windows.Forms.GroupBox();
            this.rdbBiodata = new System.Windows.Forms.RadioButton();
            this.rdbIdCard = new System.Windows.Forms.RadioButton();
            this.lblSelectOpt = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.grbMaritalStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.grbMaritalStatus);
            this.panel1.Controls.Add(this.lblSelectOpt);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(727, 43);
            this.panel1.TabIndex = 0;
            // 
            // grbMaritalStatus
            // 
            this.grbMaritalStatus.Controls.Add(this.rdbBiodata);
            this.grbMaritalStatus.Controls.Add(this.rdbIdCard);
            this.grbMaritalStatus.Location = new System.Drawing.Point(552, 8);
            this.grbMaritalStatus.Name = "grbMaritalStatus";
            this.grbMaritalStatus.Size = new System.Drawing.Size(165, 28);
            this.grbMaritalStatus.TabIndex = 85;
            this.grbMaritalStatus.TabStop = false;
            // 
            // rdbBiodata
            // 
            this.rdbBiodata.AutoSize = true;
            this.rdbBiodata.Location = new System.Drawing.Point(10, 9);
            this.rdbBiodata.Name = "rdbBiodata";
            this.rdbBiodata.Size = new System.Drawing.Size(66, 17);
            this.rdbBiodata.TabIndex = 6;
            this.rdbBiodata.Text = "Bio Data";
            this.rdbBiodata.UseVisualStyleBackColor = true;
            // 
            // rdbIdCard
            // 
            this.rdbIdCard.AutoSize = true;
            this.rdbIdCard.Location = new System.Drawing.Point(95, 9);
            this.rdbIdCard.Name = "rdbIdCard";
            this.rdbIdCard.Size = new System.Drawing.Size(61, 17);
            this.rdbIdCard.TabIndex = 7;
            this.rdbIdCard.Text = "ID Card";
            this.rdbIdCard.UseVisualStyleBackColor = true;
            // 
            // lblSelectOpt
            // 
            this.lblSelectOpt.AutoSize = true;
            this.lblSelectOpt.Location = new System.Drawing.Point(432, 19);
            this.lblSelectOpt.Name = "lblSelectOpt";
            this.lblSelectOpt.Size = new System.Drawing.Size(114, 13);
            this.lblSelectOpt.TabIndex = 84;
            this.lblSelectOpt.Text = "Select the Print Format";
            this.lblSelectOpt.Click += new System.EventHandler(this.lblMaritalStatus_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(0, 49);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(727, 391);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(552, 453);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Enabled = false;
            this.btnExit.Location = new System.Drawing.Point(633, 453);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // WinformPdfViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 488);
            this.ControlBox = false;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.panel1);
            this.Name = "WinformPdfViewer";
            this.Text = "PDF Viewer";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grbMaritalStatus.ResumeLayout(false);
            this.grbMaritalStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grbMaritalStatus;
        private System.Windows.Forms.RadioButton rdbBiodata;
        private System.Windows.Forms.RadioButton rdbIdCard;
        internal System.Windows.Forms.Label lblSelectOpt;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExit;


    }
}