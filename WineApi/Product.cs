using System;

namespace WineApi
{
    /// <summary>
    /// This is the actual product object. When in a list format some of
    /// these values will be null. A full object will only be populated
    /// when the product identifier is specified in the query.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// A unique identifier for the product.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The product name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Additional information that may accompany the product.
        /// Only available with "partner" access.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The location of the grapes, or winery, that produced this wine.
        /// Only available with "partner" access.
        /// </summary>
        public GeoLocation GeoLocation { get; set; }

        /// <summary>
        /// The url to the product detail.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The starting point for the price. Prices could be higher in
        /// certain markets, but they will never be lower than this price.
        /// </summary>
        public decimal PriceMin { get; set; }

        /// <summary>
        /// The maximum price point across all markets for this product.
        /// </summary>
        public decimal PriceMax { get; set; }

        /// <summary>
        /// The suggested retail price for the product.
        /// </summary>
        public decimal PriceRetail { get; set; }

        /// <summary>
        /// Identifies the type of product that is being described. See the
        /// list of possible product type options.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The year, or vintage of the product. If the product is not a
        /// bottle of wine, then the string will be empty. If the product
        /// is a bottle of wine, but has no vintage, it will have a
        /// designation of "Non-Vintage".
        /// </summary>
        public string Year { get; set; }

        /// <summary>
        /// The appellation that the product belongs. Note, not all products
        /// have appellations. This can be null.
        /// </summary>
        public Appellation Appellation { get; set; }

        /// <summary>
        /// The varietal that the product belongs to. Note, not all products
        /// have a varietal. This can be null.
        /// </summary>
        public Varietal Varietal { get; set; }

        /// <summary>
        /// The vineyard that the product belongs to. Note, not all products
        /// have a vineyard. This can be null.
        /// </summary>
        public Vineyard Vineyard { get; set; }

        /// <summary>
        /// A collection of additional attributes that define the product.
        /// </summary>
        public ProductAttribute[] ProductAttributes { get; set; }

        /// <summary>
        /// A collection of labels that go with the product.
        /// </summary>
        public Label[] Labels { get; set; }

        /// <summary>
        /// A collection of ratings that have been given to the product.
        /// </summary>
        public Ratings Ratings { get; set; }

        /// <summary>
        /// Retail properties for the product. This is only available when
        /// the state is specified, otherwise it is null.
        /// </summary>
        public Retail Retail { get; set; }

        /// <summary>
        /// A list of other vintages of this wine.
        /// Only available with "partner" access.
        /// </summary>
        public Vintages Vintages { get; set; }

        /// <summary>
        /// Wine.com community information.
        /// </summary>
        public Community Community { get; set; }
    }
}
