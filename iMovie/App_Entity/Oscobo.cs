using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace iMovie
{
    public class Oscobo 
    {
        private string SearchQueryPattern = @"https://www.oscobo.com/search.php?q=@QUERY@";
        private string URLTagPattern = @"<div class=""line cite"">( )*[^ <>]+( )*</div>";
        private string ExactTitleURLPattern = @"www.imdb.com/title/tt[\d]+[/]{0,1}";
        private string[] ResultItemsDelim = { @"<div class=""result"">" };
        private string[] ExtraChars = { "<strong>", "</strong>", "<b>", "</b>", "&nbsp;" };

        private WebPage searchResultPage = new WebPage(false);
        private IMDb imdbMoviePage = new IMDb(false);
        private string firstResultItemTag = "";
        private string searchText = "";

        /// <summary>
        /// Initializes an instance of Oscobo with specified search query from oscobo.com
        /// </summary>
        /// <param name="autoUpdateSearch">
        /// Value indicating that on each Search text changing should update 
        /// the search result page of this instance immediately</param>
        /// <param name="text">
        /// Text to search for in oscobo.com and get the result page</param>
        public Oscobo(bool autoUpdateSearch, string text)
        {  
            try
            {
                this.searchResultPage.AutoUpdate = autoUpdateSearch;
                this.SearchText = text;
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        /// <summary>
        /// Initializes an instance of Oscobo with specified values
        /// without getting result from google
        /// </summary>
        /// <param name="autoUpdateSearch">
        /// Value indicating that on each Search text changing should update 
        /// the search result page of this instance immediately</param>
        public Oscobo(bool autoUpdateSearch)
        {
            try
            {
                this.searchResultPage.AutoUpdate = autoUpdateSearch;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Enforces this instance to update it's data from it's search query result
        /// </summary>
        public void Update()
        {
            try
            {
                bool last = this.SearchResultPage.AutoUpdate;
                this.SearchResultPage.AutoUpdate = true;
                this.SearchText = this.SearchText;
                this.SearchResultPage.AutoUpdate = last;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadSearchResult()
        { 
            try
            {
                this.searchResultPage = new WebPage(this.SearchResultPage.AutoUpdate, this.FullSearchQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadFirstResultItemTag()
        {
            try
            {
                if (this.SearchResultPage.Source.Length <= 0)
                {
                    this.LoadSearchResult();
                }

                if (this.SearchResultPage.Source.Length > 0)
                {
                    string source = this.SearchResultPage.Source;

                    foreach (string extra in this.ExtraChars)
                    {
                        source = Regex.Replace(source, extra, "", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline);
                    }

                    string[] temp = source.Split(this.ResultItemsDelim, StringSplitOptions.RemoveEmptyEntries);

                    if (temp.Length > 1)
                    {
                        this.firstResultItemTag = temp[1];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadURL()
        {
            try
            {
                if (this.SearchResultPage.Source.Length <= 0)
                {
                    this.LoadSearchResult();
                    this.LoadFirstResultItemTag();
                }

                if (this.FirstResultItemTag.Length > 0)
                {
                    string url = "";
                    string resultTag = this.FirstResultItemTag;

                    foreach (string extra in this.ExtraChars)
                    {
                        resultTag = Regex.Replace(resultTag, extra, "", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline);
                    }

                    Regex reg = new Regex(URLTagPattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline);
                    url = reg.Match(resultTag).Value;

                    url = url.Replace(@"<div class=""line cite"">", "");
                    url = url.Replace("</div>", "");
                    url = url.Trim().Replace(" ", "");

                    string titleURL = "";

                    Regex reg2 = new Regex(ExactTitleURLPattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline);
                    titleURL = reg2.Match(url).Value;
                    titleURL = titleURL.Trim();

                    this.IMDBMoviePage.MoviePage.AutoUpdate = false;
                    this.IMDBMoviePage.URL = titleURL.TrimEnd('/');
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets or sets the search query of this instance to find in oscobo.com
        /// </summary>
        public string SearchText
        {
            get
            {
                try
                {
                    return this.searchText;
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
                    this.searchText = value.Trim();

                    if (this.SearchResultPage.AutoUpdate == true)
                    {
                        this.LoadSearchResult();
                        this.LoadFirstResultItemTag();
                        this.LoadURL();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Gets the IMDB component that represents IMDB page of requested movie
        /// </summary>
        public IMDb IMDBMoviePage
        { 
            get
            {
                try
                {
                    return this.imdbMoviePage;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Gets the WebPage that represents oscobo.com search results for requested query
        /// </summary>
        public WebPage SearchResultPage
        {
            get
            {
                try
                {
                    return this.searchResultPage;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Gets the complete search query that requested from oscobo.com
        /// </summary>
        public string FullSearchQuery
        {
            get
            {
                try
                {
                    return SearchQueryPattern.Replace("@QUERY@", this.SearchText);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Gets the first result item found in oscobo.com for the searched query
        /// </summary>
        public string FirstResultItemTag
        {
            get 
            {
                try
                {
                    return this.firstResultItemTag;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool IsFullyLoaded
        {
            get
            {
                try
                {
                    return this.HasURL;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool HasRate
        {
            get
            {
                return false;
            }
        }

        public bool HasYear
        {
            get
            {
                return false;
            }
        }

        public bool HasURL
        {
            get
            {
                try
                {
                    if (this.IMDBMoviePage.URL.Length > 0)
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
        }

        public bool HasDirector
        {
            get
            {
                return false;
            }
        }
    }
}
