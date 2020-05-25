using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace iMovie
{
    public class Language_SP
    {
        public static long Insert(Language language)
        {
            try
            {
                long count = 0;
                count = AccessDatabase.CountFunction(FunctionRepository.CountLanguageName, "@LanguageName", language.LanguageName);

                if (count > 0)
                {
                    throw new Exception(Messages.AlreadyExistLanguageName);
                }

                long languageID = 0;
                languageID = AccessDatabase.Insert(QueryRepository.Language_Insert, "@LanguageName", language.LanguageName);

                if (languageID <= 0)
                {
                    throw new Exception(Messages.DatabaseError);
                }

                return languageID;
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
                DataTable dtLanguage = new DataTable();
                dtLanguage = AccessDatabase.Select(QueryRepository.Language_Get_List);

                return dtLanguage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetByID(long languageID)
        {
            try
            {
                DataTable dtLanguage = new DataTable();
                dtLanguage = AccessDatabase.Select(QueryRepository.Language_Get_By_LanguageID, "@LanguageID", languageID);

                return dtLanguage;
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
                DataTable dtLanguage = new DataTable();
                dtLanguage = AccessDatabase.Select(QueryRepository.Language_Get_By_MovieID, "@MovieID", movieID);

                return dtLanguage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetByName(string name)
        {
            name = name.Trim();

            DataTable dtLanguages = new DataTable();
            dtLanguages = AccessDatabase.Select(QueryRepository.Language_Get_By_Name, "@LanguageName", name);

            return dtLanguages;
        }
    }
}
