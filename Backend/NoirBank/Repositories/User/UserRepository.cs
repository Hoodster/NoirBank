using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
using Profile = NoirBank.Data.DTO.Profile;

namespace NoirBank.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly DatabaseContext _db;
        private readonly IAuthenticationService _authenticationService;
        private readonly IEmailService _emailService;

        public UserRepository(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole<Guid>> roleManager,
            DatabaseContext db,
            IAuthenticationService authenticationService,
            IEmailService emailService
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _db = db;
            _authenticationService = authenticationService;
            _emailService = emailService;
        }

        public async Task CreateAccountAsync(AccountDTO newAccount, ApplicationRoles role)
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
            await LogAsync(new SessionLog(DateTimeOffset.UtcNow, user.Id, signInResult.Succeeded));
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

        public async Task<Profile> GetProfileAsync()
        {
            var user = await _authenticationService.GetCurrentUserAsync();
            return new Profile
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Login = user.UserName
            };
        }

        public async Task<IList<Object>> GetUserSessionLogsAsync()
        {
            var user = await _authenticationService.GetCurrentUserAsync();
            var sessionLogs = _db.SessionLogs.Where(log => log.UserID.Equals(user.Id)).Select<SessionLog, Object>(sessionLog => new
            {
                SessionID = sessionLog.SessionID,
                SessionDate = sessionLog.LoginDate.ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss"),
                IsSuccessfull = sessionLog.IsSuccessful ? "Succeed" : "Failed"
            }).ToList();

            return sessionLogs;
        }

        #region Private

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

        private static Customer CreateCustomerNode(AccountDTO newAccount)
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

        private async Task LogAsync(SessionLog log)
        {
            await _db.SessionLogs.AddAsync(log);
            await _db.SaveChangesAsync();
        }
        #endregion
    }
}

