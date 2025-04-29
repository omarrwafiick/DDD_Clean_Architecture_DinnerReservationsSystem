
using ApplicationLayer.Common.Interfaces.Repositories;
using DomainLayer.MenuAggregate;
using InfrastructureLayer.Data;

namespace InfrastructureLayer.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly ApplicationDbContext _context;
        public MenuRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Menu menu)
        {
            await _context.AddAsync(menu);
            await _context.SaveChangesAsync();
        }
    }
}
