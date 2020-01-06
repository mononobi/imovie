using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace iMovie
{
    public class Genre
    {
        public const int GenreID_Min_Value = 1;
        public const int GenreName_Min_Length = 1;
        public const int GenreName_Max_Length = 25; 

        private long genreID = 0; 
        private string genreName = "";

        private static string[] MainGenreList = { "animation", "documentary", "short", "sport", "talk-show", "game-show", "reality-tv" };

        public Genre(long genreID, string genreName)
        {
            try
            {
                string result = "";

                if (Genre.Validate(genreID, genreName, out result) == true)
                {
                    this.GenreID = genreID;
                    this.GenreName = genreName;
                }
                else
                {
                    throw new Exception(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Genre()
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Validate(long genreID, string genreName, out string result)
        {
            try
            {
                result = "";

                if (IsGenreID(genreID.ToString()) == false)
                {
                    result += Messages.InvalidGenreID + Environment.NewLine;
                }

                if (IsGenreName(genreName) == false)
                {
                    result += Messages.InvalidGenreName + Environment.NewLine;
                }

                if (result.Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long GenreID
        {
            get
            {
                try
                {
                    return this.genreID;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            set
            {
                try
                {
                    if (IsGenreID(value.ToString()) == true)
                    {
                        this.genreID = value;
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidGenreID);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool IsMain
        {
            get
            {
                return DetectIsMain(this.GenreName);
            }
        }

        public string GenreName
        {
            get
            {
                try
                {
                    return this.genreName;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            set
            {
                try
                {
                    if (IsGenreName(value) == true)
                    {
                        this.genreName = value;
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidGenreName);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static bool IsGenreID(string value)
        {
            try
            {
                long tmp = 0;

                if (long.TryParse(value, out tmp) == true)
                {
                    if (tmp >= GenreID_Min_Value || tmp == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool IsGenreName(string value)
        {
            try
            {
                if (value.Length >= GenreName_Min_Length && value.Length <= GenreName_Max_Length)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FetchSingleGenre(DataTable dtGenre)
        { 
            try
            {
                if (dtGenre.Rows.Count >= 1)
                {
                    Genre genre = FetchAllGenre(dtGenre)[0];

                    this.GenreID = genre.GenreID;
                    this.GenreName = genre.GenreName;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Genre[] FetchAllGenre(DataTable dtGenre)
        {
            try 
            {
                Genre[] genreTemp = new Genre[dtGenre.Rows.Count];
                int i = 0;

                while (i < dtGenre.Rows.Count)
                {
                    genreTemp[i] = new Genre();
                    i++;
                }

                i = 0;

                while (i < dtGenre.Rows.Count)
                {
                    genreTemp[i].GenreID = Convert.ToInt64(dtGenre.Rows[i]["GenreID"].ToString());
                    genreTemp[i].GenreName = dtGenre.Rows[i]["GenreName"].ToString();

                    i++;
                }

                return genreTemp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DetectIsMain(string genreName)
        {
            foreach(string genre in MainGenreList)
            {
                if (genre.ToLower() == genreName.ToLower().Trim())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
