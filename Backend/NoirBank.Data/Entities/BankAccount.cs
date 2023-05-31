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
        public double Balance { get; set; }
		public bool IsLocked { get; set; }

        [ForeignKey("Customer")]
        public Guid? CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

		[ForeignKey("AccountType")]
		public Guid AccountTypeID { get; set; }
        public virtual AccountType AccountType { get; set; }

		public IList<Card> Cards { get; set; }
		public IList<Operation> Operations { get; set; }

        public BankAccount() { }

		public BankAccount(string name, string accountNumber, Guid accountTypeID, Guid customerID)
		{
            Balance = 0.0;
            AccountTypeID = accountTypeID;
            Name = name;
            AccountNumber = accountNumber;
            CustomerID = customerID;
            IsLocked = false;
		}

    }
}

