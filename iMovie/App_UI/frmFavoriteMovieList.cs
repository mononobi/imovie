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
    public partial class frmFavoriteMovieList : frmMaster
    {
        private Movie[] dataSource = new Movie[0];

        public frmFavoriteMovieList(Movie[] dataSource)
        {
            InitializeComponent();

            this.dataSource = dataSource;
            Initialize();
        }

        private void frmFavoriteMovieList_Load(object sender, EventArgs e)
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
                // Favorite List

                repFavorite.EnableRightClickMenu = iMovieBase.IsLogin;
                repFavorite.DataSource = this.DataSource;
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
                    repFavorite.EnableRightClickMenu = true;
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
                    repFavorite.EnableRightClickMenu = false;
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
