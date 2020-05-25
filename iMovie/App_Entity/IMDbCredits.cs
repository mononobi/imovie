using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace iMovie
{
    public class IMDbCredits : WebPage
    {
        private const string DirectorsRootXPath = "//div[@class='header' and @id='fullcredits_content']";
        private const string DirectorsHNodesXPath = "h4[@class='dataHeaderWithBorder']";
        private const string DirectorsTableNodesXPath = "table[@class='simpleTable simpleCreditsTable']";
        private const string DirectorsXPath = "tbody//tr//td[@class='name']//a[contains(@href, *)]";

        private const string ActorsXPath = "//table[@class='cast_list']//tr[@class='odd' or @class='even']//" +
            "td[@class='primary_photo']//a[contains(@href, *)]//img[contains(@title, *) and contains(@alt, *)]";

        /// <summary>
        /// Initializes an instance of IMDBCredits from specified IMDB credits page.
        /// </summary>
        /// <param name="url">The imdb credits page link to retrieve data from.</param>
        public IMDbCredits(string url) : base(url)
        {
        }

        public void LoadDirectors()
        {
            this.Load();
            HtmlNode rootNode = this.GetSingleNode(IMDbCredits.DirectorsRootXPath);
            if (rootNode != null)
            {
                HtmlNodeCollection hNodes = rootNode.SelectNodes(IMDbCredits.DirectorsHNodesXPath);
                HtmlNodeCollection tableNodes = rootNode.SelectNodes(IMDbCredits.DirectorsTableNodesXPath);
                int directorsIndex = -1;
                foreach (HtmlNode potentialItem in hNodes)
                {
                    directorsIndex++;
                    if (potentialItem.InnerText.Trim().ToLower().Contains("directed"))
                    {
                        HtmlNodeCollection directorNodes = tableNodes[directorsIndex].SelectNodes(IMDbCredits.DirectorsXPath);
                        if (directorNodes != null && directorNodes.Count > 0)
                        {
                            this.Directors.Clear();
                            foreach (HtmlNode directorItem in directorNodes)
                            {
                                string name = directorItem.InnerText.Trim();
                                if (!string.IsNullOrEmpty(name))
                                {
                                    string url = directorItem.Attributes["href"].Value.Trim().TrimStart('/');
                                    url = url.Split('?')[0].TrimEnd('/');
                                    string fullURL = string.Empty;
                                    if (!string.IsNullOrEmpty(url))
                                    {
                                        fullURL = IMDb.IMDbBaseURL + "/" + url;
                                    }

                                    Person director = new Person(0, name, fullURL, string.Empty);
                                    this.Directors.Add(director);
                                }
                            }
                        }

                        break;
                    }
                }
            }
        }

        public void LoadActors()
        {
            this.Load();
            HtmlNodeCollection actorsList = this.GetMultiNodes(IMDbCredits.ActorsXPath);
            if (actorsList != null && actorsList.Count > 0)
            {
                this.Actors.Clear();
                foreach (HtmlNode actorItem in actorsList)
                {
                    string name = actorItem.Attributes["title"].Value.Trim();
                    if (!string.IsNullOrEmpty(name))
                    {
                        string url = actorItem.ParentNode.Attributes["href"].Value.Trim().TrimStart('/');
                        url = url.Split('?')[0].TrimEnd('/');
                        string fullURL = string.Empty;
                        if (!string.IsNullOrEmpty(url))
                        {
                            fullURL = IMDb.IMDbBaseURL + "/" + url;
                        }

                        Person actor = new Person(0, name, fullURL, string.Empty);
                        this.Actors.Add(actor);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the directors of the movie represented by this instance.
        /// </summary>
        public List<Person> Directors { get; private set; } = new List<Person>();

        /// <summary>
        /// Gets or sets the actors of the movie represented by this instance.
        /// </summary>
        public List<Person> Actors { get; private set; } = new List<Person>();

        public bool HasDirectors
        {
            get
            {
                return this.Directors.Count > 0;
            }
        }

        public bool HasActors
        {
            get
            {
                return this.Actors.Count > 0;
            }
        }
    }
}
