using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NoirBank.Data.DTO;
using NoirBank.Data.Entities;
using NoirBank.Data.Enums;
using NoirBank.Data.Exceptions;
using NoirBank.Utils;
using static NoirBank.Utils.TransactionHelper;

namespace NoirBank.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly DatabaseContext _db;
        private readonly ISessionLogRepository _sessionLogRepository;

        public UserRepository(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole<Guid>> roleManager,
            DatabaseContext db,
            ISessionLogRepository sessionLogRepository
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _db = db;
            _sessionLogRepository = sessionLogRepository;
        }

        public async Task CreateAccountAsync(Data.DTO.NewAccount newAccount, ApplicationRoles role)
        {
            var existingUser = await _userManager.FindByEmailAsync(newAccount.Email);
            if (existingUser != null)
            {
                throw new RecordExistsException();
            }

            CheckIfNullOrEmpty(
                newAccount.FirstName,
                newAccount.LastName,
                newAccount.Password,
                newAccount.Email
            );

            var accountNumber = AccountNumberHelper.GenerateAccountNumber();
            var customerID = Guid.Empty;
            var adminID = Guid.Empty;

            if (role == ApplicationRoles.Customer)
            {
                CheckIfNullOrEmpty(
                    newAccount.PersonalID,
                    newAccount.DocumentID,
                    newAccount.Address,
                    newAccount.Address.Street,
                    newAccount.Address.Building,
                    newAccount.Address.PostalCode,
                    newAccount.Address.City,
                    newAccount.Address.Country
                );
                var customer = CreateCustomerNode(newAccount);
                var addCustomerResult = await _db.Customers.AddAsync(customer);
                customerID = addCustomerResult.Entity.CustomerID;
            }

            if (role == ApplicationRoles.Admin)
            {
                var admin = new Admin();
                var addAdminResult = await _db.Admins.AddAsync(admin);
                adminID = addAdminResult.Entity.AdminID;
            }

            var user = new User
            {
                FirstName = newAccount.FirstName,
                LastName = newAccount.LastName,
                Email = newAccount.Email,
                UserName = role == ApplicationRoles.Admin
                ? $"adm{accountNumber}"
                : accountNumber,
                CustomerID = customerID == Guid.Empty ? customerID : null,
                AdminID = adminID == Guid.Empty ? adminID : null
            };

            var createUserResult = await _userManager.CreateAsync(user, newAccount.Password);
            if (!createUserResult.Succeeded)
            {
                throw new Exception("unhandled_exception");
            }

            var createdUser = await _userManager.FindByEmailAsync(newAccount.Email);
            await AddToRoleAsync(createdUser, role);
        }

        public async Task<bool> SignInAsync(Credentials credentials)
        {
            CheckIfNullOrEmpty(credentials, credentials.AccountNumber, credentials.Password);

            var user = _db.Users.FirstOrDefault(x => x.UserName == credentials.AccountNumber);
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, credentials.Password, false);
            await _sessionLogRepository.LogAsync(new SessionLog(DateTimeOffset.UtcNow, user.Id, signInResult.Succeeded));
            return signInResult.Succeeded;
        }

        private async Task AddToRoleAsync(User user, ApplicationRoles role)
        {
            var roleExists = await _roleManager.RoleExistsAsync(role.ToString());
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole<Guid>(role.ToString()));
            }
            await _userManager.AddToRoleAsync(user, role.ToString());
        }

        private static Customer CreateCustomerNode(NewAccount newAccount)
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
            customer.PersonalID = newAccount.PersonalID;
            customer.DocumentID = newAccount.DocumentID;
            customer.HomeAddress = address;


            return customer;
        }
    }
}

