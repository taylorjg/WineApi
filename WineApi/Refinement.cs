using System;

namespace WineApi
{
    /// <summary>
    /// A refinement is the actual category value.
    /// </summary>
    public class Refinement
    {
        /// <summary>
        /// The refinement identifier (Endeca Dimension Value Id).
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Describe name for the refinement. "Red Wine" for example.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A url to products that map to this category refinement. This
        /// includes the original filter. For example, if you are looking for
        /// all child categories for the category Red Wines, the Merlot value
        /// will include the Red Wine value.
        /// </summary>
        public string Url { get; set; }
    }
}
