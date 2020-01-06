using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace iMovie
{
    public partial class frmGetURL : Form
    {
        private object item = null;
        public string url = "";

        public frmGetURL(object item)
        {
            try
            {
                InitializeComponent();

                this.item = item;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string url = txtURL.Text.Trim();
                
                if (url.Length > 0)
                {
                    this.url = url;
                    btnUpdate.DialogResult = DialogResult.OK;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    btnUpdate.DialogResult = DialogResult.None;
                    this.DialogResult = DialogResult.None;
                    MessageBox.Show(Messages.InputIMDbURL, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmGetURL_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.item != null && (this.item is Movie))
                {
                    lblItemName.Text = (this.item as Movie).FullTitle;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
