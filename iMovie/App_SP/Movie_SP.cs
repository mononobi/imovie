using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace iMovie
{
    public class Movie_SP
    {
        private readonly static Regex MoviePagePattern = new Regex(@"^.+\.imdb\.com/title/.+$", RegexOptions.IgnoreCase | RegexOptions.Singleline);
        private readonly static string PersonPhotoPath = PathUtils.GetApplicationPersonPath();
        private readonly static string MoviePosterPath = PathUtils.GetApplicationMoviePosterPath();
        private static string[] realValues = { "%", "&", "[", "]", "=", "{", "}", "#", "@", "$", "^", @"""", ";", ",", "?", "/", @"\", ">", "<", "|", "+", "`" };
        private static string[] queryValues = { "%25", "%26", "%5B", "%5D", "%3D", "%7B", "%7D", "%23", "%40", "%24", "%5E", "%22", "%3B", "%2C", "%3F", "%2F", "%5C", "%3E", "%3C", "%7C", "%2B", "%60" };

        public static long Insert(Movie movie)
        {
            try
            {
                object realProductYear = movie.ProductYear;

                if (movie.ProductYear == 0)
                {
                    realProductYear = DBNull.Value;
                }

                long movieID = 0;
                movieID = AccessDatabase.Insert(QueryRepository.Movie_Insert,
                                                "@MovieName", movie.MovieName, "@ProductYear", realProductYear, 
                                                "@AddDate", Helper.GetShortDateTimeString(), "@IMDBRate", movie.IMDBRate,
                                                "@Duration", movie.Duration.ToString(), "@PosterLink", movie.PosterLink,
                                                "@FileLink", movie.FileLink, "@IsSeen", Convert.ToInt32(movie.IsSeen), 
                                                "@IMDBLink", movie.IMDBLink, "@Quality", (int)movie.Quality, "@StoryLine", movie.StoryLine);

                if (movieID <= 0)
                {
                    throw new Exception(Messages.DatabaseError);
                }

                if (movieID > 0)
                {
                    foreach (Person dir in movie.Director)
                    {
                        InsertMovieDirector(movieID, dir.PersonID);
                    }

                    foreach (Person act in movie.Actor)
                    {
                        InsertMovieActor(movieID, act.PersonID);
                    }

                    int i = 0;

                    foreach (Genre gen in movie.Genre)
                    {
                        if (i == 0)
                        {
                            InsertMovieGenre(movieID, gen.GenreID, true);
                        }
                        else
                        {
                            InsertMovieGenre(movieID, gen.GenreID, false);
                        }

                        i++;
                    }

                    foreach (Language lan in movie.Language)
                    {
                        InsertMovieLanguage(movieID, lan.LanguageID);
                    }
                }

                return movieID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long Update(Movie movie)
        {
            try
            {
                object realProductYear = movie.ProductYear;

                if (movie.ProductYear == 0)
                {
                    realProductYear = DBNull.Value;
                }

                long count = 0;
                count = AccessDatabase.Update(QueryRepository.Movie_Update, 
                                              "@MovieID", movie.MovieID,
                                              "@MovieName", movie.MovieName, "@ProductYear", realProductYear, 
                                              "@IMDBRate", movie.IMDBRate, "@Duration", movie.Duration.ToString(), 
                                              "@PosterLink", movie.PosterLink, "@FileLink", movie.FileLink,
                                              "@IsSeen", Convert.ToInt32(movie.IsSeen), "@IMDBLink", movie.IMDBLink, 
                                              "@Quality", (int)movie.Quality, "@StoryLine", movie.StoryLine);

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long UpdateOnline(Movie movie)
        {
            try
            {
                object realProductYear = movie.ProductYear;

                if (movie.ProductYear == 0)
                {
                    realProductYear = DBNull.Value;
                }

                long count = 0;
                count = AccessDatabase.Update(QueryRepository.Movie_Update_Online,
                                              "@MovieID", movie.MovieID, "@ProductYear", realProductYear,
                                              "@IMDBRate", movie.IMDBRate, "@Duration", movie.Duration.ToString(),
                                              "@PosterLink", movie.PosterLink, "@IMDBLink", movie.IMDBLink,
                                              "@StoryLine", movie.StoryLine);

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long UpdateIsSeen(long movieID, bool isSeen)
        {
            try
            {
                long count = 0;
                count = AccessDatabase.Update(QueryRepository.Movie_Update_IsSeen,
                                              "@MovieID", movieID,
                                              "@IsSeen", Convert.ToInt32(isSeen));

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long UpdateQuality(long movieID, enVideoQuality quality)
        {
            try 
            {
                long count = 0;
                count = AccessDatabase.Update(QueryRepository.Movie_Update_Quality,
                                              "@MovieID", movieID,
                                              "@Quality", (int)quality);

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long Delete(long movieID)
        {
            try
            {
                long count = 0;
                count = AccessDatabase.Delete(QueryRepository.Movie_Delete, "@MovieID", movieID);

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long DeleteAll()
        {
            try
            {
                long count = 0;
                count = AccessDatabase.Delete(QueryRepository.Movie_Delete_All);

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long InsertMovieDirector(long movieID, long personID)
        {
            try
            {
                long directorCount = 0;
                directorCount = AccessDatabase.CountFunction(FunctionRepository.CountDirector, "@PersonID", personID);

                if (directorCount <= 0)
                {
                    AccessDatabase.Insert(QueryRepository.Director_Insert, "@PersonID", personID);
                }

                long movieDirectorID = 0;
                movieDirectorID = AccessDatabase.Insert(QueryRepository.Movie_Director_Insert, 
                                                        "@MovieID", movieID, 
                                                        "@PersonID", personID);

                if (movieDirectorID <= 0)
                {
                    throw new Exception(Messages.DatabaseError);
                }

                return movieDirectorID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long InsertMovieActor(long movieID, long personID)
        {
            try 
            {
                long actorCount = 0;
                actorCount = AccessDatabase.CountFunction(FunctionRepository.CountActor, "@PersonID", personID);

                if (actorCount <= 0)
                {
                    AccessDatabase.Insert(QueryRepository.Actor_Insert, "@PersonID", personID);
                }

                long movieActorID = 0;
                movieActorID = AccessDatabase.Insert(QueryRepository.Movie_Actor_Insert,
                                                     "@MovieID", movieID,
                                                     "@PersonID", personID);

                if (movieActorID <= 0)
                {
                    throw new Exception(Messages.DatabaseError);
                }

                return movieActorID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long InsertMovieGenre(long movieID, long genreID, bool isMain)
        {
            try
            {
                int main = 0;
                if (isMain == true)
                {
                    main = 1;
                }

                long movieGenreID = 0;
                movieGenreID = AccessDatabase.Insert(QueryRepository.Movie_Genre_Insert, 
                                                     "@MovieID", movieID, "@GenreID", genreID, 
                                                     "@IsMain", main);

                if (movieGenreID <= 0)
                {
                    throw new Exception(Messages.DatabaseError);
                }

                return movieGenreID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long DeleteMovieGenre(long movieID, long genreID)
        {
            try
            {
                long count = 0;
                count = AccessDatabase.Delete(QueryRepository.Movie_Genre_Delete, 
                                              "@MovieID", movieID,
                                              "@GenreID", genreID);

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long DeleteAllMovieGenre(long movieID)
        {
            long count = 0;
            count = AccessDatabase.Delete(QueryRepository.Movie_Genre_Delete_All,
                                          "@MovieID", movieID);

            return count;
        }

        public static long DeleteMovieLanguage(long movieID, long languageID)
        {
            try
            {
                long count = 0;
                count = AccessDatabase.Delete(QueryRepository.Movie_Language_Delete, 
                                              "@MovieID", movieID,
                                              "@LanguageID", languageID);

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long DeleteAllMovieLanguage(long movieID)
        {
            long count = 0;
            count = AccessDatabase.Delete(QueryRepository.Movie_Language_Delete_All,
                                          "@MovieID", movieID);

            return count;
        }

        public static long DeleteMovieDirector(long movieID, long personID)
        {
            try
            {
                long count = 0;
                count = AccessDatabase.Delete(QueryRepository.Movie_Director_Delete, 
                                              "@MovieID", movieID,
                                              "@PersonID", personID);

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long DeleteMovieActor(long movieID, long personID)
        {
            try
            {
                long count = 0;
                count = AccessDatabase.Delete(QueryRepository.Movie_Actor_Delete,
                                              "@MovieID", movieID,
                                              "@PersonID", personID);

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long DeleteAllMovieDirector(long movieID)
        {
            try
            {
                long count = 0;
                count = AccessDatabase.Delete(QueryRepository.Movie_Director_Delete_All,
                                              "@MovieID", movieID);

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static long DeleteAllMovieActor(long movieID)
        {
            try
            {
                long count = 0;
                count = AccessDatabase.Delete(QueryRepository.Movie_Actor_Delete_All,
                                              "@MovieID", movieID);

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long InsertMovieLanguage(long movieID, long languageID)
        {
            try
            {
                long movieLanguageID = 0;
                movieLanguageID = AccessDatabase.Insert(QueryRepository.Movie_Language_Insert,
                                                        "@MovieID", movieID, 
                                                        "@LanguageID", languageID);

                if (movieLanguageID <= 0)
                {
                    throw new Exception(Messages.DatabaseError);
                }

                return movieLanguageID; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable FilterSearch(string movieName = "", int productYearLower = 1900, int productYearUpper = 2100,
                                             double imdbRateLower = 0, double imdbRateUpper = 10, string durationLower = "00:00:00",
                                             string durationUpper = "10:00:00", bool? isSeen = null, bool? isFavorite = true, 
                                             string orderBy = "Movie.MovieName", enOrderType orderType = enOrderType.asc, 
                                             string[] directorID = null, enFilterType directorFilter = enFilterType.Any, 
                                             string[] actorID = null, enFilterType actorFilter = enFilterType.Any,
                                             string[] genreID = null, enFilterType genreFilter = enFilterType.Any, 
                                             string[] languageID = null, enFilterType languageFilter = enFilterType.Any, 
                                             string[] qualityID = null, List<Movie> ignoreMovies = null)
        {
            try
            {
                DataTable dtSearch = new DataTable();

                string directors = null;
                string actors = null; 
                string genres = null;
                string languages = null;
                string qualities = null;
                string ignoredMovieID = null;
                string productNull = null;
                string excludeFavorite = null;
                string seenMovie = null;
                string joinActor = null;
                string joinDirector = null;
                string joinLanguage = null;
                string joinGenre = null;
                 
                string AnyGenre = " Movie_Genre.GenreID in (@List) ";
                string AnyDirector = " Movie_Director.PersonID in (@List) ";
                string AnyActor = " Movie_Actor.PersonID in (@List) ";
                string AnyLanguage = " Movie_Language.LanguageID in (@List) ";
                string AnyQuality = " Movie.Quality in (@List) ";

                string ExactGenre = " mg_in.GenreID = ";
                string ExactDirector = " md_in.PersonID = ";
                string ExactActor = " ma_in.PersonID = ";
                string ExactLanguage = " ml_in.LanguageID = ";

                string GroupBy = 
                @"group by Movie.MovieID
                having count(Movie.MovieID) >= @Count";

                long count = 0;

                string ExactGenreExpression =
                @" and     
                Exists  
                (
                select 1
                from Movie_Genre as mg_in
                where ( @ExactGenre ) and ( mg_in.MovieID=Movie.MovieID and mg_in.GenreID = Movie_Genre.GenreID )
                ) ";

                string ExactDirectorExpression =
                @" and   
                Exists  
                (
                select 1
                from Movie_Director as md_in
                where ( @ExactDirector ) and ( md_in.MovieID=Movie.MovieID and md_in.PersonID=Movie_Director.PersonID )
                ) ";

                string ExactActorExpression =
                @" and   
                Exists  
                (
                select 1
                from Movie_Actor as ma_in
                where ( @ExactActor ) and ( ma_in.MovieID=Movie.MovieID and ma_in.PersonID=Movie_Actor.PersonID )
                ) ";

                string ExactLanguageExpression =
                @" and   
                Exists     
                (
                select 1
                from Movie_Language as ml_in
                where ( @ExactLanguage ) and ( ml_in.MovieID=Movie.MovieID and ml_in.LanguageID=Movie_Language.LanguageID) 
                ) ";

                string IgnoreMovie = " Movie.MovieID not in (@List) ";

                if (isFavorite == null || isFavorite == false)
                {
                    excludeFavorite = "and (Movie.MovieID not in (select MovieID from FavoriteMovie)) ";
                }

                if(productYearLower == 1900)
                {
                    productNull = " Movie.ProductYear IS NULL or ";
                }

                if(isSeen != null)
                {
                    int seen = Convert.ToInt32((bool)isSeen);

                    seenMovie = " and Movie.IsSeen=@IsSeen ";
                    seenMovie = seenMovie.Replace("@IsSeen", seen.ToString());
                }

                if (directorID != null && directorID.Length > 0)
                {
                    joinDirector = " inner join Movie_Director on Movie.MovieID=Movie_Director.MovieID ";

                    if (directorFilter == enFilterType.Any)
                    {
                        directors = " and (" + GetAnyExpression(AnyDirector, directorID) + ")";
                    }
                    else if (directorFilter == enFilterType.Exact)
                    {
                        count += directorID.Length;

                        directors = ExactDirectorExpression.Replace("@ExactDirector", 
                                                                    GetExactExpression(ExactDirector, directorID));
                    }                      
                }

                if (actorID != null && actorID.Length > 0)
                {
                    joinActor = " inner join Movie_Actor on Movie.MovieID=Movie_Actor.MovieID ";

                    if (actorFilter == enFilterType.Any)
                    {
                        actors = " and (" + GetAnyExpression(AnyActor, actorID) + ")";
                    }
                    else if (actorFilter == enFilterType.Exact)
                    {
                        count += actorID.Length;

                        actors = ExactActorExpression.Replace("@ExactActor", GetExactExpression(ExactActor, actorID));
                    }
                }

                if (genreID != null && genreID.Length > 0)
                {
                    joinGenre = " inner join Movie_Genre on Movie.MovieID=Movie_Genre.MovieID ";

                    if (genreFilter == enFilterType.Any)
                    {
                        genres = " and (" + GetAnyExpression(AnyGenre, genreID) + ")";
                    }
                    else if (genreFilter == enFilterType.Exact)
                    {
                        count += genreID.Length;

                        genres = ExactGenreExpression.Replace("@ExactGenre", GetExactExpression(ExactGenre, genreID));
                    }
                }

                if (languageID != null && languageID.Length > 0)
                {
                    joinLanguage = " inner join Movie_Language on Movie.MovieID=Movie_Language.MovieID ";

                    if (languageFilter == enFilterType.Any)
                    {
                        languages = " and (" + GetAnyExpression(AnyLanguage, languageID) + ")";
                    }
                    else if (languageFilter == enFilterType.Exact)
                    {
                        count += languageID.Length;

                        languages = ExactLanguageExpression.Replace("@ExactLanguage",
                                                                    GetExactExpression(ExactLanguage, languageID));
                    }
                }

                if (qualityID != null && qualityID.Length > 0)
                {
                    qualities = " and (" + GetAnyExpression(AnyQuality, qualityID) + ")";
                }

                if (ignoreMovies != null && ignoreMovies.Count > 0)
                {
                    string[] ignoreItems = new string[ignoreMovies.Count];
                    int i = 0;

                    foreach(Movie movie in ignoreMovies)
                    {
                        ignoreItems[i] = movie.MovieID.ToString();
                        i++;
                    }

                    ignoredMovieID = " and (" + GetAnyExpression(IgnoreMovie, ignoreItems) + ")";
                }

                movieName = movieName.Trim();

                string finalQuery = QueryRepository.Movie_Filter_Search;

                finalQuery = finalQuery.Replace("@JoinActor", joinActor);
                finalQuery = finalQuery.Replace("@JoinDirector", joinDirector);
                finalQuery = finalQuery.Replace("@JoinGenre", joinGenre);
                finalQuery = finalQuery.Replace("@JoinLanguage", joinLanguage);
                finalQuery = finalQuery.Replace("@ProductNull", productNull);
                finalQuery = finalQuery.Replace("@IsSeen", seenMovie);
                finalQuery = finalQuery.Replace("@ActorID", actors);
                finalQuery = finalQuery.Replace("@DirectorID", directors);
                finalQuery = finalQuery.Replace("@GenreID", genres);
                finalQuery = finalQuery.Replace("@LanguageID", languages);
                finalQuery = finalQuery.Replace("@QualityID", qualities);
                finalQuery = finalQuery.Replace("@IgnoreMovieID", ignoredMovieID);
                finalQuery = finalQuery.Replace("@IsFavorite", excludeFavorite);
                finalQuery = finalQuery.Replace("@OrderBy", orderBy);
                finalQuery = finalQuery.Replace("@OrderType", orderType.ToString());

                if (count > 0)
                {
                    GroupBy = GroupBy.Replace("@Count", count.ToString());
                    finalQuery = finalQuery.Replace("@GroupBy", GroupBy);
                }
                else
                {
                    finalQuery = finalQuery.Replace("@GroupBy", string.Empty);
                }

                dtSearch = AccessDatabase.Select(finalQuery, 
                                                 "@MovieName", movieName,
                                                 "@ProductYearLower", productYearLower,
                                                 "@ProductYearUpper", productYearUpper,
                                                 "@IMDBRateLower", imdbRateLower,
                                                 "@IMDBRateUpper", imdbRateUpper,
                                                 "@DurationLower", durationLower,
                                                 "@DurationUpper", durationUpper);

                return dtSearch;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable SuggestRandom(int suggestCount = 1, string movieName = "", int productYearLower = 1900, 
                                              int productYearUpper = 2100, double imdbRateLower = 0, double imdbRateUpper = 10, 
                                              string durationLower = "00:00:00", string durationUpper = "10:00:00", 
                                              bool? isSeen = null, bool? isFavorite = null, string[] directorID = null, 
                                              enFilterType directorFilter = enFilterType.Any, string[] actorID = null, 
                                              enFilterType actorFilter = enFilterType.Any, string[] genreID = null, 
                                              enFilterType genreFilter = enFilterType.Any, string[] languageID = null, 
                                              enFilterType languageFilter = enFilterType.Any, string[] qualityID = null, 
                                              List<Movie> ignoreMovies = null)
        {
            try
            {
                DataTable dtSuggested = new DataTable();

                string directors = null;
                string actors = null;
                string genres = null;
                string languages = null;
                string qualities = null;
                string ignoredMovieID = null;
                string productNull = null;
                string excludeFavorite = null;
                string seenMovie = null;
                string joinActor = null;
                string joinDirector = null;
                string joinLanguage = null;
                string joinGenre = null;

                string AnyGenre = " Movie_Genre.GenreID in (@List) ";
                string AnyDirector = " Movie_Director.PersonID in (@List) ";
                string AnyActor = " Movie_Actor.PersonID in (@List) ";
                string AnyLanguage = " Movie_Language.LanguageID in (@List) ";
                string AnyQuality = " Movie.Quality in (@List) ";

                string ExactGenre = " mg_in.GenreID = ";
                string ExactDirector = " md_in.PersonID = ";
                string ExactActor = " ma_in.PersonID = ";
                string ExactLanguage = " ml_in.LanguageID = ";

                string GroupBy =
                @"group by Movie.MovieID
                having count(Movie.MovieID) >= @Count";

                long count = 0;

                string ExactGenreExpression =
                @" and     
                Exists  
                (
                select 1
                from Movie_Genre as mg_in
                where ( @ExactGenre ) and ( mg_in.MovieID=Movie.MovieID and mg_in.GenreID = Movie_Genre.GenreID )
                ) ";

                string ExactDirectorExpression =
                @" and   
                Exists  
                (
                select 1
                from Movie_Director as md_in
                where ( @ExactDirector ) and ( md_in.MovieID=Movie.MovieID and md_in.PersonID=Movie_Director.PersonID )
                ) ";

                string ExactActorExpression =
                @" and   
                Exists  
                (
                select 1
                from Movie_Actor as ma_in
                where ( @ExactActor ) and ( ma_in.MovieID=Movie.MovieID and ma_in.PersonID=Movie_Actor.PersonID )
                ) ";

                string ExactLanguageExpression =
                @" and   
                Exists     
                (
                select 1
                from Movie_Language as ml_in
                where ( @ExactLanguage ) and ( ml_in.MovieID=Movie.MovieID and ml_in.LanguageID=Movie_Language.LanguageID) 
                ) ";

                string IgnoreMovie = " Movie.MovieID not in (@List) ";

                if (isFavorite == null || isFavorite == false)
                {
                    excludeFavorite = "and (Movie.MovieID not in (select MovieID from FavoriteMovie)) ";
                }

                if (productYearLower == 1900)
                {
                    productNull = " Movie.ProductYear IS NULL or ";
                }

                if (isSeen != null)
                {
                    int seen = Convert.ToInt32((bool)isSeen);

                    seenMovie = " and Movie.IsSeen=@IsSeen ";
                    seenMovie = seenMovie.Replace("@IsSeen", seen.ToString());
                }

                if (directorID != null && directorID.Length > 0)
                {
                    joinDirector = " inner join Movie_Director on Movie.MovieID=Movie_Director.MovieID ";

                    if (directorFilter == enFilterType.Any)
                    {
                        directors = " and (" + GetAnyExpression(AnyDirector, directorID) + ")";
                    }
                    else if (directorFilter == enFilterType.Exact)
                    {
                        count += directorID.Length;

                        directors = ExactDirectorExpression.Replace("@ExactDirector",
                                                                    GetExactExpression(ExactDirector, directorID));
                    }
                }

                if (actorID != null && actorID.Length > 0)
                {
                    joinActor = " inner join Movie_Actor on Movie.MovieID=Movie_Actor.MovieID ";

                    if (actorFilter == enFilterType.Any)
                    {
                        actors = " and (" + GetAnyExpression(AnyActor, actorID) + ")";
                    }
                    else if (actorFilter == enFilterType.Exact)
                    {
                        count += actorID.Length;

                        actors = ExactActorExpression.Replace("@ExactActor", GetExactExpression(ExactActor, actorID));
                    }
                }

                if (genreID != null && genreID.Length > 0)
                {
                    joinGenre = " inner join Movie_Genre on Movie.MovieID=Movie_Genre.MovieID ";

                    if (genreFilter == enFilterType.Any)
                    {
                        genres = " and (" + GetAnyExpression(AnyGenre, genreID) + ")";
                    }
                    else if (genreFilter == enFilterType.Exact)
                    {
                        count += genreID.Length;

                        genres = ExactGenreExpression.Replace("@ExactGenre", GetExactExpression(ExactGenre, genreID));
                    }
                }

                if (languageID != null && languageID.Length > 0)
                {
                    joinLanguage = " inner join Movie_Language on Movie.MovieID=Movie_Language.MovieID ";

                    if (languageFilter == enFilterType.Any)
                    {
                        languages = " and (" + GetAnyExpression(AnyLanguage, languageID) + ")";
                    }
                    else if (languageFilter == enFilterType.Exact)
                    {
                        count += languageID.Length;

                        languages = ExactLanguageExpression.Replace("@ExactLanguage",
                                                                    GetExactExpression(ExactLanguage, languageID));
                    }
                }

                if (qualityID != null && qualityID.Length > 0)
                {
                    qualities = " and (" + GetAnyExpression(AnyQuality, qualityID) + ")";
                }

                if (ignoreMovies != null && ignoreMovies.Count > 0)
                {
                    string[] ignoreItems = new string[ignoreMovies.Count];
                    int i = 0;

                    foreach (Movie movie in ignoreMovies)
                    {
                        ignoreItems[i] = movie.MovieID.ToString();
                        i++;
                    }

                    ignoredMovieID = " and (" + GetAnyExpression(IgnoreMovie, ignoreItems) + ")";
                }

                movieName = movieName.Trim();

                string finalQuery = QueryRepository.Movie_Suggest_Random;

                finalQuery = finalQuery.Replace("@JoinActor", joinActor);
                finalQuery = finalQuery.Replace("@JoinDirector", joinDirector);
                finalQuery = finalQuery.Replace("@JoinGenre", joinGenre);
                finalQuery = finalQuery.Replace("@JoinLanguage", joinLanguage);
                finalQuery = finalQuery.Replace("@ProductNull", productNull);
                finalQuery = finalQuery.Replace("@IsSeen", seenMovie);
                finalQuery = finalQuery.Replace("@ActorID", actors);
                finalQuery = finalQuery.Replace("@DirectorID", directors);
                finalQuery = finalQuery.Replace("@GenreID", genres);
                finalQuery = finalQuery.Replace("@LanguageID", languages);
                finalQuery = finalQuery.Replace("@QualityID", qualities);
                finalQuery = finalQuery.Replace("@IgnoreMovieID", ignoredMovieID);
                finalQuery = finalQuery.Replace("@IsFavorite", excludeFavorite);

                if (count > 0)
                {
                    GroupBy = GroupBy.Replace("@Count", count.ToString());
                    finalQuery = finalQuery.Replace("@GroupBy", GroupBy);
                }
                else
                {
                    finalQuery = finalQuery.Replace("@GroupBy", string.Empty);
                }

                dtSuggested = AccessDatabase.Select(finalQuery, 
                                                    "@SuggestCount", suggestCount, 
                                                    "@MovieName", movieName,
                                                    "@ProductYearLower", productYearLower,
                                                    "@ProductYearUpper", productYearUpper,
                                                    "@IMDBRateLower", imdbRateLower,
                                                    "@IMDBRateUpper", imdbRateUpper,
                                                    "@DurationLower", durationLower,
                                                    "@DurationUpper", durationUpper);

                if(dtSuggested == null || dtSuggested.Rows.Count <= 0)
                {
                    Movie_SP.SuggestionCacheDelete();

                    dtSuggested = AccessDatabase.Select(finalQuery,
                                                        "@SuggestCount", suggestCount,
                                                        "@MovieName", movieName,
                                                        "@ProductYearLower", productYearLower,
                                                        "@ProductYearUpper", productYearUpper,
                                                        "@IMDBRateLower", imdbRateLower,
                                                        "@IMDBRateUpper", imdbRateUpper,
                                                        "@DurationLower", durationLower,
                                                        "@DurationUpper", durationUpper);
                }

                if (dtSuggested != null && dtSuggested.Rows.Count > 0)
                {
                    Movie[] suggestedMovies = new Movie[0];

                    suggestedMovies = Movie.FetchAllMovie(dtSuggested);

                    foreach (Movie mov in suggestedMovies)
                    {
                        Movie_SP.SuggestionCacheInsert(mov.MovieID);
                    }
                }

                return dtSuggested;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetSimilarByID(long movieID)
        {
            try
            {
                DataTable dtRelated = new DataTable();

                string isMainString = AccessDatabase.ValueFunction(FunctionRepository.GetMovieMainGenreType,
                                                                   @"MovieID", movieID);

                if (isMainString == null || isMainString.Length <= 0)
                {
                    return dtRelated;
                }

                string rateString = AccessDatabase.ValueFunction(FunctionRepository.GetMovieIMDbRate,
                                                                 "@MovieID", movieID);

                double rate = 0.0;

                if (rateString != null && rateString.Length > 0)
                {
                    rate = Convert.ToDouble(rateString);
                }

                double minRate = 0.0;
                double maxRate = 10.0;

                if(rate > 0.0)
                {
                    minRate = rate - 2;
                    maxRate = rate + 2;
                }

                bool isMain = Convert.ToBoolean(isMainString);

                // Main genre of this movie is some of Animation, Reality-Show, Talk-Show and ...
                if (isMain == true)
                {
                    string mainGenreIDString = AccessDatabase.ValueFunction(FunctionRepository.GetMovieMainGenreID,
                                                                            "@MovieID", movieID);

                    long mainGenreID = 0;

                    if (mainGenreIDString != null && mainGenreIDString.Length > 0)
                    {
                        mainGenreID = Convert.ToInt64(mainGenreIDString);
                    }

                    dtRelated = AccessDatabase.Select(QueryRepository.Movie_Get_Similar_By_MovieID_ForNotMovie,
                                                      "@MovieID", movieID,
                                                      "@MinRate", minRate,
                                                      "@MaxRate", maxRate,
                                                      "@MainGenre", mainGenreID,
                                                      "@Num", 20);
                }
                // Main Genre of this movie is a cinematic genre, like Drama, Biography, Horror and ...
                else
                {
                    dtRelated = AccessDatabase.Select(QueryRepository.Movie_Get_Similar_By_MovieID_ForMovie,
                                                      "@MovieID", movieID,
                                                      "@MinRate", minRate,
                                                      "@MaxRate", maxRate,
                                                      "@Num", 20);
                }


                return dtRelated;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetList(bool newestFirst)
        {
            try
            { 
                DataTable dtMovies = new DataTable();

                string finalQuery = QueryRepository.Movie_Get_List;

                string newFirst = string.Empty;

                if(newestFirst == true)
                {
                    newFirst = "Movie.AddDate desc,";
                }

                finalQuery = finalQuery.Replace("@NewestFirst", newFirst);

                dtMovies = AccessDatabase.Select(finalQuery);

                return dtMovies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetOfflineList()
        {
            try
            {
                DataTable dtMovie = GetList(false);
                DataTable result = new DataTable();
                int i = 0;

                foreach (DataColumn dc in dtMovie.Columns)
                {
                    result.Columns.Add(dc.ColumnName);
                }

                while (i < dtMovie.Rows.Count)
                {
                    string fileLink = dtMovie.Rows[i]["FileLink"].ToString();
                    if (!MovieFileExists(fileLink))
                    {
                        result.ImportRow(dtMovie.Rows[i]);
                    }

                    i++;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool MovieFileExists(string fileLink)
        {
            string root = string.Empty;
            foreach (DataRow dr in iMovieBase.MovieRootPath.Rows)
            {
                root = dr["PathString"].ToString() + @"\";
                if (Directory.Exists(root + fileLink) == true)
                {
                    return true;
                }
            }

            return false;
        }

        public static DataSet GetDetailsByID(long movieID) 
        {
            try
            {
                DataSet dtDetails = new DataSet();
                dtDetails = AccessDatabase.SelectSet(QueryRepository.Movie_Get_Details_By_ID,
                                                     "@MovieID", movieID);

                return dtDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetByRate(double lower = 0, double upper = 10)
        { 
            try
            {
                DataTable dtMovies = new DataTable();
                dtMovies = AccessDatabase.Select(QueryRepository.Movie_Get_By_Rate,
                                                 "@LowerBound", lower, 
                                                 "@UpperBound", upper);

                return dtMovies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetByQuality(enVideoQuality quality = enVideoQuality.Indeterminate)
        {
            try
            {
                DataTable dtMovies = new DataTable();
                dtMovies = AccessDatabase.Select(QueryRepository.Movie_Get_By_Quality,
                                                 "@Quality", (int)quality);

                return dtMovies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetByProductYear(int lower = 1900, int upper = 2100)
        {
            try
            { 
                DataTable dtMovies = new DataTable();

                string finalQuery = QueryRepository.Movie_Get_By_ProductYear;
                string productNull = string.Empty;

                if(lower <= 1900)
                {
                    productNull = "Movie.ProductYear IS NULL or";
                }


                finalQuery = finalQuery.Replace("@ProductNull", productNull);

                dtMovies = AccessDatabase.Select(finalQuery,
                                                 "@LowerBound", lower, 
                                                 "@UpperBound", upper);

                return dtMovies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetByName(string name = "")
        {
            try
            {
                name = name.Trim();

                DataTable dtMovies = new DataTable();
                dtMovies = AccessDatabase.Select(QueryRepository.Movie_Get_By_Name,
                                                 "@MovieName", name);

                return dtMovies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetByLanguageID(long languageID)
        {
            try 
            { 
                DataTable dtMovies = new DataTable();
                dtMovies = AccessDatabase.Select(QueryRepository.Movie_Get_By_LanguageID,
                                                 "@LanguageID", languageID);

                return dtMovies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetByID(long movieID)
        {
            try
            {
                DataTable dtMovies = new DataTable();
                dtMovies = AccessDatabase.Select(QueryRepository.Movie_Get_By_MovieID,
                                                 "@MovieID", movieID);

                return dtMovies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetByGenreID(long genreID)
        {
            try
            {
                DataTable dtMovies = new DataTable();
                dtMovies = AccessDatabase.Select(QueryRepository.Movie_Get_By_GenreID,
                                                 "@GenreID", genreID);

                return dtMovies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetByDuration(string lower = "00:00:00", string upper = "10:00:00")
        {
            try
            {
                DataTable dtMovies = new DataTable();
                dtMovies = AccessDatabase.Select(QueryRepository.Movie_Get_By_Duration,
                                                 "@LowerBound", lower, "@UpperBound", upper);

                return dtMovies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetByAddDateTime(DateTime lower, DateTime upper)
        {
            try
            {
                DataTable dtMovies = new DataTable();
                dtMovies = AccessDatabase.Select(QueryRepository.Movie_Get_By_AddDate,
                                                 "@LowerBound", Helper.GetShortDateString(lower), 
                                                 "@UpperBound", Helper.GetShortDateString(upper));

                return dtMovies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetByDirectorID(long directorID)
        {
            try
            {
                DataTable dtMovies = new DataTable();
                dtMovies = AccessDatabase.Select(QueryRepository.Movie_Get_By_DirectorID,
                                                 "@DirectorID", directorID);

                return dtMovies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetByActorID(long actorID)
        {
            try
            {
                DataTable dtMovies = new DataTable();
                dtMovies = AccessDatabase.Select(QueryRepository.Movie_Get_By_ActorID,
                                                 "@ActorID", actorID);

                return dtMovies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetStatistics()
        {
            try 
            {
                DataTable dtStats = new DataTable();
                dtStats = AccessDatabase.Select(QueryRepository.Get_Statistics);

                return dtStats;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SuggestionCacheDelete()
        {
            try 
            {
                AccessDatabase.Delete(QueryRepository.SuggestionCache_Delete);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SuggestionCacheInsert(long MovieID)
        {
            try 
            {
                AccessDatabase.Insert(QueryRepository.SuggestionCache_Insert, 
                                      "@MovieID", MovieID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long FavoriteInsert(long movieID, int favoriteRate)
        { 
            try
            {
                long favoriteID = 0;
                favoriteID = AccessDatabase.Insert(QueryRepository.FavoriteMovie_Insert, 
                                                   "@MovieID", movieID, 
                                                   "@FavoriteRate", favoriteRate);

                if (favoriteID <= 0)
                {
                    throw new Exception(Messages.DatabaseError);
                }

                return favoriteID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long FavoriteUpdate(long movieID, int favoriteRate)
        {
            try
            {
                long count = 0;
                count = AccessDatabase.Update(QueryRepository.FavoriteMovie_Update,
                                              "@MovieID", movieID, 
                                              "@FavoriteRate", favoriteRate);

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long FavoriteDelete(long movieID)
        {
            try
            { 
                long count = 0;
                count = AccessDatabase.Delete(QueryRepository.FavoriteMovie_Delete, 
                                              "@MovieID", movieID);

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable FavoriteGetList()
        {
            try
            {
                DataTable dtMovies = new DataTable();
                dtMovies = AccessDatabase.Select(QueryRepository.FavoriteMovie_Get_List);

                return dtMovies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected static bool IsIMDbTitlePage(string url)
        {
            try
            {
                return !string.IsNullOrEmpty(url) && 
                    Movie_SP.MoviePagePattern.IsMatch(url) && DataOperation.IsAvailable(url);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        protected static string GetMovieIMDbPage(Movie movie, bool forceUpdate = false)
        {
            bool isPageAvailable = false;
            if (!string.IsNullOrEmpty(movie.IMDBLink) && forceUpdate == false)
            {
                isPageAvailable = Movie_SP.IsIMDbTitlePage(movie.IMDBLink);
            }

            if (!isPageAvailable || forceUpdate == true)
            {
                string searchQuery = string.Empty;
                if (movie.ProductYear <= 0)
                {
                    searchQuery = movie.MovieName + " imdb title";
                }
                else
                {
                    searchQuery = movie.FullTitle + " imdb title";
                }

                int index = 0;
                foreach (string item in realValues)
                {
                    searchQuery = searchQuery.Replace(item, queryValues[index]);
                    index++;
                }

                Oscobo searchProvider = new Oscobo();
                return searchProvider.Search(searchQuery, Movie_SP.MoviePagePattern, 3);
            }
            else
            {
                return movie.IMDBLink;
            }
        }

        public static enUpdateResult UpdateOnline(Movie movie, bool image, bool rate, bool link,
                                                  bool year, bool duration, bool story, bool genre,
                                                  bool director, bool directorImage, bool language,
                                                  bool actor, bool actorImage, bool ignoreValid,
                                                  bool generateLog, bool forceUpdateURL = false, 
                                                  Form owner = null)
        {
            enUpdateResult result = enUpdateResult.NoNeedUpdate;
            List<Person> updatedDirectorsImage = new List<Person>();
            List<Person> updatedActorsImage = new List<Person>();

            try
            {
                if (!image && !rate && !link && !year && !duration && !story && !genre &&
                    !director && !directorImage && !language && !actor && !actorImage)
                {
                    return result;
                }

                string url = Movie_SP.GetMovieIMDbPage(movie, forceUpdateURL);
                if (string.IsNullOrEmpty(url))
                {
                    if (generateLog == true)
                    {
                        iMovieBase.log.GenerateSilent("Could not get movie IMDb page link." + Environment.NewLine + movie.FullTitle);
                    }

                    return enUpdateResult.UpdateError;
                }

                IMDb imdbPage = new IMDb(url);
                IMDbCredits imdbCredits = new IMDbCredits(url.TrimEnd('/') + "/fullcredits");

                if (link == true)
                {
                    if (string.IsNullOrEmpty(movie.IMDBLink) || ignoreValid == false ||
                        forceUpdateURL == true || imdbPage.URL.ToLower() != movie.IMDBLink.ToLower())
                    {
                        movie.IMDBLink = imdbPage.URL;
                    }
                }

                if (rate == true)
                {
                    if (movie.IMDBRate <= 0 || ignoreValid == false)
                    {
                        try
                        {
                            imdbPage.LoadRate();
                            if (imdbPage.HasRate == true)
                            {
                                movie.IMDBRate = imdbPage.Rate;
                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                        catch (CouldNotLoadWebPageException ex)
                        {
                            throw ex;
                        }
                        catch (Exception ex)
                        {
                            if (generateLog == true)
                            {
                                iMovieBase.log.GenerateSilent("Could not get movie IMDb rate." + Environment.NewLine + movie.FullTitle);
                            }

                            result = enUpdateResult.UpdateError;
                        }
                    }
                }

                if (year == true)
                {
                    if (movie.ProductYear <= 0 || ignoreValid == false)
                    {
                        try
                        {
                            imdbPage.LoadYear();
                            if (imdbPage.HasYear == true)
                            {
                                movie.ProductYear = imdbPage.Year;
                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                        catch (CouldNotLoadWebPageException ex)
                        {
                            throw ex;
                        }
                        catch (Exception ex)
                        {
                            if (generateLog == true)
                            {
                                iMovieBase.log.GenerateSilent("Could not get movie release year." + Environment.NewLine + movie.FullTitle);
                            }

                            result = enUpdateResult.UpdateError;
                        }
                    }
                }

                if (duration == true)
                {
                    if (movie.Duration.TotalSeconds <= 0 || ignoreValid == false)
                    {
                        try
                        {
                            imdbPage.LoadMinutes();
                            if (imdbPage.HasDuration == true)
                            {
                                movie.Duration = imdbPage.Duration;
                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                        catch (CouldNotLoadWebPageException ex)
                        {
                            throw ex;
                        }
                        catch (Exception ex)
                        {
                            if (generateLog == true)
                            {
                                iMovieBase.log.GenerateSilent("Could not get movie duration." + Environment.NewLine + movie.FullTitle);
                            }

                            result = enUpdateResult.UpdateError;
                        }
                    }
                }

                if (story == true)
                {
                    if (string.IsNullOrEmpty(movie.StoryLine) || ignoreValid == false)
                    {
                        try
                        {
                            imdbPage.LoadStoryLine();
                            if (imdbPage.HasStoryLine == true)
                            {
                                movie.StoryLine = imdbPage.StoryLine;
                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                        catch (CouldNotLoadWebPageException ex)
                        {
                            throw ex;
                        }
                        catch (Exception ex)
                        {
                            if (generateLog == true)
                            {
                                iMovieBase.log.GenerateSilent("Could not get movie story line." + Environment.NewLine + movie.FullTitle);
                            }

                            result = enUpdateResult.UpdateError;
                        }
                    }
                }

                if (image == true)
                {
                    if (string.IsNullOrEmpty(movie.PosterLink) ||
                        File.Exists(PathUtils.GetApplicationMoviePosterPath() + movie.PosterLink) == false ||
                        ignoreValid == false)
                    {
                        string name = movie.FullTitle + ".jpg";
                        string imageLink = Movie_SP.MoviePosterPath + name;

                        if (Directory.Exists(Movie_SP.MoviePosterPath) == false)
                        {
                            Directory.CreateDirectory(Movie_SP.MoviePosterPath);
                        }

                        if (Directory.Exists(PathUtils.GetApplicationTempPath()) == false)
                        {
                            Directory.CreateDirectory(PathUtils.GetApplicationTempPath());
                        }

                        try
                        {
                            if (File.Exists(imageLink) == false || ignoreValid == false)
                            {
                                imdbPage.LoadPhotoLink();
                                if (imdbPage.HasPhotoURL)
                                {
                                    string realName = movie.FullTitle + Path.GetExtension(imdbPage.PhotoURL);
                                    string realImageLink = Movie_SP.MoviePosterPath + realName;
                                    string realTemp = PathUtils.GetApplicationTempPath() + realName;

                                    IMDb.DownloadFile(imdbPage.PhotoURL, realTemp);
                                    InsertManager im = new InsertManager(generateLog, false);
                                    realImageLink = im.RenameFile(realTemp, realImageLink);

                                    if (File.Exists(realImageLink) == true)
                                    {
                                        movie.PosterLink = Path.GetFileName(realImageLink);
                                    }

                                    File.Delete(realTemp);
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            else if (File.Exists(imageLink) == true)
                            {
                                movie.PosterLink = Path.GetFileName(imageLink);
                            }
                        }
                        catch (CouldNotLoadWebPageException ex)
                        {
                            throw ex;
                        }
                        catch (Exception ex)
                        {
                            if (generateLog == true)
                            {
                                iMovieBase.log.GenerateSilent("Could not get movie poster image." + Environment.NewLine + movie.FullTitle);
                            }

                            result = enUpdateResult.UpdateError;
                        }
                    }
                }

                if (genre == true)
                {
                    DataTable dtMovieGenre = Genre_SP.GetByMovieID(movie.MovieID);

                    if (dtMovieGenre.Rows.Count == 0 || ignoreValid == false)
                    {
                        try
                        {
                            imdbPage.LoadGenres();
                            if (imdbPage.HasGenres == false)
                            {
                                throw new Exception();
                            }
                        }
                        catch (CouldNotLoadWebPageException ex)
                        {
                            throw ex;
                        }
                        catch (Exception ex)
                        {
                            if (generateLog == true)
                            {
                                iMovieBase.log.GenerateSilent("Could not get movie genres." + Environment.NewLine + movie.FullTitle);
                            }

                            result = enUpdateResult.UpdateError;
                        }
                    }
                }

                if (language == true)
                {
                    DataTable dtMovieLanguage = Language_SP.GetByMovieID(movie.MovieID);

                    if (dtMovieLanguage.Rows.Count == 0 || ignoreValid == false)
                    {
                        try
                        {
                            imdbPage.LoadLanguages();
                            if (imdbPage.HasLanguages == false)
                            {
                                throw new Exception();
                            }
                        }
                        catch (CouldNotLoadWebPageException ex)
                        {
                            throw ex;
                        }
                        catch (Exception ex)
                        {
                            if (generateLog == true)
                            {
                                iMovieBase.log.GenerateSilent("Could not get movie languages." + Environment.NewLine + movie.FullTitle);
                            }

                            result = enUpdateResult.UpdateError;
                        }
                    }
                }

                if (director == true)
                {
                    DataTable dtMovieDirector = Person_SP.GetDirectorByMovieID(movie.MovieID);

                    if (dtMovieDirector.Rows.Count == 0 || ignoreValid == false)
                    {
                        try
                        {
                            imdbCredits.LoadDirectors();
                            if (imdbCredits.HasDirectors == false)
                            {
                                throw new Exception();
                            }
                        }
                        catch (CouldNotLoadWebPageException ex)
                        {
                            throw ex;
                        }
                        catch (Exception ex)
                        {
                            if (generateLog == true)
                            {
                                iMovieBase.log.GenerateSilent("Could not get movie directors." + Environment.NewLine + movie.FullTitle);
                            }

                            result = enUpdateResult.UpdateError;
                        }
                    }
                }

                if (actor == true)
                {
                    DataTable dtMovieActor = Person_SP.GetActorByMovieID(movie.MovieID);

                    if (dtMovieActor.Rows.Count == 0 || ignoreValid == false)
                    {
                        try
                        {
                            imdbCredits.LoadActors();
                            if (imdbCredits.HasActors == false)
                            {
                                throw new Exception();
                            }
                        }
                        catch (CouldNotLoadWebPageException ex)
                        {
                            throw ex;
                        }
                        catch (Exception ex)
                        {
                            if (generateLog == true)
                            {
                                iMovieBase.log.GenerateSilent("Could not get movie actors." + Environment.NewLine + movie.FullTitle);
                            }

                            result = enUpdateResult.UpdateError;
                        }
                    }
                }

                if (directorImage == true)
                {
                    bool shouldUpdateDirectorImage = false;
                    DataTable dtMovieDirector = Person_SP.GetDirectorByMovieID(movie.MovieID);

                    if (imdbCredits.HasDirectors == true)
                    {
                        shouldUpdateDirectorImage = true;
                    }
                    else
                    {
                        foreach (DataRow dr in dtMovieDirector.Rows)
                        {
                            string imagePath = string.Format("{0}{1}", Movie_SP.PersonPhotoPath, 
                                dr["PhotoLink"]?.ToString() ?? string.Empty);

                            if (string.IsNullOrEmpty(dr["PhotoLink"]?.ToString()) || 
                                File.Exists(imagePath) == false || ignoreValid == false)
                            {
                                shouldUpdateDirectorImage = true;
                                break;
                            }
                        }
                    }

                    if (shouldUpdateDirectorImage == true)
                    {
                        if (Directory.Exists(PathUtils.GetApplicationPersonPath()) == false)
                        {
                            Directory.CreateDirectory(PathUtils.GetApplicationPersonPath());
                        }

                        if (Directory.Exists(PathUtils.GetApplicationTempPath()) == false)
                        {
                            Directory.CreateDirectory(PathUtils.GetApplicationTempPath());
                        }

                        if (imdbCredits.HasDirectors == false)
                        {
                            foreach (DataRow dr in dtMovieDirector.Rows)
                            {
                                try
                                {
                                    string imagePath = string.Format("{0}{1}", Movie_SP.PersonPhotoPath,
                                        dr["PhotoLink"]?.ToString() ?? string.Empty);

                                    if (string.IsNullOrEmpty(dr["PhotoLink"]?.ToString()) ||
                                        File.Exists(imagePath) == false || ignoreValid == false)
                                    {
                                        if (!string.IsNullOrEmpty(dr["IMDBLink"]?.ToString()) &&
                                            (File.Exists(Movie_SP.PersonPhotoPath + dr["FullName"].ToString() + ".jpg") == false ||
                                            ignoreValid == false))
                                        {
                                            IMDbPerson directorPage = new IMDbPerson(dr["IMDBLink"].ToString());
                                            directorPage.LoadPhotoLink();
                                            if (directorPage.HasPhotoLink)
                                            {
                                                string realName = dr["FullName"].ToString() + Path.GetExtension(directorPage.PhotoLink);
                                                string realImageLink = Movie_SP.PersonPhotoPath + realName;
                                                string realTemp = PathUtils.GetApplicationTempPath() + realName;

                                                IMDb.DownloadFile(directorPage.PhotoLink, realTemp);
                                                InsertManager im = new InsertManager(generateLog, false);
                                                realImageLink = im.RenameFile(realTemp, realImageLink);

                                                if (File.Exists(realImageLink) == true)
                                                {
                                                    Person p = new Person();
                                                    p.PhotoLink = Path.GetFileName(realImageLink);
                                                    p.PersonID = Convert.ToInt64(dr["PersonID"].ToString());
                                                    updatedDirectorsImage.Add(p);
                                                }

                                                File.Delete(realTemp);
                                            }
                                            else
                                            {
                                                throw new Exception();
                                            }
                                        }
                                        else if (File.Exists(Movie_SP.PersonPhotoPath + dr["FullName"].ToString() + ".jpg") == true)
                                        {
                                            Person p = new Person();
                                            p.PhotoLink = dr["FullName"].ToString() + ".jpg";
                                            p.PersonID = Convert.ToInt64(dr["PersonID"].ToString());
                                            updatedDirectorsImage.Add(p);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    if (generateLog == true)
                                    {
                                        iMovieBase.log.GenerateSilent("Could not get director photo." +
                                            Environment.NewLine + dr["FullName"].ToString() +
                                            Environment.NewLine + movie.FullTitle);
                                    }

                                    result = enUpdateResult.UpdateError;
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            foreach (Person p in imdbCredits.Directors)
                            {
                                try
                                {
                                    if (!string.IsNullOrEmpty(p.IMDBLink) &&
                                        (File.Exists(Movie_SP.PersonPhotoPath + p.FullName + ".jpg") == false || 
                                        ignoreValid == false))
                                    {
                                        IMDbPerson directorPage = new IMDbPerson(p.IMDBLink);
                                        directorPage.LoadPhotoLink();

                                        if (directorPage.HasPhotoLink)
                                        {
                                            string realName = p.FullName + Path.GetExtension(directorPage.PhotoLink);
                                            string realImageLink = PersonPhotoPath + realName;
                                            string realTemp = PathUtils.GetApplicationTempPath() + realName;

                                            IMDb.DownloadFile(directorPage.PhotoLink, realTemp);
                                            InsertManager im = new InsertManager(generateLog, false);
                                            realImageLink = im.RenameFile(realTemp, realImageLink);

                                            if (File.Exists(realImageLink) == true)
                                            {
                                                p.PhotoLink = Path.GetFileName(realImageLink);
                                                p.PersonID = 99999999;
                                            }

                                            File.Delete(realTemp);
                                        }
                                        else
                                        {
                                            throw new Exception();
                                        }
                                    }
                                    else if (File.Exists(Movie_SP.PersonPhotoPath + p.FullName + ".jpg") == true)
                                    {
                                        p.PhotoLink = p.FullName + ".jpg";
                                        p.PersonID = 99999999;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    if (generateLog == true)
                                    {
                                        iMovieBase.log.GenerateSilent("Could not get director photo." + 
                                            Environment.NewLine + p.FullName +
                                            Environment.NewLine + movie.FullTitle);
                                    }

                                    result = enUpdateResult.UpdateError;
                                    continue;
                                }
                            }
                        }
                    }
                }

                if (actorImage == true)
                {
                    bool shouldUpdateActorImage = false;
                    DataTable dtMovieActor = Person_SP.GetActorByMovieID(movie.MovieID);

                    if (imdbCredits.HasActors == true)
                    {
                        shouldUpdateActorImage = true;
                    }
                    else
                    {
                        foreach (DataRow dr in dtMovieActor.Rows)
                        {
                            string imagePath = string.Format("{0}{1}", Movie_SP.PersonPhotoPath,
                                dr["PhotoLink"]?.ToString() ?? string.Empty);

                            if (string.IsNullOrEmpty(dr["PhotoLink"]?.ToString()) ||
                                File.Exists(imagePath) == false || ignoreValid == false)
                            {
                                shouldUpdateActorImage = true;
                                break;
                            }
                        }
                    }

                    if (shouldUpdateActorImage == true)
                    {
                        if (Directory.Exists(PathUtils.GetApplicationPersonPath()) == false)
                        {
                            Directory.CreateDirectory(PathUtils.GetApplicationPersonPath());
                        }

                        if (Directory.Exists(PathUtils.GetApplicationTempPath()) == false)
                        {
                            Directory.CreateDirectory(PathUtils.GetApplicationTempPath());
                        }

                        if (imdbCredits.HasActors == false)
                        {
                            foreach (DataRow dr in dtMovieActor.Rows)
                            {
                                try
                                {
                                    string imagePath = string.Format("{0}{1}", Movie_SP.PersonPhotoPath,
                                        dr["PhotoLink"]?.ToString() ?? string.Empty);

                                    if (string.IsNullOrEmpty(dr["PhotoLink"]?.ToString()) ||
                                        File.Exists(imagePath) == false || ignoreValid == false)
                                    {
                                        if (!string.IsNullOrEmpty(dr["IMDBLink"]?.ToString()) &&
                                            (File.Exists(Movie_SP.PersonPhotoPath + dr["FullName"].ToString() + ".jpg") == false ||
                                            ignoreValid == false))
                                        {
                                            IMDbPerson actorPage = new IMDbPerson(dr["IMDBLink"].ToString());
                                            actorPage.LoadPhotoLink();
                                            if (actorPage.HasPhotoLink)
                                            {
                                                string realName = dr["FullName"].ToString() + Path.GetExtension(actorPage.PhotoLink);
                                                string realImageLink = Movie_SP.PersonPhotoPath + realName;
                                                string realTemp = PathUtils.GetApplicationTempPath() + realName;

                                                IMDb.DownloadFile(actorPage.PhotoLink, realTemp);
                                                InsertManager im = new InsertManager(generateLog, false);
                                                realImageLink = im.RenameFile(realTemp, realImageLink);

                                                if (File.Exists(realImageLink) == true)
                                                {
                                                    Person p = new Person();
                                                    p.PhotoLink = Path.GetFileName(realImageLink);
                                                    p.PersonID = Convert.ToInt64(dr["PersonID"].ToString());
                                                    updatedActorsImage.Add(p);
                                                }

                                                File.Delete(realTemp);
                                            }
                                            else
                                            {
                                                throw new Exception();
                                            }
                                        }
                                        else if (File.Exists(Movie_SP.PersonPhotoPath + dr["FullName"].ToString() + ".jpg") == true)
                                        {
                                            Person p = new Person();
                                            p.PhotoLink = dr["FullName"].ToString() + ".jpg";
                                            p.PersonID = Convert.ToInt64(dr["PersonID"].ToString());
                                            updatedActorsImage.Add(p);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    if (generateLog == true)
                                    {
                                        iMovieBase.log.GenerateSilent("Could not get actor photo." + 
                                            Environment.NewLine + dr["FullName"].ToString() +
                                            Environment.NewLine + movie.FullTitle);
                                    }

                                    result = enUpdateResult.UpdateError;
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            foreach (Person p in imdbCredits.Actors)
                            {
                                try
                                {
                                    if (!string.IsNullOrEmpty(p.IMDBLink) &&
                                        (File.Exists(Movie_SP.PersonPhotoPath + p.FullName + ".jpg") == false ||
                                        ignoreValid == false))
                                    {
                                        IMDbPerson actorPage = new IMDbPerson(p.IMDBLink);
                                        actorPage.LoadPhotoLink();
                                        if (actorPage.HasPhotoLink)
                                        {
                                            string realName = p.FullName + Path.GetExtension(actorPage.PhotoLink);
                                            string realImageLink = PersonPhotoPath + realName;
                                            string realTemp = PathUtils.GetApplicationTempPath() + realName;

                                            IMDb.DownloadFile(actorPage.PhotoLink, realTemp);
                                            InsertManager im = new InsertManager(generateLog, false);
                                            realImageLink = im.RenameFile(realTemp, realImageLink);

                                            if (File.Exists(realImageLink) == true)
                                            {
                                                p.PhotoLink = Path.GetFileName(realImageLink);
                                                p.PersonID = 99999999;
                                            }

                                            File.Delete(realTemp);
                                        }
                                        else
                                        {
                                            throw new Exception();
                                        }
                                    }
                                    else if (File.Exists(Movie_SP.PersonPhotoPath + p.FullName + ".jpg") == true)
                                    {
                                        p.PhotoLink = p.FullName + ".jpg";
                                        p.PersonID = 99999999;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    if (generateLog == true)
                                    {
                                        iMovieBase.log.GenerateSilent("Could not get actor photo." + 
                                            Environment.NewLine + p.FullName +
                                            Environment.NewLine + movie.FullTitle);
                                    }

                                    result = enUpdateResult.UpdateError;
                                    continue;
                                }
                            }
                        }
                    }
                }

                try
                {
                    if (imdbPage.HasGenres == true)
                    {
                        try
                        {
                            Movie_SP.DeleteAllMovieGenre(movie.MovieID);

                            int index = 0;
                            foreach (Genre item in imdbPage.Genres)
                            {
                                try
                                {
                                    DataTable dtGenre = Genre_SP.GetByName(item.GenreName);
                                    long genreID = 0;
                                    if (dtGenre.Rows.Count > 0)
                                    {
                                        genreID = Convert.ToInt64(dtGenre.Rows[0]["GenreID"]);
                                    }
                                    else
                                    {
                                        genreID = Genre_SP.Insert(item);
                                    }

                                    Movie_SP.InsertMovieGenre(movie.MovieID, genreID, index == 0);
                                    index++;
                                }
                                catch(Exception ex)
                                {
                                    if (generateLog == true)
                                    {
                                        iMovieBase.log.GenerateSilent("Could not save updated movie genre." + 
                                            Environment.NewLine + item.GenreName + Environment.NewLine + movie.FullTitle);
                                    }

                                    result = enUpdateResult.UpdateError;
                                    continue;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (generateLog == true)
                            {
                                iMovieBase.log.GenerateSilent("Could not save updated movie genres." + Environment.NewLine + movie.FullTitle);
                            }

                            result = enUpdateResult.UpdateError;
                        }
                    }

                    if (imdbPage.HasLanguages == true)
                    {
                        try
                        {
                            Movie_SP.DeleteAllMovieLanguage(movie.MovieID);

                            foreach (Language item in imdbPage.Languages)
                            {
                                try
                                {
                                    DataTable dtLanguage = Language_SP.GetByName(item.LanguageName);
                                    long languageID = 0;
                                    if (dtLanguage.Rows.Count > 0)
                                    {
                                        languageID = Convert.ToInt64(dtLanguage.Rows[0]["LanguageID"]);
                                    }
                                    else
                                    {
                                        languageID = Language_SP.Insert(item);
                                    }

                                    Movie_SP.InsertMovieLanguage(movie.MovieID, languageID);
                                }
                                catch (Exception ex)
                                {
                                    if (generateLog == true)
                                    {
                                        iMovieBase.log.GenerateSilent("Could not save updated movie language." +
                                            Environment.NewLine + item.LanguageName + Environment.NewLine + movie.FullTitle);
                                    }

                                    result = enUpdateResult.UpdateError;
                                    continue;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (generateLog == true)
                            {
                                iMovieBase.log.GenerateSilent("Could not save updated movie languages." + Environment.NewLine + movie.FullTitle);
                            }

                            result = enUpdateResult.UpdateError;
                        }
                    }


                    if (imdbCredits.HasDirectors)
                    {
                        try
                        {
                            Movie_SP.DeleteAllMovieDirector(movie.MovieID);

                            foreach (Person item in imdbCredits.Directors)
                            {
                                try
                                {
                                    long directorID = 0;
                                    directorID = Person_SP.GetPersonID(item.FullName, item.IMDBLink);

                                    if (directorID <= 0)
                                    {
                                        directorID = Person_SP.Insert(item, false, true);
                                    }
                                    else
                                    {
                                        bool isActor = false;
                                        bool isDirector = false;
                                        Person_SP.GetTypeByID(directorID, out isActor, out isDirector);

                                        if (isDirector == false)
                                        {
                                            AccessDatabase.Insert(QueryRepository.Director_Insert, "@PersonID", directorID);
                                        }
                                    }

                                    Movie_SP.InsertMovieDirector(movie.MovieID, directorID);
                                }
                                catch (Exception ex)
                                {
                                    if (generateLog == true)
                                    {
                                        iMovieBase.log.GenerateSilent("Could not save updated movie director." +
                                            Environment.NewLine + item.FullName + Environment.NewLine + movie.FullTitle);
                                    }

                                    result = enUpdateResult.UpdateError;
                                    continue;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (generateLog == true)
                            {
                                iMovieBase.log.GenerateSilent("Could not save updated movie directors." + Environment.NewLine + movie.FullTitle);
                            }

                            result = enUpdateResult.UpdateError;
                        }
                    }

                    if (imdbCredits.HasActors)
                    {
                        try
                        {
                            Movie_SP.DeleteAllMovieActor(movie.MovieID);

                            foreach (Person item in imdbCredits.Actors)
                            {
                                try
                                {
                                    long actorID = 0;
                                    actorID = Person_SP.GetPersonID(item.FullName, item.IMDBLink);

                                    if (actorID <= 0)
                                    {
                                        actorID = Person_SP.Insert(item, true, false);
                                    }
                                    else
                                    {
                                        bool isActor = false;
                                        bool isDirector = false;
                                        Person_SP.GetTypeByID(actorID, out isActor, out isDirector);

                                        if (isActor == false)
                                        {
                                            AccessDatabase.Insert(QueryRepository.Actor_Insert, "@PersonID", actorID);
                                        }
                                    }

                                    Movie_SP.InsertMovieActor(movie.MovieID, actorID);
                                }
                                catch (Exception ex)
                                {
                                    if (generateLog == true)
                                    {
                                        iMovieBase.log.GenerateSilent("Could not save updated movie actor." +
                                            Environment.NewLine + item.FullName + Environment.NewLine + movie.FullTitle);
                                    }

                                    result = enUpdateResult.UpdateError;
                                    continue;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (generateLog == true)
                            {
                                iMovieBase.log.GenerateSilent("Could not save updated movie actors." + Environment.NewLine + movie.FullTitle);
                            }

                            result = enUpdateResult.UpdateError;
                        }
                    }

                    if (updatedDirectorsImage.Count > 0)
                    {
                        foreach (Person item in updatedDirectorsImage)
                        {
                            Person_SP.UpdatePhotoLinkByID(item.PersonID, item.PhotoLink);
                        }
                    }

                    if (updatedActorsImage.Count > 0)
                    {
                        foreach (Person item in updatedActorsImage)
                        {
                            Person_SP.UpdatePhotoLinkByID(item.PersonID, item.PhotoLink);
                        }
                    }

                    if (imdbPage.HasDuration == true || imdbPage.HasYear == true ||
                        imdbPage.HasRate == true || imdbPage.HasPhotoURL == true || 
                        imdbPage.HasStoryLine == true)
                    {
                        long res = 0;
                        res = Movie_SP.UpdateOnline(movie);

                        if (res > 0)
                        {
                            result = enUpdateResult.Updated;
                        }
                    }
                    else if (imdbPage.HasGenres || imdbPage.HasLanguages || 
                        imdbCredits.HasActors || imdbCredits.HasDirectors ||
                        updatedActorsImage.Count > 0 || updatedDirectorsImage.Count > 0)
                    {
                        result = enUpdateResult.Updated;
                    }
                    
                    if (imdbPage.HasURL == true)
                    {
                        long res = 0;
                        res = Movie_SP.UpdateOnline(movie);

                        if (res > 0 && link == true && result == enUpdateResult.NoNeedUpdate)
                        {
                            result = enUpdateResult.Updated;
                        }
                        else if (res <= 0 && link == true && result == enUpdateResult.NoNeedUpdate)
                        {
                            result = enUpdateResult.UpdateError;
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (generateLog == true)
                    {
                        iMovieBase.log.GenerateSilent(Messages.UpdateError + Environment.NewLine + movie.FullTitle + Environment.NewLine + ex.Message);
                    }

                    result = enUpdateResult.UpdateError;
                }

                if (owner != null)
                {
                    (owner as frmOnlineMovieUpdate).InvokeHandle();
                }

                return result;
            }
            catch(CouldNotLoadWebPageException ex)
            {
                if (owner != null)
                {
                    (owner as frmOnlineMovieUpdate).InvokeHandle();
                }

                return enUpdateResult.NotOpen;
            }
            catch (Exception ex)
            {
                if (owner != null)
                {
                    (owner as frmOnlineMovieUpdate).InvokeHandle();
                }

                return enUpdateResult.UpdateError;
            }
        }

        public static long RootPathInsert(string pathString)
        {
            try 
            {
                long count = 0;
                count = AccessDatabase.CountFunction(FunctionRepository.CountRootPath,
                                                     "@PathString", pathString);

                if (count > 0)
                {
                    throw new Exception(Messages.AlreadyExistPathString);
                }

                long rootPathID = 0;
                rootPathID = AccessDatabase.Insert(QueryRepository.MovieRootPath_Insert, 
                                                   "@PathString", pathString);

                if (rootPathID <= 0)
                {
                    throw new Exception(Messages.DatabaseError);
                }

                iMovieBase.MovieRootPath = Movie_SP.RootPathGetList();

                return rootPathID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable RootPathGetList()
        {
            try
            {
                DataTable dtPath = new DataTable();
                dtPath = AccessDatabase.Select(QueryRepository.MovieRootPath_Get_List);

                return dtPath;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long RootPathDelete(long pathID) 
        {
            try
            {
                long count = 0;
                count = AccessDatabase.Delete(QueryRepository.MovieRootPath_Delete,
                                              "@PathID", pathID);

                if(count > 0)
                {
                    iMovieBase.MovieRootPath = Movie_SP.RootPathGetList();
                }

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long DuplicateMovieInsert(long movieID, long groupID)
        {
            try
            {
                long id = 0;
                id = AccessDatabase.Insert(QueryRepository.DuplicateMovie_Insert,
                                           "@MovieID", movieID,
                                           "@GroupID", groupID);

                if (id <= 0)
                {
                    throw new Exception(Messages.DatabaseError);
                }

                return id;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static long DuplicateMovieDeleteByMovieID(long movieID)
        {
            try
            {
                long count = 0;
                count = AccessDatabase.Delete(QueryRepository.DuplicateMovie_Delete_By_MovieID,
                                              "@MovieID", movieID);

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long DuplicateMovieDeleteAll()
        {
            try
            {
                long count = 0;
                count = AccessDatabase.Delete(QueryRepository.DuplicateMovie_Delete_All);

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable DuplicateMovieGetList()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = AccessDatabase.Select(QueryRepository.DuplicateMovie_Get_List);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable DuplicateMovieGetByMovieID(long movieID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = AccessDatabase.Select(QueryRepository.DuplicateMovie_Get_By_MovieID,
                                           "@MovieID", movieID);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable DuplicateMovieGetByGroupID(long groupID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = AccessDatabase.Select(QueryRepository.DuplicateMovie_Get_By_GroupID,
                                           "@GroupID", groupID);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long DuplicateMovieCleanup()
        {
            try
            {
                long count = 0;
                count = AccessDatabase.Delete(QueryRepository.DuplicateMovie_Cleanup);

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetDuplicateListExact()
        {
            try
            {
                DataTable dtMovies = new DataTable();
                dtMovies = AccessDatabase.Select(QueryRepository.Movie_Get_Duplicate_List_Exact);

                return dtMovies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetDuplicateListTradeOff()
        {
            try
            {
                StringCompare sc = new StringCompare(85, 80, 20, 10);

                DataTable dtExactDuplicate = new DataTable();
                DataTable dtAllMovies = new DataTable();
                DataTable dtNewMoviesAfterLastDuplicate = new DataTable();
                DataTable dtDuplicateMovies = new DataTable();

                DateTime lowerDateTime = Convert.ToDateTime("1900-1-1 00:00:00"); 

                dtExactDuplicate = Movie_SP.GetDuplicateListExact();
                dtAllMovies = Movie_SP.GetList(false);

                try
                {
                    string lastDuplicateDate = string.Empty;

                    DataTable dtParam = new DataTable();
                    dtParam = SystemParameters_SP.GetByParamID((long)enSystemParameters.Last_Duplicate_Movie_Rebuild);

                    if (dtParam != null && dtParam.Rows.Count > 0)
                    {
                        lastDuplicateDate = dtParam.Rows[0]["ParamValue"].ToString();
                    }

                    if (lastDuplicateDate != null && lastDuplicateDate.Length > 0)
                    {
                        lowerDateTime = Convert.ToDateTime(lastDuplicateDate);
                    }
                }
                catch (Exception ex)
                {

                }

                dtNewMoviesAfterLastDuplicate = Movie_SP.GetByAddDateTime(lowerDateTime.AddSeconds(1), DateTime.Now.AddYears(10));
                dtDuplicateMovies = Movie_SP.DuplicateMovieGetList();
                DataTable dtRemainedDuplicateMovies = new DataTable();

                bool used = false;

                foreach (DataRow drNew in dtNewMoviesAfterLastDuplicate.Rows)
                {
                    used = false;

                    string newName = drNew["MovieName"].ToString();
                    newName = DataOperation.RemoveSequenceNumber(newName);

                    string newYear = drNew["ProductYear"].ToString();

                    foreach (DataRow drDup in dtDuplicateMovies.Rows)
                    {
                        string dupName = drDup["MovieName"].ToString();
                        dupName = DataOperation.RemoveSequenceNumber(dupName);

                        string dupYear = drDup["ProductYear"].ToString();

                        if (sc.IsEqual(dupName, newName) == true)
                        {
                            if (dupYear != null && dupYear.Length > 0 && dupYear != "0" &&
                                dupYear != newYear)
                            {
                                //dtRemainedDuplicateMovies.ImportRow();
                                continue;
                            }
                            else
                            {
                                Movie_SP.DuplicateMovieInsert(Convert.ToInt64(drNew["MovieID"].ToString()),
                                                              Convert.ToInt64(drDup["GroupID"].ToString()));
                            }
                        }
                    }
                }
                    
    
                DataColumn[] dtExactPrimary = { dtExactDuplicate.Columns["MovieID"] };
                dtExactDuplicate.PrimaryKey = dtExactPrimary;

                DataColumn[] dtApproximatePrimary = { dtAllMovies.Columns["MovieID"] };
                dtAllMovies.PrimaryKey = dtApproximatePrimary;

                foreach (DataRow drFirst in dtAllMovies.Rows)
                {
                    string firstName = drFirst["MovieName"].ToString();
                    string tempFirstName = DataOperation.RemoveSequenceNumber(firstName);

                    foreach (DataRow drOther in dtAllMovies.Rows)
                    {
                        string otherName = drOther["MovieName"].ToString();
                        string tempOtherName = DataOperation.RemoveSequenceNumber(otherName);

                        if (tempFirstName.Equals(tempOtherName, StringComparison.CurrentCultureIgnoreCase) == false)
                        {
                            if (sc.IsEqual(firstName, otherName) == true)
                            {
                                if (dtExactDuplicate.Rows.Contains(drFirst["MovieID"]) == false)
                                {
                                    dtExactDuplicate.ImportRow(drFirst);
                                }

                                if (dtExactDuplicate.Rows.Contains(drOther["MovieID"]) == false)
                                {
                                    dtExactDuplicate.ImportRow(drOther);
                                }
                            }
                        }
                    }
                }

                try
                {
                    Movie_SP.UpdateLastDuplicateReportDateTime(DateTime.Now);
                }
                catch (Exception ex)
                {

                }

                return dtExactDuplicate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetByFileLink(string fileLink)
        {
            try
            {
                DataTable dtMovie = new DataTable();
                dtMovie = AccessDatabase.Select(QueryRepository.Movie_Get_By_FileLink,
                                                "@FileLink", fileLink);

                return dtMovie;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long CountByFileLink(string fileLink)
        {
            try
            {
                long count = 0;
                count = AccessDatabase.CountFunction(FunctionRepository.CountMovieByFileLink,
                                                     "@FileLink", fileLink);

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static enUpdateResult UpdateOnlineFromIMDb(string url, Movie movie, bool image, bool rate,
                                                          bool year, bool duration, bool story, bool genre,
                                                          bool director, bool directorImage, bool language,
                                                          bool actor, bool actorImage, bool ignoreValid,
                                                          bool generateLog, Form owner = null)
        {
            if (string.IsNullOrEmpty(url) || !Movie_SP.IsIMDbTitlePage(url))
            {
                return enUpdateResult.UpdateError;
            }

            movie.IMDBLink = url;
            return Movie_SP.UpdateOnline(movie, image, rate, true, year, duration, story, genre, director, 
                directorImage, language, actor, actorImage, ignoreValid, generateLog, false, owner);
        }

        public static long RequestMovieCopyDelete(long movieID)
        {
            try
            {
                long count = 0;
                count = AccessDatabase.Delete(QueryRepository.RequestMovieCopy_Delete, 
                                              "@MovieID", movieID);
                
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long RequestMovieCopyInsert(long movieID)
        {
            try
            {
                long insertID = 0;
                insertID = AccessDatabase.Insert(QueryRepository.RequestMovieCopy_Insert, 
                                                "@MovieID", movieID);

                if (insertID <= 0)
                {
                    throw new Exception(Messages.DatabaseError);
                }

                return insertID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable RequestMovieCopyGetList()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = AccessDatabase.Select(QueryRepository.RequestMovieCopy_Get_List);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long RequestMovieCopyDeleteAll()
        {
            try
            {
                long count = 0;
                count = AccessDatabase.Delete(QueryRepository.RequestMovieCopy_Delete_All);

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetByMovieIDOrIMDbBLink(long movieID, string imdbLink)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = AccessDatabase.Select(QueryRepository.Movie_Get_By_MovieID_And_IMDBLink, 
                                           "@MovieID", movieID,
                                           "@IMDbLink", imdbLink);

                if(dt == null || dt.Rows.Count <= 0)
                {
                    dt = AccessDatabase.Select(QueryRepository.Movie_Get_By_MovieID_Or_IMDBLink,
                                               "@MovieID", movieID,
                                               "@IMDbLink", imdbLink);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateLastDuplicateReportDateTime(DateTime duplicateDatetime)
        {
            try
            {
                RegistryManager.WriteValue(Helper.GetShortDateTimeString(duplicateDatetime), 
                                           Messages.RootKey, Messages.SubKeyLastDuplicateReportDateTime);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Dictionary<long, string>> ReadLastCachedDuplicateApproximate()
        {
            try
            {
                string[] movieSep = { "[&]" };
                string[] itemSep = { "[*]" };
                string rawList = "";
                rawList = RegistryManager.GetValue(Messages.RootKey, Messages.SubKeyLastCachedDuplicateAproximate);
                List<Dictionary<long, string>> list = new List<Dictionary<long, string>>();

                if (rawList != null && rawList.Length > 0)
                {
                    string[] movies = rawList.Split(movieSep, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string s in movies)
                    {
                        string[] tempMovie = s.Split(itemSep, StringSplitOptions.RemoveEmptyEntries);

                        if (tempMovie.Length == 2)
                        {
                            try
                            {
                                long movieID = Convert.ToInt64(tempMovie[0]);
                                string duplicateKey = tempMovie[1];

                                Dictionary<long, string> dicMovie = new Dictionary<long, string>();
                                dicMovie.Add(movieID, duplicateKey);
                                list.Add(dicMovie);
                            }
                            catch (Exception ex)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                return list;
            }
            catch (Exception ex)
            {
                return new List<Dictionary<long, string>>();
            }
        }

        /// <summary>
        /// This method returns movies duplicated with the given source movies to exclude them from result.
        /// </summary>
        /// <param name="sourceMovies">
        /// Movies to be excluded.
        /// </param>
        /// <returns></returns>
        public static List<Movie> GetDuplicateMoviesInSource(List<Movie> sourceMovies)
        {
            try
            {
                StringCompare sc = new StringCompare(85, 80, 20, 10);
                StringCompare scExact = new StringCompare(100, 100, 0, 0);

                DataTable dtAllMovies = new DataTable();

                dtAllMovies = Movie_SP.GetList(false);
                Movie[] allMovieList = Movie.FetchAllMovie(dtAllMovies);

                List<Movie> duplicateMovieID = new List<Movie>();

                foreach (Movie firstMovie in allMovieList)
                {
                    string firstMovieNameNoSequence = DataOperation.RemoveSequenceNumber(firstMovie.MovieName);

                    foreach (Movie secondMovie in sourceMovies)
                    {
                        string secondMovieNameNoSequence = DataOperation.RemoveSequenceNumber(secondMovie.MovieName);

                        if (scExact.IsEqual(firstMovie.FullTitle, secondMovie.FullTitle) == true)
                        {
                            if (duplicateMovieID.Contains(firstMovie) == false)
                            {
                                duplicateMovieID.Add(firstMovie);
                            }

                            continue;
                        }
                        else if (firstMovieNameNoSequence.Equals(secondMovieNameNoSequence, StringComparison.CurrentCultureIgnoreCase) == false)
                        {
                            if (sc.IsEqual(firstMovie.FullTitle, secondMovie.FullTitle) == true)
                            {
                                if (duplicateMovieID.Contains(firstMovie) == false)
                                {
                                    duplicateMovieID.Add(firstMovie);
                                }

                                continue;
                            }
                        }
                    }
                }

                return duplicateMovieID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string GetExactExpression(string exactCondition, string[] items)
        {
            string result = string.Empty;

            if (items != null)
            {
                int len = items.Length;
                int i = 0;

                foreach (string item in items)
                {
                    i++;
                    result += exactCondition + item + " ";

                    if (i < len)
                    {
                        result += " or ";
                    }
                }
            }

            return result;
        }

        private static string GetAnyExpression(string anyCondition, string[] items)
        {
            string result = string.Empty;

            if (items != null)
            {
                string list = string.Empty;
                list = Helper.GetSeparatedList(items);
                result = anyCondition.Replace("@List", list);
            }

            return result;
        }
    }
}
