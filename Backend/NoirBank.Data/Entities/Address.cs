using System;
namespace NoirBank.Data.Entities
{
    public class Address
    {
        public Guid AddressID { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Apartment { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public Address()
        {
         
        }
    }
}

