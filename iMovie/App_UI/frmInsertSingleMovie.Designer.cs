namespace iMovie
{
    partial class frmInsertSingleMovie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInsertSingleMovie));
            this.txtRoot = new System.Windows.Forms.TextBox();
            this.btnRoot = new System.Windows.Forms.Button();
            this.prgBatch = new System.Windows.Forms.ProgressBar();
            this.btnInsert = new System.Windows.Forms.Button();
            this.grpBatch = new System.Windows.Forms.GroupBox();
            this.fldRoot = new System.Windows.Forms.FolderBrowserDialog();
            this.grpBatch.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRoot
            // 
            this.txtRoot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRoot.Location = new System.Drawing.Point(22, 27);
            this.txtRoot.Multiline = true;
            this.txtRoot.Name = "txtRoot";
            this.txtRoot.ReadOnly = true;
            this.txtRoot.Size = new System.Drawing.Size(331, 26);
            this.txtRoot.TabIndex = 0;
            this.txtRoot.TabStop = false;
            this.txtRoot.WordWrap = false;
            // 
            // btnRoot
            // 
            this.btnRoot.Location = new System.Drawing.Point(361, 26);
            this.btnRoot.Name = "btnRoot";
            this.btnRoot.Size = new System.Drawing.Size(47, 28);
            this.btnRoot.TabIndex = 0;
            this.btnRoot.Text = "...";
            this.btnRoot.UseVisualStyleBackColor = true;
            this.btnRoot.Click += new System.EventHandler(this.btnRoot_Click);
            // 
            // prgBatch
            // 
            this.prgBatch.Location = new System.Drawing.Point(7, 83);
            this.prgBatch.Name = "prgBatch";
            this.prgBatch.Size = new System.Drawing.Size(342, 28);
            this.prgBatch.Step = 1;
            this.prgBatch.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgBatch.TabIndex = 2;
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(355, 81);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(82, 31);
            this.btnInsert.TabIndex = 1;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // grpBatch
            // 
            this.grpBatch.Controls.Add(this.txtRoot);
            this.grpBatch.Controls.Add(this.btnRoot);
            this.grpBatch.Location = new System.Drawing.Point(7, 5);
            this.grpBatch.Name = "grpBatch";
            this.grpBatch.Size = new System.Drawing.Size(430, 70);
            this.grpBatch.TabIndex = 4;
            this.grpBatch.TabStop = false;
            this.grpBatch.Text = "Select Movie Folder:";
            // 
            // fldRoot
            // 
            this.fldRoot.Description = "Select Movie Folder:";
            this.fldRoot.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // frmInsertSingleMovie
            // 
            this.AcceptButton = this.btnInsert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 118);
            this.Controls.Add(this.grpBatch);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.prgBatch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmInsertSingleMovie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iMovie - Force Single Movie Insert";
            this.Load += new System.EventHandler(this.frmBatchMovie_Load);
            this.grpBatch.ResumeLayout(false);
            this.grpBatch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtRoot;
        private System.Windows.Forms.Button btnRoot;
        private System.Windows.Forms.ProgressBar prgBatch;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.GroupBox grpBatch;
        private System.Windows.Forms.FolderBrowserDialog fldRoot;
    }
}