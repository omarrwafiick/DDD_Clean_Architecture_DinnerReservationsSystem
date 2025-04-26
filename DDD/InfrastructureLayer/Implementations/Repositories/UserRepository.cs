using ApplicationLayer.Common.Interfaces.Repositories;
using DomainLayer.User;

namespace InfrastructureLayer.Implementations.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public User? GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
