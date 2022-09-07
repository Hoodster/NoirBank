using System;
namespace NoirBank.Data.Entities
{
    public class Address : DTO.Address
    {
        public Guid AddressID { get; set; }

        public Address()
        {
            this.AddressID = Guid.NewGuid();
        }
    }
}

