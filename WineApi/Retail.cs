using System;

namespace WineApi
{
    /// <summary>
    /// This identifies retail values for the purchase of this product. Only
    /// available when the destination state is specified using the "state"
    /// url value.
    /// </summary>
    public class Retail
    {
        /// <summary>
        /// The unique sku for the product.
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// Indicates whether or not the product is in stock.
        /// </summary>
        public bool InStock { get; set; }

        /// <summary>
        /// Wine.com sales price for the product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The url for purchasing this product.
        /// </summary>
        public string Url { get; set; }
    }
}
