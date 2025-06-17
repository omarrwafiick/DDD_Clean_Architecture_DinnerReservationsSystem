 
using Mapster; 

namespace PresentationLayer.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson();  

            services.AddSwaggerGenNewtonsoftSupport(); 
            services.AddMapster();
            return services;
        }
    }
}  