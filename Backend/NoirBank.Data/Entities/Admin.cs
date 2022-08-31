using System;
using System.ComponentModel.DataAnnotations;

namespace NoirBank.Data.Entities
{
    public class Admin
    {
        [Key]
        public Guid AdminID { get; set; }
        /// <summary>
        /// Account number
        /// </summary>
        public string Login { get; set; }
    }
}

