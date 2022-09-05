using System;
using System.Linq;
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

            var defaultTextTransferDirection = isCustomerSender ? $"to {transfer.RecipientAccountNumber}" : $"from {transfer.SenderAccountNumber}";

            var operation = new Operation
            {
                Amount = double.Parse(transfer.Amount),
                OperationDate = DateTime.UtcNow,
                Title = transfer.Title != null
                ? transfer.Title
                : $"Transfer {defaultTextTransferDirection}",
                TranscationType = isCustomerSender ? TransactionTypes.Outcome : TransactionTypes.Income,
                OperationType = OperationTypes.Transfer
            };

            await _dbContext.Operations.AddAsync(operation);

            if (!isCustomerSender)
            {
                recipientAccount.Balance += double.Parse(transfer.Amount);
                _dbContext.BankAccounts.Update(recipientAccount);
            } else
            {
                senderAccount.Balance -= double.Parse(transfer.Amount);
                _dbContext.BankAccounts.Update(senderAccount);
            }

            

            await _dbContext.SaveChangesAsync();
        }
    }
}

