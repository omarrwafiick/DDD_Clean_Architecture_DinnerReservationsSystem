using DomainLayer.GuestAggregate;

namespace ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IGetGuestRepository
    {
        Task<Guest> GetGuestAsync(Guid id);
    }
}
