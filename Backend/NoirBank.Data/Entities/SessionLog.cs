using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoirBank.Data.Entities
{
	public class SessionLog
	{
		[Key]
		public Guid SessionID { get; set; }
		public DateTimeOffset LoginDate { get; set; }
		public virtual Customer Customer { get; set; }
		[ForeignKey("Customer")]
		public Guid? CustomerID { get; set; }
		public bool IsSuccessful {get;set;}
		public SessionLog()
		{

		}
	}
}

