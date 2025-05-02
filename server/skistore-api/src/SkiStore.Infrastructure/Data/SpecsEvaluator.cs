using Microsoft.EntityFrameworkCore;
using SkiStore.Core.Base.Entities;
using SkiStore.Core.Base.Interfaces;

namespace SkiStore.Infrastructure.Data;

public class SpecsEvaluator<T> where T : BaseEntity
{
    public static IQueryable<T> Query(IQueryable<T> query, ISpecification<T> spec)
    {
        if (spec.Criteria != null) query = query.Where(spec.Criteria); // x => x.Brand == brand
        if (spec.OrderBy != null) query = query.OrderBy(spec.OrderBy);
        if (spec.OrderByDescending != null) query = query.OrderByDescending(spec.OrderByDescending);
        if (spec.IsDistinct) query = query.Distinct();
        if (spec.IsPagingEnabled) query = query.Skip(spec.Skip).Take(spec.Take);

        query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
        query = spec.IncludeStrings.Aggregate(query, (current, include) => current.Include(include));

        return query;
    }

    // TODO: This duplication is ugly, improve this later
    public static IQueryable<TResult> Query<TSpec, TResult>(IQueryable<T> query, ISpecification<T, TResult> spec)
    {
        if (spec.Criteria != null) query = query.Where(spec.Criteria); // x => x.Brand == brand
        if (spec.OrderBy != null) query = query.OrderBy(spec.OrderBy);
        if (spec.OrderByDescending != null) query = query.OrderByDescending(spec.OrderByDescending);

        var selectQuery = query as IQueryable<TResult>;

        if (spec.Select != null) selectQuery = query.Select(spec.Select);
        if (spec.IsDistinct) selectQuery = selectQuery?.Distinct();
        if (spec.IsPagingEnabled) selectQuery = selectQuery?.Skip(spec.Skip).Take(spec.Take);

        return selectQuery ?? query.Cast<TResult>();
    }
}
