namespace iMovie
{
    partial class frmReportConsole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportConsole));
            this.btnView = new System.Windows.Forms.Button();
            this.txtSQL = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Location = new System.Drawing.Point(472, 419);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(97, 30);
            this.btnView.TabIndex = 7;
            this.btnView.Text = "View Result";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // txtSQL
            // 
            this.txtSQL.AcceptsTab = true;
            this.txtSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSQL.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtSQL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSQL.DetectUrls = false;
            this.txtSQL.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSQL.Location = new System.Drawing.Point(9, 28);
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtSQL.Size = new System.Drawing.Size(560, 385);
            this.txtSQL.TabIndex = 8;
            this.txtSQL.Text = "";
            // 
            // frmReportConsole
            // 
            this.AcceptButton = this.btnView;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 455);
            this.Controls.Add(this.txtSQL);
            this.Controls.Add(this.btnView);
            this.MaximizeBox = true;
            this.Name = "frmReportConsole";
            this.Text = "SQL Report Console";
            this.Load += new System.EventHandler(this.frmReportConsole_Load);
            this.Controls.SetChildIndex(this.btnView, 0);
            this.Controls.SetChildIndex(this.txtSQL, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.RichTextBox txtSQL;
    }
}