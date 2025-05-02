#nullable disable
using System.Collections.Concurrent;
using SkiStore.Core.Base.Entities;
using SkiStore.Core.Base.Interfaces;
using SkiStore.Core.Interfaces;
using SkiStore.Infrastructure.Data.Base.Repositories;

namespace SkiStore.Infrastructure.Data;

public class UnitOfWork(StoreContext context) : IUnitOfWork
{
    // TODO: Almost sure that is not necessary
    public void Dispose()
    {
        context.Dispose();
    }
    
    private readonly ConcurrentDictionary<string, object> _repositories = new();

    public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
    {
        var type =  typeof(TEntity).Name;

        return (IGenericRepository<TEntity>)_repositories.GetOrAdd(type, t =>
        {
            var repositoryType = typeof(GenericRepository<>).MakeGenericType(typeof(TEntity));
            return Activator.CreateInstance(repositoryType, context) ?? 
                   throw new InvalidOperationException("Could not create repository");
        });
    }

    public async Task<bool> Complete()
    {
        return await context.SaveChangesAsync() > 0;
    }
}
