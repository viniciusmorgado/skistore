using SkiStore.Core.Base.Entities;

namespace SkiStore.Core.Base.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> GetAllAsync();
    void Post(T entity);
    void Put(T entity);
    void Delete(T entity);
    Task<bool> SaveChangesAsync();
    Task<bool> Exists();
}
