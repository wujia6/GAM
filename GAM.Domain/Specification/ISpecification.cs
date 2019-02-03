using System;
using System.Linq.Expressions;
using GAM.Domain.Entities;

namespace GAM.Domain.Specification
{
    /// <summary>
    /// 规约接口
    /// </summary>
    public interface ISpecification<T> where T: class, IEntity
    {
        bool IsSatisfiedBy(T candidate);

        Expression<Func<T, bool>> Express { get; }

        //ISpecification<T> And(ISpecification<T> spec);

        //ISpecification<T> Or(ISpecification<T> spec);

        //ISpecification<T> Not(ISpecification<T> spec);
    }
}
