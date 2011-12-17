using System;

namespace WineApi
{
    /// <summary>
    /// Catalog queries give complete access to the Wine.com product catalog, including professional ratings, labels, styles of wines, and all other attributes associated with Wines.
    /// </summary>
    public class CatalogService : ServiceBase
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public CatalogService()
            : base("catalog")
        {
        }

        /// <summary>
        /// Adds the "offset" custom parameter to the query.
        /// </summary>
        /// <param name="offset">The record to start from.</param>
        /// <returns>this</returns>
        public CatalogService Offset(int offset)
        {
            AppendNameValueToQueryString("offset", offset.ToString());
            return this;
        }

        /// <summary>
        /// Adds the "size" custom parameter to the query.
        /// </summary>
        /// <param name="size">The number of records to return in a list. Max is 100, default is 5.</param>
        /// <returns>this</returns>
        public CatalogService Size(int size)
        {
            AppendNameValueToQueryString("size", size.ToString());
            return this;
        }

        /// <summary>
        /// Adds the "search" custom parameter to the query.
        /// </summary>
        /// <param name="terms">The term(s) to search for.</param>
        /// <returns>this</returns>
        public CatalogService Search(params string[] terms)
        {
            AppendNameValueToQueryString("search", string.Join("+", terms));
            return this;
        }

        /// <summary>
        /// Adds the "filter" custom parameter to the query. Specifically, it adds the "categories" filter.
        /// </summary>
        /// <param name="ids">The category attributes to filter on. Examples would be the red wine attribute, or the cabernet attribute.</param>
        /// <returns>this</returns>
        public CatalogService CategoriesFilter(params int[] ids)
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
        public CatalogService RatingFilter(int from)
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
        public CatalogService RatingFilter(int from, int to)
        {
            AppendNameValueToQueryString("filter", string.Format("rating({0}|{1})", from, to));
            return this;
        }

        /// <summary>
        /// Adds the "filter" custom parameter to the query. Specifically, it adds the "price" filter.
        /// Only supported when the state parameter is provided.
        /// </summary>
        /// <param name="from">The lower value of a range of price to filter on.</param>
        /// <returns>this</returns>
        public CatalogService PriceFilter(decimal from)
        {
            AppendNameValueToQueryString("filter", string.Format("price({0})", from));
            return this;
        }

        /// <summary>
        /// Adds the "filter" custom parameter to the query. Specifically, it adds the "price" filter.
        /// Only supported when the state parameter is provided.
        /// </summary>
        /// <param name="from">The lower value of a range of price to filter on.</param>
        /// <param name="to">The upper value of a range of price to filter on.</param>
        /// <returns>this</returns>
        public CatalogService PriceFilter(decimal from, decimal to)
        {
            AppendNameValueToQueryString("filter", string.Format("price({0}|{1})", from, to));
            return this;
        }

        /// <summary>
        /// Adds the "filter" custom parameter to the query. Specifically, it adds the "product" filter.
        /// When this is specified, full product details are provided.
        /// </summary>
        /// <param name="ids">The specific products to return.</param>
        /// <returns>this</returns>
        public CatalogService ProductFilter(params int[] ids)
        {
            string products = string.Join("+", ids);
            AppendNameValueToQueryString("filter", string.Format("product({0})", products));
            return this;
        }

        /// <summary>
        /// Adds the "state" custom parameter to the query.
        /// This is optional. If it is not present, retail information will not be displayed.
        /// </summary>
        /// <param name="state">The desired ship to state.</param>
        /// <returns>this</returns>
        public CatalogService State(string state)
        {
            AppendNameValueToQueryString("state", state);
            return this;
        }

        /// <summary>
        /// Adds the "sort" custom parameter to the query.
        /// </summary>
        /// <param name="sortOption">What sort key should be used when sorting the list.</param>
        /// <param name="sortDirection">The direction in which to sort.</param>
        /// <returns>this</returns>
        public CatalogService SortBy(SortOptions sortOption, SortDirection sortDirection)
        {
            string sortOptionValue = string.Empty;
            string sortDirectionValue = string.Empty;

            switch (sortOption) {

                case SortOptions.Popularity:
                    sortOptionValue = "popularity";
                    break;

                case SortOptions.Rating:
                    sortOptionValue = "rating";
                    break;

                case SortOptions.Vintage:
                    sortOptionValue = "vintage";
                    break;

                case SortOptions.Winery:
                    sortOptionValue = "winery";
                    break;

                case SortOptions.Name:
                    sortOptionValue = "name";
                    break;

                case SortOptions.Price:
                    sortOptionValue = "price";
                    break;

                case SortOptions.Saving:
                    sortOptionValue = "saving";
                    break;

                case SortOptions.JustIn:
                    sortOptionValue = "justIn";
                    break;

                default:
                    // throw an exception ?
                    return this;
            }

            switch (sortDirection) {

                case SortDirection.Ascending:
                    sortDirectionValue = "ascending";
                    break;

                case SortDirection.Descending:
                    sortDirectionValue = "descending";
                    break;

                default:
                    // throw an exception ?
                    return this;
            }

            AppendNameValueToQueryString(
                "sort",
                string.Format(
                    "{0}|{1}",
                    sortOptionValue,
                    sortDirectionValue));

            return this;
        }

        /// <summary>
        /// Adds the "instock" custom parameter to the query.
        /// This is a convenience method that defaults the value to true.
        /// </summary>
        /// <returns>this</returns>
        public CatalogService InStock()
        {
            return InStock(true);
        }

        /// <summary>
        /// Adds the "instock" custom parameter to the query.
        /// Limit the results to in stock products only (should be coupled with the state parameter).
        /// </summary>
        /// <param name="inStock">true or false.</param>
        /// <returns>this</returns>
        public CatalogService InStock(bool inStock)
        {
            AppendNameValueToQueryString("instock", inStock ? "true" : "false");
            return this;
        }

        /// <summary>
        /// Executes the Catalog query and returns a Catalog object.
        /// </summary>
        /// <returns>A Catalog object.</returns>
        public Catalog Execute()
        {
            Catalog catalog = Execute<Catalog>();

            if (catalog != null) {
                CheckStatus(catalog.Status);
            }

            return catalog;
        }
    }
}
