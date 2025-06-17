
using System.Linq.Expressions;

namespace ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IGetValueObjectRepository<T>
    {
        Task<T> GetAsync(Expression<Func<T, bool>> condition);
    }
}
