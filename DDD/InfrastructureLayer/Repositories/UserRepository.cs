using ApplicationLayer.Common.Interfaces.Repositories;
using DomainLayer.UserAggregate;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(User user)
        {
            await _context.Users.AddAsync(user);
            return await _context.SaveChangesAsync() > 1;
        }

        public async Task<User?> GetUserByEmail(string email)
            => await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
    }
}
