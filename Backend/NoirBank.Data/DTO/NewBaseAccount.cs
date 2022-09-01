using System;
using System.ComponentModel.DataAnnotations;

namespace NoirBank.Data.DTO
{
    public class NewBaseAccount
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public NewBaseAccount()
        {
        }
    }
}

