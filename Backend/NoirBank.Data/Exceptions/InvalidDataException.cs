using System;
namespace NoirBank.Data.Exceptions
{
    public class InvalidDataException : Exception
    {
        const string message = "invalid_data";

        public InvalidDataException() : base(message)
        {
        }
    }
}

