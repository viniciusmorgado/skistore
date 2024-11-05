using System.Linq.Expressions;
using SkiStore.Core.Base.Interfaces;

namespace SkiStore.Core.Base.Specs;

public class BaseSpec<T>(Expression<Func<T, bool>>? criteria) : ISpecification<T>
{
    protected BaseSpec() : this(null) { }
    public Expression<Func<T, bool>>? Criteria => criteria;
    public Expression<Func<T, object>>? OrderBy { get; private set; }
    public Expression<Func<T, object>>? OrderByDescending { get; private set; }
    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }
    protected void AddOrderByDescending(Expression<Func<T, object>> orderByDesc)
    {
        OrderByDescending = orderByDesc;
    }
}

public class BaseSpec<T, TResult>(Expression<Func<T, bool>> criteria) : BaseSpec<T>(criteria), ISpecification<T, TResult>
{
    public Expression<Func<T, TResult>>? Select { get; private set;}
    protected void AddSelect(Expression<Func<T, TResult>> selectExpression)
    {
        Select = selectExpression;
    }
}
