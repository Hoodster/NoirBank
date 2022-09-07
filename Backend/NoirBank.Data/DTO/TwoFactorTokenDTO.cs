using System;
namespace NoirBank.Data.DTO
{
    public class TwoFactorTokenDTO
    {
        public string Token { get; set; }
        public string Email { get; set; }

        public TwoFactorTokenDTO()
        {
        }
    }
}

