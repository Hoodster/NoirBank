using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NoirBank.Data.Enums;

namespace NoirBank.Data.Entities
{
	public class Card
	{
		[Key]
		public Guid CardID { get; set; }
		public string CardNumber { get; set; }
		public DateTimeOffset ExpirationDate { get; set; }
		public int CVV { get; set; }
		public string Cover { get; set; }
		[ForeignKey("CardType")]
		public Guid CardTypeID { get; set; }
		public virtual CardType CardType { get; set; }

		public Guid AccountID { get; set; }
		public virtual BankAccount Account { get; set; }

		public Card() { }

		public Card(string number, string cover, Guid cardTypeID, Guid accountID)
		{
			CardNumber = number;
			Cover = cover;
			CardTypeID = cardTypeID;
			ExpirationDate = DateTime.UtcNow.AddYears(6);
			CVV = new Random().Next(100, 999);
			AccountID = accountID;
        }

	}
}

