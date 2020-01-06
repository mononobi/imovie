namespace iMovie
{
    partial class ucPathListBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpPaths = new System.Windows.Forms.GroupBox();
            this.lstPath = new System.Windows.Forms.ListBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.mnuContextDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuContextDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fldRoot = new System.Windows.Forms.FolderBrowserDialog();
            this.grpPaths.SuspendLayout();
            this.mnuContextDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPaths
            // 
            this.grpPaths.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPaths.Controls.Add(this.lstPath);
            this.grpPaths.Controls.Add(this.btnChoose);
            this.grpPaths.Controls.Add(this.btnAdd);
            this.grpPaths.Controls.Add(this.txtPath);
            this.grpPaths.Location = new System.Drawing.Point(0, 0);
            this.grpPaths.Name = "grpPaths";
            this.grpPaths.Size = new System.Drawing.Size(586, 284);
            this.grpPaths.TabIndex = 6;
            this.grpPaths.TabStop = false;
            this.grpPaths.Text = "Choose Paths:";
            // 
            // lstPath
            // 
            this.lstPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstPath.FormattingEnabled = true;
            this.lstPath.HorizontalScrollbar = true;
            this.lstPath.Location = new System.Drawing.Point(9, 19);
            this.lstPath.Name = "lstPath";
            this.lstPath.Size = new System.Drawing.Size(568, 184);
            this.lstPath.Sorted = true;
            this.lstPath.TabIndex = 1;
            // 
            // btnChoose
            // 
            this.btnChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChoose.Location = new System.Drawing.Point(533, 210);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(45, 30);
            this.btnChoose.TabIndex = 2;
            this.btnChoose.Text = "...";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(496, 246);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(82, 29);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPath.Location = new System.Drawing.Point(9, 211);
            this.txtPath.Multiline = true;
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(514, 28);
            this.txtPath.TabIndex = 33;
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
            // fldRoot
            // 
            this.fldRoot.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // ucPathListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpPaths);
            this.Name = "ucPathListBox";
            this.Size = new System.Drawing.Size(586, 284);
            this.grpPaths.ResumeLayout(false);
            this.grpPaths.PerformLayout();
            this.mnuContextDelete.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPaths;
        private System.Windows.Forms.ListBox lstPath;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ContextMenuStrip mnuContextDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuContextDeleteItem;
        private System.Windows.Forms.FolderBrowserDialog fldRoot;
    }
}
