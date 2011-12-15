using System;

namespace WineApi
{
    public class Region
    {
        /// <summary>
        /// A unique (Endeca) identifier for the region.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the region.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The url to the other products in the same region.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The area that the region belongs to. This could be null.
        /// </summary>
        public Area Area { get; set; }
    }
}
