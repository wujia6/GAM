using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GAM.Domain.IDataAccess;

namespace GAM.Infrastructure.EntityFarmeworkCore
{
    public class EFCoreRepository<T> : IRepository<T> where T: class, IAggregareRoot
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T Find(int id)
        {
            throw new NotImplementedException();
        }

        public T Find(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public bool Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query(Func<ISet<T>, IQueryable<T>> include = null, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query(int index, int size, out int total, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null)
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
