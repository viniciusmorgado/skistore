#nullable disable
using Microsoft.EntityFrameworkCore;
using SkiStore.Core.Base.Entities;
using SkiStore.Core.Base.Interfaces;

namespace SkiStore.Infrastructure.Data.Base.Repositories;

public class GenericRepository<T>(StoreContext context) : IGenericRepository<T> where T : BaseEntity
{
    public async Task<T> GetByIdAsync(int id)
    {
        return await context.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

    public void Post(T entity)
    {
        context.Set<T>().Add(entity);
    }

    public void Put(T entity)
    {
        context.Set<T>().Attach(entity);
    }

    public void Delete(T entity)
    {
        context.Set<T>().Remove(entity);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
    
    public bool Exists(int id)
    {
        return context.Set<T>().Any(x => x.Id == id);
    }
}
