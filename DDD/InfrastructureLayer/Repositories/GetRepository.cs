 
using ApplicationLayer.Common.Interfaces.Repositories;
using DomainLayer.Common.BaseClasses;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InfrastructureLayer.Repositories
{
    public class GetRepository<T> : IGetRepository<T> where T : class , IEntity<Guid>
    {
        private readonly ApplicationDbContext _context;
        public GetRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<T> GetAsync(Guid id) => _context.Set<T>().SingleOrDefaultAsync(x=>x.Id == id);

        public Task<T> GetAsync(Guid id, Expression<Func<T, bool>> condition) => _context.Set<T>().Where(condition).SingleOrDefaultAsync(x => x.Id == id);
    }
}
