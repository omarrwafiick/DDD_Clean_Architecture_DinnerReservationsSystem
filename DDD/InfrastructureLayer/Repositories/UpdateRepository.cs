 
using ApplicationLayer.Common.Interfaces.Repositories;
using InfrastructureLayer.Data;

namespace InfrastructureLayer.Repositories
{
    public class UpdateRepository<T> : IUpdateRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public UpdateRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task UpdateAsync(T data)
        {
            _context.Set<T>().Update(data);
            await _context.SaveChangesAsync();
        }
    }
}
