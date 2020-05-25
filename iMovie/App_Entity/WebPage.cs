using System;
using System.Net;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace iMovie
{ 
    public class CouldNotLoadWebPageException : Exception
    {
        public CouldNotLoadWebPageException(string message, 
            Exception innerException) : base(message, innerException)
        {
        }
    }

    public abstract class WebPage
    {
        private string url = string.Empty;

        /// <summary>
        /// Initializes an instance of WebPage.
        /// </summary>
        public WebPage()
        { 
        }

        /// <summary>
        /// Initializes an instance of WebPage.
        /// </summary>
        /// <param name="url">url to load its content.</param>
        public WebPage(string url)
        {
            this.URL = url;
        }

        /// <summary>
        /// Downloads the file from its URL into specified destination.
        /// </summary>
        /// <param name="url">
        /// URL of the file</param>
        /// <param name="targetPath">
        /// Destination path to save file</param>
        public static void DownloadFile(string url, string targetName)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new Exception(Messages.InvalidFileURL);
            }

            WebClient webClient = new WebClient(); 
            webClient.DownloadFile(url, targetName);
        }

        /// <summary>
        /// Gets or sets the url of this WebPage. if AutoUpdate is true, the WebPage source code
        /// will be updated immediately after each url changing
        /// </summary>
        public string URL
        {
            get
            {
                return this.url;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception(Messages.InvalidPageURL);
                }

                Regex reg1 = new Regex(@"^www.*");
                Regex reg2 = new Regex(@"^http://.*");
                Regex reg3 = new Regex(@"^https://.*");

                if (reg2.IsMatch(value) == true || reg3.IsMatch(value) == true)
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

                this.url = value;
            }
        }

        /// <summary>
        /// Loads the content of given url into this instance.
        /// </summary>
        /// <param name="url">url to load its content.</param>
        protected void Load(string url)
        {
            if (this.WebDocument == null || url != this.URL)
            {
                this.URL = url;
                HtmlDocument result = this.LoadDocument(this.url);

                if (result == null)
                {
                    throw new Exception(Messages.CouldNotLoadWebPage + Environment.NewLine + this.url);
                }

                this.WebDocument = result;
                this.LoadExtra();
            }
        }

        /// <summary>
        /// Loads the page content from its url.
        /// </summary>
        protected void Load()
        {
            if (string.IsNullOrEmpty(this.URL))
            {
                throw new Exception(Messages.InvalidPageURL);
            }

            this.Load(this.URL);
        }

        protected virtual void LoadExtra()
        {
        }

        protected HtmlNode GetSingleNode(string xpath)
        {
            return this.WebDocument?.DocumentNode.SelectSingleNode(xpath);
        }

        protected HtmlNodeCollection GetMultiNodes(string xpath)
        {
            return this.WebDocument?.DocumentNode.SelectNodes(xpath);
        }

        protected HtmlDocument LoadDocument(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new Exception(Messages.InvalidPageURL);
            }

            try
            {
                return this.WebManager.Load(url);
            }
            catch (Exception ex)
            {
                throw new CouldNotLoadWebPageException(ex.Message, ex);
            }
        }

        private HtmlDocument WebDocument { get; set; } = null;
        private HtmlWeb WebManager { get; set; } = new HtmlWeb();
    }
}
