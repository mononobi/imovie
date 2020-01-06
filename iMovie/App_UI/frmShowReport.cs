using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace iMovie
{
    public partial class frmShowReport : Form
    {
        private DataSet dataSource = new DataSet();

        public frmShowReport(DataSet source)
        {
            try
            {
                InitializeComponent();
                this.dataSource = source;
                this.FillGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FillGridView()
        {
            try
            {
                int count = this.dataSource.Tables.Count;

                for (int i = 0; i < count; i++)
                {
                    TabPage tabTemp = new TabPage("Table " + (i + 1).ToString());

                    DataGridView dgvTemp = new DataGridView();
                    this.CustomizeGridView(dgvTemp);

                    dgvTemp.DataSource = this.dataSource.Tables[i];
                    tabTemp.Controls.Add(dgvTemp);
                    tab.TabPages.Add(tabTemp);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CustomizeGridView(DataGridView dgv)
        {
            try
            {
                dgv.BackgroundColor = this.BackColor;
                dgv.Dock = DockStyle.Fill;
                dgv.RowHeadersVisible = false;
                dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
                dgv.ReadOnly = true;
                dgv.AutoGenerateColumns = true;
                dgv.AllowUserToAddRows = false;
                dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.ButtonFace);
                dgv.DefaultCellStyle.SelectionBackColor = Color.Khaki;
                dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
