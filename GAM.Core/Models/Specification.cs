using System;
using System.Linq.Expressions;
using GAM.Core.IApi;

namespace GAM.Core.Models
{
    public abstract class Specification<T>: ISpecification<T> where T : class
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
    internal class SpecExpression<T> : Specification<T> where T : class
    {
        private readonly Expression<Func<T, bool>> express;

        public SpecExpression(Expression<Func<T, bool>> expression)
        {
            this.express = expression;
        }

        public override Expression<Func<T, bool>> Expression => express;
    }
}