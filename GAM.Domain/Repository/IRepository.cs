using System;
using System.Linq;
using System.Linq.Expressions;
using GAM.Domain.Entities.Aggregates;
using GAM.Domain.SpecAgreement;

namespace GAM.Domain.Repository
{
    public interface IRepository<T> where T : class, IAggregateRoot
    {
        #region ##成员方法
        //IQueryable<T> DbEntity { get; }

        bool Insert(T entity);

        bool Delete(T entity);

        bool Update(T entity);

        T Find(int id);

        T Find(Expression<Func<T, bool>> filter, Expression<Func<T, object>> include = null);

        T Find(ISpecification<T> spec);

        IQueryable<T> Query(
            Expression<Func<T, object>> include = null,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null);

        IQueryable<T> Query(
            int index,
            int size,
            out int total,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null);

        IQueryable<T> Query(ISpecification<T> spec);
        #endregion
    }
}
