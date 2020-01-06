using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace iMovie
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                if (username.Length > 0 && password.Length > 0)
                {
                    DataTable dtLogin = new DataTable();
                    dtLogin = Users_SP.Login(username, password);

                    if (dtLogin != null && dtLogin.Rows.Count == 1)
                    {
                        iMovieBase.User.FetchSingleUser(dtLogin);
                        iMovieBase.IsLogin = true;
                        this.Close();
                    }
                    else
                    {
                        iMovieBase.IsLogin = false;
                        MessageBox.Show(Messages.UsernameAndPasswordNotMatch, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    iMovieBase.IsLogin = false;
                    MessageBox.Show(Messages.InputUsernameAndPassword, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                iMovieBase.IsLogin = false;
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
