using System;
using System.Linq.Expressions;
using GAM.Domain.Entities;

namespace GAM.Domain.Specification
{
    /// <summary>
    /// 规约实现类
    /// </summary>
    public abstract class Specification<T> : ISpecification<T> where T : class, IEntity
    {
        public abstract Expression<Func<T, bool>> Express { get; }

        public bool IsSatisfiedBy(T candidate)
        {
            return this.Express.Compile()(candidate);
        }

        public static ISpecification<T> Eval(Expression<Func<T, bool>> expression)
        {
            return new ExpressionSpec<T>(expression);
        }
    }

    public class ExpressionSpec<T> : Specification<T> where T : class, IEntity
    {
        private Expression<Func<T, bool>> expression;

        public ExpressionSpec(Expression<Func<T, bool>> exp)
        {
            this.expression = exp;
        }

        public override Expression<Func<T, bool>> Express => expression;
    }
}
