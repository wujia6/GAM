using System;
using System.Linq.Expressions;
using GAM.Domain.Entities;

namespace GAM.Domain.SpecAgreement
{
    /// <summary>
    /// 表达式树类
    /// </summary>
    public class ExpressionSpec<T> : Specification<T> where T : class, IEntity
    {
        private readonly Expression<Func<T, bool>> expression;

        public ExpressionSpec(Expression<Func<T, bool>> express)
        {
            this.expression = express;
        }

        public override Expression<Func<T, bool>> Expression => expression;
    }
}
