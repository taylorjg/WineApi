using System;
using System.Runtime.Serialization;

namespace WineApi
{
    public class WineApiException : Exception, ISerializable
    {
        public WineApiException()
            : base()
        {
        }

        public WineApiException(String message)
            : base(message)
        {
        }

        public WineApiException(String message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected WineApiException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
