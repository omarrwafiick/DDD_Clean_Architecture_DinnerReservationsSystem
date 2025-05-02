 
namespace ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IUpdateRepository<T>
    {
        Task UpdateAsync(T data);
    }
}
