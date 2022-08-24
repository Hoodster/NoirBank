using System;
using Microsoft.Extensions.DependencyInjection;
using NoirBank.Repositories;

namespace NoirBank
{
    public static class Configuration
    {
        public static IServiceCollection UseDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}

