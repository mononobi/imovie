using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace iMovie
{
    public class Genre_SP
    {
        public static long Insert(Genre genre)
        {
            try
            {
                long count = 0;
                count = AccessDatabase.CountFunction(FunctionRepository.CountGenreName, "@GenreName", genre.GenreName);

                if (count > 0)
                {
                    throw new Exception(Messages.AlreadyExistGenreName);
                }

                long genreID = 0;
                genreID = AccessDatabase.Insert(QueryRepository.Genre_Insert, 
                                                "@GenreName", genre.GenreName,
                                                "@IsMain", Genre.DetectIsMain(genre.GenreName));

                if (genreID <= 0)
                {
                    throw new Exception(Messages.DatabaseError);
                }

                return genreID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetByID(long genreID)
        {
            try
            {
                DataTable dtGenre = new DataTable();
                dtGenre = AccessDatabase.Select(QueryRepository.Genre_Get_By_GenreID, "@GenreID", genreID);

                return dtGenre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetList()
        {
            try
            {
                DataTable dtGenre = new DataTable();
                dtGenre = AccessDatabase.Select(QueryRepository.Genre_Get_List);

                return dtGenre;
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

                DataTable dtGenres = new DataTable();
                dtGenres = AccessDatabase.Select(QueryRepository.Genre_Get_By_Name, "@GenreName", name);

                return dtGenres;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long Delete(long genreID)
        {
            try
            {
                long count = 0;
                count = AccessDatabase.Delete(QueryRepository.Genre_Delete, "@GenreID", genreID);

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetByMovieID(long movieID)
        {
            try 
            { 
                DataTable dtGenre = new DataTable();
                dtGenre = AccessDatabase.Select(QueryRepository.Genre_Get_By_MovieID, "@MovieID", movieID);

                return dtGenre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
