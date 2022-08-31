using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NoirBank.Data.DTO;
using NoirBank.Data.Entities;
using NoirBank.Utils;

namespace NoirBank.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<Data.Entities.Customer> _userManager;

        public UserRepository(UserManager<Data.Entities.Customer> userManager)
        {
            _userManager = userManager;
        }

        public async Task CreateAccount(Data.DTO.NewAccount newAccount)
        {
            var accountNumber = AccountNumberHelper.GenerateAccountNumber();
            var customer = CreateCustomerNode(newAccount);
            await _userManager.CreateAsync(customer, newAccount.Password);
        }

        private Customer CreateCustomerNode(NewAccount newAccount)
        {
            var address = new Data.Entities.Address();
            var addressDTO = newAccount.Address;
            address.Street = addressDTO.Street;
            address.Building = addressDTO.Building;
            address.Apartment = addressDTO.Apartment;
            address.PostalCode = addressDTO.PostalCode;
            address.City = addressDTO.City;
            address.Country = addressDTO.Country;

            var customer = new Customer();
            customer.FirstName = newAccount.FirstName;
            customer.LastName = newAccount.LastName;
            customer.PersonalID = newAccount.PersonalID;
            customer.DocumentID = newAccount.DocumentID;
            customer.HomeAddress = address;
            customer.Email = newAccount.Email;

            return customer;
        }
    }
}

