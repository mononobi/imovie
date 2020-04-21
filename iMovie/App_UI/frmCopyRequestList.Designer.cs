namespace iMovie
{
    partial class frmCopyRequestList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCopyRequestList));
            this.btnCopy = new System.Windows.Forms.Button();
            this.fldCopy = new System.Windows.Forms.FolderBrowserDialog();
            this.lblCopy = new System.Windows.Forms.Label();
            this.txtCopy = new System.Windows.Forms.TextBox();
            this.btnPath = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.mnuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuStripScript = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStripGenerate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStripLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.saveScript = new System.Windows.Forms.SaveFileDialog();
            this.openScript = new System.Windows.Forms.OpenFileDialog();
            this.dgvMovie = new iMovie.ucListGridView();
            this.mnuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(640, 486);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(83, 31);
            this.btnCopy.TabIndex = 1;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // fldCopy
            // 
            this.fldCopy.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // lblCopy
            // 
            this.lblCopy.AutoSize = true;
            this.lblCopy.Location = new System.Drawing.Point(4, 495);
            this.lblCopy.Name = "lblCopy";
            this.lblCopy.Size = new System.Drawing.Size(50, 13);
            this.lblCopy.TabIndex = 3;
            this.lblCopy.Text = "Copy To:";
            // 
            // txtCopy
            // 
            this.txtCopy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCopy.Location = new System.Drawing.Point(54, 486);
            this.txtCopy.Multiline = true;
            this.txtCopy.Name = "txtCopy";
            this.txtCopy.ReadOnly = true;
            this.txtCopy.Size = new System.Drawing.Size(467, 30);
            this.txtCopy.TabIndex = 4;
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(523, 486);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(30, 31);
            this.btnPath.TabIndex = 3;
            this.btnPath.Text = "...";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(555, 486);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(83, 31);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Remove All";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // mnuStrip
            // 
            this.mnuStrip.BackColor = System.Drawing.Color.Transparent;
            this.mnuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStripScript});
            this.mnuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mnuStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuStrip.MdiWindowListItem = this.mnuStripScript;
            this.mnuStrip.Name = "mnuStrip";
            this.mnuStrip.Size = new System.Drawing.Size(728, 24);
            this.mnuStrip.TabIndex = 5;
            // 
            // mnuStripScript
            // 
            this.mnuStripScript.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStripGenerate,
            this.mnuStripLoad});
            this.mnuStripScript.Name = "mnuStripScript";
            this.mnuStripScript.ShortcutKeyDisplayString = "";
            this.mnuStripScript.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.mnuStripScript.Size = new System.Drawing.Size(57, 20);
            this.mnuStripScript.Text = "SCRIPT";
            // 
            // mnuStripGenerate
            // 
            this.mnuStripGenerate.Name = "mnuStripGenerate";
            this.mnuStripGenerate.Size = new System.Drawing.Size(121, 22);
            this.mnuStripGenerate.Text = "Generate";
            this.mnuStripGenerate.Click += new System.EventHandler(this.mnuStripGenerate_Click);
            // 
            // mnuStripLoad
            // 
            this.mnuStripLoad.Name = "mnuStripLoad";
            this.mnuStripLoad.Size = new System.Drawing.Size(121, 22);
            this.mnuStripLoad.Text = "Load";
            this.mnuStripLoad.Click += new System.EventHandler(this.mnuStripLoad_Click);
            // 
            // saveScript
            // 
            this.saveScript.CreatePrompt = true;
            this.saveScript.DefaultExt = "txt";
            this.saveScript.FileName = "copy_request";
            this.saveScript.Filter = "Script file (*.txt)|*.txt";
            this.saveScript.Title = "Choose Saving Path";
            // 
            // openScript
            // 
            this.openScript.AddExtension = false;
            this.openScript.DefaultExt = "txt";
            this.openScript.Filter = "Script file (*.txt)|*.txt";
            this.openScript.Title = "Select Script File";
            // 
            // dgvMovie
            // 
            this.dgvMovie.AcceptDoubleClick = true;
            this.dgvMovie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMovie.AutoGenerateColumns = false;
            this.dgvMovie.DataSourceName = "Movie";
            this.dgvMovie.DefaultText = "Search Titles";
            this.dgvMovie.EnableRightClick = true;
            this.dgvMovie.ExitRequest = false;
            this.dgvMovie.HeaderHeight = 35;
            this.dgvMovie.IsActor = false;
            this.dgvMovie.IsCopyRequestable = false;
            this.dgvMovie.IsDeletable = false;
            this.dgvMovie.IsDirector = false;
            this.dgvMovie.IsForceUpdatable = false;
            this.dgvMovie.IsRemovable = true;
            this.dgvMovie.IsSelectable = false;
            this.dgvMovie.IsUpdatable = false;
            this.dgvMovie.IsUpdatableFromURL = false;
            this.dgvMovie.ListType = "RequestCopy";
            this.dgvMovie.Location = new System.Drawing.Point(6, 29);
            this.dgvMovie.Name = "dgvMovie";
            this.dgvMovie.SelectAll = false;
            this.dgvMovie.ShowCount = true;
            this.dgvMovie.Size = new System.Drawing.Size(718, 457);
            this.dgvMovie.TabIndex = 0;
            // 
            // frmCopyRequestList
            // 
            this.AcceptButton = this.btnCopy;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 522);
            this.Controls.Add(this.mnuStrip);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.txtCopy);
            this.Controls.Add(this.lblCopy);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.dgvMovie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCopyRequestList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copy Request List";
            this.mnuStrip.ResumeLayout(false);
            this.mnuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucListGridView dgvMovie;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.FolderBrowserDialog fldCopy;
        private System.Windows.Forms.Label lblCopy;
        private System.Windows.Forms.TextBox txtCopy;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.Button btnClear;
        protected System.Windows.Forms.MenuStrip mnuStrip;
        protected System.Windows.Forms.ToolStripMenuItem mnuStripScript;
        protected System.Windows.Forms.ToolStripMenuItem mnuStripGenerate;
        protected System.Windows.Forms.ToolStripMenuItem mnuStripLoad;
        private System.Windows.Forms.SaveFileDialog saveScript;
        private System.Windows.Forms.OpenFileDialog openScript;
    }
}