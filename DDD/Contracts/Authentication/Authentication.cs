 
namespace Contracts.Authentication
{
    public record RegisterRequest(
       string FirstName,
       string LastName,
       string Email,
       string Password
    );

    public record AuthResponse
    (
        Guid id,
        string FirstName,
        string LastName,
        string Email,
        string Token
    );

    public record LoginRequest
    (
      string Email,
      string Password
    );
}
