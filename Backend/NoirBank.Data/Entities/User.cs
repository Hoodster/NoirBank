using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace NoirBank.Data.Entities
{
    public class User : IdentityUser<Guid>
    {
        /// <summary>
        /// First name.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Email address.
        /// </summary>
        public override string Email { get; set; }

        [ForeignKey("Customer")]
        public Guid? CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey("Admin")]
        public Guid? AdminID { get; set; }
        public virtual Customer Admin { get; set; }


        public User()
        {
        }
    }
}
