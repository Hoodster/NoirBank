using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
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
                IsLocked = false
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
            await SendUsernameEmailAsync(createdUser.Email, createdUser.FirstName, createdUser.UserName);
        }

        public async Task<string> SignInAsync(Credentials credentials)
        {
            CheckIfNullOrEmpty(credentials, credentials.AccountNumber, credentials.Password);

            var user = _db.Users.FirstOrDefault(x => x.UserName == credentials.AccountNumber);
            if (user.IsLocked)
            {
                throw new Exception();
            }

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, credentials.Password, false);
            await LogAsync(new SessionLog(DateTimeOffset.UtcNow, user.Id, signInResult.Succeeded));
            if (signInResult.Succeeded)
            {
                var token = await _userManager.GenerateTwoFactorTokenAsync(user, TokenOptions.DefaultPhoneProvider);
                await SendTwoFactorEmailAsync(user.Email, user.FirstName, token);
                return user.Email;
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<JWTToken> SignInTwoFactorAsync(string email, string token)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.VerifyTwoFactorTokenAsync(user, TokenOptions.DefaultPhoneProvider, token);
            if (result)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var authToken = _authenticationService.GenerateJwtToken(user.Id, roles);
                return new JWTToken(authToken);
            } else
            {
                throw new Exception();
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
                Login = user.UserName,
            };
        }

        public async Task<IList<SessionLogDTO>> GetUserSessionLogsAsync()
        {
            var user = await _authenticationService.GetCurrentUserAsync();
            var sessionLogs = _db.SessionLogs
                .Where(log => log.UserID.Equals(user.Id))
                .OrderByDescending(x => x.LoginDate)
                .Select(sessionLog => new SessionLogDTO {
                SessionID = sessionLog.SessionID,
                SessionDate = sessionLog.LoginDate.ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss"),
                IsSuccessful = sessionLog.IsSuccessful ? "Succeed" : "Failed"
                }).ToList();

            return sessionLogs;
        }

        public async Task<IList<AdmUser>> GetAllAccounts()
        {
            var me = await _authenticationService.GetCurrentUserAsync();
            var users = await _db.Users.ToListAsync();
            var userList = new List<AdmUser>();

            foreach(var user in users)
            {
                var admId = user.CustomerID != null ? user.CustomerID : user.AdminID;
                var admUser = new AdmUser
                {
                    ID = admId.Value,
                    Name = $"{user.FirstName} {user.LastName}",
                    Status = user.IsLocked ? "Locked" : "Active",
                    AccountType = user.CustomerID != null ? "Customer" : "Administrator",
                };

                userList.Add(admUser);
                
            }

            return userList;
        }

        public async Task SwitchAccountLock(string userID)
        {
            var sessions = GetRecentSessionLogsByUserID(Guid.Parse(userID));
            var user = await _db.Users.FirstOrDefaultAsync(x => x.CustomerID.Equals(Guid.Parse(userID)));
            if (sessions.All(x => x.IsSuccessful.Equals("Failed")))
            {
                user.IsLocked = !user.IsLocked;
            }
            else
            {
                user.IsLocked = false;
            }
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
        }

        #region Private
        private async Task SendTwoFactorEmailAsync(string recipientEmail, string recipientName, string recipientToken)
        {
            var personalization = new Personalization
            {
                Tos = new List<EmailAddress>()
                {
                    new EmailAddress(recipientEmail)
                },
                TemplateData = new TwoFactorEmail(recipientName, recipientToken),
                Subject = "NoirBank - two factor token"
            };

            await _emailService.SendEmailAsync(personalization, "d-8d9e4f8b9b504e01951db534e2e4fb6c");
        }

        private async Task SendUsernameEmailAsync(string recipientEmail, string recipientName, string recipientLogin)
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

        private IEnumerable<SessionLogDTO> GetRecentSessionLogsByUserID(Guid userID)
        {
            var sessionLogs = _db.SessionLogs
                .Where(log => log.UserID.Equals(userID))
                .OrderByDescending(x => x.LoginDate)
                .Select(sessionLog => new SessionLogDTO
                {
                    IsSuccessful = sessionLog.IsSuccessful ? "Succeed" : "Failed"
                }).ToList();
            return sessionLogs.Take(3);
        }
        #endregion
    }
}

