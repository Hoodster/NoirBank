using System;
using System.Threading.Tasks;
using NoirBank.Data.Entities;

namespace NoirBank.Repositories
{
    public class SessionLogRepository : ISessionLogRepository
    {
        DatabaseContext _dbContext;

        public SessionLogRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task LogAsync(SessionLog log)
        {
            await _dbContext.SessionLogs.AddAsync(log);
        }
    }
}

