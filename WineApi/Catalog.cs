using System;

namespace WineApi
{
    /// <summary>
    /// This object is returned when a call is made to the Catalog API.
    /// </summary>
    public class Catalog
    {
        /// <summary>
        /// Contains status and debugging information.
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// This object contains products that match the catalog query.
        /// </summary>
        public Products Products { get; set; }
    }
}
