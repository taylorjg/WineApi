using System;

namespace WineApi
{
    /// <summary>
    /// This query returns the various categories and their children. These categories can then be used to retrieve products using the "filter" option.
    /// </summary>
    public class CategoryMapService : ServiceBase
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public CategoryMapService()
            : base("categorymap")
        {
        }

        /// <summary>
        /// Adds the "filter" custom parameter to the query. Specifically, it adds the "categories" filter.
        /// </summary>
        /// <param name="ids">The category attributes to filter on.</param>
        /// <returns>this</returns>
        public CategoryMapService CategoriesFilter(params int[] ids)
        {
            string categories = string.Join("+", ids);
            AppendNameValueToQueryString("filter", string.Format("categories({0})", categories));
            return this;
        }

        /// <summary>
        /// Adds the "filter" custom parameter to the query. Specifically, it adds the "rating" filter.
        /// </summary>
        /// <param name="from">The lower value of a range of rating scores to filter on.</param>
        /// <returns>this</returns>
        public CategoryMapService RatingFilter(int from)
        {
            AppendNameValueToQueryString("filter", string.Format("rating({0})", from));
            return this;
        }

        /// <summary>
        /// Adds the "filter" custom parameter to the query. Specifically, it adds the "rating" filter.
        /// </summary>
        /// <param name="from">The lower value of a range of rating scores to filter on.</param>
        /// <param name="to">The upper value of a range of rating scores to filter on.</param>
        /// <returns>this</returns>
        public CategoryMapService RatingFilter(int from, int to)
        {
            AppendNameValueToQueryString("filter", string.Format("rating({0}|{1})", from, to));
            return this;
        }

        /// <summary>
        /// Adds the "search" custom parameter to the query.
        /// </summary>
        /// <param name="terms">The term(s) to search for.</param>
        /// <returns>this</returns>
        public CategoryMapService Search(params string[] terms)
        {
            AppendNameValueToQueryString("search", string.Join("+", terms));
            return this;
        }

        /// <summary>
        /// Lists all items in the given categories.
        /// </summary>
        /// <param name="ids">The categories to be returned.</param>
        /// <returns>this</returns>
        public CategoryMapService Show(params int[] ids)
        {
            string categories = string.Join("+", ids);
            AppendNameValueToQueryString("show", string.Format("({0})", categories));
            return this;
        }

        /// <summary>
        /// Executes the CategoryMap query and returns a CategoryMap object.
        /// </summary>
        /// <returns>A CategoryMap object.</returns>
        public CategoryMap Execute()
        {
            CategoryMap categoryMap = Execute<CategoryMap>();

            if (categoryMap != null) {
                CheckStatus(categoryMap.Status);
            }

            return categoryMap;
        }
    }
}
