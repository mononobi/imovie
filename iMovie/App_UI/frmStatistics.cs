using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace iMovie
{
    public partial class frmStatistics : Form
    {
        public frmStatistics()
        {
            InitializeComponent();
        }

        private void frmStatistics_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtStats = new DataTable();
                dtStats = Movie_SP.GetStatistics();

                if (dtStats.Rows[0]["Value"].ToString() != null && dtStats.Rows[0]["Value"].ToString().Trim().Length > 0)
                {
                    if (dtStats.Rows[0]["Value"].ToString().Contains(".") == true)
                    {
                        double avg = Convert.ToDouble(dtStats.Rows[0]["Value"].ToString());
                        lblRateValue.Text = avg.ToString("#.##");
                    }
                    else
                    {
                        lblRateValue.Text = dtStats.Rows[0]["Value"].ToString();
                    }
                }
                else
                {
                    lblRateValue.Text = "N/A";
                }

                lblAllValue.Text = dtStats.Rows[7]["Value"].ToString();
                lblWatchValue.Text = dtStats.Rows[3]["Value"].ToString();
                lblDirectorValue.Text = dtStats.Rows[1]["Value"].ToString();
                lblActorValue.Text = dtStats.Rows[2]["Value"].ToString();
                lblCacheValue.Text = dtStats.Rows[5]["Value"].ToString();
                lblFavValue.Text = dtStats.Rows[6]["Value"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
