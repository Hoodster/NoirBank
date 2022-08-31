using System;
using Microsoft.Extensions.DependencyInjection;
using NoirBank.Repositories;

namespace NoirBank
{
    public static class Configuration
    {
        public static IServiceCollection UseDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<ITransferRepository, TransferRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISessionLogRepository, SessionLogRepository>();
            
            return services;
        }
    }
}

