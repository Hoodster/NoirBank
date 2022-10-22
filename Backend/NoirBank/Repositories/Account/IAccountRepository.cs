using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoirBank.Data.DTO;
using NoirBank.Data.Entities;

namespace NoirBank.Repositories
{
    public interface IAccountRepository
    {
        Task<BasicAccount> CreateAccount(BankAccountDTO accountDTO);
        Task<IList<BasicAccount>> GetAllAccounts();
        Task DepositToAccountAsync(DepositDTO deposit);
        Task<IList<Object>> GetBillingHistoryAsync();
        IList<BasicAccount> GetAllAccountsByCustomerID(string customerID);
        Task SwitchAccountLock(string accountNumber);
        Task<byte[]> GenerateOperationPDF(string transactionID);
        void TestTransaction();
    }
}

