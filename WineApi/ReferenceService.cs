using System;
using System.Linq;

namespace WineApi
{
    public class ReferenceService : ServiceBase
    {
        public ReferenceService()
            : base("reference")
        {
        }

        public ReferenceService CategoriesFilter(params int[] ids)
        {
            string categories = string.Join("+", ids);
            AppendNameValueToQueryString("filter", string.Format("categories({0})", categories));
            return this;
        }

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
