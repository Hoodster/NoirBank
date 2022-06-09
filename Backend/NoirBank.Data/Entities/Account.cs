using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NoirBank.Data.Enums;

namespace NoirBank.Data.Entities
{
	public class Account
	{
		[Key]
		public Guid AccountID { get; set; }
		public virtual Customer Customer {get;set;}
		[ForeignKey("Customer")]
        public Guid? CustomerID { get; set; }
		public AccountTypes AccountType { get; set; }
		public virtual Card Card { get; set; }
        [ForeignKey("Card")]
		public Guid? CardID { get; set; }
		public double Balance { get; set; }
		public Account()
		{
		}
	}
}

