using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.PowerPacks;

namespace iMovie
{
    public partial class ucPersonRepeater : UserControl
    {
        private Person[] dataSource = new Person[0];
         
        public ucPersonRepeater()
        {
            InitializeComponent();
            repPerson.ItemValueNeeded += repPerson_ItemValueNeeded;
            this.Load += ucPersonRepeater_Load;
        }

        void repPerson_ItemValueNeeded(object sender, DataRepeaterItemValueEventArgs e)
        {
            try
            {
                if (e.ItemIndex < this.dataSource.Length)
                {
                    switch (e.Control.Name)
                    {
                        case "picPerson":

                            if (File.Exists(PathUtils.GetApplicationPersonPath() + this.dataSource[e.ItemIndex].PhotoLink) == true)
                            {
                                try
                                {
                                    e.Value = Image.FromFile(PathUtils.GetApplicationPersonPath() + this.dataSource[e.ItemIndex].PhotoLink);
                                }
                                catch
                                {
                                    // Do nothing for image that is corrupted
                                }
                            }
                            break;

                        case "lblPersonName":

                            e.Value = this.dataSource[e.ItemIndex].FullName;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void ucPersonRepeater_Load(object sender, EventArgs e)
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

        private void picPerson_Click(object sender, EventArgs e)
        {
            try
            {
                int index = repPerson.CurrentItemIndex;

                if (FormManager.IsFormOpen(enForms.frmPerson, this.DataSource[index].PersonID) == false)
                {
                    frmPerson personTemp = new frmPerson(this.DataSource[index].PersonID);

                    personTemp.Show();
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
                repPerson.BeginResetItemTemplate();
                repPerson.EndResetItemTemplate();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataRepeater PersonRepeater
        {
            get
            {
                try
                {
                    return this.repPerson;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Person[] DataSource
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

                    DataOperation.LoadDataRepeater(this.dataSource, repPerson);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
