using System;
using System.Threading.Tasks;
using NoirBank.Data.DTO;

namespace NoirBank.Repositories
{
    public interface IAccountRepository
    {
        Task CreateAccount(NewAccount newAccount);
        Task GetAllAccounts();
        Task GetAccount(Guid accountID);
    }
}

