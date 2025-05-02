using SkiStore.Core.Base.Entities;
using SkiStore.Core.Base.Interfaces;

namespace SkiStore.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
    Task<bool> Complete();
}
