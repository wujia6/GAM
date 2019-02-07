using System;
using System.Linq.Expressions;
using GAM.Domain.Entities;

namespace GAM.Domain.SpecAgreement
{
    /// <summary>
    /// 表达式树类
    /// </summary>
    public class ExpressSpec<T> : Specification<T> where T : class, IEntity
    {
        private readonly Expression<Func<T, bool>> expression;

        public ExpressSpec(Expression<Func<T, bool>> express)
        {
            this.expression = express;
        }

        public override Expression<Func<T, bool>> Expression => expression;
    }

    /// <summary>
    /// 无条件表达式
    /// </summary>
    public class AnySpecification<T> : Specification<T> where T : class, IEntity
    {
        public override Expression<Func<T, bool>> Expression
        {
            get { return o => true; }
        }
    }

    /// <summary>
    /// 规约表达式树扩展类
    /// </summary>
    public static class ExpressionSpecExtend
    {
        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> one)
        {
            var candidateExpr = one.Parameters[0];
            var body = Expression.Not(one.Body);

            return Expression.Lambda<Func<T, bool>>(body, candidateExpr);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> one, Expression<Func<T, bool>> another)
        {
            // 首先定义好一个ParameterExpression
            var candidateExpr = Expression.Parameter(typeof(T), "candidate");
            var parameterReplacer = new ParameterReplacer(candidateExpr);

            // 将表达式树的参数统一替换成我们定义好的candidateExpr
            var left = parameterReplacer.Replace(one.Body);
            var right = parameterReplacer.Replace(another.Body);

            var body = Expression.And(left, right);

            return Expression.Lambda<Func<T, bool>>(body, candidateExpr);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> one, Expression<Func<T, bool>> another)
        {
            var candidateExpr = Expression.Parameter(typeof(T), "candidate");
            var parameterReplacer = new ParameterReplacer(candidateExpr);

            var left = parameterReplacer.Replace(one.Body);
            var right = parameterReplacer.Replace(another.Body);
            var body = Expression.Or(left, right);

            return Expression.Lambda<Func<T, bool>>(body, candidateExpr);
        }
    }

    /// <summary>
    /// 表达式树参数类
    /// </summary>
    public class ParameterReplacer : ExpressionVisitor
    {
        public ParameterReplacer(ParameterExpression paramExpr)
        {
            this.ParameterExpression = paramExpr;
        }

        public ParameterExpression ParameterExpression { get; private set; }

        public Expression Replace(Expression expr)
        {
            return this.Visit(expr);
        }

        protected override Expression VisitParameter(ParameterExpression p)
        {
            return this.ParameterExpression;
        }
    }
}
