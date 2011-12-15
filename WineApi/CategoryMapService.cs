using System;

namespace WineApi
{
    public class CategoryMapService : ServiceBase
    {
        public CategoryMapService()
            : base("categorymap")
        {
        }

        public CategoryMapService CategoriesFilter(params int[] ids)
        {
            string categories = string.Join("+", ids);
            AppendNameValueToQueryString("filter", string.Format("categories({0})", categories));
            return this;
        }

        public CategoryMapService RatingFilter(int from)
        {
            AppendNameValueToQueryString("filter", string.Format("rating({0})", from));
            return this;
        }

        public CategoryMapService RatingFilter(int from, int to)
        {
            AppendNameValueToQueryString("filter", string.Format("rating({0}|{1})", from, to));
            return this;
        }

        public CategoryMapService Search(params string[] terms)
        {
            AppendNameValueToQueryString("search", string.Join("+", terms));
            return this;
        }

        public CategoryMapService Show(int id)
        {
            AppendNameValueToQueryString("show", id.ToString());
            return this;
        }

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
