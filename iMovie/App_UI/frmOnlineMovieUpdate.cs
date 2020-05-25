using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace iMovie
{
    public partial class frmOnlineMovieUpdate : Form
    {
        private volatile bool exitRequest = false;
        private Thread SecondThread = null;
        private delegate void DelegateGeneral();
        private delegate void DelegateName(string text);
        private bool isRunning = false;

        public frmOnlineMovieUpdate()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (isRunning == false)
                {
                    prgUpdate.Value = 0;
                    int totals = 0;
                    int updated = 0;
                    int updateError = 0;
                    lblMovie.Text = "";

                    if (DataOperation.IsConnected() == true)
                    {
                        bool ignore = chkIgnore.Checked;
                        bool image = chkImage.Checked;
                        bool rate = chkRate.Checked;
                        bool link = chkLink.Checked;
                        bool year = chkYear.Checked;
                        bool duration = chkDuration.Checked;
                        bool story = chkStory.Checked;
                        bool genre = chkGenre.Checked;
                        bool director = chkDirector.Checked;
                        bool directorPhoto = chkDirectorPhoto.Checked;
                        bool actor = chkActors.Checked;
                        bool actorPhoto = chkActorPhoto.Checked;
                        bool language = chkLanguage.Checked;

                        DataTable dtMovies = new DataTable();

                        if (image == true || rate == true || link == true || year == true || duration == true || 
                            story == true || genre == true || director == true || directorPhoto == true || 
                            language == true || actor == true || actorPhoto == true)
                        {
                            string logName = "iMovie Update Log [" + Helper.GetShortDateTimeString().Replace(":", "-") + "].txt";
                            iMovieBase.log.Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), logName);

                            dtMovies = Movie_SP.GetList(true);
                            Movie[] movieList = Movie.FetchAllMovie(dtMovies);
                            prgUpdate.Maximum = movieList.Length;

                            SecondThread = new Thread(
                            new ThreadStart(() =>
                            {
                                try
                                {
                                    enUpdateResult result = enUpdateResult.UpdateError;
                                    int BannedIP = 0;
                                    int ConnectionLost = 0;
                                    int UpdateError = 0;

                                    isRunning = true;
                                    this.exitRequest = false;

                                    foreach (Movie m in movieList)
                                    {
                                        if (this.exitRequest == false)
                                        {
                                            totals++;

                                            DelegateName dlName = new DelegateName(GetCurrentName);
                                            BeginInvoke(dlName, "Updating: " + m.FullTitle);

                                            result = Movie_SP.UpdateOnline(m, image, rate, link, year, duration, story, genre, 
                                                director, directorPhoto, language, actor, actorPhoto, ignore, true, false, null);

                                            if (result == enUpdateResult.Updated)
                                            {
                                                updated++;
                                            }
                                            else if (result == enUpdateResult.NotOpen ||
                                                    result == enUpdateResult.UpdateError)
                                            {
                                                updateError++;
                                            }

                                            if (result == enUpdateResult.NotOpen)
                                            {
                                                if (DataOperation.IsConnected() == true)
                                                {
                                                    BannedIP++;
                                                    ConnectionLost = 0;
                                                }
                                                else
                                                {
                                                    ConnectionLost++;
                                                    BannedIP = 0;
                                                }
                                            }

                                            if (result == enUpdateResult.UpdateError)
                                            {
                                                UpdateError++;
                                            }
                                            else if (result != enUpdateResult.NoNeedUpdate && 
                                                     result != enUpdateResult.UpdateError)
                                            {
                                                UpdateError = 0;
                                            }

                                            if (chkWarn.Checked == true)
                                            {
                                                if (UpdateError >= 20)
                                                {
                                                    if (MessageBox.Show(Messages.CheckInternet.Replace(@"\n", Environment.NewLine).Replace("@NUM@", UpdateError.ToString()), Messages.MessageBoxTitle, MessageBoxButtons.RetryCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                                                    {
                                                        this.exitRequest = true;
                                                    }

                                                    UpdateError = 0;
                                                }
                                                else if (ConnectionLost >= 8)
                                                {
                                                    MessageBox.Show(Messages.NotConnected, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                                    ConnectionLost = 0;
                                                }
                                                else if (BannedIP >= 10)
                                                {
                                                    if (MessageBox.Show(Messages.IPBanned.Replace(@"\n", Environment.NewLine).Replace("@NUM@", BannedIP.ToString()), Messages.MessageBoxTitle, MessageBoxButtons.RetryCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                                                    {
                                                        this.exitRequest = true;
                                                    }

                                                    BannedIP = 0;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }

                                        InvokeHandle();
                                    }

                                    while (prgUpdate.Value < prgUpdate.Maximum)
                                    {
                                        InvokeHandle();
                                    }

                                    DelegateName dlReset = new DelegateName(GetCurrentName);
                                    BeginInvoke(dlReset, "");

                                    isRunning = false;
                                    this.exitRequest = false;
                    
                                    iMovieBase.log.GenerateSilent("Total movies processed: " + totals.ToString() + Environment.NewLine +
                                                                  "Movies updated: " + updated.ToString() + Environment.NewLine +
                                                                  "Movies failed to update: " + updateError.ToString());

                                    MessageBox.Show(Messages.UpdateComplete + Environment.NewLine + Messages.LogCreated + Environment.NewLine + logName, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    return;
                                }
                                catch (Exception ex)
                                {
                                    isRunning = false;
                                    exitRequest = false;

                                    DelegateName dlResetName = new DelegateName(GetCurrentName);
                                    BeginInvoke(dlResetName, "");

                                    DelegateGeneral dlReset = new DelegateGeneral(ResetProgress);
                                    BeginInvoke(dlReset);

                                    iMovieBase.log.GenerateSilent("Total movies processed: " + totals.ToString() + Environment.NewLine +
                                                                  "Movies updated: " + updated.ToString() + Environment.NewLine +
                                                                  "Movies failed to update: " + updateError.ToString());

                                    MessageBox.Show(Messages.UpdateError + Environment.NewLine + Messages.LogCreated + Environment.NewLine + ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }));

                            SecondThread.Start();
                        }
                        else
                        {
                            MessageBox.Show(Messages.SelectValues, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show(Messages.NotConnected, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show(Messages.WaitForUpdate, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                prgUpdate.Value = 0;

                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PerformStep()
        {
            try
            {
                prgUpdate.PerformStep();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ResetProgress()
        {
            try
            {
                prgUpdate.Value = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                switch (e.CloseReason)
                {
                    case CloseReason.UserClosing:

                        if (isRunning == true)
                        {
                            if (MessageBox.Show(Messages.AbortUpdate.Replace("\n", Environment.NewLine), Messages.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                this.exitRequest = true;

                                e.Cancel = true;
                            }
                            else
                            {
                                e.Cancel = true;
                            }
                        }
    
                        break;
                }

                base.OnFormClosing(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InvokeHandle()
        {
            try
            {
                DelegateGeneral dlStep = new DelegateGeneral(PerformStep);
                BeginInvoke(dlStep);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetCurrentName(string text)
        {
            try
            {
                lblMovie.Text = text;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void chkIgnore_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkIgnore.Checked == false)
                {
                    MessageBox.Show(Messages.IgnoreUpdate.Replace(@"\n", Environment.NewLine), Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkImage_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkImage.Checked == true)
                {
                    MessageBox.Show(Messages.CountriesFiltered.Replace(@"\n", Environment.NewLine), Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkDirectorPhoto_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkDirectorPhoto.Checked == true)
                {
                    MessageBox.Show(Messages.CountriesFiltered.Replace(@"\n", Environment.NewLine), Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkActorPhoto_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkActorPhoto.Checked == true)
                {
                    MessageBox.Show(Messages.CountriesFiltered.Replace(@"\n", Environment.NewLine), Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
