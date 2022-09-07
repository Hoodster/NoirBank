using System;
namespace NoirBank.Data.Email
{
    public class TwoFactorEmail
    {
        public string Name { get; set; }
        public string TwoFactorCode { get; set; }

        public TwoFactorEmail(string name, string code)
        {
            Name = name;
            TwoFactorCode = code;
        }
    }
}

