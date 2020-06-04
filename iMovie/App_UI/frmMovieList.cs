using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace iMovie
{
    public partial class frmMovieList : frmMaster
    {
        private DataTable dataSource = new DataTable();

        public frmMovieList()
        {
            InitializeComponent();
        }

        public frmMovieList(DataTable dtMovies, string text = "Movie List")
        {
            InitializeComponent();
            this.dataSource = dtMovies;
            this.Text = text;
            Initialize();
        }

        private void frmMovieList_Load(object sender, EventArgs e)
        {
            try
            {
                
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
                dgvMovie.DataGridViewColumns["dgvMovieName"].DataPropertyName = "MovieName";
                dgvMovie.DataGridViewColumns["dgvMovieName"].Visible = true;

                dgvMovie.DataGridViewColumns["dgvProductYear"].DataPropertyName = "ProductYear";
                dgvMovie.DataGridViewColumns["dgvProductYear"].Visible = true;

                dgvMovie.DataGridViewColumns["dgvIMDBRate"].DataPropertyName = "IMDBRate";
                dgvMovie.DataGridViewColumns["dgvIMDBRate"].Visible = true;

                dgvMovie.DataGridViewColumns["dgvDuration"].DataPropertyName = "Duration";
                dgvMovie.DataGridViewColumns["dgvDuration"].Visible = true;

                dgvMovie.DataGridViewColumns["dgvIsSeen"].DataPropertyName = "IsSeen";
                dgvMovie.DataGridViewColumns["dgvIsSeen"].Visible = true;

                dgvMovie.DataGridViewColumns["dgvOriginalQuality"].DataPropertyName = "Quality";
                dgvMovie.DataGridViewColumns["dgvOriginalQuality"].Visible = false;

                dgvMovie.DataGridViewColumns["dgvQuality"].DataPropertyName = "DisplayQuality";
                dgvMovie.DataGridViewColumns["dgvQuality"].Visible = true;

                dgvMovie.DataGridViewColumns["dgvArchiveDate"].DataPropertyName = "AddDate";
                dgvMovie.DataGridViewColumns["dgvArchiveDate"].Visible = true;

                dgvMovie.DataGridViewColumns["dgvSelected"].DataPropertyName = null;
                dgvMovie.DataGridViewColumns["dgvSelected"].Visible = false;

                dgvMovie.DataSource = dataSource;
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
                    dgvMovie.EnableRightClick = true;
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
                    dgvMovie.EnableRightClick = false;
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

        public DataTable DataSource
        {
            set
            {
                try
                {
                    this.dataSource = value;
                    dgvMovie.DataSource = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool TextBoxFocus
        {
            set
            {
                try
                {
                    dgvMovie.TextBoxFocus = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string TextBoxQuery 
        {
            set
            {
                try
                {
                    dgvMovie.TextBoxQuery = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                switch (e.CloseReason)
                {
                    case CloseReason.UserClosing:

                        if (dgvMovie.IsRunning == true)
                        {
                            e.Cancel = true;

                            MessageBox.Show(Messages.SomeUpdateRunning, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
