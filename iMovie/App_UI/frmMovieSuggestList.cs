using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace iMovie
{
    public partial class frmMovieSuggestList : frmMaster
    {
        private Movie[] dataSource = new Movie[0];

        public frmMovieSuggestList(Movie[] dataSource) 
        {
            InitializeComponent();
            this.dataSource = dataSource;
            Initialize();
        }

        private void frmMovieSuggestList_Load(object sender, EventArgs e)
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
                // Suggestion List

                repMovie.EnableRightClickMenu = iMovieBase.IsLogin;
                repMovie.DataSource = dataSource;
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

        public Movie[] DataSource
        {
            get
            {
                try
                {
                    return this.dataSource;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
