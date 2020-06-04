using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Data;

namespace iMovie
{
    public enum enSystemParameters
    {
        Last_Duplicate_Movie_Rebuild = 1
    }

    public enum enVideoQuality
    {
        VCD = 1,
        DVD = 2,
        _720p = 3,
        _1080p = 4,
        Indeterminate = 5
    }

    public enum enOrderType
    {
        asc = 1,
        desc = 2
    }

    public enum enFontNames
    {
        Copperplate_Gothic_Bold = 1,
        All_Caps = 2,
        Adorable = 3
    }
     
    public enum enInsertResult
    {
        EmptyFolder = 1,
        SuccessfullInsert = 2,
        AlreadyExisted = 3,
        Unknown = 4,
        Ignored = 5
    }

    public enum enUpdateResult
    {
        Updated = 1,
        UpdateError = 2,
        NotOpen = 3,
        NoNeedUpdate = 4
    }

    public enum enFilterType
    {
        Exact = 1, 
        Any = 2
    }

    public enum enForms
    {
        frmLogin = 1,
        frmMain = 2,
        frmMaster = 3,
        frmMovie = 4,
        frmPerson = 5,
        frmStatistics = 6,
        frmMovieSuggestList = 7,
        frmFavoriteMovieList = 8,
        frmMovieList = 9,
        frmAdvancedSuggest = 10,
        frmPersonList = 11,
        frmSearchArea = 12,
        frmAbout = 13,
        frmBatchMovie = 14,
        frmOnlineMovieUpdate = 15,
        frmRootPathInsert = 16,
        frmUserInsert = 17,
        frmInsertSingleMovie = 18,
        frmGetURL = 19,
        frmCopyRequestList = 20,
        frmReportConsole = 21,
        frmShowReport = 22,
        frmDuplicateMovieList = 23,
        frmOfflineMovieList = 24
    }

    public class Enums
    {
        /// <summary>
        /// Gets the enum instance of specified value
        /// </summary>
        /// <typeparam name="T">
        /// Enum type</typeparam>
        /// <param name="value">
        /// Enum value</param>
        /// <returns>
        /// Enum type</returns>
        public static T ToEnum<T>(int value) where T : struct, IComparable, IFormattable, IConvertible
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetVideoQuality(enVideoQuality quality)
        {
            try
            {
                string videoQuality = "";

                videoQuality = quality.ToString().Replace("_", "");

                return videoQuality;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetOrderType(enOrderType type)
        {
            try
            {
                string orderType = "";

                if (type.ToString().Equals("asc") == true)
                {
                    orderType = "Ascending";
                }
                else if (type.ToString().Equals("desc") == true)
                {
                    orderType = "Descending";
                }

                return orderType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Converts an Enum type to DataTable
        /// </summary>
        /// <param name="en">
        /// Enum type to be converted</param>
        /// <param name="valueField">
        /// Valuefield of DataTable</param>
        /// <param name="textField">
        /// Textfield of DataTable</param>
        /// <returns>
        /// DataTable</returns>
        public static DataTable ToDataTable(Enum en, string valueField = "Value", string textField = "Text")
        {
            try
            {
                Array array = Enum.GetValues(en.GetType());

                int a = array.Length;
                
                int[] values = new int[a];
                string[] names = new string[a];

                DataTable dt = new DataTable();
                dt.Columns.Add(textField);
                dt.Columns.Add(valueField);
               
                names = Enum.GetNames(en.GetType());

                for (int i = 0; i < a; i++)
                {
                    values[i] = Convert.ToInt32(array.GetValue(i));
                }

                if (en.GetType() == new enVideoQuality().GetType())
                {
                    for (int i = 0; i < a; i++)
                    {
                        names[i] = GetVideoQuality(ToEnum<enVideoQuality>(values[i]));
                    }
                }
                else if (en.GetType() == new enOrderType().GetType())
                {
                    for (int i = 0; i < a; i++)
                    {
                        names[i] = GetOrderType(ToEnum<enOrderType>(values[i]));
                    }
                }
                else
                {
                    return dt;
                }

                object[] obj = new object[2];

                for (int i = 0; i < a; i++)
                {
                    obj[0] = names[i];
                    obj[1] = values[i];
                    dt.Rows.Add(obj);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
