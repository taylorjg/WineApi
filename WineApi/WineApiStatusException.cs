using System;

namespace WineApi
{
    /// <summary>
    /// This exception is thrown if an Execute call results in a status return code other than 0.
    /// </summary>
    public class WineApiStatusException : WineApiException
    {
        private Status _status = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="status">The Status object.</param>
        public WineApiStatusException(Status status)
            : base(GetMessageText(status.ReturnCode))
        {
            _status = status;
        }

        /// <summary>
        /// The Status object.
        /// </summary>
        public Status Status
        {
            get
            {
                return _status;
            }
        }

        private static string GetMessageText(ReturnCode returnCode)
        {
            string enumName = Enum.GetName(returnCode.GetType(), returnCode);
            string resourceName = string.Format("ReturnCode{0}", enumName);
            string message = Resources.ResourceManager.GetString(resourceName);

            if (string.IsNullOrEmpty(message)) {
                message = enumName;
            }

            return message;
        }
    }
}
