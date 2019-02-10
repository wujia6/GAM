using System;
using System.Linq.Expressions;
using GAM.Core.IApi;
using GAM.Core.Models;

namespace GAM.Infrastructure.Repository
{
    public abstract class Specification<T>: ISpecification<T> where T : BaseEntity
    {
        public abstract Expression<Func<T, bool>> Expression { get; }

        public bool IsSatisfiedBy(T entity)
        {
            return this.Expression.Compile()(entity);
        }

        public static ISpecification<T> Eval(Expression<Func<T, bool>> expression)
        {
            return new SpecExpression<T>(expression);
        }
    }

    //引入规约表达式
    internal class SpecExpression<T> : Specification<T> where T : BaseEntity
    {
        private readonly Expression<Func<T, bool>> express;

        public SpecExpression(Expression<Func<T, bool>> expression)
        {
            this.express = expression;
        }

        public override Expression<Func<T, bool>> Expression => express;
    }
}
