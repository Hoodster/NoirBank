using System;
using System.ComponentModel.DataAnnotations;

namespace NoirBank.Data.DTO
{
    public class AccountDTO : BaseAccountDTO
    {
        [Required]
        public string PersonalID { get; set; }
        [Required]
        public string DocumentID { get; set; }
        [Required]
        public Address Address { get; set; }
    }
}

