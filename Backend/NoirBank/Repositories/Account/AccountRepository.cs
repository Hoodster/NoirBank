using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IronPdf;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NoirBank.Data.DTO;
using NoirBank.Data.Entities;
using NoirBank.Data.Enums;
using NoirBank.Utils;
using NoirBank.Utils.BraintreeService;

namespace NoirBank.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IBraintreeService _braintreeService;
        private readonly DatabaseContext _databaseContext;

        public AccountRepository(IAuthenticationService authenticationService,IBraintreeService braintreeService, DatabaseContext databaseContext)
        {
            _authenticationService = authenticationService;
            _databaseContext = databaseContext;
            _braintreeService = braintreeService;
        }

        public async Task<BasicAccount> CreateAccount(BankAccountDTO accountDTO)
        {
            var user = await _authenticationService.GetCurrentUserAsync();
            var bankAccountName = !accountDTO.Name.IsNullOrEmpty() ? accountDTO.Name : $"{accountDTO.Type.ToString().ToLower()} account";
            var accountNumber = BankNumbersHelper.GenerateBankAccountNumber();
            var typeID = TypesHelper.MapAccountTypes(accountDTO.Type);

            var bankAccount = new BankAccount(bankAccountName, accountNumber, typeID, user.CustomerID.Value);

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
                BankAccountID = account.AccountID,
                RecipientAccountNumber = account.AccountNumber,
                SenderAccountNumber = "-"
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
                    TransactionID = transaction.OperationID,
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

        public void TestTransaction()
        {
            var elo = _braintreeService.GetGateway();
            var elo2 = elo.ClientToken.Generate();
        }

        public async Task<byte[]> GenerateOperationPDF(string transactionID)
        {
            var currentDate = DateTime.UtcNow;
            var transaction = _databaseContext.Operations.Include(x => x.BankAccount).Include(x => x.TransactionType).FirstOrDefault(x => x.OperationID.Equals(Guid.Parse(transactionID)));
            var amount = transaction.Amount.ToString();
            var documentHTML = GeneratePDFStatement(
                transaction.Title,
                transaction.RecipientAccountNumber,
                transaction.SenderAccountNumber.Equals("-") ? transaction.SenderAccountNumber : BankNumbersHelper.SplitBankAccountNumber(transaction.SenderAccountNumber),
                transaction.TransactionType.Type == TransactionTypesOptions.OUTCOME,
                amount.Contains('.') || amount.Contains(',') ? amount : amount + ".00",
                "PLN",
                transaction.OperationDate.Date.ToString("dd/MM/yyyy"),
                currentDate.ToLocalTime().ToString("dd/MM/yyyy HH:mm")
                );

            var renderer = new IronPdf.ChromePdfRenderer();
            renderer.RenderingOptions = new ChromePdfRenderOptions
            {
                Timeout = 300,
                RenderDelay = 30000
            };
            var pdf = await renderer.RenderHtmlAsPdfAsync(documentHTML);

            pdf.SaveAs("statement.pdf");
            var file = await File.ReadAllBytesAsync("statement.pdf");
            return file;
        }

        private string GeneratePDFStatement(string title, string recipientNumber, string senderNumber, bool isOutcome, string amount, string currency, string operationDate, string currentDate)
        {
            var htmlCode = "<html style=\"font-family: 'Futura'\">";
            htmlCode += "<div style=\"width: 100%; text-align: right;\">";
            htmlCode += "<img style=\"max-width: 140px\" src=\"https://i.ibb.co/WsJd4hW/image.png\" alt=\"image\" border=\"0\"></div";
            htmlCode += "<h1 style=\"text-align: center;\">Operation statement</h1><hr/>";
            htmlCode += "<div style=\"text-align: left; width: 100%\">";
            htmlCode += $"<h3>Title</h3><span>{title}</span>";
            htmlCode += $"<h3>Recipient</h3><span>{BankNumbersHelper.SplitBankAccountNumber(recipientNumber)}</span>";
            htmlCode += $"<h3>Sender</h3><span>{senderNumber}</span>";
            htmlCode += $"<h3>Amount</h3><span>{(isOutcome ? "-" : "")}{amount}</span>";
            htmlCode += $"<h3>Currency</h3><span>{currency}</span>";
            htmlCode += $"<h3>Date</h3><span>{operationDate}</span></div>";
            htmlCode += $"<br/><span style=\"color: gray; font-size: 11px; margin-top: 20px;\">This statement is autogenerated by NoirBank system on {currentDate}</span></html>";

            return htmlCode;
        }
    }
}

