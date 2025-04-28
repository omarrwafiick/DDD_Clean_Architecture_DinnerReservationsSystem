
using DomainLayer.UserAggregate;

namespace ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);
    }
}
