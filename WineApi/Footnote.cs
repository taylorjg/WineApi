using System;

namespace WineApi
{
    public class Footnote
    {
        /// <summary>
        /// The article identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Descriptive name for the article.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// A url to the article on the wine.com website.
        /// </summary>
        public string Url { get; set; }
    }
}
