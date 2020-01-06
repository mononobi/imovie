namespace iMovie
{
    partial class frmMovieList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMovieList));
            this.dgvMovie = new iMovie.ucListGridView();
            this.SuspendLayout();
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
            this.dgvMovie.EnableRightClick = false;
            this.dgvMovie.ExitRequest = false;
            this.dgvMovie.HeaderHeight = 35;
            this.dgvMovie.IsActor = false;
            this.dgvMovie.IsCopyRequestable = true;
            this.dgvMovie.IsDeletable = true;
            this.dgvMovie.IsDirector = false;
            this.dgvMovie.IsForceUpdatable = true;
            this.dgvMovie.IsRemovable = false;
            this.dgvMovie.IsSelectable = false;
            this.dgvMovie.IsUpdatable = true;
            this.dgvMovie.IsUpdatableFromURL = true;
            this.dgvMovie.ListType = "";
            this.dgvMovie.Location = new System.Drawing.Point(7, 26);
            this.dgvMovie.Name = "dgvMovie";
            this.dgvMovie.SelectAll = false;
            this.dgvMovie.ShowCount = true;
            this.dgvMovie.Size = new System.Drawing.Size(718, 457);
            this.dgvMovie.TabIndex = 0;
            // 
            // frmMovieList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 485);
            this.Controls.Add(this.dgvMovie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "frmMovieList";
            this.Text = "iMovie - Movie List";
            this.Load += new System.EventHandler(this.frmMovieList_Load);
            this.Controls.SetChildIndex(this.dgvMovie, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucListGridView dgvMovie;

    }
}