namespace iMovie
{
    partial class frmPersonList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPersonList));
            this.ucPersonList = new iMovie.ucPersonList();
            this.SuspendLayout();
            // 
            // ucPersonList
            // 
            this.ucPersonList.Location = new System.Drawing.Point(0, 30);
            this.ucPersonList.Name = "ucPersonList";
            this.ucPersonList.PersonType = "";
            this.ucPersonList.Size = new System.Drawing.Size(379, 368);
            this.ucPersonList.TabIndex = 5;
            // 
            // frmPersonList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 398);
            this.Controls.Add(this.ucPersonList);
            this.Name = "frmPersonList";
            this.Text = "Person List";
            this.Controls.SetChildIndex(this.ucPersonList, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucPersonList ucPersonList;
    }
}