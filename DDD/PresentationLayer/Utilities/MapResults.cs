using ApplicationLayer.Services.Authentication;
using Contracts.Authentication;

namespace PresentationLayer.Utilities
{
    public static class MapResults
    {
        public static AuthResponse MapAuthResult(AuthResult authResult)
        {
            return new AuthResponse(authResult.user.Id, authResult.user.Email, authResult.user.FirstName, authResult.user.LastName, authResult.Token);
        }
    }
}
