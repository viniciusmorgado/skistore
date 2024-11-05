using System.Linq.Expressions;

namespace SkiStore.Core.Base.Interfaces;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> Criteria { get; }
    
}
