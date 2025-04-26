

using DomainLayer.User;

namespace ApplicationLayer.Services.Authentication.Common
{
    public record AuthResult
    ( 
        User user,
        string Token
    );
}
