using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoirBank.Data.DTO;

namespace NoirBank.Repositories
{
    public interface IAccountRepository
    {
        Task CreateAccount(BankAccountDTO accountDTO);
        Task<IList<BasicAccount>> GetAllAccounts();
        Task GetAccount(Guid accountID);
    }
}

