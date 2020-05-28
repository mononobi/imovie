using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace iMovie
{
    public partial class ucPersonList : UserControl
    {
        private string clickedPersonName = "Not Selected";
        private string clickedPersonPhoto = string.Empty;

        public ucPersonList()
        {
            InitializeComponent();
            dgvPerson.DataGridView.CurrentCellChanged += DataGridView_CurrentCellChanged;
        }

        public DataTable DtPersons { get; set; } = new DataTable();
        public string PersonType { get; set; } = string.Empty;

        private void DataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvPerson.DataGridView.CurrentCell != null)
                {
                    int r = dgvPerson.DataGridView.CurrentCell.RowIndex;
                    int c = dgvPerson.DataGridView.CurrentCell.ColumnIndex;

                    if (this.PersonType == "Director")
                    {
                        this.clickedPersonName = dgvPerson.DataGridView.Rows[r].Cells["dgvDirectorName"].Value.ToString();
                    }
                    else if (this.PersonType == "Actor")
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

        public void ValidateAccess()
        {
            dgvPerson.EnableRightClick = iMovieBase.IsLogin && this.EnableRightClick;
            dgvPerson.IsDeletable = iMovieBase.IsLogin && this.EnableRightClick;
        }

        public bool EnableRightClick { get; set; } = true;

        private void Initialize()
        {
            try
            {
                if (PersonType == "Actor")
                {
                    dgvPerson.DataGridViewColumns["dgvActorName"].DataPropertyName = "FullName";
                    dgvPerson.DataGridViewColumns["dgvActorName"].Visible = true;

                    dgvPerson.DataGridViewColumns["dgvPhotoLink"].DataPropertyName = "PhotoLink";

                    dgvPerson.DataGridViewColumns["dgvSelected"].DataPropertyName = null;
                    dgvPerson.DataGridViewColumns["dgvSelected"].Visible = false;

                    dgvPerson.DataGridView.Columns["dgvActorName"].Width = 164;
                    dgvPerson.IsActor = true;
                    dgvPerson.DefaultText = "Search Actors";
                    this.Text = "Actor List";
                }
                else if (PersonType == "Director")
                {
                    dgvPerson.DataGridViewColumns["dgvDirectorName"].DataPropertyName = "FullName";
                    dgvPerson.DataGridViewColumns["dgvDirectorName"].Visible = true;

                    dgvPerson.DataGridViewColumns["dgvPhotoLink"].DataPropertyName = "PhotoLink";

                    dgvPerson.DataGridViewColumns["dgvSelected"].DataPropertyName = null;
                    dgvPerson.DataGridViewColumns["dgvSelected"].Visible = false;

                    dgvPerson.DataGridView.Columns["dgvDirectorName"].Width = 164;
                    dgvPerson.IsDirector = true;
                    dgvPerson.DefaultText = "Search Directors";
                    this.Text = "Director List";
                }

                dgvPerson.DataSource = this.DtPersons;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ucPersonList_Load(object sender, EventArgs e)
        {
            try
            {
                DataOperation.SetFont(lblName, enFontNames.Copperplate_Gothic_Bold.ToString().Replace("_", " "), 12, FontStyle.Regular);
                Initialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
