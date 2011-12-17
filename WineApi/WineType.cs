using System;

namespace WineApi
{
    /// <summary>
    /// A wine type.
    /// </summary>
    public class WineType
    {
        /// <summary>
        /// A unique (Endeca) identifier for the type of wine.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the type of wine.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The url to other products that have the same wine type.
        /// </summary>
        public string Url { get; set; }
    }
}
