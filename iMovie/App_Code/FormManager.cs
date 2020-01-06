using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace iMovie
{
    class FormManager
    {
        public static bool IsFormOpen(enForms form, object ID)
        {
            try
            {
                switch (form)
                {
                    case enForms.frmMovie:

                        foreach (Form frm in Application.OpenForms)
                        {
                            if ((frm is frmMovie) && (frm as frmMovie).MovieID == Convert.ToInt64(ID))
                            {
                                frm.WindowState = FormWindowState.Normal;
                                frm.Focus();
                                return true;
                            }
                        }

                        return false;

                    case enForms.frmPerson:

                        foreach (Form frm in Application.OpenForms)
                        {
                            if ((frm is frmPerson) && (frm as frmPerson).PersonID == Convert.ToInt64(ID))
                            {
                                frm.WindowState = FormWindowState.Normal;
                                frm.Focus();
                                return true;
                            }
                        }

                        return false;

                    case enForms.frmLogin:

                        foreach (Form frm in Application.OpenForms)
                        {
                            if (frm is frmLogin)
                            {
                                frm.WindowState = FormWindowState.Normal;
                                frm.Focus();
                                return true;
                            }
                        }

                        return false;

                    case enForms.frmStatistics:

                        foreach (Form frm in Application.OpenForms)
                        {
                            if (frm is frmStatistics)
                            {
                                frm.WindowState = FormWindowState.Normal;
                                frm.Focus();
                                return true;
                            }
                        }

                        return false;

                    case enForms.frmMain:

                        foreach (Form frm in Application.OpenForms)
                        {
                            if (frm is frmMain)
                            {
                                frm.WindowState = FormWindowState.Normal;
                                frm.Focus();
                                return true;
                            }
                        }

                        return false;

                    case enForms.frmMovieSuggestList:

                        foreach (Form frm in Application.OpenForms)
                        {
                            if ((frm is frmMovieSuggestList) && Movie.IsEqual((frm as frmMovieSuggestList).DataSource, (ID as Movie[])) == true)
                            {
                                frm.WindowState = FormWindowState.Normal;
                                frm.Focus();
                                return true;
                            }
                        }

                        return false;

                    case enForms.frmFavoriteMovieList:

                        foreach (Form frm in Application.OpenForms)
                        {
                            if (frm is frmFavoriteMovieList)
                            {
                                frm.WindowState = FormWindowState.Normal;
                                frm.Focus();
                                return true;
                            }
                        }

                        return false;

                    case enForms.frmMovieList:

                        foreach (Form frm in Application.OpenForms)
                        {
                            if (frm is frmMovieList)
                            {
                                frm.WindowState = FormWindowState.Normal;
                                frm.Focus();
                                return true;
                            }
                        }

                        return false;

                    case enForms.frmAdvancedSuggest:

                        foreach (Form frm in Application.OpenForms)
                        {
                            if (frm is frmAdvancedSuggest)
                            {
                                frm.WindowState = FormWindowState.Normal;
                                frm.Focus();
                                return true;
                            }
                        }

                        return false;

                    case enForms.frmPersonList:

                        foreach (Form frm in Application.OpenForms)
                        {
                            if (frm is frmPersonList && (frm as frmPersonList).PersonType == ID.ToString())
                            {
                                frm.WindowState = FormWindowState.Normal;
                                frm.Focus();
                                return true;
                            }
                        }

                        return false;

                    case enForms.frmSearchArea:

                        foreach (Form frm in Application.OpenForms)
                        {
                            if (frm is frmSearchArea)
                            {
                                frm.WindowState = FormWindowState.Normal;
                                frm.Focus();
                                return true;
                            }
                        }

                        return false;

                    case enForms.frmAbout:

                        foreach (Form frm in Application.OpenForms)
                        {
                            if (frm is frmAbout)
                            {
                                frm.WindowState = FormWindowState.Normal;
                                frm.Focus();
                                return true;
                            }
                        }

                        return false;

                    case enForms.frmBatchMovie:

                        foreach (Form frm in Application.OpenForms)
                        {
                            if (frm is frmBatchMovie)
                            {
                                frm.WindowState = FormWindowState.Normal;
                                frm.Focus();
                                return true;
                            }
                        }

                        return false;

                    case enForms.frmOnlineMovieUpdate:

                        foreach (Form frm in Application.OpenForms)
                        {
                            if (frm is frmOnlineMovieUpdate)
                            {
                                frm.WindowState = FormWindowState.Normal;
                                frm.Focus();
                                return true;
                            }
                        }

                        return false;

                    case enForms.frmRootPathInsert:

                        foreach (Form frm in Application.OpenForms)
                        {
                            if (frm is frmRootPathInsert)
                            {
                                frm.WindowState = FormWindowState.Normal;
                                frm.Focus();
                                return true;
                            }
                        }

                        return false;

                    case enForms.frmUserInsert:

                        foreach (Form frm in Application.OpenForms)
                        {
                            if (frm is frmUserInsert)
                            {
                                frm.WindowState = FormWindowState.Normal;
                                frm.Focus();
                                return true;
                            }
                        }

                        return false;

                    case enForms.frmInsertSingleMovie:

                        foreach (Form frm in Application.OpenForms)
                        {
                            if (frm is frmInsertSingleMovie)
                            {
                                frm.WindowState = FormWindowState.Normal;
                                frm.Focus();
                                return true;
                            }
                        }

                        return false;

                    case enForms.frmGetURL:

                        foreach (Form frm in Application.OpenForms)
                        {
                            if (frm is frmGetURL)
                            {
                                frm.WindowState = FormWindowState.Normal;
                                frm.Focus();
                                return true;
                            }
                        }

                        return false;

                    case enForms.frmCopyRequestList:

                        foreach (Form frm in Application.OpenForms)
                        {
                            if (frm is frmCopyRequestList)
                            {
                                frm.WindowState = FormWindowState.Normal;
                                frm.Focus();
                                return true;
                            }
                        }

                        return false;

                    case enForms.frmReportConsole:

                        foreach (Form frm in Application.OpenForms)
                        {
                            if (frm is frmReportConsole)
                            {
                                frm.WindowState = FormWindowState.Normal;
                                frm.Focus();
                                return true;
                            }
                        }

                        return false;

                    case enForms.frmShowReport:

                        foreach (Form frm in Application.OpenForms)
                        {
                            if (frm is frmShowReport)
                            {
                                frm.WindowState = FormWindowState.Normal;
                                frm.Focus();
                                return true;
                            }
                        }

                        return false;

                    default:

                        return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ValidateAccessAllForm()
        {
            try
            {
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm is frmMovie)
                    {
                        (frm as frmMovie).ValidateAccess();
                    }

                    if (frm is frmPerson)
                    {
                        (frm as frmPerson).ValidateAccess();
                    }

                    if (frm is frmMovieSuggestList)
                    {
                        (frm as frmMovieSuggestList).ValidateAccess();
                    }

                    if (frm is frmMain)
                    {
                        (frm as frmMain).ValidateAccess();
                    }

                    if (frm is frmFavoriteMovieList)
                    {
                        (frm as frmFavoriteMovieList).ValidateAccess();
                    }

                    if (frm is frmMovieList)
                    {
                        (frm as frmMovieList).ValidateAccess();
                    }

                    if (frm is frmAdvancedSuggest)
                    {
                        (frm as frmAdvancedSuggest).ValidateAccess();
                    }

                    if (frm is frmPersonList)
                    {
                        (frm as frmPersonList).ValidateAccess();
                    }

                    if (frm is frmSearchArea)
                    {
                        (frm as frmSearchArea).ValidateAccess();
                    }

                    if (frm is frmCopyRequestList)
                    {
                        (frm as frmCopyRequestList).ValidateAccess();
                    }

                    if (frm is frmReportConsole)
                    {
                        (frm as frmReportConsole).ValidateAccess();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
