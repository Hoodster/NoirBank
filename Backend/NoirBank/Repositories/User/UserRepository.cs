using System;
using System.Threading.Tasks;
using NoirBank.Data.DTO;

namespace NoirBank.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {
        }

        public Task CreateAccount(NewAccount newAccount)
        {
            var i = 4;
            return Task.CompletedTask;
        }
    }
}

