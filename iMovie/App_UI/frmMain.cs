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
    public partial class frmMain : frmMaster
    {
        private delegate void DelHideSplash(bool value);
        private frmSplash splash = new frmSplash();

        public frmMain()
        {
            InitializeComponent();

            splash.Show();
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

        private void btnQuick_Click(object sender, EventArgs e)
        {
            try
            {
                bool seen = chkSeen.Checked;
                bool notSeen = chkNotSeen.Checked;
                bool? fav = chkFavorite.Checked;
                int count = Convert.ToInt32(txtCount.Value);
                bool? isSeen = null;


                if (fav != true)
                {
                    fav = null;
                }

                if (seen == true && notSeen == true)
                {
                    isSeen = null;
                }
                else if (seen == true && notSeen == false)
                {
                    isSeen = true;
                }
                else if (seen == false && notSeen == true)
                {
                    isSeen = false;
                }
                else
                {
                    isSeen = null;
                }

                double rateLow = 0;
                double rateHigh = 10;

                int productLow = 1900;
                int productHigh = 2100;

                string durationLow = "00:00:00";
                string durationHigh = "20:00:00";

                string[] qualityID = null;

                switch (dropPreset.SelectedIndex)
                {
                    case 0: // All Movies
                        
                        break;

                    case 1: // Top Movies

                        qualityID = new string[] { "3", "4" };
                        rateLow = 8;

                        break;

                    case 2: // High Rated Movies

                        rateLow = 7;

                        break;

                    case 3: // High Quality Movies

                        qualityID = new string[] { "3", "4" };

                        break;

                    case 4: // Recent Movies

                        productLow = (DateTime.Now.Year - 3);
                        productHigh = DateTime.Now.Year;

                        break;

                    case 5: // Old Movies

                        productLow = 1901;
                        productHigh = (DateTime.Now.Year - 40);

                        break;

                    case 6: // Short Movies

                        durationHigh = "01:40:00";

                        break;

                    case 7: // Long Movies

                        durationLow = "02:15:00";

                        break;
                }


                DataTable dtMovies = new DataTable();
                dtMovies = Movie_SP.SuggestRandom(count, "", productLow, productHigh, rateLow, rateHigh, durationLow,
                                                  durationHigh, isSeen, fav, null, enFilterType.Any, null, enFilterType.Any, 
                                                  null, enFilterType.Any, null, enFilterType.Any, qualityID);

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

        private void chkSeen_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkSeen.Checked == false && chkNotSeen.Checked == false)
                {
                    chkSeen.Checked = true;
                    chkNotSeen.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void chkNotSeen_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkSeen.Checked == false && chkNotSeen.Checked == false)
                {
                    chkSeen.Checked = true;
                    chkNotSeen.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMovieList_Click(object sender, EventArgs e)
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

        private void btnAdvanceSuggest_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormManager.IsFormOpen(enForms.frmAdvancedSuggest, null) == false)
                {
                    frmAdvancedSuggest suggestTemp = new frmAdvancedSuggest();
                    suggestTemp.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDirectorList_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtAllPerson = new DataTable();
                dtAllPerson = Person_SP.GetList(false, true);

                if (FormManager.IsFormOpen(enForms.frmPersonList, "Director") == false)
                {
                    frmPersonList personTemp = new frmPersonList(dtAllPerson, "Director");

                    personTemp.Show(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnActorList_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtAllPerson = new DataTable();
                dtAllPerson = Person_SP.GetList(true, false);

                if (FormManager.IsFormOpen(enForms.frmPersonList, "Actor") == false)
                {
                    frmPersonList personTemp = new frmPersonList(dtAllPerson, "Actor");

                    personTemp.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                dropPreset.SelectedIndex = 0;

                Thread SecondThread = new Thread(
                new ThreadStart(() =>
                {
                    try
                    {
                        DelHideSplash dlgVisible = new DelHideSplash(HideSplash);
                        
                        BeginInvoke(dlgVisible, false);

                        if (base.SecondThread != null)
                        {
                            base.SecondThread.Join();
                        }

                        try
                        {
                            iMovieBase.MovieRootPath = Movie_SP.RootPathGetList();
                        }
                        catch (Exception ex)
                        {

                        }

                        Thread.Sleep(1000);

                        BeginInvoke(dlgVisible, true);

                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }));

                SecondThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                switch (e.CloseReason)
                {
                    case CloseReason.UserClosing:

                        Application.Exit();
                        
                        break;
                }

                base.OnFormClosing(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HideSplash(bool value)
        {
            try
            {
                if (value == false)
                {
                    this.Visible = value;
                }
                else
                {
                    splash.Close();
                    this.Visible = value;
                    this.WindowState = FormWindowState.Normal;
                    this.Focus();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
