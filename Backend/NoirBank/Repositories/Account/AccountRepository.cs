using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using NoirBank.Data.DTO;
using NoirBank.Data.Entities;
using NoirBank.Data.Enums;
using NoirBank.Utils;

namespace NoirBank.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly DatabaseContext _databaseContext;

        public AccountRepository(IAuthenticationService authenticationService, DatabaseContext databaseContext)
        {
            _authenticationService = authenticationService;
            _databaseContext = databaseContext;
        }

        public async Task CreateAccount(BankAccountDTO accountDTO)
        {
            var user = await _authenticationService.GetCurrentUserAsync();
            var bankAccountName = !accountDTO.Name.IsNullOrEmpty() ? accountDTO.Name : $"{accountDTO.Type.ToString().ToLower()} account";
            var bankAccount = new BankAccount
            {
                Balance = 0.0,
                AccountType = (AccountTypes)Enum.Parse(typeof(AccountTypes), accountDTO.Type.ToUpper()),
                Name = bankAccountName,
                AccountNumber = BankNumbersHelper.GenerateBankAccountNumber(),
                CustomerID = user.CustomerID
            };

            await _databaseContext.BankAccounts.AddAsync(bankAccount);
            await _databaseContext.SaveChangesAsync();
        }

        public Task GetAccount(Guid accountID)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<BasicAccount>> GetAllAccounts()
        {
            var user = await _authenticationService.GetCurrentUserAsync();
            var bankAccounts = _databaseContext.BankAccounts
                .Where(bankAccount => bankAccount.CustomerID == user.CustomerID)
                .Select(bankAccount => new BasicAccount
                {
                    AccountNumber = BankNumbersHelper.SplitBankAccountNumber(bankAccount.AccountNumber),
                    AccountNumberNoSpace = bankAccount.AccountNumber,
                    Type = bankAccount.AccountType,
                    Balance = bankAccount.Balance,
                    Name = bankAccount.Name
                }).ToList();

            return bankAccounts;
        }
    }
}

