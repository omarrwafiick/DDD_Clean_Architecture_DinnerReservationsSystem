

using System.Linq.Expressions;

namespace ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IGetRepository<T>
    {
        Task<T> GetAsync(Guid id);
        Task<T> GetAsync(Guid id, Expression<Func<T, bool>> condition);
    }
}
