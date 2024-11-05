using SkiStore.Core.Base.Entities;
using SkiStore.Core.Base.Interfaces;

namespace SkiStore.Infrastructure.Data;

public class SpecsEvaluator<T> where T : BaseEntity
{
    public static IQueryable<T> Query(IQueryable<T> query, ISpecification<T> spec)
    {
        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria); // x => x.Brand == brand
        }

        return query;
    }
}
