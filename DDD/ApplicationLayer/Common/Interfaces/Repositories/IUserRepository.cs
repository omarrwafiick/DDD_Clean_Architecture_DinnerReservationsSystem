
using DomainLayer.UserAggregate;

namespace ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmail(string email);
        Task<bool> Add(User user);
    }
}
