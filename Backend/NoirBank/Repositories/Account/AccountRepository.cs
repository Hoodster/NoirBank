using System;
using System.Threading.Tasks;
using NoirBank.Data.DTO;
using NoirBank.Utils;

namespace NoirBank.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IAuthenticationService _authenticationService;

        public AccountRepository(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task CreateAccount()
        {
            var user = await _authenticationService.GetCurrentUserAsync();
            throw new NotImplementedException();
        }

        public Task GetAccount(Guid accountID)
        {
            throw new NotImplementedException();
        }

        public Task GetAllAccounts()
        {
            throw new NotImplementedException();
        }
    }
}

