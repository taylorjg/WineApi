using System;

namespace WineApi
{
    /// <summary>
    /// Summaries all of the community reviews.
    /// </summary>
    public class CommunityReviews
    {
        /// <summary>
        /// The highest review score given to the product.
        /// </summary>
        public int HighestScore { get; set; }

        /// <summary>
        /// A collection of reviews that have been given to the product.
        /// Only available with "partner" access.
        /// </summary>
        public CommunityReview[] List { get; set; }

        /// <summary>
        /// The url to the full list of reviews.
        /// </summary>
        public string Url { get; set; }
    }
}
