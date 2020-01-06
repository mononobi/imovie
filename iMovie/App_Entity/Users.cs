using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;

namespace iMovie
{
    public class Users
    {
        public const string Email_Pattern = @"(?i:^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[a-z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum)$)";

        public const int UserID_Min_Value = 1;
        public const int Username_Min_Length = 4;
        public const int Username_Max_Length = 10;
        public const int Password_Min_Length = 4;
        public const int Password_Max_Length = 10;
        public const int FName_Min_Length = 1;
        public const int FName_Max_Length = 25;
        public const int LName_Min_Length = 1;
        public const int LName_Max_Length = 25;
        public const int Email_Min_Length = 1; 
        public const int Email_Max_Length = 50;
        
        private long userID = 0;
        private string username = ""; 
        private long passwordHash = 0;
        private string fName = ""; 
        private string lName = ""; 
        private string email = ""; 

        public Users(long userID, string username, string password, string fName, string lName, string email)
        { 
            try 
            {
                string result = "";

                if (Users.Validate(userID, username, password, fName, lName, email, out result) == true)
                {
                    this.UserID = userID;
                    this.Username = username;
                    this.Password = password;
                    this.FName = fName;
                    this.LName = lName;
                    this.Email = email;
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

        public Users()
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Validate(long userID, string username, string password, string fName, string lName, string email, out string result)
        { 
            try
            {
                result = "";

                if (IsUserID(userID.ToString()) == false)
                {
                    result += Messages.InvalidUserID + Environment.NewLine;
                }

                if (IsUsername(username) == false)
                {
                    result += Messages.InvalidUsername + Environment.NewLine;
                }

                if (IsPassword(password) == false)
                {
                    result += Messages.InvalidPassword + Environment.NewLine;
                }

                if (IsFName(fName) == false)
                {
                    result += Messages.InvalidFName + Environment.NewLine;
                }

                if (IsLName(lName) == false)
                {
                    result += Messages.InvalidLName + Environment.NewLine;
                }

                if (IsEmail(email) == false)
                {
                    result += Messages.InvalidEmail + Environment.NewLine;
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

        public long UserID
        {
            get
            {
                try
                {
                    return this.userID;
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
                    if (IsUserID(value.ToString()) == true)
                    {
                        this.userID = value;
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidUserID);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string Username
        {
            get
            {
                try
                {
                    return this.username;
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
                    if (IsUsername(value) == true)
                    {
                        this.username = value;
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidUsername);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string Password
        {
            set
            {
                try
                {
                    if (IsPassword(value) == true)
                    {
                        this.passwordHash = value.GetHashCode();
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidPassword);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public long PasswordHash
        {
            get
            {
                try
                {
                    return this.passwordHash;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string FName
        {
            get
            {
                try
                {
                    return this.fName;
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
                    if (IsFName(value) == true)
                    {
                        this.fName = value;
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidFName);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string LName
        {
            get
            {
                try
                {
                    return this.lName;
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
                    if (IsLName(value) == true)
                    {
                        this.lName = value;
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidLName);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string Email
        {
            get
            {
                try
                {
                    return this.email;
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
                    if (IsEmail(value) == true)
                    {
                        this.email = value;
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidEmail);
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
                    return this.FName + " " + this.LName;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static bool IsUserID(string value)
        {
            try
            {
                long tmp = 0;

                if (long.TryParse(value, out tmp) == true)
                {
                    if (tmp >= UserID_Min_Value || tmp == 0)
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

        public static bool IsUsername(string value)
        {
            try
            {
                if (value.Length >= Username_Min_Length && value.Length <= Username_Max_Length)
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

        public static bool IsPassword(string value)
        {
            try
            { 
                if (value.Length >= Password_Min_Length && value.Length <= Password_Max_Length)
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

        public static bool IsFName(string value)
        {
            try
            {
                if (value.Length >= FName_Min_Length && value.Length <= FName_Max_Length)
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

        public static bool IsLName(string value)
        {
            try
            {
                if (value.Length >= LName_Min_Length && value.Length <= LName_Max_Length)
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

        public static bool IsEmail(string value)
        {
            try
            {
                if (value.Length >= Email_Min_Length && value.Length <= Email_Max_Length)
                {
                    Regex email = new Regex(Email_Pattern);

                    if (email.IsMatch(value) == true) 
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

        public void FetchSingleUser(DataTable dtUser)
        {
            try
            {
                if (dtUser.Rows.Count >= 1)
                {
                    Users user = FetchAllUser(dtUser)[0];

                    this.UserID = user.UserID;
                    this.Username = user.Username;
                    this.FName = user.FName;
                    this.LName = user.LName;
                    this.Email = user.Email;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Users[] FetchAllUser(DataTable dtUser)
        {
            try
            {
                Users[] userTemp = new Users[dtUser.Rows.Count];
                int i = 0;

                while (i < dtUser.Rows.Count)
                {
                    userTemp[i] = new Users();
                    i++;
                }

                i = 0;

                while (i < dtUser.Rows.Count)
                {
                    userTemp[i].UserID = Convert.ToInt64(dtUser.Rows[i]["UserID"].ToString());
                    userTemp[i].Username = dtUser.Rows[i]["Username"].ToString();
                    userTemp[i].FName = dtUser.Rows[i]["FName"].ToString();
                    userTemp[i].LName = dtUser.Rows[i]["LName"].ToString();
                    userTemp[i].Email = dtUser.Rows[i]["Email"].ToString();

                    i++;
                }

                return userTemp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
