namespace iMovie
{
    partial class ucCheckBoxList
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
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkList = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(2, 2);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(15, 14);
            this.chkAll.TabIndex = 0;
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // chkList
            // 
            this.chkList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkList.BackColor = System.Drawing.SystemColors.Control;
            this.chkList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chkList.CheckOnClick = true;
            this.chkList.FormattingEnabled = true;
            this.chkList.HorizontalScrollbar = true;
            this.chkList.Location = new System.Drawing.Point(0, 17);
            this.chkList.MultiColumn = true;
            this.chkList.Name = "chkList";
            this.chkList.Size = new System.Drawing.Size(223, 92);
            this.chkList.TabIndex = 1;
            // 
            // ucCheckBoxList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.chkList);
            this.Name = "ucCheckBoxList";
            this.Size = new System.Drawing.Size(224, 111);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.CheckedListBox chkList;
    }
}
