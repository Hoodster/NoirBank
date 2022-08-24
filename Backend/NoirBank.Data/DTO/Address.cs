using System;
namespace NoirBank.Data.DTO
{
    public class Address
    {
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

