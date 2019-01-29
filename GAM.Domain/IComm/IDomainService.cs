using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GAM.Domain.Entities;

namespace GAM.Domain.IComm
{
    public interface IDomainService<T> where T: BaseEntity, IAggregareRoot
    {
        #region ##同步
        bool Add(T entity);

        bool Remove(T entity);

        bool Edit(T entity);

        T Single(int id);

        T Single(Expression<Func<T, bool>> filter, Expression<Func<T, object>> include = null);

        IQueryable<T> Inquire(
            Expression<Func<T, object>> include = null,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null);

        IQueryable<T> Search(
            int index,
            int size,
            out int total,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null);
        #endregion

        #region ##异步
        Task<bool> AddAsync(T entity);

        Task<bool> RemoveAsync(T entity);

        Task<bool> EditAsync(T entity);

        Task<T> SingleAsync(int id);

        Task<T> SingleAsync(Expression<Func<T, bool>> filter, Expression<Func<T, object>> include = null);

        Task<IQueryable<T>> InquireAsync(
            Expression<Func<T, object>> include = null,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null);

        Task<IQueryable<T>> SearchAsync(int index,
            int size,
            out int total,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null);
        #endregion
    }
}
