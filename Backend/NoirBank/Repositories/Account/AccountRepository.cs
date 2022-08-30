using System;
using System.Threading.Tasks;
using NoirBank.Data.DTO;

namespace NoirBank.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public AccountRepository()
        {
        }

        public Task CreateAccount(NewAccount newAccount)
        {
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

