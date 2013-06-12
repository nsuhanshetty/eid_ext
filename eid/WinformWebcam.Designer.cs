namespace eid
{
    partial class WinformWebcam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinformWebcam));
            this.cmbCameraSelect = new System.Windows.Forms.ComboBox();
            this.picCapture = new System.Windows.Forms.PictureBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.lblCameraSelect = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCameraSelect
            // 
            this.cmbCameraSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCameraSelect.FormattingEnabled = true;
            this.cmbCameraSelect.Location = new System.Drawing.Point(129, 369);
            this.cmbCameraSelect.Name = "cmbCameraSelect";
            this.cmbCameraSelect.Size = new System.Drawing.Size(211, 21);
            this.cmbCameraSelect.TabIndex = 7;
            // 
            // picCapture
            // 
            this.picCapture.BackColor = System.Drawing.SystemColors.ControlDark;
            this.picCapture.Location = new System.Drawing.Point(1, 1);
            this.picCapture.Name = "picCapture";
            this.picCapture.Size = new System.Drawing.Size(350, 350);
            this.picCapture.TabIndex = 6;
            this.picCapture.TabStop = false;
            // 
            // btnCapture
            // 
            this.btnCapture.BackColor = System.Drawing.Color.Transparent;
            this.btnCapture.Image = ((System.Drawing.Image)(resources.GetObject("btnCapture.Image")));
            this.btnCapture.Location = new System.Drawing.Point(236, 297);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(104, 40);
            this.btnCapture.TabIndex = 8;
            this.btnCapture.Text = "  CAPTURE";
            this.btnCapture.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCapture.UseVisualStyleBackColor = false;
            this.btnCapture.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblCameraSelect
            // 
            this.lblCameraSelect.AutoSize = true;
            this.lblCameraSelect.Location = new System.Drawing.Point(47, 372);
            this.lblCameraSelect.Name = "lblCameraSelect";
            this.lblCameraSelect.Size = new System.Drawing.Size(76, 13);
            this.lblCameraSelect.TabIndex = 9;
            this.lblCameraSelect.Text = "Select Camera";
            // 
            // WinformWebcam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 407);
            this.Controls.Add(this.lblCameraSelect);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.cmbCameraSelect);
            this.Controls.Add(this.picCapture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "WinformWebcam";
            this.Text = "Capture Image";
            this.Load += new System.EventHandler(this.WinformWebcam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox cmbCameraSelect;
        internal System.Windows.Forms.PictureBox picCapture;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Label lblCameraSelect;
        private System.Windows.Forms.Timer timer1;
    }
}