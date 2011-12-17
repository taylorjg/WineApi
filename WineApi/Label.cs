using System;

namespace WineApi
{
    /// <summary>
    /// A label for a product.
    /// </summary>
    public class Label
    {
        /// <summary>
        /// A unique identifier for the label.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name, or description, of the label.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The url to the label.
        /// </summary>
        public string Url { get; set; }
    }
}
