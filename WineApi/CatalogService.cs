using System;

namespace WineApi
{
    /// <summary>
    /// 
    /// </summary>
    public class CatalogService : ServiceBase
    {
        public CatalogService()
            : base("catalog")
        {
        }

        public CatalogService Offset(int offset)
        {
            AppendNameValueToQueryString("offset", offset.ToString());
            return this;
        }

        public CatalogService Size(int size)
        {
            AppendNameValueToQueryString("size", size.ToString());
            return this;
        }

        public CatalogService Search(params string[] terms)
        {
            AppendNameValueToQueryString("search", string.Join("+", terms));
            return this;
        }

        public CatalogService CategoriesFilter(params int[] ids)
        {
            string categories = string.Join("+", ids);
            AppendNameValueToQueryString("filter", string.Format("categories({0})", categories));
            return this;
        }

        public CatalogService RatingFilter(int from)
        {
            AppendNameValueToQueryString("filter", string.Format("rating({0})", from));
            return this;
        }

        public CatalogService RatingFilter(int from, int to)
        {
            AppendNameValueToQueryString("filter", string.Format("rating({0}|{1})", from, to));
            return this;
        }

        public CatalogService PriceFilter(decimal from)
        {
            AppendNameValueToQueryString("filter", string.Format("price({0})", from));
            return this;
        }

        public CatalogService PriceFilter(decimal from, decimal to)
        {
            AppendNameValueToQueryString("filter", string.Format("price({0}|{1})", from, to));
            return this;
        }

        public CatalogService ProductFilter(params int[] ids)
        {
            string products = string.Join("+", ids);
            AppendNameValueToQueryString("filter", string.Format("product({0})", products));
            return this;
        }

        public CatalogService State(string state)
        {
            AppendNameValueToQueryString("state", state);
            return this;
        }

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

        public CatalogService InStock()
        {
            return InStock(true);
        }

        public CatalogService InStock(bool inStock)
        {
            AppendNameValueToQueryString("instock", inStock ? "true" : "false");
            return this;
        }

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
