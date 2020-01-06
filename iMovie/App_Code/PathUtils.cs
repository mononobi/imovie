using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace iMovie
{
    public class PathUtils
    {
        public static string GetApplicationRootPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\";
        }

        public static string GetApplicationDataPath()
        {
            return GetApplicationRootPath() + @"App_Data\";
        }

        public static string GetApplicationTempPath()
        {
            return GetApplicationDataPath() + @"Temp\";
        }

        public static string GetApplicationFontsPath()
        {
            return GetApplicationDataPath() + @"Fonts\";
        }

        public static string GetApplicationImagesPath()
        {
            return GetApplicationDataPath() + @"Images\";
        }

        public static string GetApplicationDatabasePath()
        {
            return GetApplicationDataPath() + @"Database\";
        }

        public static string GetApplicationConfigsPath()
        {
            return GetApplicationDataPath() + @"Configs\";
        }

        public static string GetApplicationMoviePosterPath()
        {
            return GetApplicationImagesPath() + @"Movie Poster\";
        }

        public static string GetApplicationPersonPath()
        {
            return GetApplicationImagesPath() + @"Person\";
        }
    }
}
