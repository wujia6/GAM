﻿using System;
using System.Linq.Expressions;
using GAM.Domain.Entities;

namespace GAM.Domain.ComponentSpec
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
            return new ExpressionSpec<T>(expression);
        }
    }
}
