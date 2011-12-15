using System;

namespace WineApi
{
    /// <summary>
    /// This is a list of products.
    /// </summary>
    public class Products
    {
        /// <summary>
        /// The total number of products that match the query. Not all products will be returned.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// The starting position in the entire list.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// The url to the list of wines.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The actual list of products.
        /// </summary>
        public Product[] List { get; set; }
    }
}
