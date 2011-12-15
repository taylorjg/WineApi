using System;

namespace WineApi
{
    /// <summary>
    /// Identifies a latitude and longitude for the location of the grapes,
    /// or winery, that produced the wine.
    /// </summary>
    public class GeoLocation
    {
        /// <summary>
        /// The latitude of the location. If this data does not exist (or you
        /// do not have access to it), the value returned will be -360.
        /// </summary>
        public int Latitude { get; set; }

        /// <summary>
        /// The longitude of the location. If this data does not exist (or
        /// you do not have access to it), the value returned will be -360.
        /// </summary>
        public int Longitude { get; set; }

        /// <summary>
        /// The url to a map of the wine.
        /// </summary>
        public string Url { get; set; }
    }
}
