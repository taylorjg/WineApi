using System;

namespace WineApi
{
    /// <summary>
    /// This links a product to other vintages, and lists some additional
    /// attributes of these products.
    /// </summary>
    public class Vintage
    {
        /// <summary>
        /// The product id of the related vintage.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The year, or vintage, of the related product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A collection of ratings that have been given to this specific
        /// vintage.
        /// </summary>
        public Ratings Ratings { get; set; }

        /// <summary>
        /// The url to the product detail for this vintage.
        /// </summary>
        public string Url { get; set; }
    }
}
