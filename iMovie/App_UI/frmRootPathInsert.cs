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
    public partial class frmRootPathInsert : Form
    {
        public frmRootPathInsert()
        {
            InitializeComponent();

            lstRootPath.MouseDown += lstRootPath_MouseDown;
        }

        void lstRootPath_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                int i = lstRootPath.IndexFromPoint(e.Location);

                if (i >= 0)
                {
                    lstRootPath.SelectedIndex = i;

                    if (e.Button == MouseButtons.Right)
                    {
                        lstRootPath.ContextMenuStrip = mnuContextDelete;
                        lstRootPath.ContextMenuStrip.Show(Cursor.Position);
                    }
                }
                else
                {
                    lstRootPath.ContextMenuStrip = null;
                    lstRootPath.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            try
            {
                if (fldRoot.ShowDialog() == DialogResult.OK)
                {
                    txtRootPath.Text = fldRoot.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string path = txtRootPath.Text;

                if (Directory.Exists(path) == true)
                {
                    long res = Movie_SP.RootPathInsert(path);

                    if (res > 0)
                    {
                        txtRootPath.Text = "";
                        LoadRootPaths();
                    }
                }
                else
                {
                    throw new Exception(Messages.InvalidTargetPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRootPaths()
        {
            try
            {
                iMovieBase.MovieRootPath = Movie_SP.RootPathGetList();

                lstRootPath.DisplayMember = "PathString";
                lstRootPath.ValueMember = "PathID";
                lstRootPath.DataSource = iMovieBase.MovieRootPath;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmRootPathInsert_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRootPaths();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuContextDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstRootPath.SelectedIndex >= 0)
                {
                    string name = lstRootPath.GetItemText(lstRootPath.SelectedItem);
                    long id = Convert.ToInt64(lstRootPath.SelectedValue);

                    if (MessageBox.Show(Messages.AreYouSureDeleteItem + Environment.NewLine + name, Messages.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        long result = Movie_SP.RootPathDelete(id);

                        if (result > 0)
                        {
                            LoadRootPaths();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
