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

        public async Task<BasicAccount> CreateAccount(BankAccountDTO accountDTO)
        {
            var user = await _authenticationService.GetCurrentUserAsync();
            var bankAccountName = !accountDTO.Name.IsNullOrEmpty() ? accountDTO.Name : $"{accountDTO.Type.ToString().ToLower()} account";
            var bankAccount = new BankAccount
            {
                Balance = 0.0,
                AccountType = Enum.Parse<AccountTypes>(accountDTO.Type, true),
                Name = bankAccountName,
                AccountNumber = BankNumbersHelper.GenerateBankAccountNumber(),
                CustomerID = user.CustomerID
            };

            var result = await _databaseContext.BankAccounts.AddAsync(bankAccount);
            await _databaseContext.SaveChangesAsync();
            return PrepareBasicAccountInfo(result.Entity);
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
                .Select(bankAccount => PrepareBasicAccountInfo(bankAccount)).ToList();

            return bankAccounts;
        }

        public async Task DepositToAccountAsync(DepositDTO deposit)
        {
            var amount = double.Parse(deposit.Amount);
            var account = _databaseContext.BankAccounts.FirstOrDefault(x => x.AccountNumber.Equals(deposit.AccountNumber));
            account.Balance += amount;
            _databaseContext.BankAccounts.Update(account);

            var operation = new Operation
            {
                Amount = amount,
                OperationDate = DateTime.UtcNow,
                TranscationType = TransactionTypes.Income,
                Title = $"Deposit to account {account.AccountNumber}",
                OperationType = OperationTypes.Deposit
            };

            await _databaseContext.Operations.AddAsync(operation);
            await _databaseContext.SaveChangesAsync();
        }

        private static BasicAccount PrepareBasicAccountInfo(BankAccount account)
        {
            return new BasicAccount
            {
                AccountNumber = BankNumbersHelper.SplitBankAccountNumber(account.AccountNumber),
                AccountNumberNoSpace = account.AccountNumber,
                Type = account.AccountType,
                Balance = account.Balance,
                Name = account.Name
            };
        }
    }
}

