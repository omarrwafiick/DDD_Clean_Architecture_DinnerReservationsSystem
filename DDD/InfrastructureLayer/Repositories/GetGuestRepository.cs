
using ApplicationLayer.Common.Interfaces.Repositories;
using DomainLayer.GuestAggregate;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Repositories
{
    public class GetGuestRepository : IGetGuestRepository
    {
        private readonly ApplicationDbContext _context;
        public GetGuestRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Guest> GetGuestAsync(Guid id)
          => await _context.Guests
                  .Include(x => x.UpcomingDinnerIds)
                  .Include(x=>x.PendingDinnerIds)
                  .Include(x=>x.PastDinnerIds)
                  .Include(x=>x.BillIds)
                  .Include(x=>x.MenuReviewIds)
                  .Include(x=>x.RatingIds)
                  .FirstOrDefaultAsync(x => x.Id.Value == id);
    }
}
