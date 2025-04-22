using FluentResults; 
namespace ApplicationLayer.Services.Authentication
{
    public interface IAuthService
    {
        Result<AuthResult> Login(string email, string password);
        Result<AuthResult> Register(string firstName, string lastName, string email, string password);
    }
}
