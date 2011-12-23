using System;

namespace WineApi
{
    /// <summary>
    /// Use this (singleton) class to configure WineApi.
    /// </summary>
    public static class Config
    {
        private readonly static string SERVICE_URL = "http://services.wine.com/api";
        private readonly static string DEFAULT_API_VERSION = "beta2";
        private readonly static string SERVICE_NAME = "service.svc";
        private readonly static string FORMAT_JSON = "json";

        static Config()
        {
            Reset();
        }

        // This method is used by unit tests.
        internal static void Reset()
        {
            ApiKey = string.Empty;
            Version = DEFAULT_API_VERSION;
        }

        /// <summary>
        /// The key given to the developer that is requesting the resource.
        /// </summary>
        public static string ApiKey { get; set; }

        /// <summary>
        /// The version of the API to use.
        /// </summary>
        public static string Version { get; set; }

        /// <summary>
        /// After signing up with LinkShare, use the "affiliateId" parameter
        /// to pass your affiliate code to the API. All links will be updated
        /// to track the sales you drive and you will receive a monthly check
        /// from LinkShare! When you sign up with LinkShare you will see the
        /// specifics of payments.
        /// </summary>
        public static string AffiliateId { get; set; }

        internal static string GetBaseUrl(string resource)
        {
            string baseUrl = string.Format(
                "{0}/{1}/{2}/{3}/{4}?apikey={5}",
                SERVICE_URL,
                Version ?? string.Empty,
                SERVICE_NAME,
                FORMAT_JSON,
                resource ?? string.Empty,
                ApiKey ?? string.Empty);

            if (!string.IsNullOrEmpty(AffiliateId)) {
                baseUrl += string.Format("&affiliateId={0}", AffiliateId);
            }

            return baseUrl;
        }
    }
}
