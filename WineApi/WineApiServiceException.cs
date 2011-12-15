using System;

namespace WineApi
{
    public class WineApiServiceException : WineApiException
    {
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
