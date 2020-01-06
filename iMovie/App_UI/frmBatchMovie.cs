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
    public partial class frmBatchMovie : Form
    {
        private InsertManager insertManager = new InsertManager(true, false);
        private Thread SecondThread = null;
        private delegate void DelegateGeneral();
        private delegate void DelegateName(string text);
        bool isRunning = false;

        public frmBatchMovie()
        { 
            InitializeComponent(); 
        }

        private void frmBatchMovie_Load(object sender, EventArgs e)
        {
            try
            {
                string path = "";
                path = RegistryManager.GetValue(Messages.RootKey, Messages.SubKeyLastBatchInsertPath);

                if (path != null && path.Length > 0 && Directory.Exists(path) == true)
                {
                    fldRoot.SelectedPath = path;
                }
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
                    lblMovie.Text = "";

                    if (Directory.Exists(path) == true)
                    {
                        string[] folders = new string[0];
                        folders = Directory.GetDirectories(path);
                        prgBatch.Maximum = folders.Length;
                        string logName = "iMovie Insert Log [" + Helper.GetShortDateTimeString().Replace(":", "-") + "].txt";
                        iMovieBase.log.Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), logName);
                        bool addRoot = chkAsRoot.Checked;
                        bool includeIndividual = chkIndividual.Checked;

                        SecondThread = new Thread(
                        new ThreadStart(() =>
                        {
                            try
                            {
                                isRunning = true;
                                insertManager.ExitRequest = false;

                                try
                                {
                                    if (addRoot == true)
                                    {
                                        Movie_SP.RootPathInsert(path);
                                    }
                                }
                                catch (Exception ex)
                                {
                                }

                                insertManager.InsertMovieBatch(path, includeIndividual, this);

                                while (prgBatch.Value < prgBatch.Maximum)
                                {
                                    InvokeHandle();
                                }

                                InvokeHandle("");

                                isRunning = false;
                                insertManager.ExitRequest = false;

                                DelegateGeneral dlResetText = new DelegateGeneral(ResetPath);
                                BeginInvoke(dlResetText);

                                MessageBox.Show(Messages.InsertComplete + Environment.NewLine + Messages.LogCreated + Environment.NewLine + logName, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                RegistryManager.WriteValue(path, Messages.RootKey, Messages.SubKeyLastBatchInsertPath);

                                return;
                            }
                            catch (Exception ex)
                            {
                                isRunning = false;
                                insertManager.ExitRequest = false;

                                DelegateGeneral dlReset = new DelegateGeneral(ResetProgress);
                                BeginInvoke(dlReset);

                                InvokeHandle("");

                                MessageBox.Show(Messages.InsertError + Environment.NewLine + Messages.LogCreated + Environment.NewLine + ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void InvokeHandle(string text)
        {
            try
            {
                DelegateName dlName = new DelegateName(GetCurrentName);
                BeginInvoke(dlName, text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetCurrentName(string text)
        {
            try
            {
                lblMovie.Text = text;
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
