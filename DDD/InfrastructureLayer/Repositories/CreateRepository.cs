
using ApplicationLayer.Common.Interfaces.Repositories;
 using InfrastructureLayer.Data;

namespace InfrastructureLayer.Repositories
{
    public class CreateRepository<T> : ICreateRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public CreateRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T data)
        {
            await _context.Set<T>().AddAsync(data);
            await _context.SaveChangesAsync();
        }
    }
}
