namespace iMovie
{
    partial class frmRootPathInsert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRootPathInsert));
            this.lstRootPath = new System.Windows.Forms.ListBox();
            this.mnuContextDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuContextDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnChoose = new System.Windows.Forms.Button();
            this.txtRootPath = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grpRootPath = new System.Windows.Forms.GroupBox();
            this.fldRoot = new System.Windows.Forms.FolderBrowserDialog();
            this.mnuContextDelete.SuspendLayout();
            this.grpRootPath.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstRootPath
            // 
            this.lstRootPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstRootPath.FormattingEnabled = true;
            this.lstRootPath.HorizontalScrollbar = true;
            this.lstRootPath.Location = new System.Drawing.Point(17, 28);
            this.lstRootPath.Name = "lstRootPath";
            this.lstRootPath.Size = new System.Drawing.Size(398, 119);
            this.lstRootPath.Sorted = true;
            this.lstRootPath.TabIndex = 1;
            // 
            // mnuContextDelete
            // 
            this.mnuContextDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuContextDeleteItem});
            this.mnuContextDelete.Name = "mnuContextDelete";
            this.mnuContextDelete.ShowImageMargin = false;
            this.mnuContextDelete.Size = new System.Drawing.Size(83, 26);
            // 
            // mnuContextDeleteItem
            // 
            this.mnuContextDeleteItem.Name = "mnuContextDeleteItem";
            this.mnuContextDeleteItem.Size = new System.Drawing.Size(82, 22);
            this.mnuContextDeleteItem.Text = "Delete";
            this.mnuContextDeleteItem.Click += new System.EventHandler(this.mnuContextDeleteItem_Click);
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(367, 155);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(48, 29);
            this.btnChoose.TabIndex = 2;
            this.btnChoose.Text = "...";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // txtRootPath
            // 
            this.txtRootPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRootPath.Location = new System.Drawing.Point(17, 155);
            this.txtRootPath.Multiline = true;
            this.txtRootPath.Name = "txtRootPath";
            this.txtRootPath.ReadOnly = true;
            this.txtRootPath.Size = new System.Drawing.Size(344, 27);
            this.txtRootPath.TabIndex = 33;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(358, 215);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(82, 28);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grpRootPath
            // 
            this.grpRootPath.Controls.Add(this.lstRootPath);
            this.grpRootPath.Controls.Add(this.btnChoose);
            this.grpRootPath.Controls.Add(this.txtRootPath);
            this.grpRootPath.Location = new System.Drawing.Point(7, 6);
            this.grpRootPath.Name = "grpRootPath";
            this.grpRootPath.Size = new System.Drawing.Size(433, 202);
            this.grpRootPath.TabIndex = 0;
            this.grpRootPath.TabStop = false;
            this.grpRootPath.Text = "Current Root Paths:";
            // 
            // fldRoot
            // 
            this.fldRoot.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // frmRootPathInsert
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 249);
            this.Controls.Add(this.grpRootPath);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRootPathInsert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iMovie - Add Movie Root Path";
            this.Load += new System.EventHandler(this.frmRootPathInsert_Load);
            this.mnuContextDelete.ResumeLayout(false);
            this.grpRootPath.ResumeLayout(false);
            this.grpRootPath.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstRootPath;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.TextBox txtRootPath;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox grpRootPath;
        private System.Windows.Forms.FolderBrowserDialog fldRoot;
        private System.Windows.Forms.ContextMenuStrip mnuContextDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuContextDeleteItem;
    }
}