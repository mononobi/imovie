namespace iMovie
{
    partial class frmMovieSuggestList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMovieSuggestList));
            this.lblSuggested = new System.Windows.Forms.Label();
            this.repMovie = new iMovie.ucMovieRepeater();
            this.SuspendLayout();
            // 
            // lblSuggested
            // 
            this.lblSuggested.AutoSize = true;
            this.lblSuggested.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSuggested.Location = new System.Drawing.Point(4, 28);
            this.lblSuggested.Name = "lblSuggested";
            this.lblSuggested.Size = new System.Drawing.Size(249, 20);
            this.lblSuggested.TabIndex = 5;
            this.lblSuggested.Text = "Here is a list of suggested movies:";
            // 
            // repMovie
            // 
            this.repMovie.DataSource = new iMovie.Movie[0];
            this.repMovie.EnableRightClickMenu = false;
            this.repMovie.Location = new System.Drawing.Point(8, 59);
            this.repMovie.MaximumSize = new System.Drawing.Size(660, 315);
            this.repMovie.MinimumSize = new System.Drawing.Size(660, 315);
            this.repMovie.Name = "repMovie";
            this.repMovie.RemoveOnNoneFavorite = false;
            this.repMovie.ShowCount = true;
            this.repMovie.Size = new System.Drawing.Size(660, 315);
            this.repMovie.TabIndex = 0;
            // 
            // frmMovieSuggestList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 372);
            this.Controls.Add(this.repMovie);
            this.Controls.Add(this.lblSuggested);
            this.Name = "frmMovieSuggestList";
            this.Text = "Suggestion List";
            this.Load += new System.EventHandler(this.frmMovieSuggestList_Load);
            this.Controls.SetChildIndex(this.lblSuggested, 0);
            this.Controls.SetChildIndex(this.repMovie, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSuggested;
        private ucMovieRepeater repMovie;

    }
}