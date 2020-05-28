using System;
using System.Data;
using System.Windows.Forms;

namespace iMovie
{
    public partial class frmReportConsole : frmMaster
    {
        private string[] forbidden = { "insert", "update", "delete", "trigger", "procedure", "create", "drop", "exec", "script", "run", "clear"};

        public frmReportConsole()
        {
            InitializeComponent();
        }

        public void ValidateAccess()
        {
            try
            {
                if (iMovieBase.IsLogin == true)
                {
                    mnuStripInsert.Visible = true;
                    mnuStripClearCache.Enabled = true;
                    mnuContextFavorite.Enabled = true;
                    mnuContextIsSeen.Enabled = true;
                    mnuContextQuality.Enabled = true;
                    mnuContextDelete.Enabled = true;
                    mnuStripClearAllMovie.Enabled = true;
                }
                else
                {
                    mnuStripInsert.Visible = false;
                    mnuStripClearCache.Enabled = false;
                    mnuContextFavorite.Enabled = false;
                    mnuContextIsSeen.Enabled = false;
                    mnuContextQuality.Enabled = false;
                    mnuContextDelete.Enabled = false;
                    mnuStripClearAllMovie.Enabled = false;

                    masterToolTip.RemoveAll();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                string query = txtSQL.Text.Trim();
                string temp = query.ToLower();

                if (temp.Length > 0)
                {
                    foreach (string forbid in this.forbidden)
                    {
                        if (temp.Contains(forbid) == true)
                        {
                            throw new Exception(Messages.ForbiddenKeywords);
                        }
                    }

                    DataSet ds = AccessDatabase.SelectSet(query);

                    if (ds.Tables.Count > 0)
                    {
                        RegistryManager.WriteValue(txtSQL.Text.Trim(), Messages.RootKey, Messages.SubKeyLastSQLReport);

                        frmShowReport report = new frmShowReport(ds);
                        report.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show(Messages.NoQuery, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmReportConsole_Load(object sender, EventArgs e)
        {
            try
            {
                string lastQuery = RegistryManager.GetValue(Messages.RootKey, Messages.SubKeyLastSQLReport);

                if (lastQuery != null && lastQuery.Length > 0)
                {
                    txtSQL.Text = lastQuery.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
