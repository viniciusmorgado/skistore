#nullable disable
using Microsoft.EntityFrameworkCore;
using SkiStore.Core.Base.Entities;
using SkiStore.Core.Base.Interfaces;

namespace SkiStore.Infrastructure.Data.Base.Repositories;

public class GenericRepository<T>(StoreContext context) : IGenericRepository<T> where T : BaseEntity
{
    // Specification methods
    public async Task<T> GetByIdAsync(int id)
    {
        return await context.Set<T>().FindAsync(id);
    }
    public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
    {
        return await ApplySpec(spec).FirstOrDefaultAsync();
    }

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    public async Task<TResult?> GetEntityWithSpec<TResult>(ISpecification<T, TResult> spec)
    {
        return await ApplySpec(spec).FirstOrDefaultAsync();
    }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }
    public async Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> spec)
    {
        return await ApplySpec(spec).ToListAsync();
    }
    public async Task<IReadOnlyList<TResult>> GetAllWithSpec<TResult>(ISpecification<T, TResult> spec)
    {
        return await ApplySpec(spec).ToListAsync();
    }


    // REST Methods
    public void Post(T entity)
    {
        context.Set<T>().Add(entity);
    }
    public void Put(T entity)
    {
        context.Set<T>().Update(entity);
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


    // Helpers
    private IQueryable<T> ApplySpec(ISpecification<T> spec)
    {
        return SpecsEvaluator<T>.Query(context.Set<T>().AsQueryable(), spec);
    }
    private IQueryable<TResult> ApplySpec<TResult>(ISpecification<T, TResult> spec)
    {
        return SpecsEvaluator<T>.Query<T, TResult>(context.Set<T>().AsQueryable(), spec);
    }

    public async Task<int> CountAsync(ISpecification<T> specs)
    {
        var query = context.Set<T>().AsQueryable();
        query = specs.ApplyCriteria(query);
        return await query.CountAsync();
    }
}
