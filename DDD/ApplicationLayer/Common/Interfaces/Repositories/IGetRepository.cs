

using System.Linq.Expressions;

namespace ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IGetRepository<T,TID> 
    {
        Task<T> GetAsync(TID id);
        Task<T> GetAsync(TID id, Expression<Func<T, bool>> condition); 
    }
}
