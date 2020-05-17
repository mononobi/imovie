using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace iMovie
{
    public partial class frmPerson : frmMaster
    {
        private long personID = 0;

        private Person person = new Person();
        private Movie[] moviesDirected = new Movie[0];
        private Movie[] moviesActed = new Movie[0];
        private bool isDirector = false;
        private bool isActor = false;

        public frmPerson(long personID)
        {
            InitializeComponent();

            this.personID = personID;
            Initialize();
        }

        private void frmPerson_Load(object sender, EventArgs e)
        {
            try
            {
                DataOperation.SetFont(lblActorName, enFontNames.Copperplate_Gothic_Bold.ToString().Replace("_", " "), 24, FontStyle.Bold);
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
                DataTable dtPerson = new DataTable();
                DataTable dtMoviesActed = new DataTable();
                DataTable dtMoviesDirected = new DataTable();
                DataTable dtPersonType = new DataTable();

                dtPerson = Person_SP.GetByID(this.personID);
                Person_SP.GetTypeByID(this.personID, out this.isActor, out this.isDirector);

                if (this.isDirector == true)
                {
                    dtMoviesDirected = Movie_SP.GetByDirectorID(this.personID);
                }

                if (this.isActor == true)
                {
                    dtMoviesActed = Movie_SP.GetByActorID(this.personID);
                }

                this.person.FetchSinglePerson(dtPerson);
                this.moviesDirected = Movie.FetchAllMovie(dtMoviesDirected);
                this.moviesActed = Movie.FetchAllMovie(dtMoviesActed);

                // Form Title

                this.Text = this.person.FullName;

                // Summary

                lblActorName.Text = this.person.FullName;

                if (File.Exists(PathUtils.GetApplicationPersonPath() + this.person.PhotoLink) == true)
                {
                    try
                    {
                        picPhoto.Image = Image.FromFile(PathUtils.GetApplicationPersonPath() + this.person.PhotoLink);
                    }
                    catch
                    {
                        // Do nothing for image that is corrupted
                    }
                }

                if (this.isActor == true && this.isDirector == true)
                {
                    lblUp.Visible = true;
                    lblUpValue.Visible = true;
                    lblDown.Visible = true;
                    lblDownValue.Visible = true;

                    lblUp.Text = "Number of Movies Directed:";
                    lblDown.Text = "Number of Movies Acted:";

                    lblUpValue.Text = this.moviesDirected.Length.ToString();
                    lblDownValue.Text = this.moviesActed.Length.ToString();
                }
                else if (this.isActor == true && this.isDirector == false)
                {
                    lblUp.Visible = false;
                    lblUpValue.Visible = false;
                    lblDown.Visible = true;
                    lblDownValue.Visible = true;

                    lblUp.Text = "";
                    lblDown.Text = "Number of Movies Acted:";

                    lblUpValue.Text = "";
                    lblDownValue.Text = this.moviesActed.Length.ToString();

                    DataOperation.HideTabPage(tab, tabDirected);
                }
                else if (this.isActor == false && this.isDirector == true)
                {
                    lblUp.Visible = false;
                    lblUpValue.Visible = false;
                    lblDown.Visible = true;
                    lblDownValue.Visible = true;

                    lblUp.Text = "";
                    lblDown.Text = "Number of Movies Directed:";

                    lblUpValue.Text = "";
                    lblDownValue.Text = this.moviesDirected.Length.ToString();

                    DataOperation.HideTabPage(tab, tabActed);
                }
                else
                {
                    lblUp.Visible = false;
                    lblUpValue.Visible = false;
                    lblDown.Visible = false;
                    lblDownValue.Visible = false;

                    lblUp.Text = "";
                    lblDown.Text = "";

                    lblUpValue.Text = "";
                    lblDownValue.Text = "";

                    DataOperation.HideTabPage(tab, tabDirected);
                    DataOperation.HideTabPage(tab, tabActed);
                }

                // Movies Directed

                repDirected.EnableRightClickMenu = iMovieBase.IsLogin;
                repDirected.DataSource = moviesDirected;

                // Movies Acted

                repActed.EnableRightClickMenu = iMovieBase.IsLogin;
                repActed.DataSource = moviesActed;
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
                if (this.person.IMDBLink.Length > 0)
                {
                    Process.Start(this.person.IMDBLink);
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
                    repDirected.EnableRightClickMenu = true;
                    repActed.EnableRightClickMenu = true;
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
                    repDirected.EnableRightClickMenu = false;
                    repActed.EnableRightClickMenu = false;
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

        public long PersonID
        {
            get
            {
                try
                {
                    return this.personID;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
