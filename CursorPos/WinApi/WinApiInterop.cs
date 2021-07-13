using System;
using CursorPos.Exceptions;

namespace CursorPos.WinApi
{
    internal static class WinApiInterop
    {
        internal static void Call(Func<bool> apiCall, string exceptionMessage)
        {
            var isSuccess = apiCall();
            CheckIfSuccess(isSuccess, exceptionMessage);
        }
        
        internal static void CheckIfSuccess(bool isSuccess, string exceptionMessage)
        {
            if (!isSuccess)
            {
                throw new UnsuccessException(exceptionMessage);
            }
        }
    }
}