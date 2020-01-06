using System;
using System.Collections.Generic;
using System.Text;

namespace iMovie
{
    public class Helper
    {
        public static string GetShortDateString()
        {
            return Helper.GetShortDateString(DateTime.Now);
        }

        public static string GetShortDateString(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        public static string GetShortDateTimeString()
        {
            return Helper.GetShortDateTimeString(DateTime.Now);
        }

        public static string GetShortDateTimeString(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string GetSeparatedList(string[] items, string separator = ",")
        {
            int count = items.Length;
            string result = string.Empty;

            for (int i = 0; i < count; i++)
            {
                result = result + items[i] + separator;
            }

            if(result.Length > 0)
            {
                result = result.Remove(result.Length - 1, 1);
            }

            return result;
        }

        public static string RemoveExtraCharacters(string input)
        {
            string result = input.Trim();
            result = result.Replace("\n", " ");
            result = result.Replace("\r", " ");
            result = result.Replace("\t", " ");
            result = result.Replace("&nbsp;", " ");
            result = result.Replace("&nbsp", " ");
            result = result.Replace("<br>", " ");
            result = StringCompare.RemoveDuplicateSpace(result);

            return result;
        }
    }
}
