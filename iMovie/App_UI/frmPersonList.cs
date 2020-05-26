using System;
using System.Data;

namespace iMovie
{
    public partial class frmPersonList : frmMaster
    {
        public frmPersonList(DataTable dtPersons, string personType)
        {
            InitializeComponent();
            this.ucPersonList.DtPersons = dtPersons;
            this.ucPersonList.PersonType = personType;
            this.Text = (personType ?? "Person") + " List";
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

                this.ucPersonList.ValidateAccess();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string PersonType
        {
            get
            {
                return this.ucPersonList.PersonType;
            }
        }
    }
}
