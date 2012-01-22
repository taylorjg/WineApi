using System;

namespace WineApi
{
    /// <summary>
    /// This identifies other attributes that describe the product. Some
    /// examples would be "Kosher" or "Collectible" or "Screw Cap".
    /// </summary>
    public class ProductAttribute
    {
        /// <summary>
        /// The unique (Endeca) id for the attribute.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name, or description, of the attribute.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A url to other products that have the same attribute.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The url to an icon for the product attribute.
        /// </summary>
        public string ImageUrl { get; set; }
    }
}
