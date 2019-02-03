using System;
using System.Linq;
using System.Linq.Expressions;
using GAM.Domain.Entities.Aggregates;

namespace GAM.Domain.Repository
{
    public interface IRepository<T> where T: class, IAggregateRoot
    {
        //IQueryable<T> DbEntity { get; }

        #region ##同步
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

        #region ##异步
        //Task<bool> InsertAsync(T entity);

        //Task<bool> DeleteAsync(T entity);

        //Task<bool> UpdateAsync(T entity);

        //Task<T> FindAsync(int id);

        //Task<T> FindAsync(Expression<Func<T, bool>> filter, Expression<Func<T, object>> include = null);

        //Task<IQueryable<T>> QueryAsync(
        //    Expression<Func<T, object>> include = null,
        //    Expression<Func<T, bool>> filter = null,
        //    Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null);

        //Task<IQueryable<T>> QueryAsync(int index,
        //    int size,
        //    out int total,
        //    Expression<Func<T, bool>> filter = null,
        //    Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null);
        #endregion
    }
}
