using System;
using System.Linq.Expressions;
using GAM.Domain.Entities;

namespace GAM.Domain.SpecAgreement
{
    /// <summary>
    /// 规约接口
    /// </summary>
    public interface ISpecification<T> where T : class, IEntity
    {
        bool IsSatisfiedBy(T entity);

        Expression<Func<T, bool>> Expression { get; }
    }

    /// <summary>
    /// 抽象规约实现类（代码复用）
    /// </summary>
    public abstract class Specification<T> : ISpecification<T> where T : class, IEntity
    {
        public abstract Expression<Func<T, bool>> Expression { get; }

        public bool IsSatisfiedBy(T entity)
        {
            return this.Expression.Compile()(entity);
        }

        public static ISpecification<T> Eval(Expression<Func<T, bool>> expression)
        {
            return new ExpressSpec<T>(expression);
        }
    }

    //引入规约表达式
    internal class SpecExpression<T> : Specification<T> where T : class, IEntity
    {
        private readonly Expression<Func<T, bool>> express;

        public SpecExpression(Expression<Func<T, bool>> expression)
        {
            this.express = expression;
        }

        public override Expression<Func<T, bool>> Expression
        {
            get { return this.express; }
        }
    }
}
