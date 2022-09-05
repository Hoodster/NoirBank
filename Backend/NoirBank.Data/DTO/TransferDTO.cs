using System;
namespace NoirBank.Data.DTO
{
    public class TransferDTO
    {
        public string SenderAccountNumber { get; set; }
        public string RecipientAccountNumber { get; set; }
        public string Amount { get; set; }
        public string Title { get; set; }
    }
}

