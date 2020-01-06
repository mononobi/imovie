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
    public partial class frmCopyRequestList: Form
    {
        private DataTable dataSource = new DataTable();

        public frmCopyRequestList(DataTable dtMovies)
        {
            InitializeComponent();

            this.dataSource = dtMovies;
            Initialize();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            try
            {
                if (fldCopy.ShowDialog() == DialogResult.OK)
                {
                    txtCopy.Text = fldCopy.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(Messages.ClearCopyList, Messages.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Movie_SP.RequestMovieCopyDeleteAll();
                    this.dataSource.Rows.Clear();
                    this.dgvMovie.DataSource = this.dataSource;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                string destination = txtCopy.Text;

                if (Directory.Exists(destination) == true)
                {
                    DataTable dtMovies = Movie_SP.RequestMovieCopyGetList();

                    if (dtMovies.Rows.Count > 0)
                    {
                        btnCopy.Enabled = false;
                        btnClear.Enabled = false;

                        InsertManager im = new InsertManager(false, false);
                        List<string> notFounded = new List<string>();

                        try
                        {
                            float size = im.CalculateSize(dtMovies, iMovieBase.MovieRootPath);

                            if (MessageBox.Show("Size to copy is about: " + SizeUtils.GetSizeString(size, SizeModeEnum.HumanReadable) + Environment.NewLine + "Start copying?", "iMovie", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                notFounded = im.CopyMovies(destination, dtMovies, iMovieBase.MovieRootPath);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        finally
                        {
                            this.dataSource = Movie_SP.RequestMovieCopyGetList();
                            dgvMovie.DataSource = dataSource;
                        }

                        if (notFounded.Count > 0)
                        {
                            MessageBox.Show(Messages.RemainingMoviesNotFound, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        btnCopy.Enabled = true;
                        btnClear.Enabled = true;
                    }
                    else
                    {
                        throw new Exception(Messages.NoMovieToCopy);
                    }
                }
                else
                {
                    throw new Exception(Messages.SelectDestinationPath);
                }
            }
            catch (Exception ex)
            {
                btnCopy.Enabled = true;
                btnClear.Enabled = true;

                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void ValidateAccess()
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                throw ex;
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

        private void mnuStripGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvMovie.DataSource.Rows.Count > 0)
                {
                    if (saveScript.ShowDialog() == DialogResult.OK)
                    {
                        DataTable dt = new DataTable();
                        dt = Movie_SP.RequestMovieCopyGetList();
                        InsertManager im = new InsertManager(false, false);
                        string file = saveScript.FileName;
                        bool a = im.GenerateCopyRequestScript(dt, file);

                        if (a == true)
                        {
                            MessageBox.Show(Messages.ScriptGeneratedSuccessfuly, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(Messages.ScriptGenerationFailed, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    throw new Exception(Messages.NoMovieToCopyScript);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuStripLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (openScript.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(openScript.FileName) == true)
                    {
                        long failed = 0;
                        long notFound = 0;
                        string file = openScript.FileName;
                        DataTable dt = new DataTable();
                        InsertManager im = new InsertManager(false, false);
                        dt = im.LoadCopyRequestScript(file, out failed, out notFound);

                        if (dt.Rows.Count > 0)
                        {
                            dgvMovie.DataSource = dt;
                            this.dataSource = dt;
                        }
                        else if(dt.Rows.Count == 0 && notFound == 0)
                        {
                            throw new Exception(Messages.NoMovieToLoadScript);
                        }

                        if (notFound > 0)
                        {
                            MessageBox.Show(Messages.SomeMoviesNotLoadInScript.Replace("@NUM@", notFound.ToString()).Replace(@"\n", Environment.NewLine), Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        throw new Exception(Messages.SelectFilePath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
