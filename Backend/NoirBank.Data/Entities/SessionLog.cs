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
		[ForeignKey("User")]
		public Guid UserID { get; set; }
        public virtual User User { get; set; }
        public bool IsSuccessful {get;set;}

		public SessionLog()
		{

		}

		public SessionLog(DateTimeOffset date, Guid userID, bool succeed)
		{
			this.LoginDate = date;
			UserID = userID;
			IsSuccessful = succeed;
		}
	}
}

