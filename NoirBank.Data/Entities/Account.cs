using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoirBank.Data.Entities
{
	public class Account
	{
		[Key]
		public Guid AccountId { get; set; }
		public virtual Customer Customer {get;set;}
		[ForeignKey("Customer")]
        public Guid? CustomerID { get; set; }
		public Account()
		{
		}
	}
}

