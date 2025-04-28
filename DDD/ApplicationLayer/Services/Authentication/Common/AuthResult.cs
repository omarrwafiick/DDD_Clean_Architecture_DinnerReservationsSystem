

using DomainLayer.UserAggregate;

namespace ApplicationLayer.Services.Authentication.Common
{
    public record AuthResult
    ( 
        User user,
        string Token
    );
}
