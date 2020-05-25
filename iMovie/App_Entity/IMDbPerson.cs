using HtmlAgilityPack;

namespace iMovie
{
    public class IMDbPerson : WebPage
    {
        private const string PersonPhotoXPath = "//div[@class='image']//a[contains(@href, *)]//img[@id='name-poster' and contains(@src, *)]";

        /// <summary>
        /// Initializes an instance of IMDBPerson from specified url.
        /// </summary>
        /// <param name="url">The imdb person page link to retrieve data from.</param>
        public IMDbPerson(string url) : base(url)
        {
        }

        public void LoadPhotoLink()
        {
            this.Load();
            HtmlNode imageNode = this.GetSingleNode(IMDbPerson.PersonPhotoXPath);
            if (imageNode != null)
            {
                string photo = imageNode.Attributes["src"].Value.Trim();
                if (!string.IsNullOrEmpty(photo))
                {
                    this.PhotoLink = photo;
                }
            }
        }

        /// <summary>
        /// Gets or sets the photo link of the person represented by this instance.
        /// </summary>
        public string PhotoLink { get; private set; } = string.Empty;

        public bool HasPhotoLink
        {
            get
            {
                return !string.IsNullOrEmpty(this.PhotoLink);
            }
        }
    }
}
