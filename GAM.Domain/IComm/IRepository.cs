using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace GAM.Domain.IComm
{
    public interface IRepository<T> where T: class, IAggregareRoot
    {
        bool Insert(T entity);

        bool Delete(T entity);

        bool Update(T entity);

        T Find(int id);

        IQueryable<T> DbEntity { get; }

        T Find(Expression<Func<T, bool>> filter);

        IQueryable<T> Query(
            Func<DbSet<T>, IQueryable<T>> include = null, 
            Expression<Func<T, bool>> filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null);

        IQueryable<T> Query(
            int index, 
            int size, 
            out int total, 
            Expression<Func<T, bool>> filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null);
    }
}
