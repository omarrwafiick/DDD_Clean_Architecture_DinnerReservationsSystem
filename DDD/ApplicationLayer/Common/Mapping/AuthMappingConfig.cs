
using ApplicationLayer.Services.Authentication.Commands;
using ApplicationLayer.Services.Authentication.Common;
using ApplicationLayer.Services.Authentication.Queries;
using Contracts.Authentication;
using Mapster;

namespace ApplicationLayer.Common.Mapping
{
    public class AuthMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<RegisterRequest, RegisterCommand>();

            config.NewConfig<AuthResult, AuthResponse>()
                .Map(dest => dest, src => src.user);
        }
    }
}
