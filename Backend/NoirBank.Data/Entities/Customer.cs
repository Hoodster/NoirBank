using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoirBank.Data.Entities
{
	public class Customer
	{
		/// <summary>
		/// ID of a customer.
		/// </summary>
		[Key]
		public Guid CustomerID { get; set; }
        /// <summary>
        /// In Poland: PESEL.
        /// </summary>
        public string PersonalID { get; set; }
		/// <summary>
		/// ID card serial number.
		/// </summary>
		public string DocumentID { get; set; }
        /// <summary>
        /// Bank accounts of a customer.
        /// </summary>
        public IList<BankAccount> BankAccounts { get; set; }
		/// <summary>
        /// Virtual address model.
        /// </summary>
		public virtual Address HomeAddress { get; set; }
        /// <summary>
        /// Home address foreign key.
        /// </summary>
        [ForeignKey("HomeAddress")]
		public Guid? HomeAddressID { get; set; }
		public Customer()
		{
		}
	}
}

