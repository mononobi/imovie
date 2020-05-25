using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;
using System.Net;
using System.Drawing;

namespace iMovie
{
    public class DataOperation
    {
        public static TimeSpan ToTimeSpan(string timeSpan)
        {
            try
            {
                string[] fields = timeSpan.Split(':');

                TimeSpan ts = new TimeSpan(Convert.ToInt32(fields[0]), Convert.ToInt32(fields[1]), Convert.ToInt32(fields[2]));

                return ts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void BindListBox(DataTable dataSource, ListBox listBox, string valueMember, string displayMember)
        { 
            try
            {
                listBox.DisplayMember = displayMember;
                listBox.ValueMember = valueMember;
                listBox.DataSource = dataSource;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void HideTabPage(TabControl tab, TabPage tabPage)
        {
            try 
            {
                tab.TabPages.Remove(tabPage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ShowTabPage(TabControl tab, TabPage tabPage, int index)
        {
            try
            { 
                tab.TabPages.Insert(index, tabPage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void LoadDataRepeater(object dataSource, DataRepeater repeater)
        {
            try 
            {
                repeater.VirtualMode = true;
                repeater.DataSource = dataSource;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SetFavoriteRate(int rate, DataRepeater repeater, ref Movie[] movieDataSource)
        {
            try 
            {
                long count = 0;
                int index = repeater.CurrentItemIndex;
                int lastRate = movieDataSource[index].FavoriteRate;

                movieDataSource[index].FavoriteRate = rate;

                if (rate == 0)
                {
                    count = Movie_SP.FavoriteDelete(movieDataSource[index].MovieID);
                }
                else
                {
                    count = Movie_SP.FavoriteInsert(movieDataSource[index].MovieID, rate);
                }

                if (count >= 0)
                {
                    repeater.BeginResetItemTemplate();
                    repeater.EndResetItemTemplate();
                }
                else
                {
                    movieDataSource[index].FavoriteRate = lastRate;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void RequestCopy(DataRepeater repeater, ref Movie[] movieDataSource)
        {
            try
            {
                int index = repeater.CurrentItemIndex;
                Movie_SP.RequestMovieCopyInsert(movieDataSource[index].MovieID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static void SetIsSeen(bool isSeen, DataRepeater repeater, ref Movie[] movieDataSource)
        { 
            try 
            {
                long count = 0;
                int index = repeater.CurrentItemIndex;
                bool lastIsSeen = movieDataSource[index].IsSeen;

                movieDataSource[index].IsSeen = isSeen;

                count = Movie_SP.UpdateIsSeen(movieDataSource[index].MovieID, movieDataSource[index].IsSeen);

                if (count > 0)
                {
                    repeater.BeginResetItemTemplate();
                    repeater.EndResetItemTemplate();
                }
                else
                {
                    movieDataSource[index].IsSeen = lastIsSeen;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static void SetIsSeen(bool isSeen, ref Movie movie, PictureBox picIsSeen, ToolTip tip)
        {
            try
            {
                long count = 0;
                bool lastIsSeen = movie.IsSeen;

                movie.IsSeen = isSeen;
                count = Movie_SP.UpdateIsSeen(movie.MovieID, movie.IsSeen);

                if (count > 0)
                {
                    if (isSeen == true)
                    {
                        picIsSeen.Image = global::iMovie.Properties.Resources.seen;
                        tip.SetToolTip(picIsSeen, Messages.IsSeen);
                    }
                    else
                    {
                        picIsSeen.Image = global::iMovie.Properties.Resources.not_seen;
                        tip.SetToolTip(picIsSeen, Messages.NotSeen);
                    }
                }
                else
                {
                    movie.IsSeen = lastIsSeen;

                    if (lastIsSeen == true)
                    {
                        picIsSeen.Image = global::iMovie.Properties.Resources.seen;
                        tip.SetToolTip(picIsSeen, Messages.IsSeen);
                    }
                    else
                    {
                        picIsSeen.Image = global::iMovie.Properties.Resources.not_seen;
                        tip.SetToolTip(picIsSeen, Messages.NotSeen);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static void SetFavoriteRate(int favoriteRate, ref Movie movie, Label lblFavValue)
        {
            try
            {
                long count = 0;
                int lastRate = movie.FavoriteRate;

                movie.FavoriteRate = favoriteRate;

                if (favoriteRate == 0)
                {
                    count = Movie_SP.FavoriteDelete(movie.MovieID);

                    if (count >= 0)
                    {
                        lblFavValue.Text = "-";
                    }
                    else
                    {
                        movie.FavoriteRate = lastRate;

                        if (lastRate == 0)
                        {
                            lblFavValue.Text = "-";
                        }
                        else
                        {
                            lblFavValue.Text = lastRate.ToString();
                        }
                    }
                }
                else
                {
                    count = Movie_SP.FavoriteInsert(movie.MovieID, favoriteRate);

                    if (count > 0)
                    {
                        lblFavValue.Text = favoriteRate.ToString();
                    }
                    else
                    {
                        movie.FavoriteRate = lastRate;

                        if (lastRate == 0)
                        {
                            lblFavValue.Text = "-";
                        }
                        else
                        {
                            lblFavValue.Text = lastRate.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Removes an element at specified index of an array
        /// </summary>
        /// <param name="array">
        /// Input array</param>
        /// <param name="index">
        /// The index of element to be removed</param>
        /// <returns>
        /// Number of removed elements</returns>
        public static int RemoveElement(ref Movie[] array, int index)
        {
            try
            {
                int deleteCount = 0;
                int len = array.Length;

                if (len <= 0)
                {
                    return deleteCount;
                }
                else if (len > 0 && index >= 0 && index < len)
                {
                    Movie[] remainElements = new Movie[len - 1];
                    int originalIndex = 0;
                    int remainIndex = 0;

                    foreach (Movie s in array)
                    {
                        if (originalIndex != index)
                        {
                            remainElements[remainIndex] = s;
                            remainIndex++;
                        }
                        else
                        {
                            deleteCount++;
                        }

                        originalIndex++;
                    }

                    array = remainElements;
                }

                return deleteCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void BindDataGridView(DataGridView dgv, object dataSource)
        {
            try
            {
                dgv.DataSource = dataSource;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void InitializeDataTable(ref DataTable dtSource, string columnName, object value)
        {
            try
            {
                foreach (DataRow dr in dtSource.Rows)
                {
                    dr[columnName] = value;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void BindCheckListBox(CheckedListBox checkList, DataTable dtSource, string displayColumn)
        {
            try 
            {
                checkList.Items.Clear();

                foreach (DataRow dr in dtSource.Rows)
                {
                    checkList.Items.Add(dr[displayColumn].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void BindComboBox(ComboBox dropDown, DataTable dtSource, string textField = "Text", string valueField = "Value")
        { 
            try 
            { 
                dropDown.DisplayMember = textField;
                dropDown.ValueMember = valueField;
                dropDown.DataSource = dtSource;
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        public static void ToggleAllItems(CheckedListBox chkl, bool state)
        {
            try 
            {
                for (int i = 0; i < chkl.Items.Count; i++)
                {
                    chkl.SetItemChecked(i, state);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string[] GetCheckedIndexes(CheckedListBox chkl)
        {
            try 
            {
                string[] checkedIndexes = new string[0];
                string checkItems = "";

                for (int i = 0; i < chkl.Items.Count; i++)
                {
                    if (chkl.GetItemChecked(i) == true)
                    {
                        checkItems += i.ToString() + ",";
                    }
                }

                string[] sep = new string[1];
                sep[0] = ",";
                checkedIndexes = checkItems.Split(sep, StringSplitOptions.RemoveEmptyEntries);

                return checkedIndexes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static AutoCompleteStringCollection MakeCustomAutoCompleteSource(DataTable dtSource, string columnName)
        {
            try
            {
                AutoCompleteStringCollection sc = new AutoCompleteStringCollection();

                foreach (DataRow dr in dtSource.Rows)
                {
                    sc.Add(dr[columnName].ToString());
                }

                return sc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SetNewFieldValueFromOriginal(DataTable dtOriginal, ref DataTable dtNew, string columnName, string keyColumnName) 
        {
            try  
            {
                object key = "";
                object value = "";

                foreach (DataRow dr in dtOriginal.Rows)
                {
                    value = dr[columnName];
                    key = dr[keyColumnName];

                    foreach (DataRow row in dtNew.Rows)
                    {
                        if (row[keyColumnName].ToString() == key.ToString())
                        {
                            row[columnName] = value;
                            break;
                        }
                    }
                } 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Appends the specified elements at the end of specified array
        /// </summary>
        /// <param name="array">
        /// Input array</param>
        /// <param name="element">
        /// Elements to be appended</param>
        /// <returns>
        /// Number of appended elements</returns>
        public static int AppendElement(ref string[] array, params string[] element)
        {
            try
            {
                int len = array.Length;
                int newLen = element.Length;

                if (len <= 0)
                {
                    array = new string[newLen];
                    int j = 0;

                    foreach (string e in element)
                    {
                        array[j] = e;
                        j++;
                    }
                }
                else
                {
                    string[] oldElements = new string[len + newLen];
                    int i = 0;

                    foreach (string s in array)
                    {
                        oldElements[i] = s;
                        i++;
                    }

                    int z = len;

                    foreach (string g in element)
                    {
                        oldElements[z] = g;
                        z++;
                    }

                    array = oldElements;
                }

                return newLen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SetQuality(enVideoQuality newQuality, Movie movie, ref PictureBox picQuality)
        {
            try 
            {
                long count = 0;
                enVideoQuality lastQuality = movie.Quality;

                if (lastQuality != newQuality) 
                {
                    movie.Quality = newQuality;

                    count = Movie_SP.UpdateQuality(movie.MovieID, movie.Quality);

                    if (count <= 0)
                    {
                        movie.Quality = lastQuality;
                    }

                    switch (movie.Quality)
                    {
                        case enVideoQuality._1080p:

                            picQuality.Image = global::iMovie.Properties.Resources._1080p;

                            break;

                        case enVideoQuality._720p:

                            picQuality.Image = global::iMovie.Properties.Resources._720p;

                            break;

                        case enVideoQuality.DVD:

                            picQuality.Image = global::iMovie.Properties.Resources.dvd;

                            break;

                        case enVideoQuality.Indeterminate:

                            picQuality.Image = global::iMovie.Properties.Resources.na;

                            break;

                        case enVideoQuality.VCD:

                            picQuality.Image = global::iMovie.Properties.Resources.vcd;

                            break;

                        default:

                            picQuality.Image = global::iMovie.Properties.Resources.na;

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static bool IsConnected()
        {
            try
            {
                IPHostEntry IPH = Dns.GetHostEntry("www.google.com");
                return !string.IsNullOrEmpty(IPH?.HostName);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool IsAvailable(string url)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "HEAD";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                bool result = response?.StatusCode == HttpStatusCode.OK;
                response.Close();

                return result;
            }
            catch
            {
                return false;
            }
        }

        public static void SetFont(Label lbl, string fontName, float fontSize, FontStyle fontStyle)
        {
            try
            {
                foreach (FontFamily ff in iMovieBase.AppFonts.Families) 
                {
                    if (ff.Name.Contains(fontName) == true)
                    {
                        lbl.Font = new Font(ff, fontSize, fontStyle);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string RemoveSequenceNumber(string text)
        {
            try 
            {
                text = text.Trim();
                string seq = "";

                string[] numbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" };
                string[] romanNumbers = { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X" };
                 
                int len = text.Length;
                int index = -1;

                for (int i = len - 1; i >= 0; i--)
                {
                    if (char.IsDigit(text[i]) == true)
                    {
                        seq = text[i].ToString() + seq;
                        index = i;
                    }
                    else
                    {
                        break;
                    }
                }

                if (seq.Length == 0)
                {
                    for (int i = len - 1; i >= 0; i--)
                    {
                        if (text[i].ToString() != " ")
                        {
                            seq = text[i].ToString() + seq;
                            index = i;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (seq.Length > 0)
                {
                    string temp = text;

                    temp = temp.Remove(index);

                    if (temp.Length > 0)
                    {
                        seq = seq.ToUpper();

                        foreach (string s in numbers)
                        {
                            if (seq == s)
                            {
                                text = text.Remove(index);
                                text = text.Trim();
                                return text;
                            }
                        }

                        foreach (string rs in romanNumbers) 
                        {
                            if (seq == rs)
                            { 
                                text = text.Remove(index);
                                text = text.Trim();
                                return text;
                            }
                        }

                        text = text.Trim();
                        return text;
                    }
                    else
                    {
                        text = text.Trim();
                        return text;
                    }
                }
                else
                {
                    text = text.Trim();
                    return text;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
