using System;

namespace WineApi
{
    /// <summary>
    /// The reference library API exposes all of the articles, blogs, and content Wine.com has about wine.
    /// </summary>
    public class ReferenceService : ServiceBase
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ReferenceService()
            : base("reference")
        {
        }

        /// <summary>
        /// Adds the "filter" custom parameter to the query. Specifically, it adds the "categories" filter.
        /// </summary>
        /// <param name="ids">The category attributes to filter on.</param>
        /// <returns>this</returns>
        public ReferenceService CategoriesFilter(params int[] ids)
        {
            string categories = string.Join("+", ids);
            AppendNameValueToQueryString("filter", string.Format("categories({0})", categories));
            return this;
        }

        /// <summary>
        /// Executes the Reference query and returns a Reference object.
        /// </summary>
        /// <returns>A Reference object.</returns>
        public Reference Execute()
        {
            Reference reference = Execute<Reference>();

            if (reference != null) {
                CheckStatus(reference.Status);
            }

            return reference;
        }
    }
}
