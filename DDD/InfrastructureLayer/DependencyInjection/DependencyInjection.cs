 
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationLayer.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        { 
            return services;
        }
    }
}
