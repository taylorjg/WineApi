using System;

namespace WineApi
{
    /// <summary>
    /// A numerical code that identifies the status. A number of 0 means everything worked correctly.
    /// </summary>
    public enum ReturnCode
    {
        /// <summary>
        /// Everything worked, no problems.
        /// </summary>
        Success = 0,

        /// <summary>
        /// A critical error was encountered. This is due to a bug in the service. Please notify wine.com ASAP to correct this issue.
        /// </summary>
        CriticalError = 100,

        /// <summary>
        /// Unable to Authorize. We cannot authorize this account.
        /// </summary>
        UnableToAuthorize = 200,

        /// <summary>
        /// No Access. Account does not have access to this service.
        /// </summary>
        NoAccess = 300
    }
}
