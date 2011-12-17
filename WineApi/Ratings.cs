using System;

namespace WineApi
{
    /// <summary>
    /// A collection of ratings.
    /// </summary>
    public class Ratings
    {
        /// <summary>
        /// The highest score given to the product.
        /// </summary>
        public int HighestScore { get; set; }

        /// <summary>
        /// A collection of ratings that have been given to the product.
        /// Only available with "partner" access.
        /// </summary>
        public Rating[] List { get; set; }
    }
}
