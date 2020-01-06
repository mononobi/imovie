using System;
using System.Collections.Generic;
using System.Text;

namespace iMovie
{
    public enum SizeModeEnum
    {
        /// <summary>
        /// Bytes
        /// </summary>
        Bytes = 0,
        /// <summary>
        /// Kilobytes
        /// </summary>
        KB = 1,
        /// <summary>
        /// Megabytes
        /// </summary>
        MB = 2,
        /// <summary>
        /// Gigabytes
        /// </summary>
        GB = 3,
        /// <summary>
        /// Terabytes
        /// </summary>
        TB = 4,
        /// <summary>
        /// Human readable value, according to actual size. ex. 2100000 Bytes -> 2.1 MB
        /// </summary>
        HumanReadable = 5
    }

    /// <summary>
    /// This class is used for converting file sizes to differnet values.
    /// </summary>
    public class SizeUtils
    {
        private const double KB_THRESHOLD = 1024;
        private const double MB_THRESHOLD = KB_THRESHOLD * 1024;
        private const double GB_THRESHOLD = MB_THRESHOLD * 1024;
        private const double TB_THRESHOLD = GB_THRESHOLD * 1024;

        /// <summary>
        /// Gets the size value of input bytes according to given size mode.
        /// </summary>
        /// <param name="inputBytes">
        /// Input size in bytes to convert to desired value.
        /// </param>
        /// <param name="sizeMode">
        /// Desired result size mode.
        /// </param>
        /// <returns>
        /// A double representing the size value in give size mode.
        /// </returns>
        public static double GetSize(double inputBytes, SizeModeEnum sizeMode = SizeModeEnum.HumanReadable)
        {
            if(inputBytes < 0)
            {
                inputBytes = 0;
            }

            switch (sizeMode)
            {
                case SizeModeEnum.Bytes:
                    return inputBytes;

                case SizeModeEnum.KB:
                    return GetSizeInKB(inputBytes);

                case SizeModeEnum.MB:
                    return GetSizeInMB(inputBytes);

                case SizeModeEnum.GB:
                    return GetSizeInGB(inputBytes);

                case SizeModeEnum.TB:
                    return GetSizeInTB(inputBytes);

                case SizeModeEnum.HumanReadable:
                    return GetSizeInHumanReadable(inputBytes);

                default:
                    return GetSizeInHumanReadable(inputBytes);
            }
        }

        /// <summary>
        /// Gets the size string of input bytes according to given size mode.
        /// </summary>
        /// <param name="inputBytes">
        /// Input size in bytes to convert to desired value.
        /// </param>
        /// <param name="sizeMode">
        /// Desired result size mode.
        /// </param>
        /// <returns>
        /// A string representing the size value in give size mode.
        /// </returns>
        public static string GetSizeString(double inputBytes, SizeModeEnum sizeMode = SizeModeEnum.HumanReadable)
        {
            if (inputBytes < 0)
            {
                inputBytes = 0;
            }

            switch (sizeMode)
            {
                case SizeModeEnum.Bytes:
                    return GetSizeInBytesString(inputBytes);

                case SizeModeEnum.KB:
                    return GetSizeInKBString(inputBytes);

                case SizeModeEnum.MB:
                    return GetSizeInMBString(inputBytes);

                case SizeModeEnum.GB:
                    return GetSizeInGBString(inputBytes);

                case SizeModeEnum.TB:
                    return GetSizeInTBString(inputBytes);

                case SizeModeEnum.HumanReadable:
                    return GetSizeInHumanReadableString(inputBytes);

                default:
                    return GetSizeInHumanReadableString(inputBytes);
            }
        }

        /// <summary>
        /// Gets the size value of input bytes in KB.
        /// </summary>
        /// <param name="inputBytes">
        /// Input size in bytes to convert to KB.
        /// </param>
        /// <returns>
        /// A double representing the size value in KB.
        /// </returns>
        private static double GetSizeInKB(double inputBytes)
        {
            if (inputBytes < 0)
            {
                inputBytes = 0;
            }

            return inputBytes / KB_THRESHOLD;
        }

        /// <summary>
        /// Gets the size value of input bytes in MB.
        /// </summary>
        /// <param name="inputBytes">
        /// Input size in bytes to convert to MB.
        /// </param>
        /// <returns>
        /// A double representing the size value in MB.
        /// </returns>
        private static double GetSizeInMB(double inputBytes)
        {
            if (inputBytes < 0)
            {
                inputBytes = 0;
            }

            return inputBytes / MB_THRESHOLD;
        }

        /// <summary>
        /// Gets the size value of input bytes in GB.
        /// </summary>
        /// <param name="inputBytes">
        /// Input size in bytes to convert to GB.
        /// </param>
        /// <returns>
        /// A double representing the size value in GB.
        /// </returns>
        private static double GetSizeInGB(double inputBytes)
        {
            if (inputBytes < 0)
            {
                inputBytes = 0;
            }

            return inputBytes / GB_THRESHOLD;
        }

        /// <summary>
        /// Gets the size value of input bytes in TB.
        /// </summary>
        /// <param name="inputBytes">
        /// Input size in bytes to convert to TB.
        /// </param>
        /// <returns>
        /// A double representing the size value in TB.
        /// </returns>
        private static double GetSizeInTB(double inputBytes)
        {
            if (inputBytes < 0)
            {
                inputBytes = 0;
            }

            return inputBytes / TB_THRESHOLD;
        }

        /// <summary>
        /// Gets the size value of input bytes in a human readable unit.
        /// </summary>
        /// <param name="inputBytes">
        /// Input size in bytes to convert to a human readable unit.
        /// </param>
        /// <returns>
        /// A double representing the size value in a human readable unit.
        /// </returns>
        private static double GetSizeInHumanReadable(double inputBytes)
        {
            if (inputBytes < 0)
            {
                inputBytes = 0;
            }

            if (inputBytes > TB_THRESHOLD)
            {
                return GetSizeInTB(inputBytes);
            }
            else if (inputBytes > GB_THRESHOLD)
            {
                return GetSizeInGB(inputBytes);
            }
            else if (inputBytes > MB_THRESHOLD)
            {
                return GetSizeInMB(inputBytes);
            }
            else if (inputBytes > KB_THRESHOLD)
            {
                return GetSizeInKB(inputBytes);
            }
            else
            {
                return inputBytes;
            }
        }

        /// <summary>
        /// Gets the size string of input bytes in Bytes.
        /// </summary>
        /// <param name="inputBytes">
        /// Input size in bytes to convert to Bytes.
        /// </param>
        /// <returns>
        /// A string representing the size value in Bytes.
        /// </returns>
        private static string GetSizeInBytesString(double inputBytes)
        {
            return inputBytes.ToString("0.# Bytes");
        }

        /// <summary>
        /// Gets the size string of input bytes in KB.
        /// </summary>
        /// <param name="inputBytes">
        /// Input size in bytes to convert to KB.
        /// </param>
        /// <returns>
        /// A string representing the size value in KB.
        /// </returns>
        private static string GetSizeInKBString(double inputBytes)
        {
            return GetSizeInKB(inputBytes).ToString("0.# KB");
        }

        /// <summary>
        /// Gets the size string of input bytes in MB.
        /// </summary>
        /// <param name="inputBytes">
        /// Input size in bytes to convert to MB.
        /// </param>
        /// <returns>
        /// A string representing the size value in MB.
        /// </returns>
        private static string GetSizeInMBString(double inputBytes)
        {
            return GetSizeInMB(inputBytes).ToString("0.# MB");
        }

        /// <summary>
        /// Gets the size string of input bytes in GB.
        /// </summary>
        /// <param name="inputBytes">
        /// Input size in bytes to convert to GB.
        /// </param>
        /// <returns>
        /// A string representing the size value in GB.
        /// </returns>
        private static string GetSizeInGBString(double inputBytes)
        {
            return GetSizeInGB(inputBytes).ToString("0.# GB");
        }

        /// <summary>
        /// Gets the size string of input bytes in TB.
        /// </summary>
        /// <param name="inputBytes">
        /// Input size in bytes to convert to TB.
        /// </param>
        /// <returns>
        /// A string representing the size value in TB.
        /// </returns>
        private static string GetSizeInTBString(double inputBytes)
        {
            return GetSizeInTB(inputBytes).ToString("0.# TB");
        }

        /// <summary>
        /// Gets the size string of input bytes in a human readable unit.
        /// </summary>
        /// <param name="inputBytes">
        /// Input size in bytes to convert to a human readable unit.
        /// </param>
        /// <returns>
        /// A string representing the size value in a human readable unit.
        /// </returns>
        private static string GetSizeInHumanReadableString(double inputBytes)
        {
            if (inputBytes < 0)
            {
                inputBytes = 0;
            }

            if (inputBytes > TB_THRESHOLD)
            {
                return GetSizeInTBString(inputBytes);
            }
            else if (inputBytes > GB_THRESHOLD)
            {
                return GetSizeInGBString(inputBytes);
            }
            else if (inputBytes > MB_THRESHOLD)
            {
                return GetSizeInMBString(inputBytes);
            }
            else if (inputBytes > KB_THRESHOLD)
            {
                return GetSizeInKBString(inputBytes);
            }
            else
            {
                return GetSizeInBytesString(inputBytes);
            }
        }
    }
}
