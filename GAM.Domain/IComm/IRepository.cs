using System;
using System.Linq;
using System.Linq.Expressions;

namespace GAM.Domain.IComm
{
    public interface IRepository<T> where T: class, IAggregareRoot
    {
        IQueryable<T> DbEntity { get; }

        #region ##同步
        bool Insert(T entity);

        bool Delete(T entity);

        bool Update(T entity);

        T Find(int id);

        T Find(Expression<Func<T, bool>> filter);

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
        //Task InsertAsync(T entity);

        //Task DeleteAsync(T entity);

        //Task UpdateAsync(T entity);

        //Task<T> FindAsync(int id);

        //Task<T> FindAsync(Expression<Func<T, bool>> filter);

        //Task<IQueryable<T>> QueryAsync(
        //    Func<DbSet<T>, IQueryable<T>> include = null,
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
