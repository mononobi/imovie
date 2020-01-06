using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace iMovie
{
    public partial class ucPathListBox : UserControl
    {
        private List<PathSource> dataSource = new List<PathSource>();

        public ucPathListBox()
        {
            InitializeComponent();

            lstPath.MouseDown += lstPath_MouseDown;
        }

        void lstPath_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                int i = lstPath.IndexFromPoint(e.Location);

                if (i >= 0)
                {
                    lstPath.SelectedIndex = i;

                    if (e.Button == MouseButtons.Right)
                    {
                        lstPath.ContextMenuStrip = mnuContextDelete;
                        lstPath.ContextMenuStrip.Show(Cursor.Position);
                    }
                }
                else
                {
                    lstPath.ContextMenuStrip = null;
                    lstPath.SelectedIndex = -1;
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
                    txtPath.Text = fldRoot.SelectedPath;
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
                string path = txtPath.Text;

                if (Directory.Exists(path) == true)
                {
                    List<PathSource> list = this.DataSource;
                    PathSource newPath = new PathSource(path);

                    if (this.IsExists(newPath) == false)
                    {
                        this.DataSource = null;
                        list.Add(newPath);
                        this.DataSource = list;

                        txtPath.Text = "";
                    }
                    else
                    {
                        throw new Exception(Messages.AlreadyExistPathString);
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

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<PathSource> DataSource
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
                    lstPath.DisplayMember = "PathString";
                    lstPath.ValueMember = "PathID";
                    this.dataSource = value;
                    lstPath.DataSource = this.dataSource;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string Path
        {
            set
            {
                this.txtPath.Text = value;
            }
            get
            {
                return this.txtPath.Text;
            }
        }

        private void mnuContextDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstPath.SelectedIndex >= 0)
                {
                    string name = lstPath.GetItemText(lstPath.SelectedItem);

                    if (MessageBox.Show(Messages.AreYouSureDeleteItem + Environment.NewLine + name, Messages.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        PathSource item = (PathSource)lstPath.SelectedItem;
                        List<PathSource> list = this.DataSource;
                        this.DataSource = null;
                        list.Remove(item);
                        this.DataSource = list;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsExists(PathSource newPath)
        {
            foreach (PathSource ps in this.DataSource)
            {
                if (ps.PathString.Equals(newPath.PathString, StringComparison.CurrentCultureIgnoreCase) == true)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
