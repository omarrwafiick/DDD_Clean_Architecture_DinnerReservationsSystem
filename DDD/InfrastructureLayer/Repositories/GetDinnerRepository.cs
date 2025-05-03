
using ApplicationLayer.Common.Interfaces.Repositories;
using DomainLayer.DinnerAggregate;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Repositories
{
    public class GetDinnerRepository : IGetDinnerRepository
    {
        private readonly ApplicationDbContext _context;
        public GetDinnerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Dinner> GetDinnerAsync(Guid id) 
            => await _context.Dinners
                    .Include(x=>x.ReservationIds)
                    .FirstOrDefaultAsync(x=>x.Id.Value == id);
    }
}
