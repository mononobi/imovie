using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace iMovie
{
    public class Language
    {
        public const int LanguageID_Min_Value = 1; 
        public const int LanguageName_Min_Length = 1;
        public const int LanguageName_Max_Length = 25;

        private long languageID = 0;
        private string languageName = "";

        public Language(long languageID, string languageName)
        {
            try
            {
                string result = "";

                if (Language.Validate(languageID, languageName, out result) == true)
                {
                    this.LanguageID = languageID;
                    this.LanguageName = languageName;
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

        public Language()
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Validate(long languageID, string languageName, out string result)
        {
            try
            {
                result = "";

                if (IsLanguageID(languageID.ToString()) == false)
                {
                    result += Messages.InvalidLanguageID + Environment.NewLine;
                }

                if (IsLanguageName(languageName) == false)
                {
                    result += Messages.InvalidLanguageName + Environment.NewLine;
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

        public long LanguageID
        {
            get
            {
                try
                {
                    return this.languageID;
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
                    if (IsLanguageID(value.ToString()) == true)
                    {
                        this.languageID = value;
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidLanguageID);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string LanguageName
        {
            get
            {
                try
                {
                    return this.languageName;
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
                    if (IsLanguageName(value) == true)
                    {
                        this.languageName = value;
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidLanguageName);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static bool IsLanguageID(string value)
        {
            try
            {
                long tmp = 0;

                if (long.TryParse(value, out tmp) == true)
                {
                    if (tmp >= LanguageID_Min_Value || tmp == 0)
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

        public static bool IsLanguageName(string value)
        {
            try
            {
                if (value.Length >= LanguageName_Min_Length && value.Length <= LanguageName_Max_Length)
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

        public void FetchLanguage(DataTable dtLanguage)
        {
            try
            {
                if (dtLanguage.Rows.Count >= 1)
                {
                    this.LanguageID = Convert.ToInt64(dtLanguage.Rows[0]["LanguageID"].ToString());
                    this.LanguageName = dtLanguage.Rows[0]["LanguageName"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FetchSingleLanguage(DataTable dtLanguage)
        {
            try
            {
                if (dtLanguage.Rows.Count >= 1)
                {
                    Language language = FetchAllLanguage(dtLanguage)[0];

                    this.LanguageID = language.LanguageID;
                    this.LanguageName = language.LanguageName;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Language[] FetchAllLanguage(DataTable dtLanguage)
        {
            try
            {
                Language[] languageTemp = new Language[dtLanguage.Rows.Count];
                int i = 0;

                while (i < dtLanguage.Rows.Count)
                {
                    languageTemp[i] = new Language();
                    i++;
                }

                i = 0;

                while (i < dtLanguage.Rows.Count)
                {
                    languageTemp[i].LanguageID = Convert.ToInt64(dtLanguage.Rows[i]["LanguageID"].ToString());
                    languageTemp[i].LanguageName = dtLanguage.Rows[i]["LanguageName"].ToString();

                    i++;
                }

                return languageTemp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
