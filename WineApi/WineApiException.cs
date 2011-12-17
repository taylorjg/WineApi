using System;
using System.Runtime.Serialization;

namespace WineApi
{
    /// <summary>
    /// Base class for exceptions thrown by the WineApi class library.
    /// </summary>
    public abstract class WineApiException : Exception, ISerializable
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public WineApiException()
            : base()
        {
        }

        /// <summary>
        /// Constructor taking a message.
        /// </summary>
        /// <param name="message"></param>
        public WineApiException(String message)
            : base(message)
        {
        }

        /// <summary>
        /// Constructor taking a message and an inner exception.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public WineApiException(String message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Some other constructor.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected WineApiException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
