using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace iMovie
{
    public class Person 
    {
        public const int PersonID_Min_Value = 1;
        public const int PersonFName_Min_Length = 1;
        public const int PersonFName_Max_Length = 25;
        public const int PersonLName_Min_Length = 0;
        public const int PersonLName_Max_Length = 25;
        public const int IMDBLink_Min_Length = 0;
        public const int IMDBLink_Max_Length = 125; 
        public const int PhotoLink_Min_Length = 0; 
        public const int PhotoLink_Max_Length = 125;
         
        private long personID = 0;
        private string personFName = ""; 
        private string personLName = ""; 
        private string imdbLink = ""; 
        private string photoLink = "";

        public Person(long personID, string personFName, string personLName, string imdbLink, string photoLink)
        {
            try 
            {
                string result = "";

                if (Person.Validate(personID, personFName, personLName, imdbLink, photoLink, out result) == true)
                {
                    this.PersonID = personID;
                    this.PersonFName = personFName;
                    this.PersonLName = personLName;
                    this.IMDBLink = imdbLink;
                    this.PhotoLink = photoLink;
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

        public Person(long personID, string personFullName, string imdbLink, string photoLink)
        {
            try 
            {
                string result = "";
                string[] name = SplitFullName(personFullName);

                if (Person.Validate(personID, name[0], name[1], imdbLink, photoLink, out result) == true)
                {
                    this.PersonID = personID;
                    this.PersonFName = name[0];
                    this.PersonLName = name[1];
                    this.IMDBLink = imdbLink;
                    this.PhotoLink = photoLink;
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

        public Person()
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Validate(long personID, string personFName, string personLName, string imdbLink, string photoLink, out string result)
        { 
            try
            {
                result = "";

                if (IsPersonID(personID.ToString()) == false)
                {
                    result += Messages.InvalidPersonID + Environment.NewLine;
                }

                if (IsPersonFName(personFName) == false)
                {
                    result += Messages.InvalidPersonFName + Environment.NewLine;
                }

                if (IsPersonLName(personLName) == false)
                {
                    result += Messages.InvalidPersonLName + Environment.NewLine;
                }

                if (IsIMDBLink(imdbLink) == false)
                {
                    result += Messages.InvalidIMDBLink + Environment.NewLine;
                }

                if (IsPhotoLink(photoLink) == false)
                {
                    result += Messages.InvalidPhotoLink + Environment.NewLine;
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

        public long PersonID
        {
            get
            {
                try
                {
                    return this.personID;
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
                    if (IsPersonID(value.ToString()) == true)
                    {
                        this.personID = value;
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidPersonID);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string PersonFName
        {
            get
            {
                try
                {
                    return this.personFName;
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
                    if (IsPersonFName(value) == true)
                    {
                        this.personFName = value;
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidPersonFName);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string PersonLName
        {
            get
            {
                try
                {
                    return this.personLName;
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
                    if (IsPersonLName(value) == true)
                    {
                        this.personLName = value;
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidPersonLName);
                    }
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
        
        public string PhotoLink
        {
            get
            {
                try
                {
                    return this.photoLink;
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
                    if (IsPhotoLink(value) == true)
                    {
                        this.photoLink = value;
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidPhotoLink);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string FullName
        {
            get
            {
                try
                {
                    return (this.PersonFName + " " + this.PersonLName).Trim();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static string[] SplitFullName(string fullName)
        {
            try
            {
                string[] result = new string[2];
                fullName = fullName.Trim();
                result[0] = "";
                result[1] = "";

                if (fullName.Length > 0)
                {
                    string[] sep = { " " };
                    string[] name = fullName.Split(sep, StringSplitOptions.RemoveEmptyEntries);

                    if (name.Length > 0)
                    {
                        result[0] = name[0];

                        for (int i = 1; i < name.Length; i++)
                        {
                            result[1] += name[i] + " ";
                        }

                        result[1] = result[1].Trim();
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool IsPersonID(string value)
        {
            try
            {
                long tmp = 0;

                if (long.TryParse(value, out tmp) == true)
                {
                    if (tmp >= PersonID_Min_Value || tmp == 0)
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

        public static bool IsPersonFName(string value)
        {
            try
            {
                if (value.Length >= PersonFName_Min_Length && value.Length <= PersonFName_Max_Length)
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

        public static bool IsPersonLName(string value)
        {
            try
            {
                if (value.Length >= PersonLName_Min_Length && value.Length <= PersonLName_Max_Length)
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

        public static bool IsPhotoLink(string value)
        {
            try
            {
                if (value.Length >= PhotoLink_Min_Length && value.Length <= PhotoLink_Max_Length)
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

        public void FetchSinglePerson(DataTable dtPerson)
        {
            try
            {
                if (dtPerson.Rows.Count >= 1)
                {
                    Person person = FetchAllPerson(dtPerson)[0];

                    this.PersonID = person.PersonID;
                    this.PersonFName = person.PersonFName;
                    this.PersonLName = person.PersonLName;
                    this.IMDBLink = person.IMDBLink;
                    this.PhotoLink = person.PhotoLink;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Person[] FetchAllPerson(DataTable dtPerson)
        {
            try
            {  
                Person[] personTemp = new Person[dtPerson.Rows.Count];
                int i = 0;

                while (i < dtPerson.Rows.Count)
                {
                    personTemp[i] = new Person();
                    i++;
                }

                i = 0;

                while (i < dtPerson.Rows.Count)
                {
                    personTemp[i].PersonID = Convert.ToInt64(dtPerson.Rows[i]["PersonID"].ToString());
                    personTemp[i].PersonFName = dtPerson.Rows[i]["PersonFName"].ToString();
                    personTemp[i].PersonLName = dtPerson.Rows[i]["PersonLName"].ToString();
                    personTemp[i].IMDBLink = dtPerson.Rows[i]["IMDBLink"].ToString();
                    personTemp[i].PhotoLink = dtPerson.Rows[i]["PhotoLink"].ToString();

                    i++;
                }

                return personTemp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
