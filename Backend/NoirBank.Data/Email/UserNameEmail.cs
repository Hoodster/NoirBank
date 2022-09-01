using System;
using NoirBank.Data.Utils;

namespace NoirBank.Data.Email
{
    public class UserNameEmail : EmailBase
    {
        public string Name { get; set; }
        public string AccountNumber { get; set; }

        public UserNameEmail(string name, string accountNumber)
        {
            Name = name;
            AccountNumber = accountNumber;
        }
    }
}

