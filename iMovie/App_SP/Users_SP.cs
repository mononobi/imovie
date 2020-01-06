using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace iMovie
{
    public class Users_SP
    {
        public static long Insert(Users user)
        {
            try
            {
                long count = 0;
                count = AccessDatabase.CountFunction(FunctionRepository.CountUsername, "@Username", user.Username);

                if (count > 0)
                {
                    throw new Exception(Messages.UnavailableUsername);
                }

                long userID = 0;
                userID = AccessDatabase.Insert(QueryRepository.Users_Insert, 
                                               "@Username", user.Username,
                                               "@PasswordHash", user.PasswordHash, "@FName", user.FName,
                                               "@LName", user.LName, "@Email", user.Email);

                if (userID <= 0)
                {
                    throw new Exception(Messages.DatabaseError);
                }

                return userID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable Login(string username, string password)
        {
            try
            {
                DataTable dtUser = new DataTable();
                dtUser = AccessDatabase.Select(QueryRepository.Users_Login,
                                               "@Username", username,
                                               "@PasswordHash", password.GetHashCode());

                return dtUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
