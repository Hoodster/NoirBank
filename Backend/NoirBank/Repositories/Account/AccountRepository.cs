using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
                AccountTypeID = TypesHelper.MapAccountTypes(accountDTO.Type),
                Name = bankAccountName,
                AccountNumber = BankNumbersHelper.GenerateBankAccountNumber(),
                CustomerID = user.CustomerID,
                IsLocked = false
            };

            var result = await _databaseContext.BankAccounts.AddAsync(bankAccount);
            await _databaseContext.SaveChangesAsync();
            return PrepareBasicAccountInfo(result.Entity, accountDTO.Type);
        }

        public async Task<IList<BasicAccount>> GetAllAccounts()
        {
            var user = await _authenticationService.GetCurrentUserAsync();

            var bankAccounts = GetCustomerAccounts(user.CustomerID.Value);

            return bankAccounts;
        }

        public IList<BasicAccount> GetAllAccountsByCustomerID(string customerID)
        {
            var custID = Guid.Parse(customerID);
            var accounts = GetCustomerAccounts(custID);
            return accounts;
        }

        public async Task DepositToAccountAsync(DepositDTO deposit)
        {
            var amount = double.Parse(deposit.Amount);
            var account = _databaseContext.BankAccounts.FirstOrDefault(x => x.AccountNumber.Equals(deposit.AccountNumber));
            account.Balance = Math.Round(account.Balance + amount, 2, MidpointRounding.AwayFromZero);
            _databaseContext.BankAccounts.Update(account);

            var operation = new Operation
            {
                Amount = amount,
                OperationDate = DateTime.UtcNow,
                TransactionTypeID = TransactionTypesIDs.INCOME,
                Title = $"Deposit to account {account.AccountNumber}",
                OperationTypeID = OperationTypesIDs.DEPOSIT,
                BankAccountID = account.AccountID
            };

            await _databaseContext.Operations.AddAsync(operation);
            await _databaseContext.SaveChangesAsync();
        }

        private IList<BasicAccount> GetCustomerAccounts(Guid customerID)
        {
            return _databaseContext.BankAccounts
                .Where(bankAccount => bankAccount.CustomerID.Equals(customerID))
                .Include(bankAccount => bankAccount.AccountType)
                .Select(bankAccount => PrepareBasicAccountInfo(bankAccount, null)).ToList();
        }

        private static BasicAccount PrepareBasicAccountInfo(BankAccount account, string accountType = null)
        {
            return new BasicAccount
            {
                AccountNumber = BankNumbersHelper.SplitBankAccountNumber(account.AccountNumber),
                AccountNumberNoSpace = account.AccountNumber,
                Type = accountType != null ? accountType : account.AccountType.Type,
                Balance = account.Balance,
                Name = account.Name,
                Status = account.IsLocked ? "Locked" : "Active"
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
                    OperationDate = transaction.OperationDate.ToLocalTime().ToString("dd/MM/yyyy HH:mm"),
                    Title = transaction.Title,
                    TransactionType = transaction.TransactionType.Type,
                    OperationType = transaction.OperationType.Type,
                    Amount = Math.Round(transaction.Amount, 2, MidpointRounding.AwayFromZero)
            });
                
            }

            return returnList;
        }

        public async Task SwitchAccountLock(string accountNumber)
        {
            var bankAccount = await _databaseContext.BankAccounts.FirstOrDefaultAsync(x => x.AccountNumber.Equals(accountNumber));
            bankAccount.IsLocked = !bankAccount.IsLocked;
            _databaseContext.BankAccounts.Update(bankAccount);
            await _databaseContext.SaveChangesAsync();
        }
    }
}

