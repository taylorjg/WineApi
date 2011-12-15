using System;

namespace WineApi
{
    public class CommunityReview
    {
        /// <summary>
        /// The unique (Endeca) id for the publication.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name, or description, of the review or publication.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The score given to the product.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// The full description of the review.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A url to other products that have been reviewed by the same
        /// publication.
        /// </summary>
        public string Url { get; set; }
    }
}
