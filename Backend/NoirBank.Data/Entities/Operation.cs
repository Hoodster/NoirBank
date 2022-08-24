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
		public TransactionTypes TranscationType { get; set; }
		public DateTimeOffset OperationDate { get; set; }
		public OperationTypes OperationType { get; set; }

		public Operation()
		{
		}
	}
}

