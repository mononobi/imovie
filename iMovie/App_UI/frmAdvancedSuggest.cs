using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace iMovie
{
    public partial class frmAdvancedSuggest : frmMaster
    {
        private DataTable dtLanguage = new DataTable();
        private DataTable dtGenre = new DataTable();
        private DataTable dtActor = new DataTable();
        private DataTable dtDirector = new DataTable();
        private DataTable dtQuality = new DataTable();

        public frmAdvancedSuggest()
        {
            InitializeComponent();
            Initialize();
        }

        private void frmAdvancedSuggest_Load(object sender, EventArgs e)
        {
            try
            {
                SetDefaults();
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
                InitializeLanguage();
                InitializeGenre();
                InitializeDirector();
                InitializeActor();
                InitializeQuality();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InitializeGenre()
        {
            try
            {
                this.dtGenre = Genre_SP.GetList();

                dgvGenre.DataGridViewColumns["dgvGenreName"].DataPropertyName = "GenreName";
                dgvGenre.DataGridViewColumns["dgvGenreName"].Visible = true;

                dgvGenre.DataSource = this.dtGenre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InitializeDirector()
        {
            try
            {
                this.dtDirector = Person_SP.GetList(false, true);

                dgvDirector.DataGridViewColumns["dgvDirectorName"].DataPropertyName = "FullName";
                dgvDirector.DataGridViewColumns["dgvDirectorName"].Visible = true;

                dgvDirector.DataGridViewColumns["dgvPhotoLink"].DataPropertyName = "PhotoLink";
                dgvDirector.DataGridViewColumns["dgvPhotoLink"].Visible = false;

                dgvDirector.DataSource = this.dtDirector;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InitializeActor()
        {
            try
            {
                this.dtActor = Person_SP.GetList(true, false);

                dgvActor.DataGridViewColumns["dgvActorName"].DataPropertyName = "FullName";
                dgvActor.DataGridViewColumns["dgvActorName"].Visible = true;

                dgvActor.DataGridViewColumns["dgvPhotoLink"].DataPropertyName = "PhotoLink";
                dgvActor.DataGridViewColumns["dgvPhotoLink"].Visible = false;

                dgvActor.DataSource = this.dtActor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InitializeLanguage()
        {
            try
            {
                this.dtLanguage = Language_SP.GetList();

                chkLanguage.DataSource = this.dtLanguage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InitializeQuality() 
        {
            try
            {
                this.dtQuality = Enums.ToDataTable(new enVideoQuality(), "QualityID", "QualityName");

                chkQuality.DataSource = this.dtQuality;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ValidateAccess()
        {
            try
            {
                if (iMovieBase.IsLogin == true)
                {
                    mnuStripInsert.Visible = true;
                    mnuStripClearCache.Enabled = true;
                    mnuContextFavorite.Enabled = true;
                    mnuContextIsSeen.Enabled = true;
                    mnuContextQuality.Enabled = true;
                    dgvActor.EnableRightClick = true;
                    dgvDirector.EnableRightClick = true;
                    dgvGenre.EnableRightClick = true;
                    mnuContextDelete.Enabled = true;
                    mnuStripClearAllMovie.Enabled = true;
                }
                else
                {
                    mnuStripInsert.Visible = false;
                    mnuStripClearCache.Enabled = false;
                    mnuContextFavorite.Enabled = false;
                    mnuContextIsSeen.Enabled = false;
                    mnuContextQuality.Enabled = false;
                    dgvActor.EnableRightClick = false;
                    dgvDirector.EnableRightClick = false;
                    dgvGenre.EnableRightClick = false;
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

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                enFilterType languageFilter = enFilterType.Any;

                if (radExactLanguage.Checked == true)
                {
                    languageFilter = enFilterType.Exact;
                }

                enFilterType genreFilter = enFilterType.Any;

                if (radExactGenre.Checked == true)
                {
                    genreFilter = enFilterType.Exact;
                }

                enFilterType directorFilter = enFilterType.Any;

                if (radExactDirector.Checked == true)
                {
                    directorFilter = enFilterType.Exact;
                }

                enFilterType actorFilter = enFilterType.Any;

                if (radExactActor.Checked == true)
                {
                    actorFilter = enFilterType.Exact;
                }

                int count = Convert.ToInt32(txtCount.Value);

                bool? isSeen = null;

                if (chkSeen.Checked == true && chkNotSeen.Checked == false)
                {
                    isSeen = true;
                }
                else if (chkSeen.Checked == false && chkNotSeen.Checked == true)
                {
                    isSeen = false;
                }

                bool? isFavorite = null;

                if (chkFavorite.Checked == true)
                {
                    isFavorite = true;
                }

                double imdbLow = Convert.ToDouble(dropRateLow.SelectedItem);
                double imdbUp = Convert.ToDouble(dropRateUp.SelectedItem);

                int productLow = 1900;
                int productUp = DateTime.Now.Year;

                if (Movie.IsProductYear(txtProductLow.Text) == true)
                {
                    productLow = Convert.ToInt32(txtProductLow.Text);
                }

                if (Movie.IsProductYear(txtProductUp.Text) == true)
                {
                    productUp = Convert.ToInt32(txtProductUp.Text);
                }

                string durationLow = "00:00:00";
                string durationUp = "20:00:00";

                if (Movie.IsDuration(txtDurationLow.Text) == true)
                {
                    durationLow = txtDurationLow.Text;
                }

                if (Movie.IsDuration(txtDurationUp.Text) == true)
                {
                    durationUp = txtDurationUp.Text;
                }

                string movieName = txtMovieName.Text;

                string[] quality = chkQuality.SelectedID;

                if (quality.Length == 0 || chkQuality.SelectAll == true)
                {
                    quality = null;
                }

                string[] language = chkLanguage.SelectedID;

                if (language.Length == 0 || chkLanguage.SelectAll == true)
                {
                    language = null;
                }

                string[] genre = dgvGenre.SelectedID;

                if (genre.Length == 0 || dgvGenre.SelectAll == true)
                {
                    genre = null;
                }

                string[] director = dgvDirector.SelectedID;

                if (director.Length == 0 || dgvDirector.SelectAll == true)
                {
                    director = null;
                }

                string[] actor = dgvActor.SelectedID;

                if (actor.Length == 0 || dgvActor.SelectAll == true)
                {
                    actor = null;
                }

                InsertManager insertManager = new InsertManager(false, false);
                List<Movie> excludedMovies = new List<Movie>();

                foreach (PathSource pathSource in pathListBox.DataSource)
                {
                    excludedMovies.AddRange(insertManager.GetMovieListFromPath(pathSource.PathString));
                }

                List<Movie> duplicateMovies = new List<Movie>();

                duplicateMovies = Movie_SP.GetDuplicateMoviesInSource(excludedMovies);

                DataTable dtMovies = Movie_SP.SuggestRandom(count, movieName, productLow, productUp, imdbLow, imdbUp,
                                                            durationLow, durationUp, isSeen, isFavorite, director, directorFilter,
                                                            actor, actorFilter, genre, genreFilter, language, languageFilter, quality, duplicateMovies);

                Movie[] suggestedMovies = new Movie[0];

                suggestedMovies = Movie.FetchAllMovie(dtMovies);

                if (suggestedMovies.Length == 1)
                {
                    if (FormManager.IsFormOpen(enForms.frmMovie, suggestedMovies[0].MovieID) == false)
                    {
                        frmMovie movieTemp = new frmMovie(suggestedMovies[0].MovieID);

                        movieTemp.Show();
                    }
                }
                else if (suggestedMovies.Length > 1)
                {
                    if (FormManager.IsFormOpen(enForms.frmMovieSuggestList, suggestedMovies) == false)
                    {
                        frmMovieSuggestList suggestList = new frmMovieSuggestList(suggestedMovies);

                        suggestList.Show();
                    }
                }
                else
                {
                    MessageBox.Show(Messages.NoMovieFound, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetDefaults()
        {
            try
            {
                dropPreset.SelectedIndex = 0;

                txtCount.Text = "5";
                chkFavorite.Checked = false;
                chkSeen.Checked = false;
                chkNotSeen.Checked = true;

                txtMovieName.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dropPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (dropPreset.SelectedIndex)
                {
                    case 0: // All Movies

                        chkQuality.SelectAll = true;
                        chkLanguage.SelectAll = true;

                        dropRateLow.SelectedIndex = 0;
                        dropRateUp.SelectedIndex = 0;

                        txtProductLow.Text = "1900";
                        txtProductUp.Text = DateTime.Now.Year.ToString();

                        txtDurationLow.Text = "000000";
                        txtDurationUp.Text = "200000";

                        break;

                    case 1: // Top Movies

                        chkQuality.SelectAll = false;
                        chkQuality.CheckListBox.SetItemChecked(2, true);
                        chkQuality.CheckListBox.SetItemChecked(3, true);

                        chkLanguage.SelectAll = true;

                        dropRateLow.SelectedIndex = 16;
                        dropRateUp.SelectedIndex = 0;

                        txtProductLow.Text = "1900";
                        txtProductUp.Text = DateTime.Now.Year.ToString();

                        txtDurationLow.Text = "000000";
                        txtDurationUp.Text = "200000";

                        break;

                    case 2: // High Rated Movies

                        chkQuality.SelectAll = true;
                        chkLanguage.SelectAll = true;

                        dropRateLow.SelectedIndex = 14;
                        dropRateUp.SelectedIndex = 0;

                        txtProductLow.Text = "1900";
                        txtProductUp.Text = DateTime.Now.Year.ToString();

                        txtDurationLow.Text = "000000";
                        txtDurationUp.Text = "200000";

                        break;

                    case 3: // High Quality Movies

                        chkQuality.SelectAll = false;
                        chkQuality.CheckListBox.SetItemChecked(2, true);
                        chkQuality.CheckListBox.SetItemChecked(3, true);

                        chkLanguage.SelectAll = true;

                        dropRateLow.SelectedIndex = 0;
                        dropRateUp.SelectedIndex = 0;

                        txtProductLow.Text = "1900";
                        txtProductUp.Text = DateTime.Now.Year.ToString();

                        txtDurationLow.Text = "000000";
                        txtDurationUp.Text = "200000";

                        break;

                    case 4: // Recent Movies

                        chkQuality.SelectAll = true;
                        chkLanguage.SelectAll = true;

                        dropRateLow.SelectedIndex = 0;
                        dropRateUp.SelectedIndex = 0;

                        txtProductLow.Text = (DateTime.Now.Year - 3).ToString();
                        txtProductUp.Text = DateTime.Now.Year.ToString();

                        txtDurationLow.Text = "000000";
                        txtDurationUp.Text = "200000";

                        break;

                    case 5: // Old Movies

                        chkQuality.SelectAll = true;
                        chkLanguage.SelectAll = true;

                        dropRateLow.SelectedIndex = 0;
                        dropRateUp.SelectedIndex = 0;

                        txtProductLow.Text = "1901";
                        txtProductUp.Text = (DateTime.Now.Year - 40).ToString();

                        txtDurationLow.Text = "000000";
                        txtDurationUp.Text = "200000";

                        break;

                    case 6: // Short Movies

                        chkQuality.SelectAll = true;
                        chkLanguage.SelectAll = true;

                        dropRateLow.SelectedIndex = 0;
                        dropRateUp.SelectedIndex = 0;

                        txtProductLow.Text = "1900";
                        txtProductUp.Text = DateTime.Now.Year.ToString();

                        txtDurationLow.Text = "000000";
                        txtDurationUp.Text = "014000";

                        break;

                    case 7: // Long Movies

                        chkQuality.SelectAll = true;
                        chkLanguage.SelectAll = true;

                        dropRateLow.SelectedIndex = 0;
                        dropRateUp.SelectedIndex = 0;

                        txtProductLow.Text = "1900";
                        txtProductUp.Text = DateTime.Now.Year.ToString();

                        txtDurationLow.Text = "021500";
                        txtDurationUp.Text = "200000";

                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
