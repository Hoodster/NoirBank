using System;
namespace NoirBank.Data.Exceptions
{
    public class RecordExistsException : Exception
    {
        const string message = "record_already_exist";

        public RecordExistsException() : base(message)
        {
        }
    }
}

