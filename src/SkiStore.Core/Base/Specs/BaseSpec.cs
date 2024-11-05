using System.Linq.Expressions;
using SkiStore.Core.Base.Interfaces;

namespace SkiStore.Core.Base.Specs;

public class BaseSpec<T>(Expression<Func<T, bool>>? criteria) : ISpecification<T>
{
    protected BaseSpec() : this(null) { }
    public Expression<Func<T, bool>>? Criteria => criteria;
}
