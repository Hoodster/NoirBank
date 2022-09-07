using System;
using System.ComponentModel.DataAnnotations;

namespace NoirBank.Data.DTO
{
    public class Credentials
    {
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public string Password { get; set; }

        public Credentials()
        {
        }
    }
}

