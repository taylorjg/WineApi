using System;

namespace WineApi
{
    /// <summary>
    /// This is also referred to as pedigree. This is a list of past vintages of the selected product.
    /// </summary>
    public class Vintages
    {
        /// <summary>
        /// A specific vintage that the product is related to.
        /// </summary>
        public Vintage[] List { get; set; }
    }
}
