namespace iMovie
{
    partial class frmBatchMovie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBatchMovie));
            this.txtRoot = new System.Windows.Forms.TextBox();
            this.btnRoot = new System.Windows.Forms.Button();
            this.prgBatch = new System.Windows.Forms.ProgressBar();
            this.btnInsert = new System.Windows.Forms.Button();
            this.grpBatch = new System.Windows.Forms.GroupBox();
            this.chkIndividual = new System.Windows.Forms.CheckBox();
            this.chkAsRoot = new System.Windows.Forms.CheckBox();
            this.fldRoot = new System.Windows.Forms.FolderBrowserDialog();
            this.lblMovie = new System.Windows.Forms.Label();
            this.grpBatch.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRoot
            // 
            this.txtRoot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRoot.Location = new System.Drawing.Point(22, 37);
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
            this.btnRoot.Location = new System.Drawing.Point(361, 36);
            this.btnRoot.Name = "btnRoot";
            this.btnRoot.Size = new System.Drawing.Size(47, 28);
            this.btnRoot.TabIndex = 0;
            this.btnRoot.Text = "...";
            this.btnRoot.UseVisualStyleBackColor = true;
            this.btnRoot.Click += new System.EventHandler(this.btnRoot_Click);
            // 
            // prgBatch
            // 
            this.prgBatch.Location = new System.Drawing.Point(7, 168);
            this.prgBatch.Name = "prgBatch";
            this.prgBatch.Size = new System.Drawing.Size(342, 28);
            this.prgBatch.Step = 1;
            this.prgBatch.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgBatch.TabIndex = 2;
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(355, 166);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(82, 31);
            this.btnInsert.TabIndex = 2;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // grpBatch
            // 
            this.grpBatch.Controls.Add(this.chkIndividual);
            this.grpBatch.Controls.Add(this.chkAsRoot);
            this.grpBatch.Controls.Add(this.txtRoot);
            this.grpBatch.Controls.Add(this.btnRoot);
            this.grpBatch.Location = new System.Drawing.Point(7, 5);
            this.grpBatch.Name = "grpBatch";
            this.grpBatch.Size = new System.Drawing.Size(430, 115);
            this.grpBatch.TabIndex = 4;
            this.grpBatch.TabStop = false;
            this.grpBatch.Text = "Select Root Path:";
            // 
            // chkIndividual
            // 
            this.chkIndividual.AutoSize = true;
            this.chkIndividual.Checked = true;
            this.chkIndividual.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIndividual.Location = new System.Drawing.Point(22, 91);
            this.chkIndividual.Name = "chkIndividual";
            this.chkIndividual.Size = new System.Drawing.Size(212, 17);
            this.chkIndividual.TabIndex = 2;
            this.chkIndividual.Text = "Include root path\'s individual movie files";
            this.chkIndividual.UseVisualStyleBackColor = true;
            // 
            // chkAsRoot
            // 
            this.chkAsRoot.AutoSize = true;
            this.chkAsRoot.Checked = true;
            this.chkAsRoot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAsRoot.Location = new System.Drawing.Point(22, 70);
            this.chkAsRoot.Name = "chkAsRoot";
            this.chkAsRoot.Size = new System.Drawing.Size(146, 17);
            this.chkAsRoot.TabIndex = 1;
            this.chkAsRoot.Text = "Add into movie root paths";
            this.chkAsRoot.UseVisualStyleBackColor = true;
            // 
            // fldRoot
            // 
            this.fldRoot.Description = "Select Root Path:";
            this.fldRoot.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // lblMovie
            // 
            this.lblMovie.AutoEllipsis = true;
            this.lblMovie.Location = new System.Drawing.Point(4, 128);
            this.lblMovie.Name = "lblMovie";
            this.lblMovie.Size = new System.Drawing.Size(433, 34);
            this.lblMovie.TabIndex = 101;
            this.lblMovie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMovie.UseMnemonic = false;
            // 
            // frmBatchMovie
            // 
            this.AcceptButton = this.btnInsert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 203);
            this.Controls.Add(this.lblMovie);
            this.Controls.Add(this.grpBatch);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.prgBatch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmBatchMovie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iMovie - Batch Movie Insert";
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
        private System.Windows.Forms.Label lblMovie;
        private System.Windows.Forms.CheckBox chkAsRoot;
        private System.Windows.Forms.CheckBox chkIndividual;
    }
}