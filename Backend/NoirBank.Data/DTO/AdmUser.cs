using System;
namespace NoirBank.Data.DTO
{
    public class AdmUser
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string AccountType { get; set; }
        public string CanDisable { get; set; }

        public AdmUser()
        {
        }
    }
}

