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
            this.grbPrintOpt = new System.Windows.Forms.GroupBox();
            this.rdbBiodata = new System.Windows.Forms.RadioButton();
            this.rdbIdCard = new System.Windows.Forms.RadioButton();
            this.lblSelectOpt = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.rptView = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1.SuspendLayout();
            this.grbPrintOpt.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.grbPrintOpt);
            this.panel1.Controls.Add(this.lblSelectOpt);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(815, 43);
            this.panel1.TabIndex = 0;
            // 
            // grbPrintOpt
            // 
            this.grbPrintOpt.Controls.Add(this.rdbBiodata);
            this.grbPrintOpt.Controls.Add(this.rdbIdCard);
            this.grbPrintOpt.Location = new System.Drawing.Point(632, 8);
            this.grbPrintOpt.Name = "grbPrintOpt";
            this.grbPrintOpt.Size = new System.Drawing.Size(166, 28);
            this.grbPrintOpt.TabIndex = 85;
            this.grbPrintOpt.TabStop = false;
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
            this.rdbBiodata.CheckedChanged += new System.EventHandler(this.grbPrintOpt_Enter);
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
            this.rdbIdCard.CheckedChanged += new System.EventHandler(this.grbPrintOpt_Enter);
            // 
            // lblSelectOpt
            // 
            this.lblSelectOpt.AutoSize = true;
            this.lblSelectOpt.Location = new System.Drawing.Point(512, 19);
            this.lblSelectOpt.Name = "lblSelectOpt";
            this.lblSelectOpt.Size = new System.Drawing.Size(114, 13);
            this.lblSelectOpt.TabIndex = 84;
            this.lblSelectOpt.Text = "Select the Print Format";
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(647, 488);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(728, 488);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // rptView
            // 
            this.rptView.Location = new System.Drawing.Point(3, 49);
            this.rptView.Name = "rptView";
            this.rptView.Size = new System.Drawing.Size(812, 433);
            this.rptView.TabIndex = 4;
            // 
            // WinformPdfViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 523);
            this.ControlBox = false;
            this.Controls.Add(this.rptView);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.panel1);
            this.Name = "WinformPdfViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDF Viewer";
            this.Load += new System.EventHandler(this.WinformPdfViewer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grbPrintOpt.ResumeLayout(false);
            this.grbPrintOpt.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grbPrintOpt;
        private System.Windows.Forms.RadioButton rdbBiodata;
        private System.Windows.Forms.RadioButton rdbIdCard;
        internal System.Windows.Forms.Label lblSelectOpt;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExit;
        private Microsoft.Reporting.WinForms.ReportViewer rptView;


    }
}