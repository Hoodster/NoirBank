using System;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using NoirBank.Data.DTO;
using NoirBank.Data.Entities;
using NoirBank.Data.Enums;
using NoirBank.Utils;

namespace NoirBank.Repositories
{
    public class TransferRepository : ITransferRepository
    {
        private readonly DatabaseContext _dbContext;
        private readonly IAuthenticationService _authService;

        public TransferRepository(DatabaseContext dbContext, IAuthenticationService authService)
        {
            _dbContext = dbContext;
            _authService = authService;
        }

        public async Task MakeTransferAsync(TransferDTO transfer)
        {
            var currentUser = await _authService.GetCurrentUserAsync();
            var senderAccount = _dbContext.BankAccounts.FirstOrDefault(bankAccount => bankAccount.AccountNumber == transfer.SenderAccountNumber);
            var recipientAccount = _dbContext.BankAccounts.FirstOrDefault(bankAccount => bankAccount.AccountNumber == transfer.RecipientAccountNumber);

            var isCustomerSender = senderAccount != null && senderAccount.CustomerID.Equals(currentUser.CustomerID);

            await ProcessTransfer(isCustomerSender, transfer, recipientAccount, senderAccount);

            if (recipientAccount != null && isCustomerSender)
            {
                await ProcessTransfer(false, transfer, recipientAccount, senderAccount);
            }

            await _dbContext.SaveChangesAsync();
        }

        private async Task ProcessTransfer(bool isCustomerSender, TransferDTO transfer, BankAccount recipientAccount, BankAccount senderAccount)
        {
            var defaultTextTransferDirection = isCustomerSender ? $"to {transfer.RecipientAccountNumber}" : $"from {transfer.SenderAccountNumber}";

            var operation = new Operation
            {
                Amount = double.Parse(transfer.Amount, CultureInfo.InvariantCulture),
                OperationDate = DateTime.UtcNow,
                Title = transfer.Title != null
                ? transfer.Title
                : $"Transfer {defaultTextTransferDirection}",
                TransactionTypeID = isCustomerSender ? TransactionTypesIDs.OUTCOME : TransactionTypesIDs.INCOME,
                OperationTypeID = OperationTypesIDs.TRANSFER,
                BankAccountID = isCustomerSender ? senderAccount.AccountID : recipientAccount.AccountID,
                RecipientAccountNumber = transfer.RecipientAccountNumber,
                SenderAccountNumber = transfer.SenderAccountNumber
            };

            await _dbContext.Operations.AddAsync(operation);

            if (!isCustomerSender)
            {
                recipientAccount.Balance = RoundValue(recipientAccount.Balance + operation.Amount);
                _dbContext.BankAccounts.Update(recipientAccount);
            }
            else
            {
                senderAccount.Balance = RoundValue(senderAccount.Balance - operation.Amount);
                _dbContext.BankAccounts.Update(senderAccount);
            }
        }

        private static double RoundValue(double val)
        {
            return Math.Round(val, 2, MidpointRounding.AwayFromZero);
        }
    }
}

