using System;

namespace WineApi
{
    public class Appellation
    {
        /// <summary>
        /// A unique (Endeca) identifier for the appellation.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the appellation.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The url to the other products in the same appellation.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The region that corresponds to the appellation.
        /// </summary>
        public Region Region { get; set; }
    }
}
