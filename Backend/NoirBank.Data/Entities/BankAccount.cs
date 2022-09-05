using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NoirBank.Data.Enums;

namespace NoirBank.Data.Entities
{
	public class BankAccount
	{
		[Key]
		public Guid AccountID { get; set; }
        public string AccountNumber { get; set; }
        public string Name { get; set; }

		[ForeignKey("Customer")]
        public Guid? CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        public double Balance { get; set; }

        public AccountTypes AccountType { get; set; }
		public IList<Card> Cards { get; set; }
		public IList<Operation> Operations { get; set; }

		public BankAccount()
		{
		}
	}
}

