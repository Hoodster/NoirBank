using System;
using System.Threading.Tasks;
using NoirBank.Data.DTO;

namespace NoirBank.Repositories
{
    public interface IUserRepository
    {
        Task CreateAccount(NewAccount newAccount);
    }
}

