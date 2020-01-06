namespace iMovie
{
    partial class frmFavoriteMovieList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFavoriteMovieList));
            this.repFavorite = new iMovie.ucMovieRepeater();
            this.SuspendLayout();
            // 
            // repFavorite
            // 
            this.repFavorite.DataSource = new iMovie.Movie[0];
            this.repFavorite.EnableRightClickMenu = false;
            this.repFavorite.Location = new System.Drawing.Point(6, 29);
            this.repFavorite.MaximumSize = new System.Drawing.Size(660, 315);
            this.repFavorite.MinimumSize = new System.Drawing.Size(660, 315);
            this.repFavorite.Name = "repFavorite";
            this.repFavorite.RemoveOnNoneFavorite = true;
            this.repFavorite.ShowCount = true;
            this.repFavorite.Size = new System.Drawing.Size(660, 315);
            this.repFavorite.TabIndex = 0;
            // 
            // frmFavoriteMovieList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 343);
            this.Controls.Add(this.repFavorite);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFavoriteMovieList";
            this.Text = "iMovie - Favorite Movies";
            this.Load += new System.EventHandler(this.frmFavoriteMovieList_Load);
            this.Controls.SetChildIndex(this.repFavorite, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucMovieRepeater repFavorite;








    }
}