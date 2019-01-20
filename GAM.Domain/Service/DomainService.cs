using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace GAM.Domain.Service
{
    public class DomainService<T>: IService<T> where T:class
    {
        //构造函数注入接口对象
        public DomainService(IRepository<T> irepos)
        {
            this.IEFCoreRepos = irepos;
        }

        /// <summary>
        /// 仓储接口对象
        /// </summary>
        private IRepository<T> IEFCoreRepos { get; }

        #region ##接口实现
        public bool AddTo(T entity)
        {
            return entity == null ? false : IEFCoreRepos.Insert(entity);
        }

        public bool EditTo(T entity)
        {
            return entity == null ? false : IEFCoreRepos.Update(entity);
        }

        public bool RemoveAt(int id)
        {
            var entity = Single(id);
            return entity == null ? false : IEFCoreRepos.Delete(entity);
        }

        public IQueryable<T> Paging(int index, int size, out int total, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null)
        {
            return IEFCoreRepos.Query(index, size, out total, filter, orderby);
        }

        public IQueryable<T> Search(Func<DbSet<T>, IQueryable<T>> include = null, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null)
        {
            return IEFCoreRepos.Query(include, filter, orderby);
        }

        public T Single(int id)
        {
            return id > 0 ? IEFCoreRepos.Find(id) : null;
        }

        public T Single(Expression<Func<T, bool>> filter)
        {
            return filter == null ? null : IEFCoreRepos.Find(filter);
        }
        #endregion
    }
}
