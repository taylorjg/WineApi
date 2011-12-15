using System;

namespace WineApi
{
    /// <summary>
    /// This object is returned when a call is made to the Reference Library API.
    /// </summary>
    public class Reference
    {
        /// <summary>
        /// Contains status and debugging information.
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// A list of reference sections, or books.
        /// </summary>
        public Book[] Books { get; set; }

        // Blog ???
        // Vineyards ???
    }
}
