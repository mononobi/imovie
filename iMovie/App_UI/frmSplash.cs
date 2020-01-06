using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace iMovie
{
    public partial class frmSplash : Form
    {
        public frmSplash() 
        {
            InitializeComponent();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            try
            {
                DataOperation.SetFont(lblTitle, enFontNames.Adorable.ToString().Replace("_", " "), 72, FontStyle.Regular);
                lblVersion.Text = Application.ProductVersion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
