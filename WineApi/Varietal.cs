using System;

namespace WineApi
{
    /// <summary>
    ///  A varietal.
    /// </summary>
    public class Varietal
    {
        /// <summary>
        /// A unique (Endeca) identifier for the varietal.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the varietal.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The url to other products that have the same varietal.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The type of wine that the varietal corresponds to.
        /// </summary>
        public WineType WineType { get; set; }
    }
}
