

using DomainLayer.Entities;

namespace ApplicationLayer.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user); 
    }
}
