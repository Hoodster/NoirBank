using System;
namespace NoirBank.Utils
{
    public static class AccountNumberHelper
    {
        public static string GenerateAccountNumber()
        {
            return new Random().Next(1000000, 9999999).ToString();
        }
    }
}

