using System;

namespace WineApi
{
    /// <summary>
    /// This exception is thrown if an any exception occurs during a call to Execute.
    /// The inner exception contains the original exception.
    /// </summary>
    public class WineApiServiceException : WineApiException
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="resource">The resource type that was being queried for e.g. "catalog".</param>
        /// <param name="innerException">The original exception.</param>
        public WineApiServiceException(string resource, Exception innerException)
            : base(GetMessageText(resource), innerException)
        {
        }

        private static string GetMessageText(string resource)
        {
            return string.Format(
                Resources.WineApiServiceExceptionMessage,
                resource);
        }
    }
}
