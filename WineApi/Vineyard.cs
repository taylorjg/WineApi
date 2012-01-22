using System;

namespace WineApi
{
    /// <summary>
    /// A vineyard.
    /// </summary>
    public class Vineyard
    {
        /// <summary>
        /// A unique identifier for the vineyard.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the vineyard.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The url to the description of the vineyard.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The url to an image of the vineyard.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// The location of the vineyard.
        /// Only available with "partner" access.
        /// </summary>
        public GeoLocation GeoLocation { get; set; }
    }
}
