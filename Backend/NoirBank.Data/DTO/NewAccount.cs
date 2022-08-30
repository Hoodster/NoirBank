using System;
using System.ComponentModel.DataAnnotations;

namespace NoirBank.Data.DTO
{
    public class NewAccount
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PersonalID { get; set; }
        [Required]
        public string DocumentID { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public Address Address { get; set; }

        public NewAccount()
        {
        }
    }
}

