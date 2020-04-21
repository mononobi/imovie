using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace iMovie
{
    public class Movie
    {
        public const int MovieID_Min_Value = 1;
        public const int MovieName_Min_Length = 1;
        public const int MovieName_Max_Length = 100;
        public const int ProductYear_Min_Value = 1901;
        public const int ProductYear_Max_Value = 2099;
        public const int IMDBRate_Min_Value = 0;
        public const int IMDBRate_Max_Value = 10;
        public static TimeSpan Duration_Min_Value = new TimeSpan(0, 0, 0);
        public const int PosterLink_Min_Length = 0;
        public const int PosterLink_Max_Length = 250;
        public const int FileLink_Min_Length = 0;
        public const int FileLink_Max_Length = 250;
        public const int IMDBLink_Min_Length = 0;
        public const int IMDBLink_Max_Length = 250;
        public const int FavoriteRate_Min_Value = 0;
        public const int FavoriteRate_Max_Value = 10;
        public const int StoryLine_Min_Length = 0;
        public const int StoryLine_Max_Length = 5000;
         
        private long movieID = 0; 
        private string movieName = ""; 
        private int productYear = 0;
        private DateTime addDate = DateTime.Now;
        private double imdbRate = 0;
        private TimeSpan duration = TimeSpan.Zero;
        private string posterLink = "";
        private string fileLink = "";
        private bool isSeen = false;
        private string imdbLink = "";
        private enVideoQuality quality = enVideoQuality.Indeterminate;
        private int favoriteRate = 0;
        private string storyLine = "";

        private Person[] director = new Person[0];
        private Person[] actor = new Person[0]; 
        private Language[] language = new Language[0];
        private Genre[] genre = new Genre[0];

        public Movie(long movieID, string movieName, int productYear, DateTime addDate,
                     double imdbRate, TimeSpan duration, string posterLink, string fileLink,
                     bool isSeen, string imdbLink, enVideoQuality quality, string storyLine, int favoriteRate)
        {
            try
            {
                string result = ""; 

                if (Movie.Validate(movieID, movieName, productYear, addDate, imdbRate, duration, posterLink, fileLink, isSeen, imdbLink, quality, storyLine, favoriteRate, out result) == true)
                { 
                    this.MovieID = movieID;
                    this.MovieName = movieName;
                    this.ProductYear = productYear;
                    this.AddDate = addDate;
                    this.IMDBRate = imdbRate;
                    this.Duration = duration;
                    this.PosterLink = posterLink;
                    this.FileLink = fileLink;
                    this.IsSeen = isSeen;
                    this.IMDBLink = imdbLink;
                    this.Quality = quality;
                    this.FavoriteRate = favoriteRate;
                    this.StoryLine = storyLine;
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

        public Movie()
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Validate(long movieID, string movieName, int productYear, DateTime addDate,
                                    double imdbRate, TimeSpan duration, string posterLink, string fileLink,
                                    bool isSeen, string imdbLink, enVideoQuality quality, string storyLine, int favoriteRate, out string result)
        { 
            try
            {
                result = "";

                if (IsMovieID(movieID.ToString()) == false)
                {
                    result += Messages.InvalidMovieID + Environment.NewLine;
                }

                if (IsMovieName(movieName) == false)
                {
                    result += Messages.InvalidMovieName + Environment.NewLine;
                }

                if (IsProductYear(productYear.ToString()) == false)
                {
                    result += Messages.InvalidProductYear + Environment.NewLine;
                }

                if (IsIMDBRate(imdbRate.ToString()) == false)
                {
                    result += Messages.InvalidIMDBRate + Environment.NewLine;
                }

                if (IsDuration(duration.ToString()) == false)
                {
                    result += Messages.InvalidDuration + Environment.NewLine;
                }

                if (IsPosterLink(posterLink) == false)
                {
                    result += Messages.InvalidPosterLink + Environment.NewLine;
                }

                if (IsFileLink(fileLink) == false)
                {
                    result += Messages.InvalidFileLink + Environment.NewLine;
                }

                if (IsIMDBLink(imdbLink) == false)
                {
                    result += Messages.InvalidIMDBLink + Environment.NewLine;
                }

                if (IsFavoriteRate(favoriteRate.ToString()) == false)
                {
                    result += Messages.InvalidFavoriteRate + Environment.NewLine;
                }

                if (IsStoryLine(storyLine) == false)
                {
                    result += Messages.InvalidStoryLine + Environment.NewLine;
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

        public long MovieID
        {
            get
            {
                try
                {
                    return this.movieID;
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
                    if (IsMovieID(value.ToString()) == true)
                    {
                        this.movieID = value;
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidMovieID);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string MovieName
        {
            get
            {
                try
                {
                    return this.movieName;
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
                    if (IsMovieName(value) == true)
                    {
                        this.movieName = value;
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidMovieName);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public int ProductYear
        {
            get
            {
                try
                {
                    return this.productYear;
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
                    if (IsProductYear(value.ToString()) == true)
                    {
                        this.productYear = value;
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidProductYear);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DateTime AddDate
        {
            get
            {
                try
                {
                    return this.addDate;
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
                    this.addDate = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public double IMDBRate
        {
            get
            { 
                try
                {
                    return this.imdbRate;
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
                    if (IsIMDBRate(value.ToString()) == true)
                    {
                        this.imdbRate = value;
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidIMDBRate);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public TimeSpan Duration
        {
            get
            {
                try
                {
                    return this.duration;
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
                    if (IsDuration(value.ToString()) == true)
                    {
                        this.duration = value;
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidDuration);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string PosterLink
        {
            get
            {
                try
                {
                    return this.posterLink;
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
                    if (IsPosterLink(value) == true)
                    {
                        this.posterLink = value;
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidPosterLink);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string FileLink
        {
            get
            {
                try
                {
                    return this.fileLink;
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
                    if (IsFileLink(value) == true)
                    {
                        this.fileLink = value;
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidFileLink);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool IsSeen
        {
            get
            {
                try
                {
                    return this.isSeen;
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
                    this.isSeen = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string IMDBLink
        {
            get
            {
                try
                {
                    return this.imdbLink;
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
                    if (IsIMDBLink(value) == true)
                    {
                        this.imdbLink = value.TrimEnd('/');
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidIMDBLink);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public enVideoQuality Quality
        {
            get
            {
                try 
                {
                    return this.quality;
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
                    this.quality = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string StoryLine
        {
            get
            {
                try
                {
                    return this.storyLine;
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
                    if (IsStoryLine(value) == true)
                    {
                        this.storyLine = value;
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidStoryLine);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public int FavoriteRate
        {
            get
            {
                try
                {
                    return this.favoriteRate;
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
                    if (IsFavoriteRate(value.ToString()) == true)
                    {
                        this.favoriteRate = value;
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidFavoriteRate);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string FullTitle
        {
            get
            {
                try
                {
                    if (this.ProductYear != 0)
                    {
                        return this.MovieName + " (" + this.ProductYear.ToString() + ")";
                    }
                    else
                    {
                        return this.MovieName;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Person[] Director
        {
            get 
            {
                try
                {
                    return this.director;
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
                    this.director = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Person[] Actor
        {
            get
            {
                try
                {
                    return this.actor;
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
                    this.actor = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Language[] Language
        {
            get
            {
                try
                {
                    return this.language;
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
                    this.language = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Genre[] Genre
        {
            get
            {
                try
                {
                    return this.genre;
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
                    this.genre = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string FileNamingTitle
        {
            get
            {
                try
                {
                    string year = "";

                    if (this.ProductYear != 0)
                    {
                        year = this.ProductYear.ToString();
                    }

                    string title = this.MovieName + " [" + year + "] [" + Enums.GetVideoQuality(this.Quality) + "]";

                    return title;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static bool IsMovieID(string value)
        {
            try
            {
                long tmp = 0;

                if (long.TryParse(value, out tmp) == true)
                {
                    if (tmp >= MovieID_Min_Value || tmp == 0)
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

        public static bool IsMovieName(string value)
        {
            try
            {
                if (value.Length >= MovieName_Min_Length && value.Length <= MovieName_Max_Length)
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

        public static bool IsProductYear(string value)
        {
            try 
            {
                int tmp = 0;

                if (int.TryParse(value, out tmp) == true)
                {
                    if ((tmp >= ProductYear_Min_Value && tmp <= ProductYear_Max_Value) || tmp == 0)
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

        public static bool IsIMDBRate(string value)
        {
            try
            {
                double tmp = 0;

                if (double.TryParse(value, out tmp) == true)
                {
                    if ((tmp >= IMDBRate_Min_Value && tmp <= IMDBRate_Max_Value) || tmp == 0)
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

        public static bool IsDuration(string value)
        {
            try
            {
                TimeSpan tmp = new TimeSpan(0, 0, 0);

                if (TimeSpan.TryParse(value, out tmp) == true)
                {
                    if (tmp >= Duration_Min_Value || tmp == TimeSpan.Zero)
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

        public static bool IsPosterLink(string value)
        {
            try 
            {
                if (value.Length >= PosterLink_Min_Length && value.Length <= PosterLink_Max_Length)
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

        public static bool IsFileLink(string value)
        {
            try
            {
                if (value.Length >= FileLink_Min_Length && value.Length <= FileLink_Max_Length)
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

        public static bool IsIMDBLink(string value)
        {
            try
            { 
                if (value.Length >= IMDBLink_Min_Length && value.Length <= IMDBLink_Max_Length)
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

        public static bool IsFavoriteRate(string value)
        {
            try
            {
                int tmp = 0;

                if (int.TryParse(value, out tmp) == true)
                {
                    if ((tmp >= FavoriteRate_Min_Value && tmp <= FavoriteRate_Max_Value) || tmp == 0)
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

        public static bool IsStoryLine(string value)
        {
            try
            {
                if (value.Length >= StoryLine_Min_Length && value.Length <= StoryLine_Max_Length)
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

        public void FetchSingleMovie(DataTable dtMovie)
        {
            try
            {
                if (dtMovie.Rows.Count >= 1)
                {
                    Movie movie = FetchAllMovie(dtMovie)[0];

                    this.MovieID = movie.MovieID;
                    this.MovieName = movie.MovieName;
                    this.ProductYear = movie.ProductYear;
                    this.AddDate = movie.AddDate;
                    this.IMDBRate = movie.IMDBRate;
                    this.Duration = movie.Duration;
                    this.PosterLink = movie.PosterLink;
                    this.FileLink = movie.FileLink;
                    this.IsSeen = movie.IsSeen;
                    this.IMDBLink = movie.IMDBLink;
                    this.Quality = movie.Quality;
                    this.FavoriteRate = movie.FavoriteRate;
                    this.StoryLine = movie.StoryLine;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Movie[] FetchAllMovie(DataTable dtMovie)
        {
            try
            {
                Movie[] movieTemp = new Movie[dtMovie.Rows.Count];
                int i = 0;
                while (i < dtMovie.Rows.Count)
                {
                    movieTemp[i] = new Movie();
                    if (dtMovie.Rows[i]["ProductYear"].ToString() == null ||
                        dtMovie.Rows[i]["ProductYear"].ToString() == "" ||
                        dtMovie.Rows[i]["ProductYear"].ToString() == "-" ||
                        dtMovie.Rows[i]["ProductYear"] == DBNull.Value ||
                        dtMovie.Rows[i]["ProductYear"] == null)
                    {
                        movieTemp[i].ProductYear = 0;
                    }
                    else
                    {
                        movieTemp[i].ProductYear = Convert.ToInt32(dtMovie.Rows[i]["ProductYear"].ToString());
                    }

                    movieTemp[i].MovieID = Convert.ToInt64(dtMovie.Rows[i]["MovieID"].ToString());
                    movieTemp[i].MovieName = dtMovie.Rows[i]["MovieName"].ToString();
                    movieTemp[i].AddDate = Convert.ToDateTime(dtMovie.Rows[i]["AddDate"].ToString());
                    movieTemp[i].IMDBRate = Convert.ToDouble(dtMovie.Rows[i]["IMDBRate"].ToString());
                    movieTemp[i].Duration = DataOperation.ToTimeSpan(dtMovie.Rows[i]["Duration"].ToString());
                    movieTemp[i].PosterLink = dtMovie.Rows[i]["PosterLink"].ToString();
                    movieTemp[i].FileLink = dtMovie.Rows[i]["FileLink"].ToString();
                    movieTemp[i].IsSeen = Convert.ToBoolean(dtMovie.Rows[i]["IsSeen"].ToString());
                    movieTemp[i].IMDBLink = dtMovie.Rows[i]["IMDBLink"].ToString();
                    movieTemp[i].Quality = Enums.ToEnum<enVideoQuality>(Convert.ToInt32(dtMovie.Rows[i]["Quality"].ToString()));
                    movieTemp[i].StoryLine = dtMovie.Rows[i]["StoryLine"].ToString();

                    if (dtMovie.Rows[i]["FavoriteRate"].ToString() != null && dtMovie.Rows[i]["FavoriteRate"].ToString().Length > 0)
                    {
                        movieTemp[i].FavoriteRate = Convert.ToInt32(dtMovie.Rows[i]["FavoriteRate"].ToString());
                    }

                    i++;
                }

                return movieTemp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool IsEqual(Movie[] firstMovie, Movie[] secondMovie)
        {
            try
            {
                if (firstMovie.Length == secondMovie.Length)
                {
                    int len = secondMovie.Length;
                    int i = 0;
                    bool flag = false;

                    foreach (Movie mov in firstMovie)
                    {
                        i = 0;
                        flag = false;

                        while (i < len)
                        {
                            if (mov.MovieID == secondMovie[i].MovieID)
                            {
                                flag = true;
                                break;
                            }
     
                            i++;
                        }

                        if (flag == false)
                        {
                            return false;
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;

                throw ex;
            }
        }
    }
}
