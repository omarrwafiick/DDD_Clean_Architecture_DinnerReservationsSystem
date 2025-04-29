

using DomainLayer.MenuAggregate;

namespace ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IMenuRepository
    {
        Task AddAsync(Menu menu);
    }
}
