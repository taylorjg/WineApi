using System;

namespace WineApi
{
    public class WineApiStatusException : WineApiException
    {
        private Status _status = null;

        public WineApiStatusException(Status status)
            : base(GetMessageText(status.ReturnCode))
        {
            _status = status;
        }

        public Status Status
        {
            get
            {
                return _status;
            }
        }

        public ReturnCode ReturnCode
        {
            get
            {
                return (_status != null) ? _status.ReturnCode : ReturnCode.Success;
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
