using System;

namespace WineApi
{
    /// <summary>
    /// This object is returned when a call is made to the Category Map API.
    /// It returns possible category matches based off a provided query.
    /// </summary>
    public class CategoryMap
    {
        /// <summary>
        /// Contains status and debugging information.
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// A list of categories that match the provided query.
        /// </summary>
        public Category[] Categories { get; set; }
    }
}
