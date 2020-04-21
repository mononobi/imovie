using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace iMovie
{
    public class Movie_SP
    {
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

        public static enUpdateResult UpdateOnline(Movie movie, bool image, bool rate, bool link, 
                                                  bool year, bool duration, bool story, bool genre,
                                                  bool director, bool directorImage, bool language,
                                                  bool ignoreValid, bool generateLog ,Form owner = null)
        {
            enUpdateResult result = enUpdateResult.NoNeedUpdate;
            bool isOpen = false;

            bool shouldUpdateRate = false;
            bool shouldUpdateLink = false;
            bool shouldUpdateYear = false;
            bool shouldUpdateDuration = false;
            bool shouldUpdateImage = false;
            bool shouldUpdateStory = false;
            bool shouldUpdateGenre = false;
            bool shouldUpdateDirector = false;
            bool shouldUpdateDirectorImage = false;
            bool shouldUpdateLanguage = false;
             
            bool rateUpdated = false;
            bool linkUpdated = false;
            bool yearUpdated = false;
            bool durationUpdated = false;
            bool imageUpdated = false;
            bool storyUpdated = false;
            bool genreUpdated = false;
            bool directorUpdated = false;
            bool directorImageUpdated = false;
            bool languageUpdated = false;

            DataTable dtAllGenre = new DataTable();
            DataTable dtMovieGenre = new DataTable();

            DataTable dtAllLanguage = new DataTable();
            DataTable dtMovieLanguage = new DataTable();
             
            DataTable dtAllDirector = new DataTable();
            DataTable dtMovieDirector = new DataTable(); 
             
            try
            {
                string searchQuery1 = "";
                string searchQuery2 = "";

                if (movie.ProductYear == 0)
                {
                    searchQuery1 = movie.MovieName + " imdb title";
                }
                else
                {
                    searchQuery1 = movie.FullTitle + " imdb title";
                    searchQuery2 = movie.MovieName + " imdb title";
                }

                int ind = 0 ;

                foreach (string s in realValues)
                {
                    searchQuery1 = searchQuery1.Replace(s, queryValues[ind]);
                    searchQuery2 = searchQuery2.Replace(s, queryValues[ind]);
                    ind++;
                }

                Google google = new Google(false);

                if (rate == true)
                {
                    if (movie.IMDBRate == 0 || ignoreValid == false)
                    {
                        shouldUpdateRate = true;

                        try
                        {
                            try
                            {
                                if (google.HasRate == false && 
                                    google.HasURL == false)
                                {
                                    google = new Google(true, searchQuery1);
                                    isOpen = true;
                                }
                                if (google.HasRate == false &&
                                    google.HasURL == true)
                                {
                                    google.IMDBMoviePage.Update();
                                    isOpen = true;
                                }
                            }
                            catch (Exception ex)
                            {
                                if (searchQuery2.Length == 0)
                                {
                                    throw ex;
                                }
                            }

                            try
                            {
                                if (google.HasRate == false &&
                                    google.HasURL == false && searchQuery2.Length > 0)
                                {
                                    google = new Google(true, searchQuery2);
                                    isOpen = true;
                                }
                                if (google.HasRate == false &&
                                    google.HasURL == true)
                                {
                                    google.IMDBMoviePage.Update();
                                    isOpen = true;
                                }
                            }
                            catch (Exception ex)
                            {

                            }

                            if (google.HasRate == true)
                            {
                                movie.IMDBRate = google.Rate;
                                rateUpdated = true;
                            }
                            else if (google.IMDBMoviePage.HasRate == true)
                            {
                                movie.IMDBRate = google.IMDBMoviePage.Rate;
                                rateUpdated = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            
                        }
                    }
                }

                if (link == true)
                {
                    if (movie.IMDBLink == "" || ignoreValid == false)
                    {
                        shouldUpdateLink = true;

                        try
                        {
                            try
                            {
                                if (google.HasURL == false)
                                {
                                    google = new Google(true, searchQuery1);
                                    isOpen = true;
                                }
                            }
                            catch (Exception ex)
                            {
                                if (searchQuery2.Length == 0)
                                {
                                    throw ex;
                                }
                            }

                            try
                            {
                                if (google.HasURL == false && searchQuery2.Length > 0)
                                {
                                    google = new Google(true, searchQuery2);
                                    isOpen = true;
                                }
                            }
                            catch (Exception ex)
                            {

                            }

                            if (google.HasURL == true)
                            {
                                movie.IMDBLink = google.IMDBMoviePage.URL;
                                linkUpdated = true;
                            }

                            if (shouldUpdateRate == true && rateUpdated == false)
                            {
                                if (google.HasRate == true)
                                {
                                    movie.IMDBRate = google.Rate;
                                    rateUpdated = true;
                                }
                                else if (google.IMDBMoviePage.HasRate == true)
                                {
                                    movie.IMDBRate = google.IMDBMoviePage.Rate;
                                    rateUpdated = true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                           
                        }
                    }
                }

                if (year == true)
                {
                    if (movie.ProductYear == 0 || ignoreValid == false)
                    {
                        shouldUpdateYear = true;

                        try
                        {
                            try
                            {
                                if (google.HasYear == false &&
                                    google.HasURL == false)
                                {
                                    google = new Google(true, searchQuery1);
                                    isOpen = true;
                                }
                                if (google.HasYear == false &&
                                    google.HasURL == true)
                                {
                                    google.IMDBMoviePage.Update();
                                    isOpen = true;
                                }
                            }
                            catch (Exception ex)
                            {
                                if (searchQuery2.Length == 0)
                                {
                                    throw ex;
                                }
                            }

                            try
                            {
                                if (google.HasYear == false &&
                                    google.HasURL == false && searchQuery2.Length > 0)
                                {
                                    google = new Google(true, searchQuery2);
                                    isOpen = true;
                                }
                                if (google.HasYear == false &&
                                    google.HasURL == true)
                                {
                                    google.IMDBMoviePage.Update();
                                    isOpen = true;
                                }
                            }
                            catch (Exception ex)
                            {
                                    
                            }

                            if (google.HasYear == true)
                            {
                                movie.ProductYear = google.Year;
                                yearUpdated = true;
                            }
                            else if (google.IMDBMoviePage.HasYear == true)
                            {
                                movie.ProductYear = google.IMDBMoviePage.Year;
                                yearUpdated = true;
                            }
          
                            if (shouldUpdateRate == true && rateUpdated == false)
                            {
                                if (google.HasRate == true)
                                {
                                    movie.IMDBRate = google.Rate;
                                    rateUpdated = true;
                                }
                                else if (google.IMDBMoviePage.HasRate == true)
                                {
                                    movie.IMDBRate = google.IMDBMoviePage.Rate;
                                    rateUpdated = true;
                                }
                            }

                            if (shouldUpdateLink == true && linkUpdated == false)
                            {
                                if (google.HasURL == true)
                                {
                                    movie.IMDBLink = google.IMDBMoviePage.URL;
                                    linkUpdated = true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                       
                        }
                    }
                }

                if (duration == true)
                {
                    if (movie.Duration.TotalSeconds == 0 || ignoreValid == false)
                    {
                        shouldUpdateDuration = true;

                        try
                        {
                            try
                            {
                                if (google.HasURL == false && google.IMDBMoviePage.HasDuration == false)
                                {
                                    if (movie.IMDBLink.Length > 0)
                                    {
                                        try
                                        {
                                            google.IMDBMoviePage.URL = movie.IMDBLink;
                                            google.IMDBMoviePage.Update();
                                            isOpen = true;
                                        }
                                        catch (Exception ex)
                                        {
                                        }
                                    }
                                    
                                    if (google.IMDBMoviePage.HasDuration == false)
                                    {
                                        try
                                        {
                                            google = new Google(true, searchQuery1);
                                            isOpen = true;
                                        }
                                        catch (Exception ex)
                                        {
                                            if (searchQuery2.Length == 0)
                                            {
                                                throw ex;
                                            }
                                        }

                                        try
                                        {
                                            if (google.HasURL == false &&
                                                google.IMDBMoviePage.HasDuration == false &&
                                                searchQuery2.Length > 0)
                                            {
                                                google = new Google(true, searchQuery2);
                                                isOpen = true;
                                            }

                                            if (google.HasURL == true &&
                                                google.IMDBMoviePage.HasDuration == false)
                                            {
                                                google.IMDBMoviePage.Update();
                                                isOpen = true;
                                            }

                                        }
                                        catch (Exception ex)
                                        {

                                        }
                                    }
                                }

                                if (google.HasURL == true && google.IMDBMoviePage.HasDuration == false)
                                {
                                    google.IMDBMoviePage.Update();
                                    isOpen = true;
                                }
                            }
                            catch (Exception ex)
                            {
                                
                            }

                            if (google.IMDBMoviePage.HasDuration == true)
                            {
                                movie.Duration = google.IMDBMoviePage.Duration;
                                durationUpdated = true;
                            }

                            if (shouldUpdateRate == true && rateUpdated == false)
                            {
                                if (google.HasRate == true)
                                {
                                    movie.IMDBRate = google.Rate;
                                    rateUpdated = true;
                                }
                                else if (google.IMDBMoviePage.HasRate == true)
                                {
                                    movie.IMDBRate = google.IMDBMoviePage.Rate;
                                    rateUpdated = true;
                                }
                            }

                            if (shouldUpdateLink == true && linkUpdated == false)
                            {
                                if (google.HasURL == true)
                                {
                                    movie.IMDBLink = google.IMDBMoviePage.URL;
                                    linkUpdated = true;
                                }
                            }

                            if (shouldUpdateYear == true && yearUpdated == false)
                            {
                                if (google.HasYear == true)
                                {
                                    movie.ProductYear = google.Year;
                                    yearUpdated = true;
                                }
                                else if (google.IMDBMoviePage.HasYear == true)
                                {
                                    movie.ProductYear = google.IMDBMoviePage.Year;
                                    yearUpdated = true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                       
                        }
                    }
                }

                if (story == true)
                {
                    if (movie.StoryLine.Length == 0 || ignoreValid == false)
                    {
                        shouldUpdateStory = true;

                        try
                        {
                            try
                            {
                                if (google.HasURL == false && google.IMDBMoviePage.HasStoryLine == false)
                                {
                                    if (movie.IMDBLink.Length > 0)
                                    {
                                        try
                                        {
                                            google.IMDBMoviePage.URL = movie.IMDBLink;
                                            google.IMDBMoviePage.Update();
                                            isOpen = true;
                                        }
                                        catch (Exception ex)
                                        {
                                        }
                                    }

                                    if (google.IMDBMoviePage.HasStoryLine == false)
                                    {
                                        try
                                        {
                                            google = new Google(true, searchQuery1);
                                            isOpen = true;
                                        }
                                        catch (Exception ex)
                                        {
                                            if (searchQuery2.Length == 0)
                                            {
                                                throw ex;
                                            }
                                        }

                                        try
                                        {
                                            if (google.HasURL == false &&
                                                google.IMDBMoviePage.HasStoryLine == false &&
                                                searchQuery2.Length > 0)
                                            {
                                                google = new Google(true, searchQuery2);
                                                isOpen = true;
                                            }

                                            if (google.HasURL == true &&
                                                google.IMDBMoviePage.HasStoryLine == false)
                                            {
                                                google.IMDBMoviePage.Update();
                                                isOpen = true;
                                            }

                                        }
                                        catch (Exception ex)
                                        {

                                        }
                                    }
                                }

                                if (google.HasURL == true && google.IMDBMoviePage.HasStoryLine == false)
                                {
                                    google.IMDBMoviePage.Update();
                                    isOpen = true;
                                }
                            }
                            catch (Exception ex)
                            {

                            }

                            if (google.IMDBMoviePage.HasStoryLine == true)
                            {
                                movie.StoryLine = google.IMDBMoviePage.StoryLine;
                                storyUpdated = true;
                            }

                            if (shouldUpdateRate == true && rateUpdated == false)
                            {
                                if (google.HasRate == true)
                                {
                                    movie.IMDBRate = google.Rate;
                                    rateUpdated = true;
                                }
                                else if (google.IMDBMoviePage.HasRate == true)
                                {
                                    movie.IMDBRate = google.IMDBMoviePage.Rate;
                                    rateUpdated = true;
                                }
                            }

                            if (shouldUpdateLink == true && linkUpdated == false)
                            {
                                if (google.HasURL == true)
                                {
                                    movie.IMDBLink = google.IMDBMoviePage.URL;
                                    linkUpdated = true;
                                }
                            }

                            if (shouldUpdateYear == true && yearUpdated == false)
                            {
                                if (google.HasYear == true)
                                {
                                    movie.ProductYear = google.Year;
                                    yearUpdated = true;
                                }
                                else if (google.IMDBMoviePage.HasYear == true)
                                {
                                    movie.ProductYear = google.IMDBMoviePage.Year;
                                    yearUpdated = true;
                                }
                            }

                            if (shouldUpdateDuration == true && durationUpdated == false)
                            {
                                if (google.IMDBMoviePage.HasStoryLine == true)
                                {
                                    movie.StoryLine = google.IMDBMoviePage.StoryLine;
                                    storyUpdated = true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                if (genre == true)
                {
                    dtMovieGenre = Genre_SP.GetByMovieID(movie.MovieID);

                    if (dtMovieGenre.Rows.Count == 0 || ignoreValid == false)
                    {
                        shouldUpdateGenre = true;

                        if (dtAllGenre.Rows.Count == 0)
                        {
                            dtAllGenre = Genre_SP.GetList();
                        }

                        try
                        {
                            try
                            {
                                if (google.HasURL == false && google.IMDBMoviePage.HasGenre == false)
                                {
                                    if (movie.IMDBLink.Length > 0)
                                    {
                                        try
                                        {
                                            google.IMDBMoviePage.URL = movie.IMDBLink;
                                            google.IMDBMoviePage.Update();
                                            isOpen = true;
                                        }
                                        catch (Exception ex)
                                        {
                                        }
                                    }

                                    if (google.IMDBMoviePage.HasGenre == false)
                                    {
                                        try
                                        {
                                            google = new Google(true, searchQuery1);
                                            isOpen = true;
                                        }
                                        catch (Exception ex)
                                        {
                                            if (searchQuery2.Length == 0)
                                            {
                                                throw ex;
                                            }
                                        }

                                        try
                                        {
                                            if (google.HasURL == false &&
                                                google.IMDBMoviePage.HasGenre == false &&
                                                searchQuery2.Length > 0)
                                            {
                                                google = new Google(true, searchQuery2);
                                                isOpen = true;
                                            }

                                            if (google.HasURL == true &&
                                                google.IMDBMoviePage.HasGenre == false)
                                            {
                                                google.IMDBMoviePage.Update();
                                                isOpen = true;
                                            }

                                        }
                                        catch (Exception ex)
                                        {

                                        }
                                    }
                                }

                                if (google.HasURL == true && google.IMDBMoviePage.HasGenre == false)
                                {
                                    google.IMDBMoviePage.Update();
                                    isOpen = true;
                                }
                            }
                            catch (Exception ex)
                            {

                            }

                            if (google.IMDBMoviePage.HasGenre == true)
                            {
                                genreUpdated = true;
                            }

                            if (shouldUpdateRate == true && rateUpdated == false)
                            {
                                if (google.HasRate == true)
                                {
                                    movie.IMDBRate = google.Rate;
                                    rateUpdated = true;
                                }
                                else if (google.IMDBMoviePage.HasRate == true)
                                {
                                    movie.IMDBRate = google.IMDBMoviePage.Rate;
                                    rateUpdated = true;
                                }
                            }

                            if (shouldUpdateLink == true && linkUpdated == false)
                            {
                                if (google.HasURL == true)
                                {
                                    movie.IMDBLink = google.IMDBMoviePage.URL;
                                    linkUpdated = true;
                                }
                            }

                            if (shouldUpdateYear == true && yearUpdated == false)
                            {
                                if (google.HasYear == true)
                                {
                                    movie.ProductYear = google.Year;
                                    yearUpdated = true;
                                }
                                else if (google.IMDBMoviePage.HasYear == true)
                                {
                                    movie.ProductYear = google.IMDBMoviePage.Year;
                                    yearUpdated = true;
                                }
                            }

                            if (shouldUpdateDuration == true && durationUpdated == false)
                            {
                                if (google.IMDBMoviePage.HasStoryLine == true)
                                {
                                    movie.StoryLine = google.IMDBMoviePage.StoryLine;
                                    storyUpdated = true;
                                }
                            }

                            if (shouldUpdateStory == true && storyUpdated == false)
                            {
                                if (google.IMDBMoviePage.HasStoryLine == true)
                                {
                                    movie.StoryLine = google.IMDBMoviePage.StoryLine;
                                    storyUpdated = true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                if (director == true)
                {
                    dtMovieDirector = Person_SP.GetDirectorByMovieID(movie.MovieID);

                    if (dtMovieDirector.Rows.Count == 0 || ignoreValid == false)
                    {
                        shouldUpdateDirector = true;

                        if (dtAllDirector.Rows.Count == 0)
                        {
                            dtAllDirector = Person_SP.GetList();
                        }

                        try
                        {
                            try
                            {
                                if (google.HasURL == false && google.IMDBMoviePage.HasDirector == false)
                                {
                                    if (movie.IMDBLink.Length > 0)
                                    {
                                        try
                                        {
                                            google.IMDBMoviePage.URL = movie.IMDBLink;
                                            google.IMDBMoviePage.Update();
                                            isOpen = true;
                                        }
                                        catch (Exception ex)
                                        {
                                        }
                                    }

                                    if (google.IMDBMoviePage.HasDirector == false)
                                    {
                                        try
                                        {
                                            google = new Google(true, searchQuery1);
                                            isOpen = true;
                                        }
                                        catch (Exception ex)
                                        {
                                            if (searchQuery2.Length == 0)
                                            {
                                                throw ex;
                                            }
                                        }

                                        try
                                        {
                                            if (google.HasURL == false &&
                                                google.IMDBMoviePage.HasDirector == false &&
                                                searchQuery2.Length > 0)
                                            {
                                                google = new Google(true, searchQuery2);
                                                isOpen = true;
                                            }

                                            if (google.HasURL == true &&
                                                google.IMDBMoviePage.HasDirector == false)
                                            {
                                                google.IMDBMoviePage.Update();
                                                isOpen = true;
                                            }

                                        }
                                        catch (Exception ex)
                                        {

                                        }
                                    }
                                }

                                if (google.HasURL == true && google.IMDBMoviePage.HasDirector == false)
                                {
                                    google.IMDBMoviePage.Update();
                                    isOpen = true;
                                }
                            }
                            catch (Exception ex)
                            {

                            }

                            if (google.IMDBMoviePage.HasDirector == true)
                            {
                                directorUpdated = true;
                            }

                            if (shouldUpdateRate == true && rateUpdated == false)
                            {
                                if (google.HasRate == true)
                                {
                                    movie.IMDBRate = google.Rate;
                                    rateUpdated = true;
                                }
                                else if (google.IMDBMoviePage.HasRate == true)
                                {
                                    movie.IMDBRate = google.IMDBMoviePage.Rate;
                                    rateUpdated = true;
                                }
                            }

                            if (shouldUpdateLink == true && linkUpdated == false)
                            {
                                if (google.HasURL == true)
                                {
                                    movie.IMDBLink = google.IMDBMoviePage.URL;
                                    linkUpdated = true;
                                }
                            }

                            if (shouldUpdateYear == true && yearUpdated == false)
                            {
                                if (google.HasYear == true)
                                {
                                    movie.ProductYear = google.Year;
                                    yearUpdated = true;
                                }
                                else if (google.IMDBMoviePage.HasYear == true)
                                {
                                    movie.ProductYear = google.IMDBMoviePage.Year;
                                    yearUpdated = true;
                                }
                            }

                            if (shouldUpdateDuration == true && durationUpdated == false)
                            {
                                if (google.IMDBMoviePage.HasStoryLine == true)
                                {
                                    movie.StoryLine = google.IMDBMoviePage.StoryLine;
                                    storyUpdated = true;
                                }
                            }

                            if (shouldUpdateStory == true && storyUpdated == false)
                            {
                                if (google.IMDBMoviePage.HasStoryLine == true)
                                {
                                    movie.StoryLine = google.IMDBMoviePage.StoryLine;
                                    storyUpdated = true;
                                }
                            }

                            if (shouldUpdateGenre == true && genreUpdated == false)
                            {
                                if (google.IMDBMoviePage.HasGenre == true)
                                {
                                    genreUpdated = true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                if (language == true)
                {
                    dtMovieLanguage = Language_SP.GetByMovieID(movie.MovieID);

                    if (dtMovieLanguage.Rows.Count == 0 || ignoreValid == false)
                    {
                        shouldUpdateLanguage = true;

                        if (dtAllLanguage.Rows.Count == 0)
                        {
                            dtAllLanguage = Language_SP.GetList();
                        }

                        try
                        {
                            try
                            {
                                if (google.HasURL == false && google.IMDBMoviePage.HasLanguage == false)
                                {
                                    if (movie.IMDBLink.Length > 0)
                                    {
                                        try
                                        {
                                            google.IMDBMoviePage.URL = movie.IMDBLink;
                                            google.IMDBMoviePage.Update();
                                            isOpen = true;
                                        }
                                        catch (Exception ex)
                                        {
                                        }
                                    }

                                    if (google.IMDBMoviePage.HasLanguage == false)
                                    {
                                        try
                                        {
                                            google = new Google(true, searchQuery1);
                                            isOpen = true;
                                        }
                                        catch (Exception ex)
                                        {
                                            if (searchQuery2.Length == 0)
                                            {
                                                throw ex;
                                            }
                                        }

                                        try
                                        {
                                            if (google.HasURL == false &&
                                                google.IMDBMoviePage.HasLanguage == false &&
                                                searchQuery2.Length > 0)
                                            {
                                                google = new Google(true, searchQuery2);
                                                isOpen = true;
                                            }

                                            if (google.HasURL == true &&
                                                google.IMDBMoviePage.HasLanguage == false)
                                            {
                                                google.IMDBMoviePage.Update();
                                                isOpen = true;
                                            }

                                        }
                                        catch (Exception ex)
                                        {

                                        }
                                    }
                                }

                                if (google.HasURL == true && google.IMDBMoviePage.HasLanguage == false)
                                {
                                    google.IMDBMoviePage.Update();
                                    isOpen = true;
                                }
                            }
                            catch (Exception ex)
                            {

                            }

                            if (google.IMDBMoviePage.HasLanguage == true)
                            {
                                languageUpdated = true;
                            }

                            if (shouldUpdateRate == true && rateUpdated == false)
                            {
                                if (google.HasRate == true)
                                {
                                    movie.IMDBRate = google.Rate;
                                    rateUpdated = true;
                                }
                                else if (google.IMDBMoviePage.HasRate == true)
                                {
                                    movie.IMDBRate = google.IMDBMoviePage.Rate;
                                    rateUpdated = true;
                                }
                            }

                            if (shouldUpdateLink == true && linkUpdated == false)
                            {
                                if (google.HasURL == true)
                                {
                                    movie.IMDBLink = google.IMDBMoviePage.URL;
                                    linkUpdated = true;
                                }
                            }

                            if (shouldUpdateYear == true && yearUpdated == false)
                            {
                                if (google.HasYear == true)
                                {
                                    movie.ProductYear = google.Year;
                                    yearUpdated = true;
                                }
                                else if (google.IMDBMoviePage.HasYear == true)
                                {
                                    movie.ProductYear = google.IMDBMoviePage.Year;
                                    yearUpdated = true;
                                }
                            }

                            if (shouldUpdateDuration == true && durationUpdated == false)
                            {
                                if (google.IMDBMoviePage.HasStoryLine == true)
                                {
                                    movie.StoryLine = google.IMDBMoviePage.StoryLine;
                                    storyUpdated = true;
                                }
                            }

                            if (shouldUpdateStory == true && storyUpdated == false)
                            {
                                if (google.IMDBMoviePage.HasStoryLine == true)
                                {
                                    movie.StoryLine = google.IMDBMoviePage.StoryLine;
                                    storyUpdated = true;
                                }
                            }

                            if (shouldUpdateGenre == true && genreUpdated == false)
                            {
                                if (google.IMDBMoviePage.HasGenre == true)
                                {
                                    genreUpdated = true;
                                }
                            }

                            if (shouldUpdateDirector == true && directorUpdated == false)
                            {
                                if (google.IMDBMoviePage.HasDirector == true)
                                {
                                    directorUpdated = true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                if (directorImage == true)
                {
                    dtMovieDirector = Person_SP.GetDirectorByMovieID(movie.MovieID);
                    
                    try
                    {
                        try
                        {
                            if (directorUpdated == true)
                            {
                                shouldUpdateDirectorImage = true;
                            }
                            else
                            {
                                foreach (DataRow dr in dtMovieDirector.Rows)
                                {
                                    if (File.Exists(dr["PhotoLink"].ToString()) == false)
                                    {
                                        shouldUpdateDirectorImage = true;
                                        break;
                                    }
                                }
                            }

                            if (shouldUpdateDirectorImage == true && google.HasURL == false && google.IMDBMoviePage.HasDirector == false)
                            {
                                if (movie.IMDBLink.Length > 0)
                                {
                                    try
                                    {
                                        google.IMDBMoviePage.URL = movie.IMDBLink;
                                        google.IMDBMoviePage.Update();
                                        isOpen = true;
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                }

                                if (google.IMDBMoviePage.HasDirector == false)
                                {
                                    try
                                    {
                                        google = new Google(true, searchQuery1);
                                        isOpen = true;
                                    }
                                    catch (Exception ex)
                                    {
                                        if (searchQuery2.Length == 0)
                                        {
                                            throw ex;
                                        }
                                    }

                                    try
                                    {
                                        if (google.HasURL == false &&
                                            google.IMDBMoviePage.HasDirector == false &&
                                            searchQuery2.Length > 0)
                                        {
                                            google = new Google(true, searchQuery2);
                                            isOpen = true;
                                        }

                                        if (google.HasURL == true &&
                                            google.IMDBMoviePage.HasDirector == false)
                                        {
                                            google.IMDBMoviePage.Update();
                                            isOpen = true;
                                        }

                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }

                                if (google.HasURL == true && google.IMDBMoviePage.HasDirector == false)
                                {
                                    google.IMDBMoviePage.Update();
                                    isOpen = true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }

                        if (shouldUpdateDirectorImage == true && google.IMDBMoviePage.HasDirector == true)
                        {
                            if (Directory.Exists(PathUtils.GetApplicationPersonPath()) == false)
                            {
                                Directory.CreateDirectory(PathUtils.GetApplicationPersonPath());
                            }

                            if (Directory.Exists(PathUtils.GetApplicationTempPath()) == false)
                            {
                                Directory.CreateDirectory(PathUtils.GetApplicationTempPath());
                            }

                            if (directorUpdated == false)
                            {
                                foreach (DataRow dr in dtMovieDirector.Rows)
                                {
                                    if (File.Exists(dr["PhotoLink"].ToString()) == false)
                                    {
                                        foreach (Person p in google.IMDBMoviePage.Directors)
                                        {
                                            if (dr["FullName"].ToString() == p.FullName && p.PhotoLink.Length > 0)
                                            {
                                                if (File.Exists(PersonPhotoPath + dr["FullName"].ToString() + ".jpg") == false)
                                                {
                                                    string realName = p.FullName + Path.GetExtension(p.PhotoLink);
                                                    string realImageLink = PersonPhotoPath + realName;
                                                    string realTemp = PathUtils.GetApplicationTempPath() + realName;

                                                    IMDb.DownloadImage(p.PhotoLink, realTemp);
                                                    isOpen = true;

                                                    InsertManager im = new InsertManager(generateLog, false);
                                                    realImageLink = im.RenameFile(realTemp, realImageLink);

                                                    if (File.Exists(realImageLink) == true)
                                                    {
                                                        p.PhotoLink = Path.GetFileName(realImageLink);
                                                        p.PersonID = Convert.ToInt64(dr["PersonID"].ToString());
                                                        directorImageUpdated = true;
                                                    }

                                                    File.Delete(realTemp);
                                                    break;
                                                }
                                                else
                                                {
                                                    p.PhotoLink = dr["FullName"].ToString() + ".jpg";
                                                    p.PersonID = Convert.ToInt64(dr["PersonID"].ToString());
                                                    directorImageUpdated = true;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                foreach (Person p in google.IMDBMoviePage.Directors)
                                {
                                    if (File.Exists(PersonPhotoPath + p.FullName + ".jpg") == false)
                                    {
                                        string realName = p.FullName + Path.GetExtension(p.PhotoLink);
                                        string realImageLink = PersonPhotoPath + realName;
                                        string realTemp = PathUtils.GetApplicationTempPath() + realName;

                                        IMDb.DownloadImage(p.PhotoLink, realTemp);
                                        isOpen = true;

                                        InsertManager im = new InsertManager(generateLog, false);
                                        realImageLink = im.RenameFile(realTemp, realImageLink);

                                        if (File.Exists(realImageLink) == true)
                                        {
                                            p.PhotoLink = Path.GetFileName(realImageLink);
                                            p.PersonID = 99999999;
                                            directorImageUpdated = true;
                                        }

                                        File.Delete(realTemp);
                                    }
                                    else
                                    {
                                        p.PhotoLink = p.FullName + ".jpg";
                                        p.PersonID = 99999999;
                                        directorImageUpdated = true;
                                    }
                                }
                            }
                        }

                        if (shouldUpdateRate == true && rateUpdated == false)
                        {
                            if (google.HasRate == true)
                            {
                                movie.IMDBRate = google.Rate;
                                rateUpdated = true;
                            }
                            else if (google.IMDBMoviePage.HasRate == true)
                            {
                                movie.IMDBRate = google.IMDBMoviePage.Rate;
                                rateUpdated = true;
                            }
                        }

                        if (shouldUpdateLink == true && linkUpdated == false)
                        {
                            if (google.HasURL == true)
                            {
                                movie.IMDBLink = google.IMDBMoviePage.URL;
                                linkUpdated = true;
                            }
                        }

                        if (shouldUpdateYear == true && yearUpdated == false)
                        {
                            if (google.HasYear == true)
                            {
                                movie.ProductYear = google.Year;
                                yearUpdated = true;
                            }
                            else if (google.IMDBMoviePage.HasYear == true)
                            {
                                movie.ProductYear = google.IMDBMoviePage.Year;
                                yearUpdated = true;
                            }
                        }

                        if (shouldUpdateDuration == true && durationUpdated == false)
                        {
                            if (google.IMDBMoviePage.HasStoryLine == true)
                            {
                                movie.StoryLine = google.IMDBMoviePage.StoryLine;
                                storyUpdated = true;
                            }
                        }

                        if (shouldUpdateStory == true && storyUpdated == false)
                        {
                            if (google.IMDBMoviePage.HasStoryLine == true)
                            {
                                movie.StoryLine = google.IMDBMoviePage.StoryLine;
                                storyUpdated = true;
                            }
                        }

                        if (shouldUpdateGenre == true && genreUpdated == false)
                        {
                            if (google.IMDBMoviePage.HasGenre == true)
                            {
                                genreUpdated = true;
                            }
                        }

                        if (shouldUpdateDirector == true && directorUpdated == false)
                        {
                            if (google.IMDBMoviePage.HasDirector == true)
                            {
                                directorUpdated = true;
                            }
                        }

                        if (shouldUpdateLanguage == true && languageUpdated == false)
                        {
                            if (google.IMDBMoviePage.HasLanguage == true)
                            {
                                languageUpdated = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }

                if (image == true)
                {
                    if (File.Exists(PathUtils.GetApplicationMoviePosterPath() + movie.PosterLink) == false || ignoreValid == false)
                    {
                        string photoURL = "";
                        shouldUpdateImage = true;

                        try
                        {
                            string name = movie.FullTitle + ".jpg";
                            string imageLink = MoviePosterPath + name;

                            if (Directory.Exists(MoviePosterPath) == false)
                            {
                                Directory.CreateDirectory(MoviePosterPath);
                            }

                            try
                            {
                                if (File.Exists(imageLink) == true)
                                {
                                    photoURL = imageLink;
                                    isOpen = true;
                                }
                                else
                                {
                                    try
                                    {
                                        if (google.HasURL == false && google.IMDBMoviePage.HasPhotoURL == false)
                                        {
                                            if (movie.IMDBLink.Length > 0)
                                            {
                                                try
                                                {
                                                    google.IMDBMoviePage.URL = movie.IMDBLink;
                                                    google.IMDBMoviePage.Update();
                                                    isOpen = true;
                                                }
                                                catch (Exception ex)
                                                {
                                                }
                                            }

                                            if (google.IMDBMoviePage.HasPhotoURL == false)
                                            {
                                                try
                                                {
                                                    google = new Google(true, searchQuery1);
                                                    isOpen = true;
                                                }
                                                catch (Exception ex)
                                                {
                                                    if (searchQuery2.Length == 0)
                                                    {
                                                        throw ex;
                                                    }
                                                }

                                                try
                                                {
                                                    if (google.HasURL == false &&
                                                        google.IMDBMoviePage.HasPhotoURL == false &&
                                                        searchQuery2.Length > 0)
                                                    {
                                                        google = new Google(true, searchQuery2);
                                                        isOpen = true;
                                                    }

                                                    if (google.HasURL == true &&
                                                        google.IMDBMoviePage.HasPhotoURL == false)
                                                    {
                                                        google.IMDBMoviePage.Update();
                                                        isOpen = true;
                                                    }

                                                }
                                                catch (Exception ex)
                                                {

                                                }
                                            }
                                        }

                                        if (google.HasURL == true && google.IMDBMoviePage.HasPhotoURL == false)
                                        {
                                            google.IMDBMoviePage.Update();
                                            isOpen = true;
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }

                                if (shouldUpdateRate == true && rateUpdated == false)
                                {
                                    if (google.HasRate == true)
                                    {
                                        movie.IMDBRate = google.Rate;
                                        rateUpdated = true;
                                    }
                                    else if (google.IMDBMoviePage.HasRate == true)
                                    {
                                        movie.IMDBRate = google.IMDBMoviePage.Rate;
                                        rateUpdated = true;
                                    }
                                }

                                if (shouldUpdateLink == true && linkUpdated == false)
                                {
                                    if (google.HasURL == true)
                                    {
                                        movie.IMDBLink = google.IMDBMoviePage.URL;
                                        linkUpdated = true;
                                    }
                                }

                                if (shouldUpdateYear == true && yearUpdated == false)
                                {
                                    if (google.HasYear == true)
                                    {
                                        movie.ProductYear = google.Year;
                                        yearUpdated = true;
                                    }
                                    else if (google.IMDBMoviePage.HasYear == true)
                                    {
                                        movie.ProductYear = google.IMDBMoviePage.Year;
                                        yearUpdated = true;
                                    }
                                }

                                if (shouldUpdateDuration == true && durationUpdated == false)
                                {
                                    if (google.IMDBMoviePage.HasDuration == true)
                                    {
                                        movie.Duration = google.IMDBMoviePage.Duration;
                                        durationUpdated = true;
                                    }
                                }

                                if (shouldUpdateStory == true && storyUpdated == false)
                                {
                                    if (google.IMDBMoviePage.HasStoryLine == true)
                                    {
                                        movie.StoryLine = google.IMDBMoviePage.StoryLine;
                                        storyUpdated = true;
                                    }
                                }

                                if (shouldUpdateGenre == true && genreUpdated == false)
                                {
                                    if (google.IMDBMoviePage.HasGenre == true)
                                    {
                                        genreUpdated = true;
                                    }
                                }

                                if (shouldUpdateDirector == true && directorUpdated == false)
                                {
                                    if (google.IMDBMoviePage.HasDirector == true)
                                    {
                                        directorUpdated = true;
                                    }
                                }

                                if (shouldUpdateLanguage == true && languageUpdated == false)
                                {
                                    if (google.IMDBMoviePage.HasLanguage == true)
                                    {
                                        languageUpdated = true;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                        
                            }

                            if (File.Exists(photoURL) == true)
                            {
                                movie.PosterLink = Path.GetFileName(photoURL);
                                imageUpdated = true;
                                isOpen = true;
                            }
                            else
                            {
                                if (google.IMDBMoviePage.HasPhotoURL == true)
                                {
                                    string realName = movie.FullTitle + Path.GetExtension(google.IMDBMoviePage.PhotoURL);
                                    string realImageLink = MoviePosterPath + realName;
                                    string realTemp = PathUtils.GetApplicationTempPath() + realName;

                                    if (Directory.Exists(MoviePosterPath) == false)
                                    {
                                        Directory.CreateDirectory(MoviePosterPath);
                                    }

                                    if (Directory.Exists(PathUtils.GetApplicationTempPath()) == false)
                                    {
                                        Directory.CreateDirectory(PathUtils.GetApplicationTempPath());
                                    }

                                    IMDb.DownloadImage(google.IMDBMoviePage.PhotoURL, realTemp);
                                    isOpen = true;

                                    InsertManager im = new InsertManager(generateLog, false);
                                    realImageLink = im.RenameFile(realTemp, realImageLink);

                                    if (File.Exists(realImageLink) == true)
                                    {
                                        movie.PosterLink = Path.GetFileName(realImageLink);
                                        imageUpdated = true;
                                    }

                                    File.Delete(realTemp);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                          
                        }
                    }
                }

                if (shouldUpdateDuration == true && durationUpdated == false)
                {
                    if (generateLog == true)
                    {
                        iMovieBase.log.GenerateSilent("Could not get movie duration." + Environment.NewLine + movie.FullTitle);
                    }
                }

                if (shouldUpdateImage == true && imageUpdated == false)
                {
                    if (generateLog == true)
                    {
                        iMovieBase.log.GenerateSilent("Could not get movie poster image." + Environment.NewLine + movie.FullTitle);
                    }
                }

                if (shouldUpdateLink == true && linkUpdated == false)
                {
                    if (generateLog == true)
                    {
                        iMovieBase.log.GenerateSilent("Could not get movie IMDb page link." + Environment.NewLine + movie.FullTitle);
                    }
                }

                if (shouldUpdateRate == true && rateUpdated == false)
                {
                    if (generateLog == true)
                    {
                        iMovieBase.log.GenerateSilent("Could not get movie IMDb rate." + Environment.NewLine + movie.FullTitle);
                    }
                }

                if (shouldUpdateYear == true && yearUpdated == false)
                {
                    if (generateLog == true)
                    {
                        iMovieBase.log.GenerateSilent("Could not get movie release year." + Environment.NewLine + movie.FullTitle);
                    }
                }

                if (shouldUpdateStory == true && storyUpdated == false)
                {
                    if (generateLog == true)
                    {
                        iMovieBase.log.GenerateSilent("Could not get movie storyline." + Environment.NewLine + movie.FullTitle);
                    }
                }

                if (shouldUpdateGenre == true && genreUpdated == false)
                {
                    if (generateLog == true)
                    {
                        iMovieBase.log.GenerateSilent("Could not get movie genres." + Environment.NewLine + movie.FullTitle);
                    }
                }

                if (shouldUpdateDirector == true && directorUpdated == false)
                {
                    if (generateLog == true)
                    {
                        iMovieBase.log.GenerateSilent("Could not get movie directors." + Environment.NewLine + movie.FullTitle);
                    }
                }

                if (shouldUpdateDirectorImage == true && directorImageUpdated == false)
                {
                    if (generateLog == true)
                    {
                        iMovieBase.log.GenerateSilent("Could not get director's image." + Environment.NewLine + movie.FullTitle);
                    }
                }

                if (shouldUpdateLanguage == true && languageUpdated == false)
                {
                    if (generateLog == true)
                    {
                        iMovieBase.log.GenerateSilent("Could not get movie language." + Environment.NewLine + movie.FullTitle);
                    }
                }

                if (shouldUpdateDuration == true || shouldUpdateImage == true || shouldUpdateLink == true ||
                    shouldUpdateRate == true || shouldUpdateYear == true || shouldUpdateStory == true || shouldUpdateLanguage == true ||
                    shouldUpdateDirector == true || shouldUpdateGenre == true || shouldUpdateDirectorImage == true)
                {
                    if (rateUpdated == true || linkUpdated == true || yearUpdated == true ||
                        durationUpdated == true || imageUpdated == true || storyUpdated == true || languageUpdated == true ||
                        genreUpdated == true || directorUpdated == true || directorImageUpdated == true)
                    {
                        try
                        {
                            if (genreUpdated == true)
                            {
                                bool existedGenre = false;

                                foreach (DataRow mdr in dtMovieGenre.Rows)
                                {
                                    existedGenre = false;

                                    foreach (Genre gen in google.IMDBMoviePage.Genre)
                                    {
                                        if (mdr["GenreName"].ToString().Equals(gen.GenreName, StringComparison.CurrentCultureIgnoreCase) == true)
                                        {
                                            existedGenre = true;
                                            break;
                                        }
                                    }

                                    if (existedGenre == false)
                                    {
                                        long genID = Convert.ToInt64(mdr["GenreID"].ToString());

                                        try
                                        {
                                            Movie_SP.DeleteMovieGenre(movie.MovieID, genID);
                                        }
                                        catch (Exception ex)
                                        {

                                        }
                                    }
                                }

                                int i = 0;

                                foreach (Genre gen in google.IMDBMoviePage.Genre)
                                {
                                    existedGenre = false;
                                    long insertGenreID = 0;

                                    foreach (DataRow mdr in dtMovieGenre.Rows)
                                    {
                                        if (mdr["GenreName"].ToString().Equals(gen.GenreName, StringComparison.CurrentCultureIgnoreCase) == true)
                                        {
                                            existedGenre = true;
                                            break;
                                        }
                                    } 

                                    if (existedGenre == false)
                                    {
                                        foreach (DataRow alldr in dtAllGenre.Rows)
                                        {
                                            if (alldr["GenreName"].ToString().Equals(gen.GenreName, StringComparison.CurrentCultureIgnoreCase) == true)
                                            {
                                                insertGenreID = Convert.ToInt64(alldr["GenreID"].ToString());
                                                break;
                                            }
                                        }

                                        try
                                        {
                                            if (insertGenreID > 0)
                                            {
                                                if (i == 0)
                                                {
                                                    Movie_SP.InsertMovieGenre(movie.MovieID, insertGenreID, true);
                                                }
                                                else
                                                {
                                                    Movie_SP.InsertMovieGenre(movie.MovieID, insertGenreID, false);
                                                }
                                            }
                                            else
                                            {
                                                insertGenreID = Genre_SP.Insert(gen);

                                                if (insertGenreID > 0)
                                                {
                                                    if (i == 0)
                                                    {
                                                        Movie_SP.InsertMovieGenre(movie.MovieID, insertGenreID, true);
                                                    }
                                                    else
                                                    {
                                                        Movie_SP.InsertMovieGenre(movie.MovieID, insertGenreID, false);
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                        }
                                    }

                                    i++;
                                }
                            }

                            if (languageUpdated == true)
                            {
                                bool existedLanguage = false;
                                 
                                foreach (DataRow mdr in dtMovieLanguage.Rows)
                                {
                                    existedLanguage = false;

                                    foreach (Language lang in google.IMDBMoviePage.Languages)
                                    {
                                        if (mdr["LanguageName"].ToString().Equals(lang.LanguageName, StringComparison.CurrentCultureIgnoreCase) == true)
                                        {
                                            existedLanguage = true;
                                            break;
                                        }
                                    }

                                    if (existedLanguage == false)
                                    {
                                        long langID = Convert.ToInt64(mdr["LanguageID"].ToString());

                                        try
                                        {
                                            Movie_SP.DeleteMovieLanguage(movie.MovieID, langID);
                                        }
                                        catch (Exception ex)
                                        {

                                        }
                                    }
                                }

                                foreach (Language lang in google.IMDBMoviePage.Languages)
                                {
                                    existedLanguage = false;
                                    long insertLanguageID = 0;

                                    foreach (DataRow mdr in dtMovieLanguage.Rows)
                                    {
                                        if (mdr["LanguageName"].ToString().Equals(lang.LanguageName, StringComparison.CurrentCultureIgnoreCase) == true)
                                        {
                                            existedLanguage = true;
                                            break;
                                        }
                                    }

                                    if (existedLanguage == false)
                                    {
                                        foreach (DataRow alldr in dtAllLanguage.Rows)
                                        {
                                            if (alldr["LanguageName"].ToString().Equals(lang.LanguageName, StringComparison.CurrentCultureIgnoreCase) == true)
                                            {
                                                insertLanguageID = Convert.ToInt64(alldr["LanguageID"].ToString());
                                                break;
                                            }
                                        }

                                        try
                                        {
                                            if (insertLanguageID > 0)
                                            {
                                                Movie_SP.InsertMovieLanguage(movie.MovieID, insertLanguageID);
                                            }
                                            else
                                            {
                                                insertLanguageID = Language_SP.Insert(lang);

                                                if (insertLanguageID > 0)
                                                {
                                                    Movie_SP.InsertMovieLanguage(movie.MovieID, insertLanguageID);
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                        }
                                    }
                                }
                            }

                            if (directorUpdated == true)
                            {
                                bool existedDirector = false;

                                foreach (DataRow mdr in dtMovieDirector.Rows)
                                {
                                    existedDirector = false;

                                    foreach (Person per in google.IMDBMoviePage.Directors)
                                    {
                                        if (Person_SP.IsSamePerson(per.FullName, per.IMDBLink, mdr) > 0)
                                        {
                                            existedDirector = true;
                                            break;
                                        }
                                    }

                                    if (existedDirector == false)
                                    {
                                        long personID = Convert.ToInt64(mdr["PersonID"].ToString());

                                        try
                                        {
                                            Movie_SP.DeleteMovieDirector(movie.MovieID, personID);
                                        }
                                        catch (Exception ex)
                                        {

                                        }
                                    }
                                }

                                foreach (Person per in google.IMDBMoviePage.Directors)
                                {
                                    existedDirector = false;
                                    long insertDirectorID = 0;

                                    foreach (DataRow mdr in dtMovieDirector.Rows)
                                    {
                                        if (Person_SP.IsSamePerson(per.FullName, per.IMDBLink, mdr) > 0)
                                        {
                                            existedDirector = true;
                                            break;
                                        }
                                    }

                                    if (existedDirector == false)
                                    {
                                        try
                                        {
                                            insertDirectorID = Person_SP.GetPersonID(per.FullName, per.IMDBLink);

                                            if (insertDirectorID > 0)
                                            {
                                                Movie_SP.InsertMovieDirector(movie.MovieID, insertDirectorID);
                                            }
                                            else
                                            {
                                                insertDirectorID = Person_SP.Insert(per, false, true);

                                                if (insertDirectorID > 0)
                                                {
                                                    Movie_SP.InsertMovieDirector(movie.MovieID, insertDirectorID);
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                        }
                                    }
                                }
                            }

                            if (directorImageUpdated == true)
                            {
                                if (directorUpdated == false)
                                {
                                    foreach (Person p in google.IMDBMoviePage.Directors)
                                    {
                                        try
                                        {
                                            if (p.PersonID > 0 && p.PhotoLink.Length > 0)
                                            {
                                                Person_SP.UpdatePhotoLinkByID(p.PersonID, p.PhotoLink);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                        }
                                    }
                                }
                                else
                                {
                                    dtMovieDirector = Person_SP.GetDirectorByMovieID(movie.MovieID);

                                    foreach (DataRow dr in dtMovieDirector.Rows)
                                    {
                                        foreach (Person p in google.IMDBMoviePage.Directors)
                                        {
                                            if (dr["FullName"].ToString() == p.FullName && p.PersonID == 99999999)
                                            {
                                                Person_SP.UpdatePhotoLinkByID(Convert.ToInt64(dr["PersonID"].ToString()), p.PhotoLink);
                                                break;
                                            }
                                        }
                                    }
                                }
                            }

                            if (rateUpdated == true || linkUpdated == true || yearUpdated == true ||
                                durationUpdated == true || imageUpdated == true || storyUpdated == true)
                            {
                                long res = 0;
                                res = Movie_SP.UpdateOnline(movie);

                                if (res > 0)
                                {
                                    result = enUpdateResult.Updated;
                                }
                            }
                            else
                            {
                                result = enUpdateResult.Updated;
                            }
                        }
                        catch (Exception ex)
                        {
                            if (generateLog == true)
                            {
                                iMovieBase.log.GenerateSilent(Messages.UpdateError + Environment.NewLine + movie.FullTitle + Environment.NewLine + ex.Message);
                            }
                        }
                    }
                    else
                    {
                        if (generateLog == true)
                        {
                            iMovieBase.log.GenerateSilent("Could not get online updates for this movie." + Environment.NewLine + movie.FullTitle);
                        }
                    }

                    Thread.Sleep(700);
                }

                if (owner != null)
                {
                    (owner as frmOnlineMovieUpdate).InvokeHandle();
                }

                if (result == enUpdateResult.Updated)
                {
                    return enUpdateResult.Updated; // Updated
                }
                else if ((shouldUpdateDuration == true || shouldUpdateImage == true || shouldUpdateLink == true || shouldUpdateGenre == true || shouldUpdateDirector == true || shouldUpdateDirectorImage == true || shouldUpdateLanguage == true ||
                          shouldUpdateRate == true || shouldUpdateYear == true || shouldUpdateStory == true) && isOpen == false &&
                          result != enUpdateResult.Updated)
                {
                    return enUpdateResult.NotOpen; // Not Open Banned
                }
                else if ((shouldUpdateDuration == true || shouldUpdateImage == true || shouldUpdateLink == true || shouldUpdateGenre == true || shouldUpdateDirector == true || shouldUpdateDirectorImage == true || shouldUpdateLanguage == true ||
                          shouldUpdateRate == true || shouldUpdateYear == true || shouldUpdateStory == true) && isOpen == true &&
                          result != enUpdateResult.Updated)
                {
                    return enUpdateResult.UpdateError; // Update Error
                }
                else
                {
                    return enUpdateResult.NoNeedUpdate; // No Need Update
                }
            }
            catch (Exception ex)
            {
                if (owner != null)
                {
                    (owner as frmOnlineMovieUpdate).InvokeHandle();
                }

                if (result == enUpdateResult.Updated)
                {
                    return enUpdateResult.Updated; // Updated
                }
                else if ((shouldUpdateDuration == true || shouldUpdateImage == true || shouldUpdateLink == true || shouldUpdateGenre == true || shouldUpdateDirector == true || shouldUpdateDirectorImage == true || shouldUpdateLanguage == true ||
                          shouldUpdateRate == true || shouldUpdateYear == true || shouldUpdateStory == true) && isOpen == false &&
                          result != enUpdateResult.Updated)
                {
                    return enUpdateResult.NotOpen; // Not Open Banned
                }
                else if ((shouldUpdateDuration == true || shouldUpdateImage == true || shouldUpdateLink == true || shouldUpdateGenre == true || shouldUpdateDirector == true || shouldUpdateDirectorImage == true || shouldUpdateLanguage == true ||
                          shouldUpdateRate == true || shouldUpdateYear == true || shouldUpdateStory == true) && isOpen == true &&
                          result != enUpdateResult.Updated)
                {
                    return enUpdateResult.UpdateError; // Update Error
                }
                else
                {
                    return enUpdateResult.NoNeedUpdate; // No Need Update
                }
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

        public static enUpdateResult UpdateOnlineFromIMDb(Movie movie, bool image, bool rate,
                                                          bool year, bool duration, bool story, bool genre,
                                                          bool director, bool directorImage, bool language,
                                                          bool ignoreValid, bool generateLog, Form owner = null)
        { 
            enUpdateResult result = enUpdateResult.NoNeedUpdate;
            bool isOpen = false;

            bool shouldUpdateRate = false;
            bool shouldUpdateYear = false;
            bool shouldUpdateDuration = false;
            bool shouldUpdateImage = false;
            bool shouldUpdateStory = false;
            bool shouldUpdateGenre = false;
            bool shouldUpdateDirector = false;
            bool shouldUpdateDirectorImage = false;
            bool shouldUpdateLanguage = false;
             
            bool rateUpdated = false;
            bool yearUpdated = false;
            bool durationUpdated = false;
            bool imageUpdated = false;
            bool storyUpdated = false;
            bool genreUpdated = false;
            bool directorUpdated = false;
            bool directorImageUpdated = false;
            bool languageUpdated = false;

            DataTable dtMovieGenre = new DataTable();
            DataTable dtAllGenre = new DataTable();

            DataTable dtAllLanguage = new DataTable();
            DataTable dtMovieLanguage = new DataTable();

            DataTable dtAllDirector = new DataTable();
            DataTable dtMovieDirector = new DataTable(); 

            try
            {
                IMDb imdb = new IMDb(false);

                if (rate == true) 
                {
                    if (movie.IMDBRate == 0 || ignoreValid == false)
                    {
                        shouldUpdateRate = true;

                        try
                        {
                            try
                            {
                                if (imdb.HasRate == false &&
                                    imdb.HasURL == false)
                                {
                                    imdb = new IMDb(true, movie.IMDBLink);
                                    isOpen = true;
                                }

                                if (imdb.HasRate == false &&
                                    imdb.HasURL == true)
                                {
                                    imdb.Update();
                                    isOpen = true;
                                }
                            }
                            catch (Exception ex)
                            {
                                
                            }

                            movie.IMDBRate = imdb.Rate;
                            rateUpdated = true;
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }


                if (year == true)
                {
                    if (movie.ProductYear == 0 || ignoreValid == false)
                    {
                        shouldUpdateYear = true;

                        try
                        {
                            try
                            {
                                if (imdb.HasYear == false &&
                                    imdb.HasURL == false)
                                {
                                    imdb = new IMDb(true, movie.IMDBLink);
                                    isOpen = true;
                                }

                                if (imdb.HasYear == false &&
                                    imdb.HasURL == true)
                                {
                                    imdb.Update();
                                    isOpen = true;
                                }
                            }
                            catch (Exception ex)
                            {
                               
                            }

                            movie.ProductYear = imdb.Year;
                            yearUpdated = true;

                            if (shouldUpdateRate == true)
                            {
                                if (imdb.HasRate == true)
                                {
                                    movie.IMDBRate = imdb.Rate;
                                    rateUpdated = true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                if (duration == true)
                {
                    if (movie.Duration.TotalSeconds == 0 || ignoreValid == false)
                    {
                        shouldUpdateDuration = true;

                        try
                        {
                            try
                            {
                                if (imdb.HasDuration == false &&
                                    imdb.HasURL == false)
                                {
                                    imdb = new IMDb(true, movie.IMDBLink);
                                    isOpen = true;
                                }

                                if (imdb.HasDuration == false &&
                                    imdb.HasURL == true)
                                {
                                    imdb.Update();
                                    isOpen = true;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                      
                            movie.Duration = imdb.Duration;
                            durationUpdated = true;

                            if (shouldUpdateRate == true)
                            {
                                if (imdb.HasRate == true)
                                {
                                    movie.IMDBRate = imdb.Rate;
                                    rateUpdated = true;
                                }
                            }

                            if (shouldUpdateYear == true)
                            {
                                if (imdb.HasYear == true)
                                {
                                    movie.ProductYear = imdb.Year;
                                    yearUpdated = true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                if (story == true)
                {
                    if (movie.StoryLine.Length == 0 || ignoreValid == false)
                    {
                        shouldUpdateStory = true;

                        try
                        {
                            try
                            {
                                if (imdb.HasStoryLine == false &&
                                    imdb.HasURL == false)
                                {
                                    imdb = new IMDb(true, movie.IMDBLink);
                                    isOpen = true;
                                }

                                if (imdb.HasStoryLine == false &&
                                    imdb.HasURL == true)
                                {
                                    imdb.Update();
                                    isOpen = true;
                                }
                            }
                            catch (Exception ex)
                            {
                            }

                            movie.StoryLine = imdb.StoryLine;
                            storyUpdated = true;

                            if (shouldUpdateRate == true)
                            {
                                if (imdb.HasRate == true)
                                {
                                    movie.IMDBRate = imdb.Rate;
                                    rateUpdated = true;
                                }
                            }

                            if (shouldUpdateYear == true)
                            {
                                if (imdb.HasYear == true)
                                {
                                    movie.ProductYear = imdb.Year;
                                    yearUpdated = true;
                                }
                            }

                            if (shouldUpdateDuration == true)
                            {
                                if (imdb.HasDuration == true)
                                {
                                    movie.Duration = imdb.Duration;
                                    durationUpdated = true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                if (genre == true)
                {
                    dtMovieGenre = Genre_SP.GetByMovieID(movie.MovieID);

                    if (dtMovieGenre.Rows.Count == 0 || ignoreValid == false)
                    {
                        shouldUpdateGenre = true;

                        if (dtAllGenre.Rows.Count == 0)
                        {
                            dtAllGenre = Genre_SP.GetList();
                        }

                        try
                        {
                            try
                            {
                                if (imdb.HasGenre == false &&
                                    imdb.HasURL == false)
                                {
                                    imdb = new IMDb(true, movie.IMDBLink);
                                    isOpen = true;
                                }

                                if (imdb.HasGenre == false &&
                                    imdb.HasURL == true)
                                {
                                    imdb.Update();
                                    isOpen = true;
                                }
                            }
                            catch (Exception ex)
                            {
                            }

                            genreUpdated = true;

                            if (shouldUpdateRate == true)
                            {
                                if (imdb.HasRate == true)
                                {
                                    movie.IMDBRate = imdb.Rate;
                                    rateUpdated = true;
                                }
                            }

                            if (shouldUpdateYear == true)
                            {
                                if (imdb.HasYear == true)
                                {
                                    movie.ProductYear = imdb.Year;
                                    yearUpdated = true;
                                }
                            }

                            if (shouldUpdateDuration == true)
                            {
                                if (imdb.HasDuration == true)
                                {
                                    movie.Duration = imdb.Duration;
                                    durationUpdated = true;
                                }
                            }

                            if (shouldUpdateStory == true)
                            {
                                if (imdb.HasStoryLine == true)
                                {
                                    movie.StoryLine = imdb.StoryLine;
                                    storyUpdated = true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                if (director == true)
                {
                    dtMovieDirector = Person_SP.GetDirectorByMovieID(movie.MovieID);

                    if (dtMovieDirector.Rows.Count == 0 || ignoreValid == false)
                    {
                        shouldUpdateDirector = true;

                        if (dtAllDirector.Rows.Count == 0)
                        {
                            dtAllDirector = Person_SP.GetList();
                        }

                        try
                        {
                            try
                            {
                                if (imdb.HasDirector == false &&
                                    imdb.HasURL == false)
                                {
                                    imdb = new IMDb(true, movie.IMDBLink);
                                    isOpen = true;
                                }

                                if (imdb.HasDirector == false &&
                                    imdb.HasURL == true)
                                {
                                    imdb.Update();
                                    isOpen = true;
                                }
                            }
                            catch (Exception ex)
                            {
                            }

                            directorUpdated = true;

                            if (shouldUpdateRate == true)
                            {
                                if (imdb.HasRate == true)
                                {
                                    movie.IMDBRate = imdb.Rate;
                                    rateUpdated = true;
                                }
                            }

                            if (shouldUpdateYear == true)
                            {
                                if (imdb.HasYear == true)
                                {
                                    movie.ProductYear = imdb.Year;
                                    yearUpdated = true;
                                }
                            }

                            if (shouldUpdateDuration == true)
                            {
                                if (imdb.HasDuration == true)
                                {
                                    movie.Duration = imdb.Duration;
                                    durationUpdated = true;
                                }
                            }

                            if (shouldUpdateStory == true)
                            {
                                if (imdb.HasStoryLine == true)
                                {
                                    movie.StoryLine = imdb.StoryLine;
                                    storyUpdated = true;
                                }
                            }

                            if (shouldUpdateGenre == true)
                            {
                                if (imdb.HasGenre == true)
                                {
                                    genreUpdated = true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                if (language == true)
                {
                    dtMovieLanguage = Language_SP.GetByMovieID(movie.MovieID);

                    if (dtMovieLanguage.Rows.Count == 0 || ignoreValid == false)
                    {
                        shouldUpdateLanguage = true;

                        if (dtAllLanguage.Rows.Count == 0)
                        {
                            dtAllLanguage = Language_SP.GetList();
                        }

                        try
                        {
                            try
                            {
                                if (imdb.HasLanguage == false &&
                                    imdb.HasURL == false)
                                {
                                    imdb = new IMDb(true, movie.IMDBLink);
                                    isOpen = true;
                                }

                                if (imdb.HasLanguage == false &&
                                    imdb.HasURL == true)
                                {
                                    imdb.Update();
                                    isOpen = true;
                                }
                            }
                            catch (Exception ex)
                            {
                            }

                            languageUpdated = true;

                            if (shouldUpdateRate == true)
                            {
                                if (imdb.HasRate == true)
                                {
                                    movie.IMDBRate = imdb.Rate;
                                    rateUpdated = true;
                                }
                            }

                            if (shouldUpdateYear == true)
                            {
                                if (imdb.HasYear == true)
                                {
                                    movie.ProductYear = imdb.Year;
                                    yearUpdated = true;
                                }
                            }

                            if (shouldUpdateDuration == true)
                            {
                                if (imdb.HasDuration == true)
                                {
                                    movie.Duration = imdb.Duration;
                                    durationUpdated = true;
                                }
                            }

                            if (shouldUpdateStory == true)
                            {
                                if (imdb.HasStoryLine == true)
                                {
                                    movie.StoryLine = imdb.StoryLine;
                                    storyUpdated = true;
                                }
                            }

                            if (shouldUpdateGenre == true)
                            {
                                if (imdb.HasGenre == true)
                                {
                                    genreUpdated = true;
                                }
                            }

                            if (shouldUpdateDirector == true)
                            {
                                if (imdb.HasDirector == true)
                                {
                                    directorUpdated = true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                if (directorImage == true)
                {
                    dtMovieDirector = Person_SP.GetDirectorByMovieID(movie.MovieID);

                    try
                    {
                        try
                        {
                            if (directorUpdated == true)
                            {
                                shouldUpdateDirectorImage = true;
                            }
                            else
                            {
                                foreach (DataRow dr in dtMovieDirector.Rows)
                                {
                                    if (File.Exists(dr["PhotoLink"].ToString()) == false)
                                    {
                                        shouldUpdateDirectorImage = true;
                                        break;
                                    }
                                }
                            }
                            
                            if (shouldUpdateDirectorImage == true && imdb.HasURL == false && imdb.HasDirector == false)
                            {
                                try
                                {
                                    if (imdb.HasURL == false && imdb.HasDirector == false)
                                    {
                                        imdb = new IMDb(true, movie.IMDBLink);
                                        isOpen = true;
                                    }

                                    if (imdb.HasURL == true && imdb.HasDirector == false)
                                    {
                                        imdb.Update();
                                        isOpen = true;
                                    }
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }

                        if (imdb.HasDirector == true)
                        {
                            if (Directory.Exists(PathUtils.GetApplicationPersonPath()) == false)
                            {
                                Directory.CreateDirectory(PathUtils.GetApplicationPersonPath());
                            }

                            if (Directory.Exists(PathUtils.GetApplicationTempPath()) == false)
                            {
                                Directory.CreateDirectory(PathUtils.GetApplicationTempPath());
                            }

                            if (directorUpdated == false)
                            {
                                foreach (DataRow dr in dtMovieDirector.Rows)
                                {
                                    if (File.Exists(dr["PhotoLink"].ToString()) == false)
                                    {
                                        foreach (Person p in imdb.Directors)
                                        {
                                            if (dr["FullName"].ToString() == p.FullName && p.PhotoLink.Length > 0)
                                            {
                                                if (File.Exists(PersonPhotoPath + dr["FullName"].ToString() + ".jpg") == false)
                                                {
                                                    string realName = p.FullName + Path.GetExtension(p.PhotoLink);
                                                    string realImageLink = PersonPhotoPath + realName;
                                                    string realTemp = PathUtils.GetApplicationTempPath() + realName;

                                                    IMDb.DownloadImage(p.PhotoLink, realTemp);
                                                    isOpen = true;

                                                    InsertManager im = new InsertManager(generateLog, false);
                                                    realImageLink = im.RenameFile(realTemp, realImageLink);

                                                    if (File.Exists(realImageLink) == true)
                                                    {
                                                        p.PhotoLink = Path.GetFileName(realImageLink);
                                                        p.PersonID = Convert.ToInt64(dr["PersonID"].ToString());
                                                        directorImageUpdated = true;
                                                    }

                                                    File.Delete(realTemp);
                                                    break;
                                                }
                                                else
                                                {
                                                    p.PhotoLink = dr["FullName"].ToString() + ".jpg";
                                                    p.PersonID = Convert.ToInt64(dr["PersonID"].ToString());
                                                    directorImageUpdated = true;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                foreach (Person p in imdb.Directors)
                                {
                                    if (File.Exists(PersonPhotoPath + p.FullName + ".jpg") == false)
                                    {
                                        string realName = p.FullName + Path.GetExtension(p.PhotoLink);
                                        string realImageLink = PersonPhotoPath + realName;
                                        string realTemp = PathUtils.GetApplicationTempPath() + realName;

                                        IMDb.DownloadImage(p.PhotoLink, realTemp);
                                        isOpen = true;

                                        InsertManager im = new InsertManager(generateLog, false);
                                        realImageLink = im.RenameFile(realTemp, realImageLink);

                                        if (File.Exists(realImageLink) == true)
                                        {
                                            p.PhotoLink = Path.GetFileName(realImageLink);
                                            p.PersonID = 99999999;
                                            directorImageUpdated = true;
                                        }

                                        File.Delete(realTemp);
                                    }
                                    else
                                    {
                                        p.PhotoLink = p.FullName + ".jpg";
                                        p.PersonID = 99999999;
                                        directorImageUpdated = true;
                                    }
                                }
                            }
                        }

                        if (shouldUpdateRate == true)
                        {
                            if (imdb.HasRate == true)
                            {
                                movie.IMDBRate = imdb.Rate;
                                rateUpdated = true;
                            }
                        }

                        if (shouldUpdateYear == true)
                        {
                            if (imdb.HasYear == true)
                            {
                                movie.ProductYear = imdb.Year;
                                yearUpdated = true;
                            }
                        }

                        if (shouldUpdateDuration == true)
                        {
                            if (imdb.HasDuration == true)
                            {
                                movie.Duration = imdb.Duration;
                                durationUpdated = true;
                            }
                        }

                        if (shouldUpdateStory == true)
                        {
                            if (imdb.HasStoryLine == true)
                            {
                                movie.StoryLine = imdb.StoryLine;
                                storyUpdated = true;
                            }
                        }

                        if (shouldUpdateGenre == true)
                        {
                            if (imdb.HasGenre == true)
                            {
                                genreUpdated = true;
                            }
                        }

                        if (shouldUpdateDirector == true)
                        {
                            if (imdb.HasDirector == true)
                            {
                                directorUpdated = true;
                            }
                        }

                        if (shouldUpdateLanguage == true)
                        {
                            if (imdb.HasLanguage == true)
                            {
                                languageUpdated = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }

                if (image == true)
                {

                    if (File.Exists(PathUtils.GetApplicationMoviePosterPath() + movie.PosterLink) == false || ignoreValid == false)
                    {
                        shouldUpdateImage = true;

                        try
                        {
                            try
                            {
                                try
                                {
                                    if (imdb.HasPhotoURL == false &&
                                        imdb.HasURL == false)
                                    {
                                        imdb = new IMDb(true, movie.IMDBLink);
                                        isOpen = true;
                                    }

                                    if (imdb.HasPhotoURL == false &&
                                        imdb.HasURL == true)
                                    {
                                        imdb.Update();
                                        isOpen = true;
                                    }
                                }
                                catch (Exception ex)
                                {

                                }
                                

                                if (shouldUpdateRate == true)
                                {
                                    if (imdb.HasRate == true)
                                    {
                                        movie.IMDBRate = imdb.Rate;
                                        rateUpdated = true;
                                    }
                                }

                                if (shouldUpdateYear == true)
                                {
                                    if (imdb.HasYear == true)
                                    {
                                        movie.ProductYear = imdb.Year;
                                        yearUpdated = true;
                                    }
                                }

                                if (shouldUpdateDuration == true)
                                {
                                    if (imdb.HasDuration == true)
                                    {
                                        movie.Duration = imdb.Duration;
                                        durationUpdated = true;
                                    }
                                }

                                if (shouldUpdateStory == true)
                                {
                                    if (imdb.HasStoryLine == true)
                                    {
                                        movie.StoryLine = imdb.StoryLine;
                                        storyUpdated = true;
                                    }
                                }

                                if (shouldUpdateGenre == true)
                                {
                                    if (imdb.HasGenre == true)
                                    {
                                        genreUpdated = true;
                                    }
                                }

                                if (shouldUpdateDirector == true)
                                {
                                    if (imdb.HasDirector == true)
                                    {
                                        directorUpdated = true;
                                    }
                                }

                                if (shouldUpdateLanguage == true)
                                {
                                    if (imdb.HasLanguage == true)
                                    {
                                        languageUpdated = true;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }

                            if (imdb.HasPhotoURL == true)
                            {
                                string realName = movie.FullTitle + Path.GetExtension(imdb.PhotoURL);
                                string realImageLink = PathUtils.GetApplicationMoviePosterPath() + realName;
                                string realTemp = PathUtils.GetApplicationTempPath() + realName;

                                if (Directory.Exists(PathUtils.GetApplicationMoviePosterPath()) == false)
                                {
                                    Directory.CreateDirectory(PathUtils.GetApplicationMoviePosterPath());
                                }

                                if (Directory.Exists(PathUtils.GetApplicationTempPath()) == false)
                                {
                                    Directory.CreateDirectory(PathUtils.GetApplicationTempPath());
                                }

                                IMDb.DownloadImage(imdb.PhotoURL, realTemp);
                                isOpen = true;

                                InsertManager im = new InsertManager(generateLog, false);
                                realImageLink = im.RenameFile(realTemp, realImageLink);

                                if (File.Exists(realImageLink) == true)
                                {
                                    movie.PosterLink = Path.GetFileName(realImageLink);
                                    imageUpdated = true;
                                }

                                File.Delete(realTemp);
                            }
                            else
                            {
                                string realName = movie.FullTitle + ".jpg";
                                string realImageLink = PathUtils.GetApplicationMoviePosterPath() + realName;

                                File.Delete(realImageLink);

                                movie.PosterLink = "";
                                imageUpdated = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            
                        }
                    }
                }

                if (shouldUpdateDuration == true && durationUpdated == false)
                {
                    if (generateLog == true)
                    {
                        iMovieBase.log.GenerateSilent("Could not get movie duration." + Environment.NewLine + movie.FullTitle);
                    }
                }

                if (shouldUpdateImage == true && imageUpdated == false)
                {
                    if (generateLog == true)
                    {
                        iMovieBase.log.GenerateSilent("Could not get movie poster image." + Environment.NewLine + movie.FullTitle);
                    }
                }

                if (shouldUpdateRate == true && rateUpdated == false)
                {
                    if (generateLog == true)
                    {
                        iMovieBase.log.GenerateSilent("Could not get movie IMDb rate." + Environment.NewLine + movie.FullTitle);
                    }
                }

                if (shouldUpdateYear == true && yearUpdated == false)
                {
                    if (generateLog == true)
                    {
                        iMovieBase.log.GenerateSilent("Could not get movie release year." + Environment.NewLine + movie.FullTitle);
                    }
                }

                if (shouldUpdateStory == true && storyUpdated == false)
                {
                    if (generateLog == true)
                    {
                        iMovieBase.log.GenerateSilent("Could not get movie storyline." + Environment.NewLine + movie.FullTitle);
                    }
                }

                if (shouldUpdateGenre == true && genreUpdated == false)
                {
                    if (generateLog == true)
                    {
                        iMovieBase.log.GenerateSilent("Could not get movie genres." + Environment.NewLine + movie.FullTitle);
                    }
                }

                if (shouldUpdateDirector == true && directorUpdated == false)
                {
                    if (generateLog == true)
                    {
                        iMovieBase.log.GenerateSilent("Could not get movie directors." + Environment.NewLine + movie.FullTitle);
                    }
                }

                if (shouldUpdateDirectorImage == true && directorImageUpdated == false)
                {
                    if (generateLog == true)
                    {
                        iMovieBase.log.GenerateSilent("Could not get director image." + Environment.NewLine + movie.FullTitle);
                    }
                }

                if (shouldUpdateLanguage == true && languageUpdated == false)
                {
                    if (generateLog == true)
                    {
                        iMovieBase.log.GenerateSilent("Could not get movie language." + Environment.NewLine + movie.FullTitle);
                    }
                }

                if (shouldUpdateDuration == true || shouldUpdateImage == true || shouldUpdateGenre == true || shouldUpdateDirector ==true || shouldUpdateDirectorImage == true || shouldUpdateLanguage == true ||
                    shouldUpdateRate == true || shouldUpdateYear == true || shouldUpdateStory == true)
                {
                    if (rateUpdated == true || yearUpdated == true || genreUpdated == true || directorUpdated ==true || directorImageUpdated == true || languageUpdated == true ||
                        durationUpdated == true || imageUpdated == true || storyUpdated == true)
                    {
                        try
                        {
                            if (genreUpdated == true)
                            {
                                bool existedGenre = false;

                                foreach (DataRow mdr in dtMovieGenre.Rows)
                                {
                                    existedGenre = false;

                                    foreach (Genre gen in imdb.Genre)
                                    {
                                        if (mdr["GenreName"].ToString().Equals(gen.GenreName, StringComparison.CurrentCultureIgnoreCase) == true)
                                        {
                                            existedGenre = true;
                                            break;
                                        }
                                    }

                                    if (existedGenre == false)
                                    {
                                        long genID = Convert.ToInt64(mdr["GenreID"].ToString());

                                        try
                                        {
                                            Movie_SP.DeleteMovieGenre(movie.MovieID, genID);
                                        }
                                        catch (Exception ex)
                                        {

                                        }
                                    }
                                }

                                int i = 0;

                                foreach (Genre gen in imdb.Genre)
                                {
                                    existedGenre = false;
                                    long insertGenreID = 0;

                                    foreach (DataRow mdr in dtMovieGenre.Rows)
                                    {
                                        if (mdr["GenreName"].ToString().Equals(gen.GenreName, StringComparison.CurrentCultureIgnoreCase) == true)
                                        {
                                            existedGenre = true;
                                            break;
                                        }
                                    } 

                                    if (existedGenre == false)
                                    {
                                        foreach (DataRow alldr in dtAllGenre.Rows)
                                        {
                                            if (alldr["GenreName"].ToString().Equals(gen.GenreName, StringComparison.CurrentCultureIgnoreCase) == true)
                                            {
                                                insertGenreID = Convert.ToInt64(alldr["GenreID"].ToString());
                                                break;
                                            }
                                        }

                                        try
                                        {
                                            if (insertGenreID > 0)
                                            {
                                                if (i == 0)
                                                {
                                                    Movie_SP.InsertMovieGenre(movie.MovieID, insertGenreID, true);
                                                }
                                                else
                                                {
                                                    Movie_SP.InsertMovieGenre(movie.MovieID, insertGenreID, false);
                                                }
                                            }
                                            else
                                            {
                                                insertGenreID = Genre_SP.Insert(gen);

                                                if (insertGenreID > 0)
                                                {
                                                    if (i == 0)
                                                    {
                                                        Movie_SP.InsertMovieGenre(movie.MovieID, insertGenreID, true);
                                                    }
                                                    else
                                                    {
                                                        Movie_SP.InsertMovieGenre(movie.MovieID, insertGenreID, false);
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                        }
                                    }
                                }
                            }

                            if (languageUpdated == true)
                            {
                                bool existedLanguage = false;

                                foreach (DataRow mdr in dtMovieLanguage.Rows)
                                {
                                    existedLanguage = false;

                                    foreach (Language lang in imdb.Languages)
                                    {
                                        if (mdr["LanguageName"].ToString().Equals(lang.LanguageName, StringComparison.CurrentCultureIgnoreCase) == true)
                                        {
                                            existedLanguage = true;
                                            break;
                                        }
                                    }

                                    if (existedLanguage == false)
                                    {
                                        long langID = Convert.ToInt64(mdr["LanguageID"].ToString());

                                        try
                                        {
                                            Movie_SP.DeleteMovieLanguage(movie.MovieID, langID);
                                        }
                                        catch (Exception ex)
                                        {

                                        }
                                    }
                                }

                                foreach (Language lang in imdb.Languages)
                                {
                                    existedLanguage = false;
                                    long insertLanguageID = 0;

                                    foreach (DataRow mdr in dtMovieLanguage.Rows)
                                    {
                                        if (mdr["LanguageName"].ToString().Equals(lang.LanguageName, StringComparison.CurrentCultureIgnoreCase) == true)
                                        {
                                            existedLanguage = true;
                                            break;
                                        }
                                    }

                                    if (existedLanguage == false)
                                    {
                                        foreach (DataRow alldr in dtAllLanguage.Rows)
                                        {
                                            if (alldr["LanguageName"].ToString().Equals(lang.LanguageName, StringComparison.CurrentCultureIgnoreCase) == true)
                                            {
                                                insertLanguageID = Convert.ToInt64(alldr["LanguageID"].ToString());
                                                break;
                                            }
                                        }

                                        try
                                        {
                                            if (insertLanguageID > 0)
                                            {
                                                Movie_SP.InsertMovieLanguage(movie.MovieID, insertLanguageID);
                                            }
                                            else
                                            {
                                                insertLanguageID = Language_SP.Insert(lang);

                                                if (insertLanguageID > 0)
                                                {
                                                    Movie_SP.InsertMovieLanguage(movie.MovieID, insertLanguageID);
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                        }
                                    }
                                }
                            }

                            if (directorUpdated == true)
                            {
                                bool existedDirector = false;

                                foreach (DataRow mdr in dtMovieDirector.Rows)
                                {
                                    existedDirector = false;

                                    foreach (Person per in imdb.Directors)
                                    {
                                        if (Person_SP.IsSamePerson(per.FullName, per.IMDBLink, mdr) > 0)
                                        {
                                            existedDirector = true;
                                            break;
                                        }
                                    }

                                    if (existedDirector == false)
                                    {
                                        long personID = Convert.ToInt64(mdr["PersonID"].ToString());

                                        try
                                        {
                                            Movie_SP.DeleteMovieDirector(movie.MovieID, personID);
                                        }
                                        catch (Exception ex)
                                        {

                                        }
                                    }
                                }

                                foreach (Person per in imdb.Directors)
                                {
                                    existedDirector = false;
                                    long insertDirectorID = 0;

                                    foreach (DataRow mdr in dtMovieDirector.Rows)
                                    {
                                        if (Person_SP.IsSamePerson(per.FullName, per.IMDBLink, mdr) > 0)
                                        {
                                            existedDirector = true;
                                            break;
                                        }
                                    }

                                    if (existedDirector == false)
                                    {   
                                        try
                                        {
                                            insertDirectorID = Person_SP.GetPersonID(per.FullName, per.IMDBLink);

                                            if (insertDirectorID > 0)
                                            {
                                                Movie_SP.InsertMovieDirector(movie.MovieID, insertDirectorID);
                                            }
                                            else
                                            {
                                                insertDirectorID = Person_SP.Insert(per, false, true);

                                                if (insertDirectorID > 0)
                                                {
                                                    Movie_SP.InsertMovieDirector(movie.MovieID, insertDirectorID);
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                        }
                                    }
                                }
                            }

                            if (directorImageUpdated == true)
                            {
                                if (directorUpdated == false)
                                {
                                    foreach (Person p in imdb.Directors)
                                    {
                                        try
                                        {
                                            if (p.PersonID > 0 && p.PhotoLink.Length > 0)
                                            {
                                                Person_SP.UpdatePhotoLinkByID(p.PersonID, p.PhotoLink);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                        }
                                    }
                                }
                                else
                                {
                                    dtMovieDirector = Person_SP.GetDirectorByMovieID(movie.MovieID);

                                    foreach (DataRow dr in dtMovieDirector.Rows)
                                    {
                                        foreach (Person p in imdb.Directors)
                                        {
                                            if (dr["FullName"].ToString() == p.FullName && p.PersonID == 99999999)
                                            {
                                                Person_SP.UpdatePhotoLinkByID(Convert.ToInt64(dr["PersonID"].ToString()), p.PhotoLink);
                                                break;
                                            }
                                        }
                                    }
                                }
                            }

                            if (rateUpdated == true || yearUpdated == true ||
                                durationUpdated == true || imageUpdated == true || storyUpdated == true)
                            {

                                movie.IMDBLink = imdb.URL;

                                long res = 0;
                                res = Movie_SP.UpdateOnline(movie);

                                if (res > 0)
                                {
                                    result = enUpdateResult.Updated;
                                }
                            }
                            else
                            {
                                result = enUpdateResult.Updated;
                            }
                        }
                        catch (Exception ex)
                        {
                            if (generateLog == true)
                            {
                                iMovieBase.log.GenerateSilent(Messages.UpdateError + Environment.NewLine + movie.FullTitle + Environment.NewLine + ex.Message);
                            }
                        }
                    }
                    else
                    {
                        if (generateLog == true)
                        {
                            iMovieBase.log.GenerateSilent("Could not get online updates for this movie." + Environment.NewLine + movie.FullTitle);
                        }
                    }

                    Thread.Sleep(700);
                }

                if (owner != null)
                {
                    (owner as frmOnlineMovieUpdate).InvokeHandle();
                }

                if (result == enUpdateResult.Updated)
                {
                    return enUpdateResult.Updated; // Updated
                }
                else if ((shouldUpdateDuration == true || shouldUpdateImage == true || shouldUpdateGenre == true || shouldUpdateDirector == true || shouldUpdateDirectorImage == true || shouldUpdateLanguage == true ||
                          shouldUpdateRate == true || shouldUpdateYear == true || shouldUpdateStory == true) && isOpen == false &&
                          result != enUpdateResult.Updated)
                {
                    return enUpdateResult.NotOpen; // Not Open Banned
                }
                else if ((shouldUpdateDuration == true || shouldUpdateImage == true || shouldUpdateGenre == true || shouldUpdateDirector == true || shouldUpdateDirectorImage == true || shouldUpdateLanguage == true ||
                          shouldUpdateRate == true || shouldUpdateYear == true || shouldUpdateStory == true) && isOpen == true &&
                          result != enUpdateResult.Updated)
                {
                    return enUpdateResult.UpdateError; // Update Error
                }
                else
                {
                    return enUpdateResult.NoNeedUpdate; // No Need Update
                }
            }
            catch (Exception ex)
            {
                if (owner != null)
                {
                    (owner as frmOnlineMovieUpdate).InvokeHandle();
                }

                if (result == enUpdateResult.Updated)
                {
                    return enUpdateResult.Updated; // Updated
                }
                else if ((shouldUpdateDuration == true || shouldUpdateImage == true || shouldUpdateGenre == true || shouldUpdateDirector == true || shouldUpdateDirectorImage == true || shouldUpdateLanguage == true ||
                          shouldUpdateRate == true || shouldUpdateYear == true || shouldUpdateStory == true) && isOpen == false &&
                          result != enUpdateResult.Updated)
                {
                    return enUpdateResult.NotOpen; // Not Open Banned
                }
                else if ((shouldUpdateDuration == true || shouldUpdateImage == true || shouldUpdateGenre == true || shouldUpdateDirector == true || shouldUpdateDirectorImage == true || shouldUpdateLanguage == true ||
                          shouldUpdateRate == true || shouldUpdateYear == true || shouldUpdateStory == true) && isOpen == true &&
                          result != enUpdateResult.Updated)
                {
                    return enUpdateResult.UpdateError; // Update Error
                }
                else
                {
                    return enUpdateResult.NoNeedUpdate; // No Need Update
                }
            }
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
