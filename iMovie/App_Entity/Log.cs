using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace iMovie
{
    public class Log
    {
        private string path = "";
        private string logDelimiter = "------------------------------------------------------------------------------------------------";
        private string stampDelimiter = "";
        private string staticText = "";
        private bool timeStamp = true;
        private bool dateStamp = true;

        /// <summary>
        /// Initializes a new instance of Log with specified values
        /// </summary>
        /// <param name="path">
        /// Path to create log file, Existing file will be appended</param>
        /// <param name="logDelimiter">
        /// Delimiter between each written log, leave empty to use default delimiter</param>
        /// <param name="stampDelimiter">
        /// Delimiter after date and time stamp</param>
        /// <param name="staticText">
        /// Static text which should appear in each written log</param>
        /// <param name="timeStamp">
        /// Value indicating that logs should have time stamp</param>
        /// <param name="dateStamp">
        /// Value indicating that logs should have date stamp</param>
        public Log(string path, string logDelimiter, string stampDelimiter, string staticText, bool timeStamp, bool dateStamp)
        {
            try
            {
                this.Path = path;
                this.LogDelimiter = logDelimiter;
                this.StampDelimiter = stampDelimiter;
                this.StaticText = staticText;
                this.TimeStamp = timeStamp;
                this.DateStamp = dateStamp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Initializes a new instance of Log with default values
        /// </summary>
        public Log()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Returns current date as string
        /// </summary>
        /// <returns>
        /// current date</returns>
        private string MakeDate()
        {
            try
            {
                string date = DateTime.Now.Year.ToString() + "-" + ExtendNumber(DateTime.Now.Month.ToString()) + "-" + ExtendNumber(DateTime.Now.Day.ToString());

                return date;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Returns current time as string
        /// </summary>
        /// <returns>
        /// Current time</returns>
        private string MakeTime()
        { 
            try
            {
                string time = ExtendNumber(DateTime.Now.Hour.ToString()) + ":" + ExtendNumber(DateTime.Now.Minute.ToString()) + ":" + ExtendNumber(DateTime.Now.Second.ToString());

                return time;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Adds "0" to inputed value until reaches to desired length
        /// </summary>
        /// <param name="number">
        /// Inputed number</param>
        /// <param name="length">
        /// Desired length for the number</param>
        /// <returns>
        /// Number with desired length</returns>
        private string ExtendNumber(string number, int length = 2)
        {
            try 
            {
                while (number.Length < length)
                {
                    number = "0" + number;
                }

                return number;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets or sets the log path of this instance
        /// </summary>
        public string Path 
        {
            get
            {
                try
                {
                    return this.path;
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
                    if (value.Length > 0)
                    {
                        if (File.Exists(value) == true)
                        {
                            this.path = value;
                        }
                        else
                        {
                            FileStream fstream = File.Create(value);
                            fstream.Close();
                            fstream.Dispose();
                          
                            this.path = value;
                        }
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidTargetPath);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Gets or sets the log delimiter of this instance
        /// </summary>
        public string LogDelimiter
        {
            get
            {
                try
                {
                    return this.logDelimiter;
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
                    if (value.Length > 0)
                    {
                        this.logDelimiter = value;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Gets or sets the stamp delimiter of this instance
        /// </summary>
        public string StampDelimiter
        {
            get 
            {
                try
                {
                    return this.stampDelimiter;
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
                    if (value.Length > 0)
                    {
                        this.stampDelimiter = value;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Gets or sets the static text of this instance
        /// </summary>
        public string StaticText
        {
            get
            {
                try
                {
                    return this.staticText;
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
                    if (value.Length > 0)
                    {
                        this.staticText = value;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the usage of time stamp for this instance
        /// </summary>
        public bool TimeStamp
        {
            get
            {
                try
                {
                    return this.timeStamp;
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
                    this.timeStamp = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the usage of date stamp for this instance
        /// </summary>
        public bool DateStamp
        {
            get
            {
                try
                {
                    return this.dateStamp;
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
                    this.dateStamp = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Gets the full usable date and time stamp of this instance
        /// </summary>
        public string Stamp
        {
            get
            {
                try
                {
                    string stamp = "[";

                    if (this.DateStamp == true)
                    {
                        stamp += this.MakeDate();

                        if (this.TimeStamp == true)
                        {
                            stamp += "  ";
                        }
                    }

                    if (this.TimeStamp == true)
                    {
                        stamp += this.MakeTime();
                    }

                    stamp += "]";

                    if (stamp.Length == 2)
                    {
                        stamp = "";
                    }

                    return stamp;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Generates a log using this instance attributes
        /// </summary>
        /// <param name="text">
        /// Value to write in generated log</param>
        public void Generate(string text)
        {
            try
            {
                StreamWriter write = new StreamWriter(this.Path, true);

                string log = "";

                if (this.Stamp.Length > 0)
                {
                    log += this.Stamp + Environment.NewLine;

                    if (this.StampDelimiter.Length > 0)
                    {
                        log += this.StampDelimiter + Environment.NewLine;
                    }
                }

                if (this.StaticText.Length > 0)
                {
                    log += this.StaticText + Environment.NewLine;
                }

                if (text.Length > 0)
                {
                    log += text + Environment.NewLine;
                }

                if (log.Length > 0)
                {
                    log += this.LogDelimiter + Environment.NewLine;
                    write.Write(log);
                }

                write.Close();
                write.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Generates a log using this instance attributes without throwing any exceptions
        /// </summary>
        /// <param name="text">
        /// Value to write in generated log</param>
        public void GenerateSilent(string text)
        {
            try
            {
                this.Generate(text);
            }
            catch
            {

            }
        }

        /// <summary>
        /// Returns a well formed string that is usable as text input for log generation
        /// </summary>
        /// <param name="header">
        /// Text header</param>
        /// <param name="body">
        /// Text body</param>
        /// <param name="footer">
        /// Text footer</param>
        /// <returns>
        /// Well formed string</returns>
        public static string MakeText(string header, string body, string footer)
        {
            try
            {
                string text = "";

                if (header.Length > 0)
                {
                    text += header;

                    if (body.Length > 0 || footer.Length > 0)
                    {
                        text += Environment.NewLine;
                    }
                }

                if (body.Length > 0)
                {
                    text += body;

                    if (footer.Length > 0)
                    {
                        text += Environment.NewLine;
                    }
                }

                if (footer.Length > 0)
                {
                    text += footer;
                }

                return text;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
