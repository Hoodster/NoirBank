using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
                //TODO:Change types
                //AccountType = Enum.Parse<AccountTypes>(accountDTO.Type, true),
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

            var incomeTransacitonType = _databaseContext.TransactionTypes.First(x => x.Type.Equals(TransactionTypesOptions.INCOME));

            var operation = new Operation
            {
                Amount = amount,
                OperationDate = DateTime.UtcNow,
                TransactionTypeID = incomeTransacitonType.TransactionTypeID,
                Title = $"Deposit to account {account.AccountNumber}",
               // OperationType = OperationTypes.Deposit,
                BankAccountID = account.AccountID
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
                //TODO:Change type
            //    Type = account.AccountType.Type,
                Balance = account.Balance,
                Name = account.Name
            };
        }

        public async Task<IList<Object>> GetBillingHistoryAsync()
        {
            var currentUser = await _authenticationService.GetCurrentUserAsync();
            var operations = _databaseContext.BankAccounts
                .Where(x => x.CustomerID.Equals(currentUser.CustomerID))
                .SelectMany(s => s.Operations)
                .Include(x => x.BankAccount)
                .Include(x => x.OperationType)
                .Include(x => x.TransactionType)
                .ToList();

            var flattenOperations = operations.OrderByDescending(x => x.OperationDate).ToList();

            List<Object> returnList = new List<object>();

            foreach(var transaction in flattenOperations)
            {

                returnList.Add(new
                {
                    AccountName = transaction.BankAccount.Name,
                    OperationDate = transaction.OperationDate.ToLocalTime().ToString("dd:MM:yyyy HH:mm"),
                    Title = transaction.Title,
                    TransactionTypeID = transaction.TransactionType.Type,
                    OperaitonType = transaction.OperationType.Type,
                    Amount = transaction.Amount
            });
                
            }

            return returnList;
        }
    }
}

