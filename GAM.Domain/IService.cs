using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace GAM.Domain
{
    public interface IService<T> where T: class, IAggregareRoot
    {
        bool AddTo(T entity);

        bool RemoveAt(int id);

        bool EditTo(T entity);

        T Single(int id);

        T Single(Expression<Func<T, bool>> filter);

        IQueryable<T> Search(
            Func<DbSet<T>, IQueryable<T>> include = null,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null);

        IQueryable<T> Paging(
            int index,
            int size,
            out int total,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null);
    }
}
