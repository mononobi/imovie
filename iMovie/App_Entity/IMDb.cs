using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using HtmlAgilityPack;

namespace iMovie 
{
    public class IMDb
    {
        private string SearchQueryPattern = @"http://www.imdb.com/find?q=@QUERY@&s=tt";
        private string PhotoCoverTagPattern = @"src=""[^"" <>]*""";
        private string GenreTagPattern = @"(?<=<div[ ]*?class=""see-more[ ]*?inline[ ]*?canwrap""[ ]*?itemprop=""genre"">[ ]*?<h4[ ]*?class=""inline"">Genres:</h4>[ ]*?)(.*)(?=[ ]*?</div>)";
        private string GenreEachTagPattern = @"(?<=<a[^<>]*>)([^<>]*)(?=</a>)";
        private string DirectorsListPattern = @"<h4[ ]*?class=""inline"">Director[s]{0,1}:</h4>[ ]*?<span[ ]*?itemprop=""director""[ ]*?itemscope[ ]*?itemtype=""http://schema.org/Person"">[ ]*?(.*?)[ ]*?</span>[ ]*?</div>";
        private string EachDirectorTagPattern = @"<span[ ]*?itemprop=""director""[ ]*?itemscope[ ]*?itemtype=""http://schema.org/Person"">[ ]*?<a[ ]*?href=""/name/[^"" <>]*""[ ]*?itemprop='url'><span[ ]*?class=""itemprop""[ ]*?itemprop=""name"">[^<>]*</span></a>";
        private string DirectorNamePattern = @"(?<=<span[ ]*?class=""itemprop""[ ]*?itemprop=""name"">)([^<>]*)(?=</span>)";
        private string DirectorURLPattern = @"/name/nm[\d]+";
        private string PersonImageTagPattern = @"alt=""[^""<>]*[ ]*?Picture""[ ]*?title=""[^""<>]*[ ]*?Picture""[ ]*?src=""[^"" <>]*""[ ]*?itemprop=""image""[ ]*?/>";
        private string LanguageTagPattern = @"(?<=<h4[ ]*?class=""inline"">Language:</h4>[ ]*?)(.*)(?=[ ]*?</div>)";
        private string LanguageEachTagPattern = @"(?<=<a[ ]*?href=""[^<> ""]*""[ ]*?itemprop='url'>)([^<>]*)(?=</a>)";

        // This is the standard way of parsing html, all the other regex based patterns, should be changed this way.
        private string ActorsListXPath = "//table[contains(@class,'cast_list')]//a[contains(@itemprop,'url')]";
        private string ActorURLPattern = @"/name/nm[\d]+";
        
        private WebPage moviePage = new WebPage(false);
        private WebPage creditsPage = new WebPage(false);
        private List<Genre> genre = new List<Genre>();
        private List<Person> directors = new List<Person>();
        private List<Person> actors = new List<Person>();
        private List<Language> languages = new List<Language>();
        private double rate = 0;
        private int year = 0; 
        private int minutes = 0;
        private string photoURL = string.Empty;
        private string storyLine = string.Empty;

        private HtmlWeb web = new HtmlWeb();
        private HtmlDocument document = null;

        /// <summary>
        /// Initializes an instance of IMDB from specified IMDB page
        /// </summary>
        /// <param name="autoUpdatePage">
        /// Value indicating that on each URL changing should update 
        /// the movie page of this instance immediately</param>
        /// <param name="imdbURL">
        /// The imdb page link to retrieve data from</param>
        public IMDb(bool autoUpdatePage, string imdbURL)
        {
            try
            {
                this.MoviePage.AutoUpdate = autoUpdatePage;
                this.CreditsPage.AutoUpdate = autoUpdatePage;
                this.URL = imdbURL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Initializes an instance of IMDB without getting data from IMDB
        /// </summary>
        /// <param name="autoUpdatePage">
        /// Value indicating that on each URL changing should update 
        /// the movie page of this instance immediately</param>
        public IMDb(bool autoUpdatePage)
        {
            try
            {
                this.MoviePage.AutoUpdate = autoUpdatePage;
                this.CreditsPage.AutoUpdate = autoUpdatePage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadHTML()
        {
            if (!string.IsNullOrEmpty(this.URL) && this.document == null)
            {
                this.document = this.web.Load(this.URL);
            }
        }

        private void LoadRate()
        {
            try
            {
                if (this.MoviePage.Source.Length <= 0)
                {
                    this.MoviePage.Update();
                }

                if (this.MoviePage.Source.Length > 0)
                {
                    this.LoadHTML();

                    if (this.document != null)
                    {
                        HtmlNode node = this.document.DocumentNode.
                            SelectSingleNode("//div[@class='imdbRating']//div[@class='ratingValue']//strong//span[@itemprop='ratingValue']");
                        if (node != null)
                        {
                            string rate = node.InnerText.Trim();
                            double value = 0;
                            double.TryParse(rate, out value);
                            this.rate = value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadMinute()
        {
            try
            {
                if (this.MoviePage.Source.Length <= 0)
                {
                    this.MoviePage.Update();
                }

                if (this.MoviePage.Source.Length > 0)
                {
                    this.LoadHTML();

                    if (this.document != null)
                    {
                        HtmlNode node = this.document.DocumentNode.
                            SelectSingleNode("//div[@class='article' and @id='titleDetails']//div[@class='txt-block']//time[contains(@datetime, *)]");
                        if (node != null)
                        {
                            string minutes = node.Attributes["datetime"].Value.Trim();
                            minutes = minutes.Replace("PT", "").Replace("M", "").Trim();
                            int value = 0;
                            int.TryParse(minutes, out value);
                            this.minutes = value;
                        }
                    }
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
                if (this.MoviePage.Source.Length <= 0)
                {
                    this.MoviePage.Update();
                }

                if (this.MoviePage.Source.Length > 0)
                {
                    this.LoadHTML();

                    if (this.document != null)
                    {
                        HtmlNode node = this.document.DocumentNode.
                            SelectSingleNode("//div[@class='title_wrapper']//h1//span[@id='titleYear']//a[contains(@href, *)]");
                        if (node != null)
                        {
                            string year = node.InnerText.Trim();
                            int value = 0;
                            int.TryParse(year, out value);
                            this.year = value;
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
        /// Enforces this instance to update it's data from it's URL
        /// </summary>
        public void Update()
        {
            try
            {
                bool last = this.MoviePage.AutoUpdate;
                this.MoviePage.AutoUpdate = true;
                this.CreditsPage.AutoUpdate = true;
                this.URL = this.URL;
                this.MoviePage.AutoUpdate = last;
                this.CreditsPage.AutoUpdate = last;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadPhotoLink()
        {
            try
            {
                if (this.MoviePage.Source.Length <= 0)
                {
                    this.MoviePage.Update();
                }

                if (this.MoviePage.Source.Length > 0)
                {
                    this.LoadHTML();

                    if (this.document != null)
                    {
                        HtmlNode node = this.document.DocumentNode.SelectSingleNode("//div[@class='poster']//a//img[contains(@src, *)]");
                        if (node != null)
                        {
                            string photo = node.Attributes["src"].Value.Trim();
                            if (!string.IsNullOrEmpty(photo))
                            {
                                this.photoURL = photo;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadStoryLine()
        {
            try
            {
                if (this.MoviePage.Source.Length <= 0)
                {
                    this.MoviePage.Update();
                }

                if (this.MoviePage.Source.Length > 0)
                {
                    this.LoadHTML();

                    if (this.document != null)
                    {
                        HtmlNode node = this.document.DocumentNode.
                            SelectSingleNode("//div[@class='article' and @id='titleStoryLine']//div[@class='inline canwrap']//p//span");
                        if (node != null)
                        {
                            string story = node.InnerText.Trim();
                            if (!string.IsNullOrEmpty(story))
                            {
                                this.storyLine = story;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadGenre()
        { 
            try
            {
                string general = "";

                if (this.MoviePage.Source.Length <= 0)
                {
                    this.MoviePage.Update();
                }

                if (this.MoviePage.Source.Length > 0)
                {
                    string source = this.MoviePage.Source;

                    Regex reg = new Regex(GenreTagPattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline);
                    general = reg.Match(source).Value;

                    if (general.Length > 0)
                    {
                        this.Genre.Clear();

                        int ind = -1;

                        general = StringCompare.RemoveDuplicateSpace(general);
                        general = general.Replace("</div>", "Ξ");
                        ind = general.IndexOf("Ξ");

                        if (ind > 0)
                        {
                            general = general.Substring(0, ind);
                        }

                        reg = new Regex(GenreEachTagPattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline);

                        foreach (Match mat in reg.Matches(general))
                        {
                            Genre gen = new Genre(0, mat.Value.Trim());

                            this.genre.Add(gen);
                        }
                    }
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
                string directorsList = "";

                if (this.MoviePage.Source.Length <= 0)
                {
                    this.MoviePage.Update();
                }

                if (this.MoviePage.Source.Length > 0)
                {
                    string source = this.MoviePage.Source;

                    Regex reg = new Regex(DirectorsListPattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline);
                    directorsList = reg.Match(source).Value;

                    if (directorsList.Length > 0)
                    {
                        this.Directors.Clear();

                        directorsList = StringCompare.RemoveDuplicateSpace(directorsList);

                        reg = new Regex(EachDirectorTagPattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline);

                        foreach (Match mat in reg.Matches(directorsList))
                        {
                            reg = new Regex(DirectorNamePattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline);
                            string name = reg.Match(mat.Value).Value;

                            reg = new Regex(DirectorURLPattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline);
                            string url = reg.Match(mat.Value).Value;
                            url = "http://www.imdb.com" + url.Trim().TrimEnd('/');
                            Person p = new Person(0, name.Trim(), url, "");
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

        private void LoadActors()
        {
            try
            {
                if (this.CreditsPage.Source.Length <= 0)
                {
                    this.CreditsPage.Update();
                }

                if (this.CreditsPage.Source.Length > 0)
                {
                    string source = this.CreditsPage.Source;

                    HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                    document.LoadHtml(source);

                    HtmlNodeCollection actors = document.DocumentNode.SelectNodes(this.ActorsListXPath);
                    Regex reg = new Regex(ActorURLPattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline);

                    if (actors != null && actors.Count > 0)
                    {
                        this.Actors.Clear();

                        foreach (HtmlNode actorNode in actors)
                        {
                            string url = reg.Match(actorNode.Attributes["href"].Value).Value;
                            url = "http://www.imdb.com" + url.Trim().TrimEnd('/');

                            string name = actorNode.InnerText.Trim();

                            Person p = new Person(0, name.Trim(), url, "");
                            this.actors.Add(p);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadDirectorsPhotoLink()
        {
            try 
            {
                if (this.HasDirector == false)
                {
                    this.LoadDirectors();
                }

                if (this.HasDirector == true)
                {
                    foreach (Person dir in this.Directors)
                    {
                        try
                        {
                            WebPage p = new WebPage(true, dir.IMDBLink);

                            if (p.Source.Length > 0)
                            {
                                string source = p.Source;

                                Regex reg = new Regex(PersonImageTagPattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline);
                                string photoTag = reg.Match(source).Value;

                                Regex regRef = new Regex(PhotoCoverTagPattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline);

                                string photo = "";
                                photo = regRef.Match(photoTag).Value;

                                photo = photo.Replace(@"src=""", "");
                                photo = photo.Replace(@"""", "");
                                photo = photo.Trim();

                                dir.PhotoLink = photo;
                            }
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private void LoadActorsPhotoLink()
        {
            try
            {
                if (this.HasActor == false)
                {
                    this.LoadActors();
                }

                if (this.HasActor == true)
                {
                    foreach (Person act in this.Actors)
                    {
                        try
                        {
                            WebPage p = new WebPage(true, act.IMDBLink);

                            if (p.Source.Length > 0)
                            {
                                string source = p.Source;

                                Regex reg = new Regex(PersonImageTagPattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline);
                                string photoTag = reg.Match(source).Value;

                                Regex regRef = new Regex(PhotoCoverTagPattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline);

                                string photo = "";
                                photo = regRef.Match(photoTag).Value;

                                photo = photo.Replace(@"src=""", "");
                                photo = photo.Replace(@"""", "");
                                photo = photo.Trim();

                                act.PhotoLink = photo;
                            }
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadLanguage()
        {
            try
            { 
                if (this.MoviePage.Source.Length <= 0)
                {
                    this.MoviePage.Update();
                }

                if (this.MoviePage.Source.Length > 0)
                {
                    string source = this.MoviePage.Source;

                    Regex reg = new Regex(LanguageTagPattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline);

                    string languageTag = reg.Match(source).Value;

                    languageTag = languageTag.Replace("</div>", "Ξ");
                    int ind = languageTag.IndexOf("Ξ");

                    if (ind > 0)
                    {
                        languageTag = languageTag.Substring(0, ind);

                        if (languageTag.Length > 0)
                        {
                            this.Languages.Clear();

                            languageTag = StringCompare.RemoveDuplicateSpace(languageTag);

                            reg = new Regex(LanguageEachTagPattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline);

                            foreach (Match mat in reg.Matches(languageTag))
                            {
                                string lang = mat.Value;
                                Language l = new Language(0, lang);
                                this.Languages.Add(l);
                            }
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
        /// Downloads the image from it's photo URL into specified destination
        /// </summary>
        /// <param name="photoURL">
        /// URL of the photo</param>
        /// <param name="targetPath">
        /// Destination path to save file</param>
        public static void DownloadImage(string photoURL, string targetPath)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFile(photoURL, targetPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the rate value of this instance
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
        /// Gets the photo URL of this instance
        /// </summary>
        public string PhotoURL
        {
            get
            {
                try
                {
                    return this.photoURL;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Gets the WebPage component of this instance that represents an IMDB movie page
        /// </summary>
        public WebPage MoviePage
        {
            get
            {
                try
                {
                    return this.moviePage;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Gets the WebPage component of this instance that represents an IMDB full credits page
        /// </summary>
        public WebPage CreditsPage
        {
            get
            {
                try
                {
                    return this.creditsPage;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Gets or sets the URL of IMDB page that represents by this instance
        /// </summary>
        public string URL
        {
            get
            {
                try
                {
                    return this.MoviePage.URL;
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
                    string normalizedURL = value.Trim().TrimEnd('/');
                    this.MoviePage.URL = normalizedURL;
                    this.CreditsPage.URL = normalizedURL + "/fullcredits";

                    if (this.MoviePage.AutoUpdate == true)
                    {
                        LoadRate();
                        LoadPhotoLink();
                        LoadMinute();
                        LoadYear();
                        LoadStoryLine();
                        LoadGenre();
                        LoadDirectors();
                        LoadDirectorsPhotoLink();
                        LoadLanguage();
                    }

                    if (this.CreditsPage.AutoUpdate == true)
                    {
                        LoadActors();
                        LoadActorsPhotoLink();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Gets the duration of the movie represented by this instance
        /// </summary>
        public TimeSpan Duration 
        { 
            get 
            {
                try
                {
                    TimeSpan ts = new TimeSpan(0, this.minutes, 0);

                    return ts;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Gets the product year of the movie represented by this instance
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

        /// <summary>
        /// Gets the storyline of the movie represented by this instance
        /// </summary>
        public string StoryLine
        {
            get
            {
                try
                {
                    return this.storyLine;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Gets the genres of the movie represented by this instance
        /// </summary>
        public List<Genre> Genre
        {
            get
            {
                try
                {
                    return this.genre;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Gets the directors of the movie represented by this instance
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
        /// Gets the actors of the movie represented by this instance
        /// </summary>
        public List<Person> Actors
        {
            get
            {
                try
                {
                    return this.actors;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Gets the languages of the movie represented by this instance
        /// </summary>
        public List<Language> Languages
        {
            get
            {
                try
                {
                    return this.languages;
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
                    if (this.URL.Length > 0)
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

        public bool HasDuration
        {
            get
            {
                try
                {
                    if (this.Duration.TotalSeconds > 0)
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

        public bool HasPhotoURL
        {
            get 
            {
                try
                {
                    if (this.PhotoURL.Length > 0)
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

        public bool HasStoryLine
        {
            get 
            {
                try
                {
                    if (this.StoryLine.Length > 0)
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

        public bool HasGenre
        {
            get
            { 
                try
                {
                    if (this.genre.Count > 0)
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
                    if (this.directors.Count > 0)
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

        public bool HasActor
        {
            get
            {
                try
                {
                    if (this.actors.Count > 0)
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

        public bool HasLanguage
        {
            get
            {
                try
                {
                    if (this.Languages.Count > 0)
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
