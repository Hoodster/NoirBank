using System;
using System.ComponentModel.DataAnnotations;

namespace NoirBank.Data.Enums
{
	public static class OperationTypesOptions
	{
		public const string TRANSFER = "Transfer";
		public const string CARD_TRANSACTION = "CardTransaction";
		public const string DEPOSIT = "Deposit";
	}

	public static class OperationTypesIDs
	{
		public static readonly Guid TRANSFER = new Guid("18d8de41-d705-4dde-beed-3b27c4a67395");
		public static readonly Guid CARD_TRANSACTION = new Guid("a1b21558-f719-4203-b986-fe68e5844d44");
		public static readonly Guid DEPOSIT = new Guid("bd8b5c71-f5ae-4356-9e91-8ee54c62f801");
    }

	public class OperationType
	{
		[Key]
		public Guid OperationTypeID { get; set; }
		public string Type { get; set; }
	}
}

