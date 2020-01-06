using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;
using System.IO;

namespace iMovie
{
    public partial class ucMovieRepeater : UserControl
    {
        private Movie[] dataSource = new Movie[0];
        private bool removeOnNoneFavorite = false;
         
        public ucMovieRepeater()
        {
            InitializeComponent();
            this.Load += ucMovieRepeater_Load;
            MovieRepeater.ItemValueNeeded += repMovie_ItemValueNeeded;
            toolStripRequestCopy.Click += toolStripRequestCopy_Click;
        }

        private void ucMovieRepeater_Load(object sender, EventArgs e)
        {
            try
            {
                this.DataSource = this.dataSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
         
        private void repMovie_ItemValueNeeded(object sender, DataRepeaterItemValueEventArgs e)
        {
            try
            {
                if (e.ItemIndex < this.DataSource.Length)
                {
                    switch (e.Control.Name)
                    {
                        case "picImage":

                            if (File.Exists(PathUtils.GetApplicationMoviePosterPath() + this.DataSource[e.ItemIndex].PosterLink) == true)
                            {
                                try
                                {
                                    e.Value = Image.FromFile(PathUtils.GetApplicationMoviePosterPath() + this.DataSource[e.ItemIndex].PosterLink);
                                }
                                catch
                                {
                                    // Do nothing for image that is corrupted
                                }
                            }
                            break;

                        case "picIsSeen":

                            if (this.DataSource[e.ItemIndex].IsSeen == true)
                            {
                                e.Value = global::iMovie.Properties.Resources.seen_61;
                            }
                            else
                            {
                                e.Value = global::iMovie.Properties.Resources.not_seen_61;
                            }
                            break;

                        case "lblIMDBRate":

                            e.Value = this.DataSource[e.ItemIndex].IMDBRate.ToString();
                            break;

                        case "lblTitle":

                            e.Value = this.DataSource[e.ItemIndex].FullTitle;
                            break;

                        case "lblFavoriteRate":

                            if (this.DataSource[e.ItemIndex].FavoriteRate == 0)
                            {
                                e.Value = "-";
                            }
                            else
                            {
                                e.Value = this.DataSource[e.ItemIndex].FavoriteRate.ToString();
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void picImage_Click(object sender, EventArgs e)
        {
            try
            {
                int index = repMovie.CurrentItemIndex;

                if (FormManager.IsFormOpen(enForms.frmMovie, this.DataSource[index].MovieID) == false)
                {
                    frmMovie movieTemp = new frmMovie(this.DataSource[index].MovieID);

                    movieTemp.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void ReloadDataSource()
        { 
            try 
            {
                repMovie.BeginResetItemTemplate();
                repMovie.EndResetItemTemplate();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataRepeater MovieRepeater
        {
            get
            {
                try
                {
                    return this.repMovie;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
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
            set
            {
                try
                {
                    this.dataSource = value;

                    DataOperation.LoadDataRepeater(this.dataSource, repMovie);

                    lblCountValue.Text = repMovie.ItemCount.ToString();

                    DataOperation.SetFont(lblIMDBRate, enFontNames.Copperplate_Gothic_Bold.ToString().Replace("_", " "), 11, FontStyle.Bold);
                    DataOperation.SetFont(lblFavoriteRate, enFontNames.Copperplate_Gothic_Bold.ToString().Replace("_", " "), 11, FontStyle.Bold);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool EnableRightClickMenu 
        {
            set 
            {
                try
                {
                    mnuContextFavorite.Enabled = value;
                    mnuContextIsSeen.Enabled = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            get 
            {
                try
                {
                    return mnuContextFavorite.Enabled;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool RemoveOnNoneFavorite
        {
            set 
            {
                try
                {
                    this.removeOnNoneFavorite = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            get 
            {
                try
                { 
                    return this.removeOnNoneFavorite;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool ShowCount
        {
            set
            {
                try
                {
                    lblCount.Visible = value;
                    lblCountValue.Visible = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            get
            {
                try
                {
                    return lblCount.Visible;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        void mnuContextNotSeen_Click(object sender, EventArgs e)
        {
            try
            {
                DataOperation.SetIsSeen(false, repMovie, ref this.dataSource);
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
                DataOperation.SetIsSeen(true, repMovie, ref this.dataSource);
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
                DataOperation.SetFavoriteRate(10, repMovie, ref this.dataSource);
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
                DataOperation.SetFavoriteRate(9, repMovie, ref this.dataSource);
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
                DataOperation.SetFavoriteRate(8, repMovie, ref this.dataSource);
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
                DataOperation.SetFavoriteRate(7, repMovie, ref this.dataSource);
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
                DataOperation.SetFavoriteRate(6, repMovie, ref this.dataSource);
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
                DataOperation.SetFavoriteRate(5, repMovie, ref this.dataSource);
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
                DataOperation.SetFavoriteRate(4, repMovie, ref this.dataSource);
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
                DataOperation.SetFavoriteRate(3, repMovie, ref this.dataSource);
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
                DataOperation.SetFavoriteRate(2, repMovie, ref this.dataSource);
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
                DataOperation.SetFavoriteRate(1, repMovie, ref this.dataSource);
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
                DataOperation.SetFavoriteRate(0, repMovie, ref this.dataSource);

                if (this.RemoveOnNoneFavorite == true)
                {
                    int index = repMovie.CurrentItemIndex;
                    DataOperation.RemoveElement(ref this.dataSource, index);

                    this.DataSource = this.dataSource;
                }

                if (repMovie.ItemCount == 0)
                {
                    MessageBox.Show(Messages.FavoriteListEmpty, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    this.FindForm().Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void toolStripRequestCopy_Click(object sender, EventArgs e)
        {
            DataOperation.RequestCopy(repMovie, ref this.dataSource);
        }
    }
}
