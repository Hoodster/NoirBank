using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NoirBank.Data.DTO;
using NoirBank.Data.Email;
using NoirBank.Data.Entities;
using NoirBank.Data.Enums;
using NoirBank.Data.Exceptions;
using NoirBank.Data.Utils;
using NoirBank.Utils;
using NoirBank.Utils.EmailService;
using SendGrid.Helpers.Mail;
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
        private readonly IAuthenticationService _authenticationService;
        private readonly IEmailService _emailService;

        public UserRepository(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole<Guid>> roleManager,
            DatabaseContext db,
            ISessionLogRepository sessionLogRepository,
            IAuthenticationService authenticationService,
            IEmailService emailService
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _db = db;
            _sessionLogRepository = sessionLogRepository;
            _authenticationService = authenticationService;
            _emailService = emailService;
        }

        public async Task CreateAccountAsync(Data.DTO.NewAccount newAccount, ApplicationRoles role)
        {
            CheckIfNullOrEmpty(
                newAccount.FirstName,
                newAccount.LastName,
                newAccount.Password,
                newAccount.Email
            );

            var existingUser = await _userManager.FindByEmailAsync(newAccount.Email);
            if (existingUser != null)
            {
                throw new RecordExistsException();
            }

            var accountNumber = AccountNumberHelper.GenerateAccountNumber();

            var user = new User
            {
                FirstName = newAccount.FirstName,
                LastName = newAccount.LastName,
                Email = newAccount.Email,
            };


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
                user.Customer = addCustomerResult.Entity;
                user.UserName = accountNumber;
            }

            if (role == ApplicationRoles.Admin)
            {
                var admin = new Admin();
                var addAdminResult = await _db.Admins.AddAsync(admin);
                user.Admin = addAdminResult.Entity;
                user.UserName = $"adm{accountNumber}";
            }

            var createUserResult = await _userManager.CreateAsync(user, newAccount.Password);
            if (!createUserResult.Succeeded)
            {
                throw new Exception("unhandled_exception");
            }
            await _db.SaveChangesAsync();
            var createdUser = await _userManager.FindByEmailAsync(newAccount.Email);
            await AddToRoleAsync(createdUser, role);
            await SendUsernameEmail(createdUser.Email, createdUser.FirstName, createdUser.UserName);
        }

        public async Task<JWTToken> SignInAsync(Credentials credentials)
        {
            CheckIfNullOrEmpty(credentials, credentials.AccountNumber, credentials.Password);

            var user = _db.Users.FirstOrDefault(x => x.UserName == credentials.AccountNumber);
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, credentials.Password, false);
            await _sessionLogRepository.LogAsync(new SessionLog(DateTimeOffset.UtcNow, user.Id, signInResult.Succeeded));
            if (signInResult.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var token = _authenticationService.GenerateJwtToken(user.Id, roles);
                return new JWTToken(token);
            } else
            {
                throw new InvalidDataException();
            }
        }

        private async Task SendUsernameEmail(string recipientEmail, string recipientName, string recipientLogin)
        {
            var personalization = new Personalization
            {
                Tos = new List<EmailAddress>()
                {
                    new EmailAddress(recipientEmail)
                },
                TemplateData = new UserNameEmail(recipientName, recipientLogin),
                Subject = "NoirBank - new account login"
            };

            await _emailService.SendEmailAsync(personalization, "d-3d8d3b6fa0984d0c944f3094c4948969");
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

