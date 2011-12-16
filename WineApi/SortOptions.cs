using System;

namespace WineApi
{
    /// <summary>
    /// Supported sort options.
    /// </summary>
    public enum SortOptions
    {
        /// <summary>
        /// The products are sorted by popularity.
        /// </summary>
        Popularity,

        /// <summary>
        /// The products are sorted by their top professional rating score.
        /// </summary>
        Rating,

        /// <summary>
        /// The products are sorted by their vintage.
        /// </summary>
        Vintage,

        /// <summary>
        /// The products are sorted by the winery name.
        /// </summary>
        Winery,

        /// <summary>
        /// The products are sorted alphabetically, by the product name.
        /// </summary>
        Name,

        /// <summary>
        /// The products are sorted by price. This is only available when the state parameter is specified.
        /// </summary>
        Price,

        /// <summary>
        /// The products are sorted by the amount they are discounted. This is only available when the state parameter is specified.
        /// </summary>
        Saving,

        /// <summary>
        /// The products are sorted by when wine.com first received them.
        /// </summary>
        JustIn
    }
}
