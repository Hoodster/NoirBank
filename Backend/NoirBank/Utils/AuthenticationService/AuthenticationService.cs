using System;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using NoirBank.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace NoirBank.Utils
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly byte[] _symmetricKey;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public AuthenticationService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _symmetricKey = Encoding.UTF8.GetBytes(configuration.GetValue<string>("SymmetricKey"));
            _userManager = userManager;
        }

        public JwtSecurityToken GenerateJwtToken(Guid userId, IList<string> roles)
        {
            var key = new SymmetricSecurityKey(_symmetricKey);
            var expirationTime = DateTime.Now.AddMonths(1);

            return new JwtSecurityToken(
                claims: GetTokenClaims(userId.ToString(), roles, expirationTime),
                expires: expirationTime,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256),
                notBefore: DateTime.Now
                );
        }

        public async Task<User> GetCurrentUserAsync()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _userManager.FindByIdAsync(userId);
        }

        private static IEnumerable<Claim> GetTokenClaims(string userId, IList<string> roles, DateTime expirationTime)
        {
            var claimsList = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, expirationTime.ToString()),

            };

            foreach (var role in roles)
            {
                claimsList.Add(new Claim(ClaimTypes.Role, role));
            }

            return claimsList;
        }
    }
}

