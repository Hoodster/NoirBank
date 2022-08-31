using System;
using System.Threading.Tasks;
using NoirBank.Data.Entities;

namespace NoirBank.Repositories
{
    public interface ISessionLogRepository
    {
        Task LogAsync(SessionLog log);
    }
}

