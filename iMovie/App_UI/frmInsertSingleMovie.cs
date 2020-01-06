using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace iMovie
{
    public partial class frmInsertSingleMovie : Form
    {
        private InsertManager insertManager = new InsertManager(false, true);
        private Thread SecondThread = null;
        private delegate void DelegateGeneral(); 
        bool isRunning = false;

        public frmInsertSingleMovie()
        { 
            InitializeComponent(); 
        }

        private void frmBatchMovie_Load(object sender, EventArgs e)
        {
            try
            {
       
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRoot_Click(object sender, EventArgs e)
        {
            try
            {
                if (fldRoot.ShowDialog() == DialogResult.OK)
                {
                    txtRoot.Text = fldRoot.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (isRunning == false)
                {
                    string path = txtRoot.Text;
                    prgBatch.Value = 0;

                    if (Directory.Exists(path) == true)
                    {
                        prgBatch.Maximum = 1;
                      
                        SecondThread = new Thread(
                        new ThreadStart(() =>
                        {
                            try
                            {
                                isRunning = true;
                                insertManager.ExitRequest = false;

                                enInsertResult result = insertManager.InsertMovieSingle(path);
                                string messageResult = "";

                                switch (result)
                                {
                                    case enInsertResult.AlreadyExisted:

                                        messageResult = "It seems that this movie has been already existed.";

                                        break;

                                    case enInsertResult.EmptyFolder:

                                        messageResult = "This folder does not have any movie files.";

                                        break;

                                    case enInsertResult.SuccessfullInsert:

                                        messageResult = "Movie inserted successfully.";

                                        break;

                                    default:

                                        messageResult = "Movie could not be inserted due to an error.";

                                        break;
                                }

                                while (prgBatch.Value < prgBatch.Maximum)
                                {
                                    InvokeHandle();
                                }

                                if(result == enInsertResult.SuccessfullInsert)
                                {
                                    try
                                    {
                                        if (Path.GetDirectoryName(path) != null)
                                        {
                                            Movie_SP.RootPathInsert(Path.GetDirectoryName(path));
                                        }
                                        else
                                        {
                                            Movie_SP.RootPathInsert(path);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                }

                                isRunning = false;
                                insertManager.ExitRequest = false;

                                DelegateGeneral dlResetText = new DelegateGeneral(ResetPath);
                                BeginInvoke(dlResetText);

                                MessageBox.Show(Messages.InsertComplete + Environment.NewLine + messageResult, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                return;
                            }
                            catch (Exception ex)
                            {
                                isRunning = false;
                                insertManager.ExitRequest = false;

                                DelegateGeneral dlReset = new DelegateGeneral(ResetProgress);
                                BeginInvoke(dlReset);

                                MessageBox.Show(Messages.InsertError + Environment.NewLine + ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }));

                        SecondThread.Start();
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidTargetPath);
                    }
                }
                else
                {
                    MessageBox.Show(Messages.WaitForInsert, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                prgBatch.Value = 0;
                insertManager.ExitRequest = false;

                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PerformStep()
        {
            try
            {
                prgBatch.PerformStep();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ResetProgress()
        {
            try 
            {
                prgBatch.Value = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ResetPath()
        {
            try
            {
                txtRoot.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InvokeHandle()
        {
            try
            {
                DelegateGeneral dlStep = new DelegateGeneral(PerformStep);
                BeginInvoke(dlStep);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                switch (e.CloseReason)
                {
                    case CloseReason.UserClosing:

                        if (isRunning == true)
                        {
                            if (MessageBox.Show(Messages.AbortInsert.Replace("\n", Environment.NewLine), Messages.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                insertManager.ExitRequest = true;

                                e.Cancel = true;
                            }
                            else
                            {
                                e.Cancel = true;
                            }
                        }

                        break;
                }

                base.OnFormClosing(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
