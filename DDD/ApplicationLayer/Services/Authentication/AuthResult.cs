using DomainLayer.Entities;

namespace ApplicationLayer.Services.Authentication
{
    public record AuthResult
    (
        User user,
        string Token
    );
}
