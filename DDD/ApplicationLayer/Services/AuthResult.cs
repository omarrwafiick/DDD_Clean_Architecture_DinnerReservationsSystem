 
namespace ApplicationLayer.Services
{
    public record AuthResult
    (
        Guid id,
        string FirstName,
        string LastName,
        string Email,
        string Token
    );
}
