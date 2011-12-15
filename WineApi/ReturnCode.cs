using System;

namespace WineApi
{
    // 0 Everything worked, no problems. 
    // 100 A critical error was encountered. This is due to a bug in the service. Please notify wine.com ASAP to correct this issue. 
    // 200 Unable to Authorize. We cannot authorize this account. 
    // 300 No Access. Account does not have access to this service. 

    public enum ReturnCode
    {
        Success = 0,
        CriticalError = 100,
        UnableToAuthorize = 200,
        NoAccess = 300
    }
}
