

using DomainLayer.Entities;

namespace ApplicationLayer.Common.Interfaces.JwtToken
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user); 
    }
}
