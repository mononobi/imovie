using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Drawing.Text;

namespace iMovie
{
    public partial class frmMovie : frmMaster
    {
        private long movieID = 0;
   
        private Movie movie = new Movie();
        private Person[] director = new Person[0];
        private DataTable actor = new DataTable();
        private Language[] language = new Language[0];
        private Genre[] genre = new Genre[0];
        private Movie[] similar = new Movie[0];

        public frmMovie(long movieID)
        {
            InitializeComponent();

            mnuContextNone.Click += mnuContextNone_Click;
            mnuContext1.Click += mnuContext1_Click;
            mnuContext2.Click += mnuContext2_Click;
            mnuContext3.Click += mnuContext3_Click;
            mnuContext4.Click += mnuContext4_Click;
            mnuContext5.Click += mnuContext5_Click;
            mnuContext6.Click += mnuContext6_Click;
            mnuContext7.Click += mnuContext7_Click;
            mnuContext8.Click += mnuContext8_Click;
            mnuContext9.Click += mnuContext9_Click;
            mnuContext10.Click += mnuContext10_Click;
            mnuContextSeen.Click += mnuContextSeen_Click;
            mnuContextNotSeen.Click += mnuContextNotSeen_Click;

            mnuContextIndeterminate.Click += mnuContextIndeterminate_Click;
            mnuContext1080.Click += mnuContext1080_Click;
            mnuContext720.Click += mnuContext720_Click;
            mnuContextDVD.Click += mnuContextDVD_Click;
            mnuContextVCD.Click += mnuContextVCD_Click;

            this.movieID = movieID;

            Initialize();
        }

        void mnuContextVCD_Click(object sender, EventArgs e)
        {
            try
            {
                DataOperation.SetQuality(enVideoQuality.VCD, this.movie, ref picQuality);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void mnuContextDVD_Click(object sender, EventArgs e)
        {
            try
            {
                DataOperation.SetQuality(enVideoQuality.DVD, this.movie, ref picQuality);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void mnuContext720_Click(object sender, EventArgs e)
        {
            try
            {
                DataOperation.SetQuality(enVideoQuality._720p, this.movie, ref picQuality);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void mnuContext1080_Click(object sender, EventArgs e)
        {
            try
            {
                DataOperation.SetQuality(enVideoQuality._1080p, this.movie, ref picQuality);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void mnuContextIndeterminate_Click(object sender, EventArgs e)
        {
            try
            {
                DataOperation.SetQuality(enVideoQuality.Indeterminate, this.movie, ref picQuality);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void mnuContextNotSeen_Click(object sender, EventArgs e)
        {
            try
            {
                DataOperation.SetIsSeen(false, ref this.movie, picIsSeen, tooltip);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void mnuContextSeen_Click(object sender, EventArgs e)
        {
            try
            {
                DataOperation.SetIsSeen(true, ref this.movie, picIsSeen, tooltip);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void mnuContext10_Click(object sender, EventArgs e)
        {
            try
            {
                DataOperation.SetFavoriteRate(10, ref this.movie, lblFavValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void mnuContext9_Click(object sender, EventArgs e)
        {
            try
            {
                DataOperation.SetFavoriteRate(9, ref this.movie, lblFavValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void mnuContext8_Click(object sender, EventArgs e)
        {
            try
            {
                DataOperation.SetFavoriteRate(8, ref this.movie, lblFavValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void mnuContext7_Click(object sender, EventArgs e)
        {
            try
            {
                DataOperation.SetFavoriteRate(7, ref this.movie, lblFavValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void mnuContext6_Click(object sender, EventArgs e)
        {
            try
            {
                DataOperation.SetFavoriteRate(6, ref this.movie, lblFavValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void mnuContext5_Click(object sender, EventArgs e)
        {
            try
            {
                DataOperation.SetFavoriteRate(5, ref this.movie, lblFavValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void mnuContext4_Click(object sender, EventArgs e)
        {
            try
            {
                DataOperation.SetFavoriteRate(4, ref this.movie, lblFavValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void mnuContext3_Click(object sender, EventArgs e)
        {
            try
            {
                DataOperation.SetFavoriteRate(3, ref this.movie, lblFavValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void mnuContext2_Click(object sender, EventArgs e)
        {
            try
            {
                DataOperation.SetFavoriteRate(2, ref this.movie, lblFavValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void mnuContext1_Click(object sender, EventArgs e)
        {
            try
            {
                DataOperation.SetFavoriteRate(1, ref this.movie, lblFavValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void mnuContextNone_Click(object sender, EventArgs e)
        {
            try
            {
                 DataOperation.SetFavoriteRate(0, ref this.movie, lblFavValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmMovie_Load(object sender, EventArgs e)
        {
            try
            {
                DataOperation.SetFont(lblMovieName, enFontNames.Copperplate_Gothic_Bold.ToString().Replace("_", " "), 18, FontStyle.Bold);
                DataOperation.SetFont(lblRateValue, enFontNames.Copperplate_Gothic_Bold.ToString().Replace("_", " "), 18, FontStyle.Bold);
                DataOperation.SetFont(lblFavValue, enFontNames.Copperplate_Gothic_Bold.ToString().Replace("_", " "), 18, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Initialize()
        {
            try 
            {
                DataSet dsMovie = new DataSet();
                DataTable dtSimilar = new DataTable();

                dsMovie = Movie_SP.GetDetailsByID(this.movieID);
                dtSimilar = Movie_SP.GetSimilarByID(this.movieID);

                this.movie.FetchSingleMovie(dsMovie.Tables[0]);
                this.director = Person.FetchAllPerson(dsMovie.Tables[1]);
                this.actor = dsMovie.Tables[2];
                this.language = Language.FetchAllLanguage(dsMovie.Tables[3]);
                this.genre = Genre.FetchAllGenre(dsMovie.Tables[4]);
                this.similar = Movie.FetchAllMovie(dtSimilar);

                // Form Title

                this.Text = this.movie.FullTitle;

                // Summary

                switch (this.movie.Quality)
                {
                    case enVideoQuality._1080p:
                        picQuality.Image = global::iMovie.Properties.Resources._1080p;
                        break;

                    case enVideoQuality._720p:
                        picQuality.Image = global::iMovie.Properties.Resources._720p;
                        break;

                    case enVideoQuality.DVD:
                        picQuality.Image = global::iMovie.Properties.Resources.dvd;
                        break;

                    case enVideoQuality.Indeterminate:
                        picQuality.Image = global::iMovie.Properties.Resources.na;
                        break;

                    case enVideoQuality.VCD:
                        picQuality.Image = global::iMovie.Properties.Resources.vcd;
                        break;

                    default:
                        picQuality.Image = global::iMovie.Properties.Resources.na;
                        break;
                }

                if (this.movie.IsSeen == true)
                {
                    this.tooltip.SetToolTip(this.picIsSeen, Messages.IsSeen);
                    picIsSeen.Image = global::iMovie.Properties.Resources.seen;
                }
                else
                {
                    this.tooltip.SetToolTip(this.picIsSeen, Messages.NotSeen);
                    picIsSeen.Image = global::iMovie.Properties.Resources.not_seen;
                }

                string title = this.movie.FullTitle;

                lblMovieName.Text = title;

                lblRateValue.Text = this.movie.IMDBRate.ToString();

                if (this.movie.FavoriteRate == 0)
                {
                    lblFavValue.Text = "-";
                }
                else
                {
                    lblFavValue.Text = this.movie.FavoriteRate.ToString();
                }

                if (File.Exists(PathUtils.GetApplicationMoviePosterPath() + this.movie.PosterLink) == true)
                {
                    try
                    {
                        picPoster.Image = Image.FromFile(PathUtils.GetApplicationMoviePosterPath() + this.movie.PosterLink);
                    }
                    catch
                    {
                        // Do nothing for image that is corrupted
                    }
                }

                int i = this.director.Length;
                int j = 0;

                if (i > 0)
                {
                    lblDirectorValue.Text = "";
                }

                foreach (Person dir in this.director)
                {
                    lblDirectorValue.Text += dir.FullName;
                    j++;

                    if (j < i)
                    {
                        lblDirectorValue.Text += ", ";
                    }
                }

                j = 0;
                i = this.genre.Length;

                if (i > 0)
                {
                    lblGenreValue.Text = "";
                }

                foreach (Genre gen in this.genre)
                {
                    lblGenreValue.Text += gen.GenreName;
                    j++;

                    if (j < i)
                    {
                        lblGenreValue.Text += ", ";
                    }
                }

                j = 0;
                i = this.language.Length;

                if (i > 0)
                {
                    lblLanguageValue.Text = "";
                }

                foreach (Language lan in this.language)
                {
                    lblLanguageValue.Text += lan.LanguageName;
                    j++;

                    if (j < i)
                    {
                        lblLanguageValue.Text += ", ";
                    }
                }

                lblDurationValue.Text = this.movie.Duration.ToString();

                lblAddDateValue.Text = this.movie.AddDate.ToShortDateString();

                // StoryLine

                lblStoryText.Text = movie.StoryLine;

                // Cast & Crew

                repDirector.DataSource = this.director;
                this.ucActorList.DtPersons = this.actor;
                this.ucActorList.PersonType = "Actor";

                // Similar Movies

                repMovie.EnableRightClickMenu = iMovieBase.IsLogin;
                repMovie.DataSource = this.similar;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void linkIMDB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (this.movie.IMDBLink.Length > 0)
                {
                    Process.Start(this.movie.IMDBLink);
                }
                else
                {
                    throw new Exception(Messages.IMDBLinkNotExist);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void linkFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (this.movie.FileLink.Length > 0)
                {
                    string root = "";
                    int flag = 0;

                    foreach (DataRow dr in iMovieBase.MovieRootPath.Rows)
                    {
                        root = dr["PathString"].ToString() + @"\";

                        if (Directory.Exists(root + this.movie.FileLink) == true)
                        {
                            flag = 1;
                            Process.Start(root + this.movie.FileLink);
                        }
                    }

                    if (flag == 0)
                    {
                        throw new Exception(Messages.MovieNotExist);
                    }
                }
                else
                {
                    throw new Exception(Messages.MovieNotExist);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void ValidateAccess()
        { 
            try
            {
                int count = tab.TabCount;

                if (iMovieBase.IsLogin == true)
                {
                    mnuStripInsert.Visible = true;
                    mnuStripClearCache.Enabled = true;
                    mnuContextFavorite.Enabled = true;
                    mnuContextIsSeen.Enabled = true;
                    repMovie.EnableRightClickMenu = true;
                    mnuContextQuality.Enabled = true;
                    mnuContextDelete.Enabled = true;
                    mnuStripClearAllMovie.Enabled = true;
                }
                else
                {
                    mnuStripInsert.Visible = false;
                    mnuStripClearCache.Enabled = false;
                    mnuContextFavorite.Enabled = false;
                    mnuContextIsSeen.Enabled = false;
                    repMovie.EnableRightClickMenu = false;
                    mnuContextQuality.Enabled = false;
                    mnuContextDelete.Enabled = false;
                    mnuStripClearAllMovie.Enabled = false;

                    masterToolTip.RemoveAll();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long MovieID
        {
            get
            {
                try
                {
                    return this.movieID;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void requestCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Movie_SP.RequestMovieCopyInsert(this.movieID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void removeDirectorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Movie_SP.DeleteAllMovieDirector(this.movieID);
                lblDirectorValue.Text = Messages.NotAvailable;
                repDirector.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
