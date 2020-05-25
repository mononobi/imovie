using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace iMovie 
{
    public class IMDb : WebPage
    {
        public const string IMDbBaseURL = @"https://www.imdb.com";

        private const string RateXPath = "//div[@class='imdbRating']//div[@class='ratingValue']//strong//span[@itemprop='ratingValue']";
        private const string MinutesXPath = "//div[@class='article' and @id='titleDetails']//div[@class='txt-block']//time[contains(@datetime, *)]";
        private const string YearXPath = "//div[@class='title_wrapper']//h1//span[@id='titleYear']//a[contains(@href, *)]";
        private const string PhotoLinkXPath = "//div[@class='poster']//a//img[contains(@src, *)]";
        private const string StoryLineXPath = "//div[@class='article' and @id='titleStoryLine']//div[@class='inline canwrap']//p//span";
        private const string LanguagesXPath = "//div[@class='article' and @id='titleDetails']//div[@class='txt-block']//h4[@class='inline']";
        private const string GenresXPath = "//div[@class='see-more inline canwrap']//h4[@class='inline']";

        private int minutes = 0;

        /// <summary>
        /// Initializes an instance of IMDB from specified IMDB page.
        /// </summary>
        /// <param name="url">The imdb page link to retrieve data from.</param>
        public IMDb(string url) : base(url)
        {
        }

        public void LoadRate()
        {
            this.Load();
            HtmlNode node = this.GetSingleNode(IMDb.RateXPath);
            if (node != null)
            {
                string rate = node.InnerText.Trim();
                double value = 0;
                double.TryParse(rate, out value);
                this.Rate = value;
            }
        }

        public void LoadMinutes()
        {
            this.Load();
            HtmlNode node = this.GetSingleNode(IMDb.MinutesXPath);
            if (node != null)
            {
                string minutes = node.Attributes["datetime"].Value.Trim();
                minutes = minutes.Replace("PT", string.Empty).Replace("M", string.Empty).Trim();
                int value = 0;
                int.TryParse(minutes, out value);
                this.minutes = value;
            }
        }

        public void LoadYear()
        {
            this.Load();
            HtmlNode node = this.GetSingleNode(IMDb.YearXPath);
            if (node != null)
            {
                string year = node.InnerText.Trim();
                int value = 0;
                int.TryParse(year, out value);
                this.Year = value;
            }
        }

        public void LoadPhotoLink()
        {
            this.Load();
            HtmlNode node = this.GetSingleNode(IMDb.PhotoLinkXPath);
            if (node != null)
            {
                string photo = node.Attributes["src"].Value.Trim();
                if (!string.IsNullOrEmpty(photo))
                {
                    this.PhotoURL = photo;
                }
            }
        }

        public void LoadStoryLine()
        {
            this.Load();
            HtmlNode node = this.GetSingleNode(IMDb.StoryLineXPath);
            if (node != null)
            {
                string story = node.InnerText.Trim();
                if (!string.IsNullOrEmpty(story))
                {
                    this.StoryLine = story;
                }
            }
        }

        public void LoadLanguages()
        {
            this.Load();
            HtmlNodeCollection potentialNodes = this.GetMultiNodes(IMDb.LanguagesXPath);
            if (potentialNodes != null && potentialNodes.Count > 0)
            {
                foreach (HtmlNode potentialItem in potentialNodes)
                {
                    if (potentialItem.InnerText.Trim().ToLower().Contains("language"))
                    {
                        HtmlNodeCollection languageNodes = potentialItem.ParentNode?.SelectNodes("a[contains(@href, *)]");
                        if (languageNodes != null && languageNodes.Count > 0)
                        {
                            this.Languages.Clear();
                            foreach (HtmlNode languageItem in languageNodes)
                            {
                                string value = languageItem.InnerText.Trim();
                                if (!string.IsNullOrEmpty(value))
                                {
                                    Language language = new Language(0, value);
                                    this.Languages.Add(language);
                                }
                            }

                            break;
                        }
                    }
                }
            }
        }

        public void LoadGenres()
        {
            this.Load();
            HtmlNodeCollection potentialNodes = this.GetMultiNodes(IMDb.GenresXPath);
            if (potentialNodes != null && potentialNodes.Count > 0)
            {
                foreach (HtmlNode potentialItem in potentialNodes)
                {
                    if (potentialItem.InnerText.Trim().ToLower().Contains("genre"))
                    {
                        HtmlNodeCollection genreNodes = potentialItem.ParentNode?.SelectNodes("a[contains(@href, *)]");
                        if (genreNodes != null && genreNodes.Count > 0)
                        {
                            this.Genres.Clear();
                            foreach (HtmlNode genreItem in genreNodes)
                            {
                                string value = genreItem.InnerText.Trim();
                                if (!string.IsNullOrEmpty(value))
                                {
                                    Genre genre = new Genre(0, value);
                                    this.Genres.Add(genre);
                                }
                            }

                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the rate value of this instance.
        /// </summary>
        public double Rate { get; private set; } = 0;

        /// <summary>
        /// Gets or sets the photo URL of this instance.
        /// </summary>
        public string PhotoURL { get; private set; } = string.Empty;

        /// <summary>
        /// Gets the duration of the movie represented by this instance.
        /// </summary>
        public TimeSpan Duration
        {
            get
            {
                TimeSpan ts = new TimeSpan(0, this.minutes, 0);
                return ts;
            }
        }

        /// <summary>
        /// Gets or sets the product year of the movie represented by this instance.
        /// </summary>
        public int Year { get; private set; } = 0;

        /// <summary>
        /// Gets the storyline of the movie represented by this instance.
        /// </summary>
        public string StoryLine { get; private set; } = string.Empty;

        /// <summary>
        /// Gets the languages of the movie represented by this instance
        /// </summary>
        public List<Language> Languages { get; private set; } = new List<Language>();

        /// <summary>
        /// Gets or sets the genres of the movie represented by this instance.
        /// </summary>
        public List<Genre> Genres { get; private set; } = new List<Genre>();

        public bool HasRate
        {
            get
            {
                return this.Rate > 0 && this.Rate <= 10;
            }
        }

        public bool HasYear
        {
            get
            {
                return this.Year >= Movie.ProductYear_Min_Value && 
                    this.Year <= Movie.ProductYear_Max_Value;
            }
        }

        public bool HasURL
        {
            get
            {
                return !string.IsNullOrEmpty(this.URL);
            }
        }

        public bool HasDuration
        {
            get
            {
                return this.Duration.TotalSeconds > 0;
            }
        }

        public bool HasPhotoURL
        {
            get
            {
                return !string.IsNullOrEmpty(this.PhotoURL);
            }
        }

        public bool HasStoryLine
        {
            get
            {
                return !string.IsNullOrEmpty(this.StoryLine);
            }
        }

        public bool HasLanguages
        {
            get
            {
                return this.Languages.Count > 0;
            }
        }

        public bool HasGenres
        {
            get
            {
                return this.Genres.Count > 0;
            }
        }
    }
}
