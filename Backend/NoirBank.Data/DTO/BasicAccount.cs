using System;
using NoirBank.Data.Enums;

namespace NoirBank.Data.DTO
{
    public class BasicAccount
    {
        public string AccountNumber { get; set; }
        public AccountTypes Type { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public string AccountNumberNoSpace { get; set; }

        public BasicAccount()
        {
        }
    }
}

