using System;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace iMovie
{
    public class Oscobo : WebPage
    {
        private const string SearchQueryPattern = @"https://www.oscobo.com/search.php?q={0}";
        private const string SearchResultXPath = "//div[@id='results-list']//div[@class='result']" +
            "//a[@target='_blank']//div[@class='line cite']";

        private string searchText = string.Empty;

        /// <summary>
        /// Initializes an instance of Oscobo with specified search query from oscobo.com
        /// </summary>
        public Oscobo() : base()
        {  
        }

        public string Search(string text)
        {
            this.SearchText = text;
            this.Load(this.FullSearchQuery);
            this.DoSearch();
            return this.FoundedURL;
        }

        public string Search(string text, Regex pattern, int limit)
        {
            this.SearchText = text;
            this.Load(this.FullSearchQuery);
            this.DoSearch(pattern, limit);
            return this.FoundedURL;
        }

        /// <summary>
        /// Gets or sets the search query of this instance to find in oscobo.com
        /// </summary>
        public string SearchText
        {
            get
            {
                return this.searchText;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception(Messages.InvalidSearchText);
                }

                this.searchText = value.Trim();
            }
        }

        /// <summary>
        /// Gets the complete search query that requested from oscobo.com
        /// </summary>
        public string FullSearchQuery
        {
            get
            {
                return string.Format(SearchQueryPattern, this.SearchText);
            }
        }

        public string FoundedURL { get; private set; } = string.Empty;

        private bool DoSearch()
        {
            HtmlNode node = this.GetSingleNode(Oscobo.SearchResultXPath);
            string result = node?.InnerText.Trim();

            if (!string.IsNullOrEmpty(result))
            {
                this.FoundedURL = result;
                return true;
            }

            return false;
        }
        
        /// <summary>
        /// Enforces this instance to load its data from its search query result.
        /// </summary>
        private bool DoSearch(Regex pattern, int limit = 1) 
        {
            limit = Math.Min(limit, 5);
            HtmlNodeCollection nodes = this.GetMultiNodes(Oscobo.SearchResultXPath);
            if (nodes != null && nodes.Count > 0)
            {
                foreach (HtmlNode item in nodes)
                {
                    if (limit <= 0)
                    {
                        break;
                    }

                    limit--;
                    string result = item.InnerText.Trim();
                    if (pattern.IsMatch(result))
                    {
                        this.FoundedURL = result;
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
