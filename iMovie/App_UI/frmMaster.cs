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
    public partial class frmMaster : Form
    {
        protected Thread SecondThread = null;
        private delegate void DelegateGeneral();

        public frmMaster()
        {
            InitializeComponent();
        }

        private void frmMaster_Load(object sender, EventArgs e)
        {
            try
            {
                this.ValidateAccessMaster();
                FormManager.ValidateAccessAllForm();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuStripLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormManager.IsFormOpen(enForms.frmLogin, 0) == false)
                {
                    frmLogin login = new frmLogin();

                    login.ShowDialog();

                    this.ValidateAccessMaster();
                    FormManager.ValidateAccessAllForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuStripLogout_Click(object sender, EventArgs e)
        {
            try
            {
                iMovieBase.IsLogin = false;
                iMovieBase.User = new Users();

                this.ValidateAccessMaster();
                FormManager.ValidateAccessAllForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuStripStats_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormManager.IsFormOpen(enForms.frmStatistics, null) == false)
                {
                    frmStatistics stats = new frmStatistics();

                    stats.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuStripMain_Click(object sender, EventArgs e)
        {
            try
            {
                Application.OpenForms[0].WindowState = FormWindowState.Normal;
                Application.OpenForms[0].Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuStripExit_Click(object sender, EventArgs e)
        {
            try
            {
                int count = Application.OpenForms.Count;
                int i = count - 1;

                while (i > 0)
                {
                    Application.OpenForms[i].Close();

                    i--;
                }

                if (Application.OpenForms.Count == 1)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuStripKeepMain_Click(object sender, EventArgs e)
        {
            try
            {
                int count = Application.OpenForms.Count;
                int i = count - 1;

                while (i > 0)
                {
                    Application.OpenForms[i].Close();

                    i--;
                }

                Application.OpenForms[0].WindowState = FormWindowState.Normal;
                Application.OpenForms[0].Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuStripQuick_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtMovie = new DataTable();
                dtMovie = Movie_SP.SuggestRandom(1, "", 1900, 2100, 0, 10, "00:00:00", "10:00:00",
                                                 false, null, null, enFilterType.Any, null, enFilterType.Any, 
                                                 null, enFilterType.Any, null, enFilterType.Any, null);

                Movie suggested = new Movie();

                suggested.FetchSingleMovie(dtMovie);

                if (dtMovie.Rows.Count >= 1)
                {
                    if (FormManager.IsFormOpen(enForms.frmMovie, suggested.MovieID) == false)
                    {
                        frmMovie movieTemp = new frmMovie(suggested.MovieID);

                        movieTemp.Show();
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

        private void mnuStripClearCache_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(Messages.DeleteCache, Messages.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Movie_SP.SuggestionCacheDelete();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuStripFavorite_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtFavorite = new DataTable();

                dtFavorite = Movie_SP.FavoriteGetList();

                if (dtFavorite.Rows.Count > 0)
                {
                    Movie[] favoriteMovies = new Movie[0];
                    favoriteMovies = Movie.FetchAllMovie(dtFavorite);

                    if (FormManager.IsFormOpen(enForms.frmFavoriteMovieList, null) == false)
                    {
                        frmFavoriteMovieList favoriteTemp = new frmFavoriteMovieList(favoriteMovies);

                        favoriteTemp.Show();
                    }
                }
                else
                {
                    MessageBox.Show(Messages.FavoriteListEmpty, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuStripSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormManager.IsFormOpen(enForms.frmSearchArea, null) == false)
                {
                    frmSearchArea searchTemp = new frmSearchArea();

                    searchTemp.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuStripAbout_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormManager.IsFormOpen(enForms.frmAbout, null) == false)
                {
                    frmAbout about = new frmAbout();

                    about.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuStripBatchMovie_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormManager.IsFormOpen(enForms.frmBatchMovie, null) == false)
                {
                    frmBatchMovie batch = new frmBatchMovie();

                    batch.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void ValidateAccessMaster()
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

        private void mnuStripOnlineMovie_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormManager.IsFormOpen(enForms.frmOnlineMovieUpdate, null) == false)
                {
                    frmOnlineMovieUpdate online = new frmOnlineMovieUpdate();

                    online.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuStripRootPath_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormManager.IsFormOpen(enForms.frmRootPathInsert, null) == false)
                {
                    frmRootPathInsert root = new frmRootPathInsert();

                    root.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuStripUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormManager.IsFormOpen(enForms.frmUserInsert, null) == false)
                {
                    frmUserInsert user = new frmUserInsert();

                    user.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuStripDuplicate_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtDuplicate = new DataTable();
                dtDuplicate = Movie_SP.GetDuplicateListTradeOff();

                this.ShowDuplicate(dtDuplicate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuStripClearAllMovie_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(Messages.DeleteAllMovies.Replace("\n",Environment.NewLine), Messages.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    long r = 0;

                    r = Movie_SP.DeleteAll();

                    if (r > 0)
                    {
                        mnuStripKeepMain_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuStripSingleMovie_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormManager.IsFormOpen(enForms.frmInsertSingleMovie, null) == false)
                {
                    frmInsertSingleMovie single = new frmInsertSingleMovie();

                    single.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuStripAllMovie_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtAllMovie = new DataTable();
                dtAllMovie = Movie_SP.GetList(false);
                Movie[] movie = new Movie[0];
                movie = Movie.FetchAllMovie(dtAllMovie);

                if (FormManager.IsFormOpen(enForms.frmMovieList, null) == false)
                {
                    frmMovieList movieTemp = new frmMovieList(dtAllMovie);

                    movieTemp.Show();
                }
                else
                {
                    foreach (Form frm in Application.OpenForms)
                    {
                        if (frm is frmMovieList)
                        {
                            (frm as frmMovieList).DataSource = dtAllMovie;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ShowDuplicate(DataTable dtDuplicate)
        {
            try
            {
                if (dtDuplicate.Rows.Count > 1)
                {
                    if (FormManager.IsFormOpen(enForms.frmMovieList, null) == false)
                    {
                        frmMovieList movieList = new frmMovieList(dtDuplicate);

                        movieList.Show();
                    }
                    else
                    {
                        foreach (Form frm in Application.OpenForms)
                        {
                            if (frm is frmMovieList)
                            {
                                (frm as frmMovieList).TextBoxFocus = false;
                                (frm as frmMovieList).DataSource = dtDuplicate;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(Messages.NoDuplicateMovieFound, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void copyRequestListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtCopy = new DataTable();
                dtCopy = Movie_SP.RequestMovieCopyGetList();

                if (FormManager.IsFormOpen(enForms.frmCopyRequestList, null) == false)
                {
                    frmCopyRequestList copy = new frmCopyRequestList(dtCopy);

                    copy.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuStripReportConsole_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormManager.IsFormOpen(enForms.frmReportConsole, null) == false)
                {
                    frmReportConsole report = new frmReportConsole();

                    report.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void generateConfigFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                bool append = false;

                if (MessageBox.Show(Messages.AppendConfigs.Replace(@"\n", Environment.NewLine), Messages.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    append = true;
                }

                ConfigManager.GenerateConfigFiles(append);

                MessageBox.Show(Messages.ConfigsGenerated, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
