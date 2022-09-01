using System;
using System.IdentityModel.Tokens.Jwt;

namespace NoirBank.Data.Utils
{
    public class JWTToken
    {
        public string Token { get; set; }
        public DateTime ExpiresIn { get; set; }

        public JWTToken(JwtSecurityToken token)
        {
            this.Token = new JwtSecurityTokenHandler().WriteToken(token);
            this.ExpiresIn = token.ValidTo;
        }
    }
}

