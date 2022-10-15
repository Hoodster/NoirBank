using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoirBank.Data.DTO;
using NoirBank.Data.Enums;
using NoirBank.Data.Utils;

namespace NoirBank.Repositories
{
    public interface IUserRepository
    {
        Task CreateAccountAsync(AccountDTO newAccount, ApplicationRoles role);
        Task<string> SignInAsync(Credentials credentials);
        Task<Profile> GetProfileAsync();
        Task<IList<SessionLogDTO>> GetUserSessionLogsAsync();
        Task<IList<AdmUser>> GetAllAccounts();
        Task SwitchAccountLock(string userID);
        Task<Address> GetAccountAddressAsync();
        Task UpdateEmailAsync(string newEmail);
        Task<JWTToken> SignInTwoFactorAsync(string email, string token);
    }
}

