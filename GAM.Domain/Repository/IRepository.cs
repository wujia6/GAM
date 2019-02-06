using System;
using System.Linq;
using System.Linq.Expressions;
using GAM.Domain.Entities;

namespace GAM.Domain.Repository
{
    public interface IRepository<T> where T : class, IEntity
    {
        #region ##同步
        //IQueryable<T> DbEntity { get; }

        bool Insert(T entity);

        bool Delete(T entity);

        bool Update(T entity);

        T Find(int id);

        T Find(Expression<Func<T, bool>> filter, Expression<Func<T, object>> include = null);

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
        #endregion
    }
}
