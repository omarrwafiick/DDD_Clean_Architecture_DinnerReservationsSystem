using ApplicationLayer.Common.Interfaces.JwtToken;
using ApplicationLayer.Common.Interfaces.Repositories;
using ApplicationLayer.Common.Services;
using InfrastructureLayer.Data;
using InfrastructureLayer.Implementations.JwtToken;
using InfrastructureLayer.Interceptors;
using InfrastructureLayer.Repositories;
using InfrastructureLayer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApplicationLayer.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager config)
        {
            services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(config.GetConnectionString("DefaultConnection"))); 
            services.AddAuthenticationCustome(config);
            services.AddScoped<PublishDomainEventInterceptors>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>(); 
            return services;
        }

        private static IServiceCollection AddAuthenticationCustome(this IServiceCollection services, ConfigurationManager config)
        {
            var jwtSettings = new JwtSettings();
            config.Bind(nameof(JwtSettings), jwtSettings);
            services.AddSingleton(Options.Create(jwtSettings));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Secret))
                });
            return services;
        }
    }
}
