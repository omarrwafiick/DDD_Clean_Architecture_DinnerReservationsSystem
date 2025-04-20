namespace ApplicationLayer.Services.Authentication
{
    public interface IAuthService
    {
        AuthResult Login(string email, string password);
        AuthResult Register(string firstName, string lastName, string email, string password);
    }
}
