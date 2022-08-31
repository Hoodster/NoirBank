using System;
using NoirBank.Data.Exceptions;

namespace NoirBank.Utils
{
    public static class TransactionHelper
    {
        /// <summary>
        /// Checks multiple values if they are null. Throws exception if invalid.
        /// </summary>
        /// <param name="parameters">Any values of any type.</param>
        /// <exception cref="InvalidDataException"/>
        public static void CheckIfNullOrEmpty(params object[] parameters)
        {
            foreach (var parameter in parameters)
            {
                if (parameter == null)
                {
                    throw new InvalidDataException();
                }

                if (parameter is string @stringParam)
                {
                    if (string.IsNullOrWhiteSpace(stringParam))
                    {
                        throw new InvalidDataException();
                    }
                }
            }
        }
    }
}

