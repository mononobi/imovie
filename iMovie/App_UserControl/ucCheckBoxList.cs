using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace iMovie
{
    public partial class ucCheckBoxList : UserControl
    {
        private DataTable dataSource = new DataTable();
        private string dataSourceName = "";
        private int checkedCount = 0;

        public ucCheckBoxList()
        {
            InitializeComponent();

            this.Load += ucCheckBoxList_Load;
            chkAll.Click += chkAll_Click;
            chkList.SelectedIndexChanged += chkList_SelectedIndexChanged;
        }

        void chkList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                checkedCount = SelectedID.Length;

                if (checkedCount == chkList.Items.Count)
                {
                    chkAll.Checked = true;
                }
                else
                {
                    chkAll.Checked = false;
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

                if (state == true)
                {
                    checkedCount = chkList.Items.Count;
                }
                else
                {
                    checkedCount = 0;
                }

                DataOperation.ToggleAllItems(chkList, state);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void ucCheckBoxList_Load(object sender, EventArgs e)
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

        public DataTable DataSource
        {
            set
            {
                try
                {
                    this.dataSource = value;

                    DataOperation.BindCheckListBox(chkList, this.dataSource, this.DataSourceName + "Name");
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

        public string[] SelectedID
        {
            get
            {
                try
                {
                    string[] index = new string[0];
                    index = DataOperation.GetCheckedIndexes(chkList);
                    int i = 0;
                    string[] id = new string[0];

                    foreach (string s in index)
                    {
                        DataOperation.AppendElement(ref id, this.DataSource.Rows[Convert.ToInt32(index[i])][this.DataSourceName + "ID"].ToString());
                        i++;
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
                    chkAll_Click(new object(),new EventArgs());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public CheckedListBox CheckListBox
        {
            get 
            {
                try
                {
                    return this.chkList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
