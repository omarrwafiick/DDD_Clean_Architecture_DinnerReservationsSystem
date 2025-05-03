
using DomainLayer.DinnerAggregate;

namespace ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IGetDinnerRepository
    {
        Task<Dinner> GetDinnerAsync(Guid id);
    }
}
