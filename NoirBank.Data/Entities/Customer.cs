using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NoirBank.Data.Entities
{
	public class Customer
	{
		[Key]
		public Guid CustomerID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		/// <summary>
        /// PESEL
        /// </summary>
		public string PersonID { get; set; }
		public string IDCardNumber { get; set; }
		public IList<Account> Accounts { get; set; }
		public IList<SessionLog> SessionLogs { get; set; }
		public Customer()
		{
		}
	}
}

