using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace iMovie
{
    public partial class ucListGridView : UserControl
    {
        private delegate void dlGeneral(long ID);
        private delegate void dlUpdateLabel(bool show);
        private delegate void dlUpdateToolTip();

        private DataTable baseDataSource = new DataTable();
        private DataTable dataSource = new DataTable();
        private Movie[] movieSource = new Movie[0];
        private Person[] personSource = new Person[0];
        private Genre[] genreSource = new Genre[0];
        private int checkedCount = 0;

        private string defaultText = "Search";
        private string dataSourceName = "";
        private string listType = "";
        private bool isActor = false;
        private bool isDirector = false;
        bool acceptDoubleClick = false;
        private string lastQuery = "Search";
        private int runningCount = 0; 
        private bool exitRequest = false;

        private DataGridViewCellStyle hoverStyle = new DataGridViewCellStyle();
         
        public ucListGridView()  
        { 
            InitializeComponent(); 

            dgv.CellDoubleClick += dgv_CellDoubleClick;
            dgv.CellContentClick += dgv_CellContentClick;
            txtSearch.Click += txtSearch_Click;
            txtSearch.GotFocus += txtSearch_GotFocus;
            txtSearch.LostFocus += txtSearch_LostFocus;
            this.Load += ucListGridView_Load;
            chkAll.Click += chkAll_Click;
            dgv.CellMouseDown += dgv_CellMouseDown;
            dgv.CellMouseEnter += dgv_CellMouseEnter;
            dgv.CellMouseLeave += dgv_CellMouseLeave;
            dgv.SelectionChanged += dgv_SelectionChanged;

            this.hoverStyle.BackColor = Color.Khaki;
            this.dgv.AllowUserToResizeColumns = true;
        }

        void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if(dgv.SelectedCells.Count > 1)
            {
                mnuContextDeleteItem.Enabled = false;
                mnuContextUpdate.Enabled = false;
                mnuContextUpdateURL.Enabled = false;
                mnuContextForceUpdateOnline.Enabled = false;
            }
            else
            {
                mnuContextDeleteItem.Enabled = true;
                mnuContextUpdate.Enabled = true;
                mnuContextUpdateURL.Enabled = true;
                mnuContextForceUpdateOnline.Enabled = true;
            }
        }

        void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        dgv.Rows[e.RowIndex].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void dgv_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (e.RowIndex % 2 == 0)
                    {
                        dgv.Rows[e.RowIndex].DefaultCellStyle = dgv.DefaultCellStyle;
                    }
                    else
                    {
                        dgv.Rows[e.RowIndex].DefaultCellStyle = dgv.AlternatingRowsDefaultCellStyle;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void dgv_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    dgv.Rows[e.RowIndex].DefaultCellStyle = this.hoverStyle;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void chkAll_Click(object sender, EventArgs e)
        {
            try
            {
                bool state = chkAll.Checked;
                string result = "";

                if (state == true)
                {
                    result = "1";
                    checkedCount = this.baseDataSource.Rows.Count;
                }
                else
                {
                    result = "0";
                    checkedCount = 0;
                }

                DataOperation.InitializeDataTable(ref this.baseDataSource, "Selected", result);

                foreach (DataGridViewRow dgr in dgv.Rows)
                {
                    dgr.Cells["dgvSelected"].Value = result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (this.acceptDoubleClick == true)
                    {
                        int r = dgv.CurrentCell.RowIndex;

                        long ID = Convert.ToInt64(dgv.Rows[r].Cells["dgvID"].Value);

                        switch (this.DataSourceName)
                        {
                            case "Genre":
                                break;

                            case "Movie":

                                if (FormManager.IsFormOpen(enForms.frmMovie, ID) == false)
                                {
                                    frmMovie movieTemp = new frmMovie(ID);

                                    movieTemp.Show();
                                }

                                break;

                            case "Person":

                                if (FormManager.IsFormOpen(enForms.frmPerson, ID) == false)
                                {
                                    frmPerson personTemp = new frmPerson(ID);

                                    personTemp.Show();
                                }

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

        void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
                {
                if (e.RowIndex >= 0)
                {
                    int r = dgv.SelectedCells[0].RowIndex;
                    int c = dgv.SelectedCells[0].ColumnIndex;
                    string col = dgv.Columns[c].Name;

                    if (col == "dgvSelected")
                    {
                        string result = dgv.SelectedCells[0].Value.ToString();

                        if (result == "1")
                        {
                            result = "0";
                            chkAll.Checked = false;
                            checkedCount--;
                        }
                        else
                        {
                            result = "1";
                            checkedCount++;

                            if (checkedCount == this.baseDataSource.Rows.Count)
                            {
                                chkAll.Checked = true;
                            }
                            else
                            {
                                chkAll.Checked = false;
                            }
                        }

                        string ID = dgv.Rows[r].Cells["dgvID"].Value.ToString();
                        string keyColumn = this.DataSourceName + "ID";

                        foreach (DataRow dr in this.DataSource.Rows)
                        {
                            if (dr[keyColumn].ToString() == ID)
                            {
                                dr["Selected"] = result;
                                break;
                            }
                        }

                        dgv.SelectedCells[0].Value = result;

                        foreach (DataRow dr in this.baseDataSource.Rows)
                        {
                            if (dr[keyColumn].ToString() == ID)
                            {
                                dr["Selected"] = result;
                                break;
                            }
                        }
                    }
                    else if (col == "dgvIsSeen" && iMovieBase.IsLogin == true)
                    {
                        long result = 0;

                        bool last = Convert.ToBoolean(dgv.SelectedCells[0].Value);

                        string ID = dgv.Rows[r].Cells["dgvID"].Value.ToString();
                        string keyColumn = this.DataSourceName + "ID";

                        foreach (DataRow dr in this.DataSource.Rows)
                        {
                            if (dr[keyColumn].ToString() == ID)
                            {
                                dr["IsSeen"] = !last;
                                break;
                            }
                        }

                        foreach (Movie m in this.movieSource)
                        {
                            if (m.MovieID.ToString() == ID)
                            {
                                m.IsSeen = !last;
                                result = Movie_SP.UpdateIsSeen(m.MovieID, m.IsSeen);
                                break;
                            }
                        }

                        if (result > 0)
                        {
                            dgv.SelectedCells[0].Value = !last;
                        }
                        else
                        {
                            foreach (DataRow dr in this.DataSource.Rows)
                            {
                                if (dr[keyColumn].ToString() == ID)
                                {
                                    dr["IsSeen"] = last;
                                    break;
                                }
                            }

                            foreach (Movie m in this.movieSource)
                            {
                                if (m.MovieID.ToString() == ID)
                                {
                                    m.IsSeen = last;
                                    break;
                                }
                            }

                            dgv.SelectedCells[0].Value = last;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void ucListGridView_Load(object sender, EventArgs e)
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

        void txtSearch_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text == "")
                {
                    txtSearch.Text = this.DefaultText;
                    txtSearch.ForeColor = Color.Silver;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void txtSearch_GotFocus(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text == this.DefaultText)
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void txtSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text == this.DefaultText)
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public DataGridView DataGridView
        {
            get
            {
                try
                {
                    return dgv;
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
                    this.dgv = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataGridViewColumnCollection DataGridViewColumns
        {
            get
            {
                try
                {
                    return dgv.Columns;
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
                    foreach (DataGridViewColumn d in value)
                    {
                        this.dgv.Columns.Add(d);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataTable DataSource
        {
            set
            {
                try
                {
                    this.dataSource = value;

                    if (this.IsSelectable == true)
                    {
                        this.dataSource.Columns.Add("Selected");
                        DataOperation.InitializeDataTable(ref this.dataSource, "Selected", "0");

                        if (this.baseDataSource.Rows.Count > 0)
                        {
                            DataOperation.SetNewFieldValueFromOriginal(this.baseDataSource, ref this.dataSource, "Selected", this.dataSourceName + "ID");
                        }
                        else
                        {
                            this.baseDataSource = this.dataSource;
                        }
                    }

                    string s = this.DataSourceName;

                    if (s == "Person")
                    {
                        s = "Full";
                    }

                    //txtSearch.AutoCompleteCustomSource = DataOperation.MakeCustomAutoCompleteSource(this.dataSource, s + "Name");

                    if (this.DataSourceName == "Genre")
                    {
                        this.genreSource = Genre.FetchAllGenre(this.dataSource);

                        dgv.Columns["dgvID"].DataPropertyName = "GenreID";
                    }
                    else if (this.DataSourceName == "Movie")
                    {
                        this.movieSource = Movie.FetchAllMovie(this.dataSource);

                        dgv.Columns["dgvID"].DataPropertyName = "MovieID";
                    }
                    else if (this.DataSourceName == "Person")
                    {
                        this.personSource = Person.FetchAllPerson(this.dataSource);

                        dgv.Columns["dgvID"].DataPropertyName = "PersonID";
                    }

                    DataOperation.BindDataGridView(this.dgv, this.dataSource);

                    if (this.DataSourceName == "Movie")
                    {
                        ReplaceQuality();
                    }

                    lblCountValue.Text = dgv.Rows.Count.ToString();
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
                    return this.dataSource;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string DataSourceName
        {
            set
            {
                try
                {
                    this.dataSourceName = value;
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
                    return this.dataSourceName;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string ListType
        {
            set
            {
                try
                {
                    this.listType = value;
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
                    return this.listType;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string DefaultText
        {
            set
            {
                try
                {
                    this.defaultText = value;
                    txtSearch.Text = value;
                    this.lastQuery = value;
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
                    return this.defaultText;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool IsSelectable
        {
            set
            {
                try
                {
                    if (value == true)
                    {
                        dgv.Columns["dgvSelected"].DataPropertyName = "Selected";
                        dgv.Columns["dgvSelected"].Visible = true;
                        chkAll.Visible = true;
                    }
                    else
                    {
                        dgv.Columns["dgvSelected"].DataPropertyName = null;
                        dgv.Columns["dgvSelected"].Visible = false;
                        chkAll.Visible = false;
                    }
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
                    return chkAll.Visible;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool IsDirector
        {
            set
            {
                try
                {
                    this.isDirector = value;
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
                    return this.isDirector;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool IsActor
        {
            set
            {
                try
                {
                    this.isActor = value;
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
                    return this.isActor;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public int HeaderHeight
        {
            set
            {
                try
                {
                    if (value > 20)
                    {
                        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                        dgv.ColumnHeadersHeight = value;
                    }
                    else
                    {
                        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                    }
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
                    return dgv.ColumnHeadersHeight;
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

        public bool AcceptDoubleClick
        {
            set
            {
                try
                {
                    this.acceptDoubleClick = value; 
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
                    return this.acceptDoubleClick;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text != this.DefaultText && lastQuery != this.DefaultText)
                {
                    string filter = txtSearch.Text.Trim();

                    int nameLen = (filter.Length / 2) + 1;

                    while (nameLen >= 0)
                    {
                        filter = filter.Replace("  ", " ");

                        nameLen--;
                    }

                    switch (this.DataSourceName)
                    {
                        case "Genre":

                            this.DataSource.DefaultView.RowFilter = String.Format("GenreName LIKE '%{0}%'", filter);

                            break;

                        case "Person":
                     
                            this.DataSource.DefaultView.RowFilter = String.Format("FullName LIKE '%{0}%'", filter); 

                            break;

                        case "Movie":

                            this.DataSource.DefaultView.RowFilter = String.Format("MovieName LIKE '%{0}%'", filter);
                            
                            break;

                        default:
                            break;
                    }

                    lblCountValue.Text = dgv.RowCount.ToString();
                }

                this.lastQuery = txtSearch.Text;
            }
            catch
            {
            }
        }

        private void ReplaceQuality()
        {
            try
            {
                if(this.DataSourceName == "Movie")
                {
                    foreach (DataGridViewRow dr in dgv.Rows)
                    {
                        switch (dr.Cells["dgvOriginalQuality"].Value.ToString())
                        {
                            case "1":
                                dr.Cells["dgvQuality"].Value = Enums.GetVideoQuality(enVideoQuality.VCD);
                                break;

                            case "2":
                                dr.Cells["dgvQuality"].Value = Enums.GetVideoQuality(enVideoQuality.DVD);
                                break;

                            case "3":
                                dr.Cells["dgvQuality"].Value = Enums.GetVideoQuality(enVideoQuality._720p);
                                break;

                            case "4":
                                dr.Cells["dgvQuality"].Value = Enums.GetVideoQuality(enVideoQuality._1080p);
                                break;

                            case "5":
                                dr.Cells["dgvQuality"].Value = Enums.GetVideoQuality(enVideoQuality.Indeterminate);
                                break;

                            default:
                                dr.Cells["dgvQuality"].Value = Enums.GetVideoQuality(enVideoQuality.Indeterminate);
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string[] SelectedID
        {
            get
            {
                try
                {
                    string[] id = new string[0];

                    foreach (DataRow dr in this.baseDataSource.Rows)
                    {
                        if (dr["Selected"].ToString() == "1")
                        {
                            DataOperation.AppendElement(ref id, dr[this.DataSourceName + "ID"].ToString());
                        }
                    }

                    return id;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool SelectAll
        {
            get
            {
                try
                {
                    return chkAll.Checked;
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
                    chkAll.Checked = value;
                    chkAll_Click(new object(), new EventArgs());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool AutoGenerateColumns
        {
            get
            {
                try
                {
                    return dgv.AutoGenerateColumns;
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
                    dgv.AutoGenerateColumns = value;
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
                    if (value == false)
                    {
                        dgv.Focus();
                    }
                    else
                    {
                        txtSearch.Focus();
                    }
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
                    txtSearch.Text = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void mnuContextDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                int row = dgv.CurrentCell.RowIndex;

                if (row >= 0)
                {
                    string name = "";

                    switch (this.DataSourceName)
                    {
                        case "Movie":

                            name = dgv.Rows[row].Cells["dgvMovieName"].Value.ToString();

                            if (dgv.Rows[row].Cells["dgvProductYear"].Value != null &&
                                dgv.Rows[row].Cells["dgvProductYear"].Value != DBNull.Value &&
                                dgv.Rows[row].Cells["dgvProductYear"].Value.ToString() != null &&
                                dgv.Rows[row].Cells["dgvProductYear"].Value.ToString() != "" &&
                                dgv.Rows[row].Cells["dgvProductYear"].Value.ToString() != "-")
                            {
                                name += " [" + dgv.Rows[row].Cells["dgvProductYear"].Value.ToString() + "]";
                            }

                            name += " [" + dgv.Rows[row].Cells["dgvQuality"].Value.ToString() + "]";

                            break;

                        case "Person":

                            if (this.IsActor == true)
                            {
                                name = dgv.Rows[row].Cells["dgvActorName"].Value.ToString();
                            }
                            else if (this.IsDirector == true)
                            {
                                name = dgv.Rows[row].Cells["dgvDirectorName"].Value.ToString();
                            }

                            break;

                        case "Genre":

                            name = dgv.Rows[row].Cells["dgvGenreName"].Value.ToString();

                            break;
                    }

                    long result = 0;
                    int id = Convert.ToInt32(dgv.Rows[row].Cells["dgvID"].Value.ToString());

                    if (MessageBox.Show(Messages.AreYouSureDeleteItem + Environment.NewLine + name, Messages.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        switch (this.DataSourceName)
                        {
                            case "Movie":

                                result = Movie_SP.Delete(id);

                                break;

                            case "Person":

                                result = Person_SP.Delete(id);

                                break;

                            case "Genre":

                                result = Genre_SP.Delete(id);

                                break;
                        }

                        if (result > 0)
                        {
                            dgv.Rows.Remove(dgv.Rows[row]);
                            lblCountValue.Text = dgv.Rows.Count.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public bool IsDeletable
        {
            get
            { 
                try
                {
                    if (mnuContextRight.Items.Contains(mnuContextDeleteItem) == true)
                    {
                        return true;
                    }
                    {
                        return false;
                    }
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
                    if (value == true)
                    {
                        if (mnuContextRight.Items.Contains(mnuContextDeleteItem) == false)
                        {
                            mnuContextRight.Items.Add(mnuContextDeleteItem);
                        }

                        dgv.Columns["dgvMovieName"].ContextMenuStrip = mnuContextRight;
                        dgv.Columns["dgvActorName"].ContextMenuStrip = mnuContextRight;
                        dgv.Columns["dgvDirectorName"].ContextMenuStrip = mnuContextRight;
                        dgv.Columns["dgvGenreName"].ContextMenuStrip = mnuContextRight;
                    }
                    else
                    {
                        if (mnuContextRight.Items.Contains(mnuContextDeleteItem) == true)
                        {
                            mnuContextRight.Items.Remove(mnuContextDeleteItem);
                        }

                        if (this.IsForceUpdatable == false && this.IsUpdatable == false && 
                            IsUpdatableFromURL == false && IsCopyRequestable == false &&
                            IsRemovable == false)
                        {
                            dgv.Columns["dgvMovieName"].ContextMenuStrip = null;
                            dgv.Columns["dgvActorName"].ContextMenuStrip = null;
                            dgv.Columns["dgvDirectorName"].ContextMenuStrip = null;
                            dgv.Columns["dgvGenreName"].ContextMenuStrip = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool IsForceUpdatable
        {
            get
            { 
                try  
                {
                    if (mnuContextRight.Items.Contains(mnuContextForceUpdateOnline) == true)
                    {
                        return true;
                    }
                    {
                        return false;
                    }
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
                    if (value == true)
                    {
                        if (mnuContextRight.Items.Contains(mnuContextForceUpdateOnline) == false)
                        {
                            mnuContextRight.Items.Add(mnuContextForceUpdateOnline);
                        }

                        dgv.Columns["dgvMovieName"].ContextMenuStrip = mnuContextRight;
                        dgv.Columns["dgvActorName"].ContextMenuStrip = mnuContextRight;
                        dgv.Columns["dgvDirectorName"].ContextMenuStrip = mnuContextRight;
                        dgv.Columns["dgvGenreName"].ContextMenuStrip = mnuContextRight;
                    }
                    else
                    {
                        if (mnuContextRight.Items.Contains(mnuContextForceUpdateOnline) == true)
                        {
                            mnuContextRight.Items.Remove(mnuContextForceUpdateOnline);
                        }

                        if (this.IsDeletable == false && this.IsUpdatable == false && 
                            IsUpdatableFromURL == false && IsCopyRequestable == false &&
                            IsRemovable == false)
                        {
                            dgv.Columns["dgvMovieName"].ContextMenuStrip = null;
                            dgv.Columns["dgvActorName"].ContextMenuStrip = null;
                            dgv.Columns["dgvDirectorName"].ContextMenuStrip = null;
                            dgv.Columns["dgvGenreName"].ContextMenuStrip = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool IsUpdatable
        {
            get
            {
                try
                {
                    if (mnuContextRight.Items.Contains(mnuContextUpdate) == true)
                    {
                        return true;
                    }
                    {
                        return false;
                    }
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
                    if (value == true)
                    {
                        if (mnuContextRight.Items.Contains(mnuContextUpdate) == false)
                        {
                            mnuContextRight.Items.Add(mnuContextUpdate);
                        }

                        dgv.Columns["dgvMovieName"].ContextMenuStrip = mnuContextRight;
                        dgv.Columns["dgvActorName"].ContextMenuStrip = mnuContextRight;
                        dgv.Columns["dgvDirectorName"].ContextMenuStrip = mnuContextRight;
                        dgv.Columns["dgvGenreName"].ContextMenuStrip = mnuContextRight;
                    }
                    else
                    {
                        if (mnuContextRight.Items.Contains(mnuContextUpdate) == true)
                        {
                            mnuContextRight.Items.Remove(mnuContextUpdate);
                        }

                        if (this.IsDeletable == false && this.IsForceUpdatable == false && 
                            IsUpdatableFromURL == false && IsCopyRequestable == false &&
                            IsRemovable == false)
                        {
                            dgv.Columns["dgvMovieName"].ContextMenuStrip = null;
                            dgv.Columns["dgvActorName"].ContextMenuStrip = null;
                            dgv.Columns["dgvDirectorName"].ContextMenuStrip = null;
                            dgv.Columns["dgvGenreName"].ContextMenuStrip = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool IsUpdatableFromURL
        {
            get 
            {
                try
                {
                    if (mnuContextRight.Items.Contains(mnuContextUpdateURL) == true)
                    {
                        return true;
                    }
                    {
                        return false;
                    }
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
                    if (value == true)
                    {
                        if (mnuContextRight.Items.Contains(mnuContextUpdateURL) == false)
                        {
                            mnuContextRight.Items.Add(mnuContextUpdateURL);
                        }

                        dgv.Columns["dgvMovieName"].ContextMenuStrip = mnuContextRight;
                        dgv.Columns["dgvActorName"].ContextMenuStrip = mnuContextRight;
                        dgv.Columns["dgvDirectorName"].ContextMenuStrip = mnuContextRight;
                        dgv.Columns["dgvGenreName"].ContextMenuStrip = mnuContextRight;
                    }
                    else
                    {
                        if (mnuContextRight.Items.Contains(mnuContextUpdateURL) == true)
                        {
                            mnuContextRight.Items.Remove(mnuContextUpdateURL);
                        }

                        if (this.IsDeletable == false && this.IsForceUpdatable == false && 
                            IsUpdatable == false && IsCopyRequestable == false &&
                            IsRemovable == false)
                        {
                            dgv.Columns["dgvMovieName"].ContextMenuStrip = null;
                            dgv.Columns["dgvActorName"].ContextMenuStrip = null;
                            dgv.Columns["dgvDirectorName"].ContextMenuStrip = null;
                            dgv.Columns["dgvGenreName"].ContextMenuStrip = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool IsCopyRequestable
        {
            get
            {
                try
                {
                    if (mnuContextRight.Items.Contains(mnuContextRequestCopy) == true)
                    {
                        return true;
                    }
                    {
                        return false;
                    }
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
                    if (value == true)
                    {
                        if (mnuContextRight.Items.Contains(mnuContextRequestCopy) == false)
                        {
                            mnuContextRight.Items.Add(mnuContextRequestCopy);
                        }

                        dgv.Columns["dgvMovieName"].ContextMenuStrip = mnuContextRight;
                        dgv.Columns["dgvActorName"].ContextMenuStrip = mnuContextRight;
                        dgv.Columns["dgvDirectorName"].ContextMenuStrip = mnuContextRight;
                        dgv.Columns["dgvGenreName"].ContextMenuStrip = mnuContextRight;
                    }
                    else
                    {
                        if (mnuContextRight.Items.Contains(mnuContextRequestCopy) == true)
                        {
                            mnuContextRight.Items.Remove(mnuContextRequestCopy);
                        }

                        if (this.IsDeletable == false && this.IsForceUpdatable == false && 
                            IsUpdatable == false && IsUpdatableFromURL == false &&
                            IsRemovable == false)
                        {
                            dgv.Columns["dgvMovieName"].ContextMenuStrip = null;
                            dgv.Columns["dgvActorName"].ContextMenuStrip = null;
                            dgv.Columns["dgvDirectorName"].ContextMenuStrip = null;
                            dgv.Columns["dgvGenreName"].ContextMenuStrip = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool IsRemovable
        {
            get
            {
                try
                {
                    if (mnuContextRight.Items.Contains(mnuContextRemove) == true)
                    {
                        return true;
                    }
                    {
                        return false;
                    }
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
                    if (value == true)
                    {
                        if (mnuContextRight.Items.Contains(mnuContextRemove) == false)
                        {
                            mnuContextRight.Items.Add(mnuContextRemove);
                        }

                        dgv.Columns["dgvMovieName"].ContextMenuStrip = mnuContextRight;
                        dgv.Columns["dgvActorName"].ContextMenuStrip = mnuContextRight;
                        dgv.Columns["dgvDirectorName"].ContextMenuStrip = mnuContextRight;
                        dgv.Columns["dgvGenreName"].ContextMenuStrip = mnuContextRight;
                    }
                    else
                    {
                        if (mnuContextRight.Items.Contains(mnuContextRemove) == true)
                        {
                            mnuContextRight.Items.Remove(mnuContextRemove);
                        }

                        if (this.IsDeletable == false && this.IsForceUpdatable == false &&
                            IsUpdatable == false && IsUpdatableFromURL == false &&
                            IsCopyRequestable == false)
                        {
                            dgv.Columns["dgvMovieName"].ContextMenuStrip = null;
                            dgv.Columns["dgvActorName"].ContextMenuStrip = null;
                            dgv.Columns["dgvDirectorName"].ContextMenuStrip = null;
                            dgv.Columns["dgvGenreName"].ContextMenuStrip = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool EnableRightClick
        {
            get
            { 
                try
                {
                    return mnuContextRight.Enabled;
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
                    mnuContextRight.Enabled = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void mnuContextForceUpdateOnline_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dgv.CurrentCell.RowIndex;
                string name = "";

                if (rowIndex >= 0) 
                {
                    if (DataOperation.IsConnected() == true)
                    {
                        long ID = Convert.ToInt64(dgv.Rows[rowIndex].Cells["dgvID"].Value);

                        DataTable dt = new DataTable();

                        switch (this.DataSourceName)
                        {
                            case "Movie":

                                name = dgv.Rows[rowIndex].Cells["dgvMovieName"].Value.ToString();

                                if (dgv.Rows[rowIndex].Cells["dgvProductYear"].Value.ToString() != null &&
                                    dgv.Rows[rowIndex].Cells["dgvProductYear"].Value.ToString() != "" &&
                                    dgv.Rows[rowIndex].Cells["dgvProductYear"].Value.ToString() != "-" &&
                                    dgv.Rows[rowIndex].Cells["dgvProductYear"].Value != DBNull.Value &&
                                    dgv.Rows[rowIndex].Cells["dgvProductYear"].Value != null)
                                {
                                    name += " [" + dgv.Rows[rowIndex].Cells["dgvProductYear"].Value.ToString() + "]";
                                }

                                name += " [" + dgv.Rows[rowIndex].Cells["dgvQuality"].Value.ToString() + "]";

                                if (MessageBox.Show(Messages.ForceUpdateSure.Replace("\n", Environment.NewLine) + Environment.NewLine + name, Messages.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    dt = Movie_SP.GetByID(ID);

                                    if (dt.Rows.Count > 0)
                                    {
                                        string logName = "iMovie Update Log [" + Helper.GetShortDateTimeString().Replace(":", "-") + "].txt";
                                        iMovieBase.log.Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), logName);

                                        Thread SecondThread = new Thread(
                                        new ThreadStart(() =>
                                        {
                                            try
                                            {
                                                this.runningCount++;

                                                dlUpdateToolTip dlTip = new dlUpdateToolTip(UpdateToolTip);
                                                BeginInvoke(dlTip);

                                                dlUpdateLabel dlLabel = new dlUpdateLabel(UpdateLabel);
                                                BeginInvoke(dlLabel, true);

                                                if (this.ExitRequest == false)
                                                {
                                                    Movie m = new Movie();
                                                    m.FetchSingleMovie(dt);

                                                    enUpdateResult res = enUpdateResult.UpdateError;
                                                    res = Movie_SP.UpdateOnline(m, true, true, true, true, true, true, true,
                                                        true, true, true, true, true, false, true, true, null);

                                                    if (res == enUpdateResult.Updated)
                                                    {
                                                        dlGeneral dl = new dlGeneral(UpdateRow);
                                                        BeginInvoke(dl, ID);
                                                    }
                                                }

                                                this.runningCount--;

                                                if (this.runningCount == 0)
                                                {
                                                    BeginInvoke(dlLabel, false);
                                                }

                                                dlUpdateToolTip dlTip2 = new dlUpdateToolTip(UpdateToolTip);
                                                BeginInvoke(dlTip2);

                                                return;
                                            }
                                            catch (Exception ex)
                                            {
                                                this.runningCount--;

                                                if (this.runningCount == 0)
                                                {
                                                    dlUpdateLabel dlLabel = new dlUpdateLabel(UpdateLabel);
                                                    BeginInvoke(dlLabel, false);
                                                }

                                                dlUpdateToolTip dlTip = new dlUpdateToolTip(UpdateToolTip);
                                                BeginInvoke(dlTip);

                                                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }));

                                        SecondThread.Start();
                                    }
                                }

                                break;

                            case "Person":

                                if (this.IsActor == true)
                                {
                                    name = dgv.Rows[rowIndex].Cells["dgvActorName"].Value.ToString();
                                }
                                else if (this.IsDirector == true)
                                {
                                    name = dgv.Rows[rowIndex].Cells["dgvDirectorName"].Value.ToString();
                                }

                                break;

                            case "Genre":

                                name = dgv.Rows[rowIndex].Cells["dgvGenreName"].Value.ToString();

                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show(Messages.NotConnected, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateRow(long ID)
        { 
            try
            {
                if (ID > 0)
                {
                    int rowIndex = -1;

                    foreach (DataGridViewRow dgvr in dgv.Rows)
                    {
                        if (Convert.ToInt64(dgvr.Cells["dgvID"].Value) == ID)
                        {
                            rowIndex = dgvr.Index;
                        }
                    }

                    if (rowIndex >= 0)
                    {
                        DataTable dt = new DataTable();

                        switch (this.DataSourceName)
                        {
                            case "Movie":

                                dt = Movie_SP.GetByID(ID);

                                if (dt.Rows.Count > 0)
                                {
                                    Movie m = new Movie();
                                    m.FetchSingleMovie(dt);

                                    if (m.ProductYear != 0)
                                    {
                                        dgv.Rows[rowIndex].Cells["dgvProductYear"].Value = m.ProductYear;
                                    }
                                    else
                                    {
                                        dgv.Rows[rowIndex].Cells["dgvProductYear"].Value = DBNull.Value;
                                    }

                                    dgv.Rows[rowIndex].Cells["dgvDuration"].Value = m.Duration;
                                    dgv.Rows[rowIndex].Cells["dgvIMDBRate"].Value = m.IMDBRate;
                                }

                                break;

                            case "Person":

                                break;

                            case "Genre":

                                break;
                        }
                    }
                }

                return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsRunning
        {
            get
            {
                try
                {
                    if (this.runningCount <= 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool ExitRequest
        {
            get
            {
                try
                {
                    return this.exitRequest;
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
                    this.exitRequest = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void UpdateLabel(bool show)
        {
            try
            {
                lblUpdate.Visible = show;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateToolTip()
        {
            try
            {
                if (runningCount > 0)
                {
                    if (runningCount == 1)
                    {
                        toolTip.SetToolTip(lblUpdate, runningCount.ToString() + " Update in progress...");
                    }
                    else
                    {
                        toolTip.SetToolTip(lblUpdate, runningCount.ToString() + " Updates in progress...");
                    }
                }
                else
                {
                    toolTip.SetToolTip(lblUpdate, "No updates in progress");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void mnuContextUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dgv.CurrentCell.RowIndex;

                if (rowIndex >= 0)
                {
                    if (DataOperation.IsConnected() == true)
                    {
                        long ID = Convert.ToInt64(dgv.Rows[rowIndex].Cells["dgvID"].Value);

                        DataTable dt = new DataTable();

                        switch (this.DataSourceName)
                        {
                            case "Movie":

                                dt = Movie_SP.GetByID(ID);

                                if (dt.Rows.Count > 0)
                                {
                                    string logName = "iMovie Update Log [" + Helper.GetShortDateTimeString().Replace(":", "-") + "].txt";
                                    iMovieBase.log.Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), logName);

                                    Thread SecondThread = new Thread(
                                    new ThreadStart(() =>
                                    {
                                        try
                                        {
                                            this.runningCount++;

                                            dlUpdateToolTip dlTip = new dlUpdateToolTip(UpdateToolTip);
                                            BeginInvoke(dlTip);

                                            dlUpdateLabel dlLabel = new dlUpdateLabel(UpdateLabel);
                                            BeginInvoke(dlLabel, true);

                                            if (this.ExitRequest == false)
                                            {
                                                Movie m = new Movie();
                                                m.FetchSingleMovie(dt);

                                                enUpdateResult res = enUpdateResult.UpdateError;
                                                res = Movie_SP.UpdateOnline(m, true, true, true, true, true, true,
                                                    true, true, true, true, true, true, true, true, false, null);

                                                if (res == enUpdateResult.Updated)
                                                {
                                                    dlGeneral dl = new dlGeneral(UpdateRow);
                                                    BeginInvoke(dl, ID);
                                                }
                                            }

                                            this.runningCount--;

                                            if (this.runningCount == 0)
                                            {
                                                BeginInvoke(dlLabel, false);
                                            }

                                            dlUpdateToolTip dlTip2 = new dlUpdateToolTip(UpdateToolTip);
                                            BeginInvoke(dlTip2);

                                            return;
                                        }
                                        catch (Exception ex)
                                        {
                                            this.runningCount--;

                                            if (this.runningCount == 0)
                                            {
                                                dlUpdateLabel dlLabel = new dlUpdateLabel(UpdateLabel);
                                                BeginInvoke(dlLabel, false);
                                            }

                                            dlUpdateToolTip dlTip = new dlUpdateToolTip(UpdateToolTip);
                                            BeginInvoke(dlTip);

                                            MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }));

                                    SecondThread.Start();
                                }

                                break;

                            case "Person":

                                break;

                            case "Genre":

                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show(Messages.NotConnected, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuContextUpdateURL_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dgv.CurrentCell.RowIndex;

                if (rowIndex >= 0)
                {
                    if (DataOperation.IsConnected() == true)
                    {
                        long ID = Convert.ToInt64(dgv.Rows[rowIndex].Cells["dgvID"].Value);

                        DataTable dt = new DataTable();

                        switch (this.DataSourceName)
                        {
                            case "Movie":

                                dt = Movie_SP.GetByID(ID);

                                Movie m = new Movie();
                                m.FetchSingleMovie(dt);
          
                                if (FormManager.IsFormOpen(enForms.frmGetURL, null) == false)
                                {
                                    frmGetURL url = new frmGetURL(m);

                                    if (url.ShowDialog() == DialogResult.OK)
                                    {
                                        if (dt.Rows.Count > 0 && url.url.Length > 0)
                                        {
                                            string lastUrl = m.IMDBLink;

                                            try
                                            {
                                                if (File.Exists(PathUtils.GetApplicationMoviePosterPath() + m.FullTitle + ".jpg") == true)
                                                {
                                                    File.Move(PathUtils.GetApplicationMoviePosterPath() + m.FullTitle + ".jpg", PathUtils.GetApplicationTempPath() + m.FullTitle + "Temp.jpg");
                                                }
                                            }
                                            catch (Exception ex)
                                            {

                                            }

                                            string logName = "iMovie Update Log [" + Helper.GetShortDateTimeString().Replace(":", "-") + "].txt";
                                            iMovieBase.log.Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), logName);

                                            Thread SecondThread = new Thread(
                                            new ThreadStart(() =>
                                            {
                                                try
                                                {
                                                    this.runningCount++;

                                                    dlUpdateToolTip dlTip = new dlUpdateToolTip(UpdateToolTip);
                                                    BeginInvoke(dlTip);

                                                    dlUpdateLabel dlLabel = new dlUpdateLabel(UpdateLabel);
                                                    BeginInvoke(dlLabel, true);

                                                    if (this.ExitRequest == false)
                                                    {
                                                        enUpdateResult res = enUpdateResult.UpdateError;
                                                        res = Movie_SP.UpdateOnlineFromIMDb(url.url, m, true, true, true, true, true,
                                                            true, true, true, true, true, true, false, true, null);

                                                        if (res == enUpdateResult.Updated)
                                                        {
                                                            dlGeneral dl = new dlGeneral(UpdateRow);
                                                            BeginInvoke(dl, ID);

                                                            File.Delete(PathUtils.GetApplicationTempPath() + m.FullTitle + "Temp.jpg");
                                                        }
                                                        else
                                                        {
                                                            m.IMDBLink = lastUrl;

                                                            if (File.Exists(PathUtils.GetApplicationTempPath() + m.FullTitle + "Temp.jpg") == true)
                                                            {
                                                                File.Move(PathUtils.GetApplicationTempPath() + m.FullTitle + "Temp.jpg", PathUtils.GetApplicationMoviePosterPath() + m.FullTitle + ".jpg");
                                                            }
                                                        }
                                                    }

                                                    this.runningCount--;

                                                    if (this.runningCount == 0)
                                                    {
                                                        BeginInvoke(dlLabel, false);
                                                    }

                                                    dlUpdateToolTip dlTip2 = new dlUpdateToolTip(UpdateToolTip);
                                                    BeginInvoke(dlTip2);

                                                    return;
                                                }
                                                catch (Exception ex)
                                                {
                                                    this.runningCount--;

                                                    if (this.runningCount == 0)
                                                    {
                                                        dlUpdateLabel dlLabel = new dlUpdateLabel(UpdateLabel);
                                                        BeginInvoke(dlLabel, false);
                                                    }

                                                    dlUpdateToolTip dlTip = new dlUpdateToolTip(UpdateToolTip);
                                                    BeginInvoke(dlTip);

                                                    MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                            }));

                                            SecondThread.Start();
                                        }
                                    }
                                }

                                break;

                            case "Person":

                                break;

                            case "Genre":

                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show(Messages.NotConnected, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuContextRequestCopy_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewCell dgvc in dgv.SelectedCells)
                {
                    int row = dgvc.RowIndex;
                    int id = Convert.ToInt32(dgv.Rows[row].Cells["dgvID"].Value.ToString());

                    if (row >= 0)
                    {
                        switch (this.DataSourceName)
                        {
                            case "Movie":

                                Movie_SP.RequestMovieCopyInsert(id);

                                break;

                            case "Person":

                                break;

                            case "Genre":

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

        private void mnuContextRemove_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewCell dgvc in dgv.SelectedCells)
                {
                    int row = dgvc.RowIndex;
                    int id = Convert.ToInt32(dgv.Rows[row].Cells["dgvID"].Value.ToString());
                    long result = 0;

                    if (row >= 0)
                    {
                        switch (this.DataSourceName)
                        {
                            case "Movie":

                                if (this.ListType == "RequestCopy")
                                {
                                    result = Movie_SP.RequestMovieCopyDelete(id);
                                }
                                else if (this.ListType == "Request")
                                {
                                }
                                else if (this.ListType == "ToWatch")
                                {
                                }

                                break;

                            case "Person":

                                break;

                            case "Genre":

                                break;
                        }
                    }

                    if (result > 0)
                    {
                        dgv.Rows.Remove(dgv.Rows[row]);
                        lblCountValue.Text = dgv.Rows.Count.ToString();
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
