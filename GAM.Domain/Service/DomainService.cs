using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GAM.Domain.Entities.Aggregates;
using GAM.Domain.Repository;

namespace GAM.Domain.Service
{
    internal class DomainService<T>: IDomainService<T> where T: class, IAggregateRoot
    {
        private readonly IRepository<T> iRepos;

        public DomainService(IRepository<T> irepos)
        {
            this.iRepos = irepos;
        }

        #region ##实现接口
        public bool Add(T entity)
        {
            if (entity == null)
                return false;
            return iRepos.Insert(entity);
        }

        public bool Remove(T entity)
        {
            return entity == null ? false : iRepos.Delete(entity);
        }

        public bool Edit(T entity)
        {
            return entity == null ? false : iRepos.Update(entity);
        }

        public T Single(int id)
        {
            return iRepos.Find(id);
        }

        public T Single(Expression<Func<T, bool>> filter, Expression<Func<T, object>> include = null)
        {
            return iRepos.Find(filter, include);
        }

        public IQueryable<T> Inquire(Expression<Func<T, object>> include = null, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null)
        {
            return iRepos.Query(include, filter, orderby);
        }

        public IQueryable<T> Search(int index, int size, out int total, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null)
        {
            return iRepos.Query(index, size, out total, filter, orderby);
        }
        #endregion

        #region ##实现接口
        public Task<bool> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> InquireAsync(Expression<Func<T, object>> include = null, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> SearchAsync(int index, int size, out int total, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> SingleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> SingleAsync(Expression<Func<T, bool>> filter, Expression<Func<T, object>> include = null)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
