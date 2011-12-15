using System;

namespace WineApi
{
    /// <summary>
    /// This defines a high level area that the wine belongs to. An example
    /// would be "New World", or "France".
    /// </summary>
    public class Area
    {
        /// <summary>
        /// A unique (Endeca) identifier for the area.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the area.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The url to the other products in the same area.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// If there is a higher area classification, this will be populated
        /// with the parent. An example could be an area called "Old World"
        /// which would be the parent of an area called "France". This could
        /// be null.
        /// </summary>
        public Area Parent { get; set; }
    }
}
