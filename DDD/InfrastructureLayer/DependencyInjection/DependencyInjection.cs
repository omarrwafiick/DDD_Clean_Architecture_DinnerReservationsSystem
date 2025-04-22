using ApplicationLayer.Common.Interfaces.JwtToken;
using ApplicationLayer.Common.Interfaces.Repositories;
using ApplicationLayer.Common.Services;
using InfrastructureLayer.Implementations.JwtToken;
using InfrastructureLayer.Implementations.Repositories;
using InfrastructureLayer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationLayer.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager config)
        {
            services.Configure<JwtSettings>(config.GetSection(nameof(JwtSettings)));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddSingleton<IUserRepository, UserRepository>();
            return services;
        }
    }
}
