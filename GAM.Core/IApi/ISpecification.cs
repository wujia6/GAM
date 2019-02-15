using System;
using System.Linq.Expressions;
using GAM.Core.Models;

namespace GAM.Core.IApi
{
    public interface ISpecification<T> where T: class
    {
        bool IsSatisfiedBy(T entity);

        Expression<Func<T, bool>> Expression { get; }
    }
}
