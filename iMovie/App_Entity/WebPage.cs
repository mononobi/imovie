using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;

namespace iMovie
{ 
    public class WebPage
    {
        private const int RetryMinValue = 1;
        private const int RetryMaxValue = 10;
        private const int SleepValue = 600;

        private string source = "";
        private string url = "";
        private bool autoUpdate = true;
        private int retryCount = 3;

        /// <summary>
        /// Initializes an instance of WebPage with specified values
        /// </summary>
        /// <param name="autoUpdate">
        /// if set to true, after each url changing, the webpage source code will be updated immediately.
        /// otherwise false</param>
        /// <param name="url">
        /// The url to retrieve webpage from</param>
        public WebPage(bool autoUpdate, string url)
        {
            try
            {
                this.AutoUpdate = autoUpdate;
                this.URL = url;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Initializes an instance of WebPage with empty url
        /// </summary>
        /// <param name="autoUpdate">
        /// if set to true, after each url changing, the webpage source code will be updated immediately.
        /// otherwise false</param>
        public WebPage(bool autoUpdate)
        {
            try
            {
                this.AutoUpdate = autoUpdate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Enforces this instance to update it's data from it's URL
        /// </summary>
        public void Update()
        {
            try
            {
                bool last = this.AutoUpdate;
                string temp = this.URL;
                this.AutoUpdate = false;
                this.URL = ".";
                this.AutoUpdate = true;
                this.URL = temp;
                this.AutoUpdate = last;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the source code of this WebPage
        /// </summary>
        public string Source
        {
            get
            {
                try
                {
                    return this.source;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Gets or sets the url of this WebPage. if AutoUpdate is true, the WebPage source code
        /// will be updated immediately after each url changing
        /// </summary>
        public string URL
        {
            get
            {
                try
                { 
                    return this.url;
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
                        Regex reg1 = new Regex(@"^www.*");
                        Regex reg2 = new Regex(@"^http://.*");

                        if (reg2.IsMatch(value) == true)
                        {
                            // OK
                        }
                        else if (reg1.IsMatch(value) == true)
                        {
                            value = @"http://" + value;
                        }
                        else
                        {
                            value = @"http://" + value;
                        }

                        if (this.AutoUpdate == true)
                        {
                            if (value != this.url && value != ".")
                            {
                                string result = GetPageSourceCode(value);

                                if (result.Length > 0)
                                {
                                    this.url = value;
                                    this.source = result;
                                }
                                else
                                {
                                    throw new Exception(Messages.CouldNotGetPageSource + Environment.NewLine + value);
                                }
                            }
                            else if (value == ".")
                            {
                                this.url = value;
                            }
                        }
                        else
                        {
                            this.url = value;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private string GetPageSourceCode(string url)
        {
            try
            {
                int count = this.retryCount;
                string result = "";

                while (count > 0)
                {
                    try
                    {
                        count--;

                        HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
                        myRequest.AllowAutoRedirect = true;
                        myRequest.Method = "GET";
                        myRequest.Timeout = 15000;
                        myRequest.ReadWriteTimeout = 15000;

                        HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();

                        if (myResponse.StatusCode == HttpStatusCode.OK)
                        {
                            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
                            result = sr.ReadToEnd();
                            sr.Close();
                            myResponse.Close();

                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (count == 0)
                        {
                            throw ex;
                        } 
                    }

                    Thread.Sleep(SleepValue);
                }

                return Helper.RemoveExtraCharacters(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating that the source code of this WebPage 
        /// should be updated after each url changing
        /// </summary>
        public bool AutoUpdate
        {
            get
            {
                try
                {
                    return this.autoUpdate;
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
                    this.autoUpdate = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Gets or sets the maximum number of attempts to get the webpage source code if not succeeded, value between 1 to 10
        /// </summary>
        public int RetryCount
        {
            get
            {
                try
                {
                    return this.retryCount;
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
                    if (value < RetryMinValue)
                    {
                        value = RetryMinValue;
                    }
                    else if(value > RetryMaxValue)
                    {
                        value = RetryMaxValue;
                    }
     
                    this.retryCount = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
