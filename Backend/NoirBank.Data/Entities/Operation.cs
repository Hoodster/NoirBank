using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NoirBank.Data.Enums;

namespace NoirBank.Data.Entities
{
	public class Operation
	{
		[Key]
		public Guid OperationID { get; set; }
		public string Title { get; set; }
		public double Amount { get; set; }
		public DateTimeOffset OperationDate { get; set; }
		public string RecipientAccountNumber { get; set; }
		public string SenderAccountNumber { get; set; }

        [ForeignKey("TransactionType")]
        public Guid TransactionTypeID { get; set; }
        public virtual TransactionType TransactionType { get; set; }

        [ForeignKey("OperationType")]
		public Guid OperationTypeID { get; set; }
		public virtual OperationType OperationType { get; set; }

		[ForeignKey("BankAccount")]
		public Guid BankAccountID { get; set; }
		public virtual BankAccount BankAccount { get; set; }

		public Operation()
		{
		}
	}
}

