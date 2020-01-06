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
    public partial class frmPersonList : frmMaster
    {
        private DataTable dtPersons = new DataTable();
        private string personType = "";
        private string clickedPersonName = "Not Selected";
        private string clickedPersonPhoto = "";

        public frmPersonList(DataTable dtPersons, string personType)
        {
            InitializeComponent();
            dgvPerson.DataGridView.CurrentCellChanged += DataGridView_CurrentCellChanged;

            this.personType = personType;
            this.dtPersons = dtPersons;
            Initialize();
        }

        void DataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvPerson.DataGridView.CurrentCell != null)
                {
                    int r = dgvPerson.DataGridView.CurrentCell.RowIndex;
                    int c = dgvPerson.DataGridView.CurrentCell.ColumnIndex;

                    if (this.personType == "Director")
                    {
                        this.clickedPersonName = dgvPerson.DataGridView.Rows[r].Cells["dgvDirectorName"].Value.ToString();
                    }
                    else if (this.personType == "Actor")
                    {
                        this.clickedPersonName = dgvPerson.DataGridView.Rows[r].Cells["dgvActorName"].Value.ToString();
                    }

                    this.clickedPersonPhoto = dgvPerson.DataGridView.Rows[r].Cells["dgvPhotoLink"].Value.ToString();
                }
                else
                {
                    this.clickedPersonName = "Not Selected";
                    this.clickedPersonPhoto = "";
                }

                if (this.clickedPersonName.Length > 0)
                {
                    lblName.Text = this.clickedPersonName;
                }

                if (File.Exists(PathUtils.GetApplicationPersonPath() + this.clickedPersonPhoto) == true)
                {
                    try
                    {
                        picPhoto.Image = Image.FromFile(PathUtils.GetApplicationPersonPath() + this.clickedPersonPhoto);
                    }
                    catch
                    {
                        picPhoto.Image = global::iMovie.Properties.Resources.no_pic;
                    }
                }
                else
                {
                    picPhoto.Image = global::iMovie.Properties.Resources.no_pic;
                }
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
                if (personType == "Actor")
                {
                    dgvPerson.DataGridViewColumns["dgvActorName"].DataPropertyName = "FullName";
                    dgvPerson.DataGridViewColumns["dgvActorName"].Visible = true;

                    dgvPerson.DataGridViewColumns["dgvPhotoLink"].DataPropertyName = "PhotoLink";

                    dgvPerson.DataGridViewColumns["dgvSelected"].DataPropertyName = null;
                    dgvPerson.DataGridViewColumns["dgvSelected"].Visible = false;

                    dgvPerson.DataGridView.Columns["dgvActorName"].Width = 164;
                    dgvPerson.IsActor = true;
                    dgvPerson.DefaultText = "Search Actors";
                    this.Text = "iMovie - Actor List";
                }
                else if (personType == "Director")
                {
                    dgvPerson.DataGridViewColumns["dgvDirectorName"].DataPropertyName = "FullName";
                    dgvPerson.DataGridViewColumns["dgvDirectorName"].Visible = true;

                    dgvPerson.DataGridViewColumns["dgvPhotoLink"].DataPropertyName = "PhotoLink";

                    dgvPerson.DataGridViewColumns["dgvSelected"].DataPropertyName = null;
                    dgvPerson.DataGridViewColumns["dgvSelected"].Visible = false;

                    dgvPerson.DataGridView.Columns["dgvDirectorName"].Width = 164;
                    dgvPerson.IsDirector = true;
                    dgvPerson.DefaultText = "Search Directors";
                    this.Text = "iMovie - Director List";
                }

                dgvPerson.DataSource = this.dtPersons;
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
                    dgvPerson.EnableRightClick = true;
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
                    dgvPerson.EnableRightClick = false;
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

        public string PersonType
        {
            get
            {
                try
                {
                    return this.personType;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void frmPersonList_Load(object sender, EventArgs e)
        {
            try
            {
                DataOperation.SetFont(lblName, enFontNames.Copperplate_Gothic_Bold.ToString().Replace("_", " "), 12, FontStyle.Regular);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
