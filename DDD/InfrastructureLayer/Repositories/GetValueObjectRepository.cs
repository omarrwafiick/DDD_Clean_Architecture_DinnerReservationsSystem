using ApplicationLayer.Common.Interfaces.Repositories;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InfrastructureLayer.Repositories
{
    public class GetValueObjectRepository<T> : IGetValueObjectRepository<T>
    where T : class
    {
        private readonly ApplicationDbContext _context;
        public GetValueObjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<T> GetAsync(Expression<Func<T, bool>> condition) 
            => await _context.Set<T>().Where(condition).SingleOrDefaultAsync()!;
    }
}
