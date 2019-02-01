using System;
using System.Linq.Expressions;

namespace GAM.Domain.Entities.Specification
{
    /// <summary>
    /// 规约接口
    /// </summary>
    public interface ISpecification<T> where T: class, Aggregates.IAggregateRoot
    {
        bool IsSatisfiedBy(T candidate);

        Expression<Func<object, bool>> Expression { get; }

        //ISpecification<T> And(ISpecification<T> spec);

        //ISpecification<T> Or(ISpecification<T> spec);

        //ISpecification<T> Not(ISpecification<T> spec);
    }
}
