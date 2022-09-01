using System;
using Microsoft.Extensions.DependencyInjection;
using NoirBank.Repositories;
using NoirBank.Utils;
using NoirBank.Utils.EmailService;

namespace NoirBank
{
    public static class Configuration
    {
        public static IServiceCollection UseDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IEmailService, EmailService>();
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

