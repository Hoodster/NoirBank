using System;
using System.Threading.Tasks;
using NoirBank.Data.DTO;
using NoirBank.Data.Enums;
using NoirBank.Data.Utils;

namespace NoirBank.Repositories
{
    public interface IUserRepository
    {
        Task CreateAccountAsync(AccountDTO newAccount, ApplicationRoles role);
        Task<JWTToken> SignInAsync(Credentials credentials);
        Task<Profile> GetProfileAsync();
    }
}

