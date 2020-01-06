using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace iMovie
{
    public class Google 
    {
        private string SearchQueryPattern = @"http://www.google.com/search?q=@QUERY@";
        private string RateTagPattern = @"Rating:[ ]*?[0-9]{1}(([\.]{1}[0-9]{1})|([0]{0,1}))/10";
        private string URLTagPattern = @"<cite>[^ <>]*</cite>";
        private string YearTagPattern = @"(?<=>[^<>]*\([^<>]*)([1|2]{1}[0|9]{1}[0-9]{2})(?=[^<>]*\)[ ]*?-[ ]*?IMDb</a>)";
        private string DirectorsPattern = @"(?<=Directed[ ]*?by)([^<>]*)(?=\.[ ]*?With)";
        private string ExactTitleURLPattern = @"www.imdb.com/title/tt[\d]+[/]{0,1}";
        private string[] ResultItemsDelim = { @"<div class=""g""><h3 class=""r"">" };
        private string[] ExtraChars = { "<strong>", "</strong>", "<b>", "</b>", "&nbsp;" };

        private WebPage searchResultPage = new WebPage(false);
        private IMDb imdbMoviePage = new IMDb(false);
        private string firstResultItemTag = "";
        private double rate = 0;
        private int year = 0;
        private string searchText = "";
        private List<Person> directors = new List<Person>();

        /// <summary>
        /// Initializes an instance of Google with specified search query from google.com
        /// </summary>
        /// <param name="autoUpdateSearch">
        /// Value indicating that on each Search text changing should update 
        /// the search result page of this instance immediately</param>
        /// <param name="text">
        /// Text to search for in google.com and get the result page</param>
        public Google(bool autoUpdateSearch, string text)
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
        /// Initializes an instance of Google with specified values
        /// without getting result from google
        /// </summary>
        /// <param name="autoUpdateSearch">
        /// Value indicating that on each Search text changing should update 
        /// the search result page of this instance immediately</param>
        public Google(bool autoUpdateSearch)
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

        private void LoadRate()
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
                    string rate = "0"; 
                    string resultTag = this.FirstResultItemTag;
                     
                    foreach (string extra in this.ExtraChars)
                    {
                        resultTag = Regex.Replace(resultTag, extra, "", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline);
                    }

                    Regex reg = new Regex(RateTagPattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline);
                    rate = reg.Match(resultTag).Value;

                    rate = rate.Replace("Rating: ", "");
                    rate = rate.Replace("/10", "");
                    rate = rate.Trim();

                    double value = 0;
                    double.TryParse(rate, out value);

                    this.rate = value;
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

                    url = url.Replace("<cite>", "");
                    url = url.Replace("</cite>", "");
                    url = url.Trim();

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

        private void LoadYear()
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
                    string year = "0";
                    string resultTag = this.FirstResultItemTag;
                     
                    foreach (string extra in this.ExtraChars)
                    {
                        resultTag = Regex.Replace(resultTag, extra, "", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline);
                    }

                    Regex reg = new Regex(YearTagPattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline);
                    year = reg.Match(resultTag).Value;

                    year = year.Trim();

                    int value = 0;
                    int.TryParse(year, out value);

                    this.year = value;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadDirectors()
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
                    string rawDirectors = "";
                    string resultTag = this.FirstResultItemTag;

                    foreach (string extra in this.ExtraChars)
                    {
                        resultTag = Regex.Replace(resultTag, extra, "", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline);
                    }

                    Regex reg = new Regex(DirectorsPattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline);
                    rawDirectors = reg.Match(resultTag).Value;

                    if (rawDirectors.Length > 0)
                    {
                        this.Directors.Clear();

                        string[] sep = { "," };
                        string[] dirs = rawDirectors.Split(sep, StringSplitOptions.RemoveEmptyEntries);

                        foreach (string dr in dirs)
                        {
                            string tmp = dr.Trim();
                            Person p = new Person(0, tmp, "", "");
                            this.directors.Add(p);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets or sets the search query of this instance to find in google.com
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
                        this.LoadRate();
                        this.LoadURL();
                        this.LoadYear();
                        this.LoadDirectors();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Gets the rate value of retrieved movie from google.com search result
        /// </summary>
        public double Rate
        {
            get
            {
                try
                {
                    return this.rate;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Gets the directors of retrieved movie from google.com search result
        /// </summary>
        public List<Person> Directors
        {
            get
            {
                try
                {
                    return this.directors;
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
        /// Gets the WebPage that represents google.com search results for requested query
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
        /// Gets the complete search query that requested from google.com
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
        /// Gets the first result item found in google.com for the searched query
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

        /// <summary>
        /// Gets the product year of the movie retrieved from google.com search result
        /// </summary>
        public int Year
        {
            get
            {
                try
                {
                    return this.year;
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
                    if (this.HasRate == true && this.HasYear == true && this.HasURL == true && this.HasDirector == true)
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

        public bool HasRate
        {
            get
            {
                try
                {
                    if (this.Rate > 0 && this.Rate <= 10)
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

        public bool HasYear
        {
            get
            { 
                try
                {
                    if (this.Year >= Movie.ProductYear_Min_Value &&
                        this.Year <= Movie.ProductYear_Max_Value)
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
                try
                {
                    if (this.Directors.Count > 0)
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
    }
}
