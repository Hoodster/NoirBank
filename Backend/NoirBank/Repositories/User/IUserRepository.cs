using System;
using System.Threading.Tasks;
using NoirBank.Data.DTO;
using NoirBank.Data.Enums;

namespace NoirBank.Repositories
{
    public interface IUserRepository
    {
        Task CreateAccountAsync(NewAccount newAccount, ApplicationRoles role);
        Task<bool> SignInAsync(Credentials credentials);
    }
}

