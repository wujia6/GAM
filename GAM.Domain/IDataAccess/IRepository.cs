using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GAM.Domain.IDataAccess
{
    public interface IRepository<T> where T: class, IAggregareRoot
    {
        bool Insert(T entity);

        bool Delete(int id);

        bool Update(T entity);

        T Find(int id);

        T Find(Expression<Func<T, bool>> filter);

        IQueryable<T> Query(Func<ISet<T>, IQueryable<T>> include = null, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null);

        IQueryable<T> Query(int index, int size, out int total, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null);
    }
}
