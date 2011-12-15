using System;

namespace WineApi
{
    /// <summary>
    /// This object is returned with every query. It contains a status code,
    /// and any debugging information that might accompany an error.
    /// </summary>
    public class Status
    {
        /// <summary>
        /// A numerical code that identifies the status. A number of 0 means
        /// everything worked correctly.
        /// </summary>
        public ReturnCode ReturnCode { get; set; }

        /// <summary>
        /// Returns a list of messages that contain debugging information to
        /// assist with correcting the issue.
        /// </summary>
        public string[] Messages { get; set; }
    }
}
