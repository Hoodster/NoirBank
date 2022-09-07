using System;
using System.ComponentModel.DataAnnotations;

namespace NoirBank.Data.Enums
{
	public static class CardTypesOptions
	{
		public const string DEBIT = "Debit";
		public const string CREDIT = "Credit";
	}

	public static class CardTypesIDs
	{
		public static readonly Guid DEBIT = new Guid("37b71328-e1a8-4d3c-9939-a3816243cab9");
		public static readonly Guid CREDIT = new Guid("9944d4f9-3d34-449b-a531-a8fbcb2f0751");

    }

	public class CardType
	{
		[Key]
		public Guid CardTypeID { get; set; }
		public string Type { get; set; }
	}
}

