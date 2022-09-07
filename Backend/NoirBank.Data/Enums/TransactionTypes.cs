using System;
using System.ComponentModel.DataAnnotations;

namespace NoirBank.Data.Enums
{
	public static class TransactionTypesOptions
	{
		public const string INCOME = "Income";
		public const string OUTCOME = "Outcome";
	}

	public static class TransactionTypesIDs
	{
		public static readonly Guid INCOME = new Guid("ca898a8f-4bf9-4f05-aed6-5e9c0f746b3c");
		public static readonly Guid OUTCOME = new Guid("09fc3207-4da1-4048-bf7b-40e687b88ca5");
    }

	public class TransactionType
	{
		[Key]
		public Guid TransactionTypeID { get; set; }
		public string Type { get; set; }
	}
}

