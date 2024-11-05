using SkiStore.Core.Base.Entities;

namespace SkiStore.Core.Base.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<T?> GetEntityWithSpec(ISpecification<T> spec);

    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> spec);

    void Post(T entity);
    void Put(T entity);
    void Delete(T entity);
    Task<bool> SaveChangesAsync();
    bool Exists(int id);
}
