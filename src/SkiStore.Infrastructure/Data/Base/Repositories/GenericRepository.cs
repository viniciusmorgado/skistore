using SkiStore.Core.Base.Entities;
using SkiStore.Core.Base.Interfaces;

namespace SkiStore.Infrastructure.Data.Base.Repositories;

public class GenericRepository<T>(StoreContext context) : IGenericRepository<T> where T : BaseEntity
{
    public Task<T> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public void Post(T entity)
    {
        throw new NotImplementedException();
    }

    public void Put(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Exists()
    {
        throw new NotImplementedException();
    }
}
