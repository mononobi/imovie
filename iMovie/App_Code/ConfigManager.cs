using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace iMovie
{
    public class ConfigManager
    {
        private readonly static string ExtraCharsConfigFile = PathUtils.GetApplicationConfigsPath() + @"extra_chars.config";
        private readonly static string IgnoreCharsConfigFile = PathUtils.GetApplicationConfigsPath() + @"ignore_chars.config";
        /// <summary>
        /// Characters that if a folder name starts with them, will be ignored.
        /// </summary>
        private static readonly string[] ignoreChars = { "@" };
        /// <summary>
        /// Characters that will be removed from movie name
        /// </summary>
        private static readonly string[] extraChars = { "fullhd", "bdrip", "ac3", "aac", "h264", "dvdscr", 
            "brip", "dvdrip", "hdrip", "brrip", "x264", "hdtvrip", "xvid", "divx", "720p", "1080p", 
            "bluray", "480p", "360p", "directors cut", "director cut", "extended cut", "yify", "isohunt",
            "maxspeed", "kickasstorrents", "extratorrent", "extended", "theatrical cut", "unrated cut", 
            "unrated", "hdtv", "m-hd", "theatrical edition", "theatrical-edition", "theatrical" };

        public static string[] GetExtraCharacters()
        {
            string[] result = ReadFile(ExtraCharsConfigFile);

            if (result == null)
            {
                result = extraChars.Clone() as string[];
            }

            return Sort(result);
        }

        public static string[] GetIgnoreCharacters()
        {
            string[] result = ReadFile(IgnoreCharsConfigFile);

            if (result == null)
            {
                result = ignoreChars.Clone() as string[];
            }

            return Sort(result);
        }

        public static void GenerateConfigFiles(bool append)
        {
            if (Directory.Exists(PathUtils.GetApplicationConfigsPath()) == false)
            {
                Directory.CreateDirectory(PathUtils.GetApplicationConfigsPath());
            }

            using (StreamWriter sw1 = new StreamWriter(ExtraCharsConfigFile, append))
            {
                foreach (string s in extraChars)
                {
                    sw1.Write(Environment.NewLine + s.Trim());
                }
            }

            using (StreamWriter sw2 = new StreamWriter(IgnoreCharsConfigFile, append))
            {
                foreach (string s in ignoreChars)
                {
                    sw2.Write(Environment.NewLine + s.Trim());
                }
            }
        }

        private static string[] Sort(string[] items)
        {
            string[] result = new string[0];

            if (items != null && items.Length > 0)
            {
                result = items.Clone() as string[];

                for (int i = 0; i < result.Length; i++)
                {
                    for (int j = 0; j < result.Length; j++)
                    {
                        if (result[i].Length > result[j].Length)
                        {
                            string temp = result[i];
                            result[i] = result[j];
                            result[j] = temp;
                        }
                    }
                }
            }

            return result;
        }

        private static string[] ReadFile(string configFilePath)
        {
            string[] result = null;

            try
            {
                if (File.Exists(configFilePath) == true)
                {
                    using (StreamReader sr = new StreamReader(configFilePath))
                    {
                        string file = sr.ReadToEnd();
                        result = file.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    }

                    for (int i = 0; i < result.Length; i++)
                    {
                        result[i] = result[i].Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                result = null;
            }

            return result;
        }
    }
}
