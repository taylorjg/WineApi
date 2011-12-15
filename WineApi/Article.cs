using System;

namespace WineApi
{
    public class Article
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
        /// A short description, or abstract, for the article.
        /// </summary>
        public string Abstract { get; set; }

        /// <summary>
        /// The article content. This is only populated when the article
        /// identifier is specified in the filter.
        /// Only available with "partner" access.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// A url to the article on the wine.com website.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Footnotes to other articles that are related to this article.
        /// </summary>
        public Footnote[] Footnotes { get; set; }
    }
}
