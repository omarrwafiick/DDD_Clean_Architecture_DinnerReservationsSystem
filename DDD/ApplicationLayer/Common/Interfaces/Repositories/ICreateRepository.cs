 

namespace ApplicationLayer.Common.Interfaces.Repositories
{
    public interface ICreateRepository<T>
    {
        Task AddAsync(T data);
    }
}
