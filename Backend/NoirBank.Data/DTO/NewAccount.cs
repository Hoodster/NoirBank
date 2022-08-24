using System;
namespace NoirBank.Data.DTO
{
    public class NewAccount
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalID { get; set; }
        public string DocumentID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }

        public NewAccount()
        {
        }
    }
}

