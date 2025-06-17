using ApplicationLayer.Common.Interfaces.Repositories;
using DomainLayer.Common.BaseClasses;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InfrastructureLayer.Repositories
{
    public class GetRepository<T, TID> : IGetRepository<T, TID>
        where T : Entity<TID>
        where TID : notnull
    {
        private readonly ApplicationDbContext _context;
        public GetRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<T> GetAsync(TID id) 
            => await _context.Set<T>().SingleOrDefaultAsync(x=>x.Id.Equals(id))!;

        public async Task<T> GetAsync(TID id, Expression<Func<T, bool>> condition) 
            => await _context.Set<T>().Where(condition).SingleOrDefaultAsync(x => x.Id.Equals(id))!;

    }
}
