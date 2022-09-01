using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NoirBank.Data.Entities;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NoirBank.Utils
{
    public interface IAuthenticationService
    {
        JwtSecurityToken GenerateJwtToken(Guid userId, IList<string> roles);

        Task<User> GetCurrentUserAsync();
    }
}

