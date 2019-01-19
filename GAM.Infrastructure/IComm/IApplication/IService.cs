using System;
using System.Linq;
using System.Linq.Expressions;
using GAM.Infrastructure.IComm.IDomain;
using Microsoft.EntityFrameworkCore;

namespace GAM.Infrastructure.IComm.IApplication
{
    public interface IService<T> where T: class, IAggregareRoot
    {
        //bool Insert(T entity);

        //bool Delete(int id);

        //bool Update(T entity);

        //T Find(int id);

        //T Find(Expression<Func<T, bool>> filter);

        //IQueryable<T> Query(
        //    Func<DbSet<T>, IQueryable<T>> include = null, 
        //    Expression<Func<T, bool>> filter = null, 
        //    Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null);

        //IQueryable<T> Query(
        //    int index, 
        //    int size, 
        //    out int total, 
        //    Expression<Func<T, bool>> filter = null, 
        //    Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null);
    }
}
