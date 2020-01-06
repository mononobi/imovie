using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace iMovie
{
    public partial class frmUserInsert : Form
    {
        public frmUserInsert()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                string confirm = txtConfirm.Text;
                string fname = txtFName.Text;
                string lname = txtLName.Text;
                string mail = txtMail.Text;

                Users newUser = new Users(0, username, password, fname, lname, mail);

                if (password != confirm)
                {
                    throw new Exception(Messages.PasswordAndConfirmationNotMatch);
                }
                else
                {
                    long result = 0;

                    result = Users_SP.Insert(newUser);

                    if (result > 0)
                    {
                        MessageBox.Show(Messages.UserCreatedOK, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
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
