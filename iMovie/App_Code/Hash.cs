using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace iMovie
{
    public class Hash
    {
        /// <summary>
        /// Gets the unique hash value for specified file
        /// </summary>
        /// <param name="fileName">
        /// Full file path</param>
        /// <returns>
        /// Hash value in a string</returns>
        public static string MD5Hash(string fileName)
        {
            try
            {
                string check;

                FileStream FileCheck = File.OpenRead(fileName);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] md5Hash = md5.ComputeHash(FileCheck);
                check = BitConverter.ToString(md5Hash).Replace("-", "").ToLower();
              
                return check;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
