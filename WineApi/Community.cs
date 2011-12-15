using System;

namespace WineApi
{
    /// <summary>
    /// This object contains summaries the community content, as well as
    /// access to the more detailed community information.
    /// </summary>
    public class Community
    {
        /// <summary>
        /// A collection of reviews that community members have written.
        /// </summary>
        public CommunityReviews Reviews { get; set; }

        ///// <summary>
        ///// A collection of lists that the product belongs to.
        ///// Only available with "partner" access.
        ///// </summary>
        //public CommunityLists Lists { get; set; }

        /// <summary>
        /// The url to the product detail page that contains the community notes.
        /// </summary>
        public string Url { get; set; }
    }
}
