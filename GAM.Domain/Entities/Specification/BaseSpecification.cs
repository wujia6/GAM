using System;
using System.Linq.Expressions;
using GAM.Domain.Entities.Aggregates;

namespace GAM.Domain.Entities.Specification
{
    /// <summary>
    /// 规约实现类
    /// </summary>
    public abstract class BaseSpecification<T> : ISpecification<T> where T : class, IAggregateRoot
    {
        public abstract Expression<Func<object, bool>> Expression { get; }

        public bool IsSatisfiedBy(T candidate)
        {
            return this.Expression.Compile()(candidate);
        }
    }

    public class ExpressionSpec<T> : BaseSpecification<T> where T : class, IAggregateRoot
    {
        private readonly Expression<Func<object, bool>> expression;

        public ExpressionSpec(Expression<Func<object, bool>> exp)
        {
            this.expression = exp;
        }

        public override Expression<Func<object, bool>> Expression => expression;
    }
}
