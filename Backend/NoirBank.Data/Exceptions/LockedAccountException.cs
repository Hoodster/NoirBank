using System;
namespace NoirBank.Data.Exceptions
{
    public class LockedAccountException : Exception
    {
        const string message = "locked_account";

        public LockedAccountException() : base(message)
        {
        }
    }
}

