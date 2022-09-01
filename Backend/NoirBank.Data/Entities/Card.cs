using System;
using System.ComponentModel.DataAnnotations;
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
		public CardTypes CardType { get; set; }
	}
}

