namespace iMovie
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.grpAbout = new System.Windows.Forms.GroupBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblReport = new System.Windows.Forms.Label();
            this.lblDesignerName = new System.Windows.Forms.Label();
            this.lblDesigner = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.grpAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAbout
            // 
            this.grpAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAbout.Controls.Add(this.lblEmail);
            this.grpAbout.Controls.Add(this.lblReport);
            this.grpAbout.Controls.Add(this.lblDesignerName);
            this.grpAbout.Controls.Add(this.lblDesigner);
            this.grpAbout.Controls.Add(this.lblName);
            this.grpAbout.Location = new System.Drawing.Point(9, 5);
            this.grpAbout.Name = "grpAbout";
            this.grpAbout.Size = new System.Drawing.Size(331, 185);
            this.grpAbout.TabIndex = 0;
            this.grpAbout.TabStop = false;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(112, 153);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(111, 13);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "mononobi@gmail.com";
            // 
            // lblReport
            // 
            this.lblReport.AutoSize = true;
            this.lblReport.Location = new System.Drawing.Point(101, 125);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(131, 13);
            this.lblReport.TabIndex = 3;
            this.lblReport.Text = "Report Bugs and Ideas to:";
            // 
            // lblDesignerName
            // 
            this.lblDesignerName.AutoSize = true;
            this.lblDesignerName.Location = new System.Drawing.Point(145, 95);
            this.lblDesignerName.Name = "lblDesignerName";
            this.lblDesignerName.Size = new System.Drawing.Size(36, 13);
            this.lblDesignerName.TabIndex = 2;
            this.lblDesignerName.Text = "MoNo";
            // 
            // lblDesigner
            // 
            this.lblDesigner.AutoSize = true;
            this.lblDesigner.Location = new System.Drawing.Point(93, 69);
            this.lblDesigner.Name = "lblDesigner";
            this.lblDesigner.Size = new System.Drawing.Size(145, 13);
            this.lblDesigner.TabIndex = 1;
            this.lblDesigner.Text = "Designed and Developed by:";
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Adorable", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(14, 14);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(301, 34);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "iMovie";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 199);
            this.Controls.Add(this.grpAbout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            this.grpAbout.ResumeLayout(false);
            this.grpAbout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAbout;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDesignerName;
        private System.Windows.Forms.Label lblDesigner;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblReport;
    }
}