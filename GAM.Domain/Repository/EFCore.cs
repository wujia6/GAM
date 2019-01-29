using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using GAM.Domain.Entities;
using GAM.Domain.IComm;
using System.Threading.Tasks;

namespace GAM.Domain.Repository
{
    internal class EFCore<T> : IRepository<T> where T: BaseEntity, IAggregareRoot
    {
        //数据上下文
        private readonly EFCoreContext objContext;

        //构造函数
        public EFCore(EFCoreContext context)
        {
            objContext = context;
        }
        
        //表映射
        private DbSet<T> TSet => objContext.Set<T>();

        //获取IQueryable<T>集合对象
        public IQueryable<T> DbEntity => TSet.AsQueryable();

        #region ##同步
        public bool Delete(T entity)
        {
            objContext.Entry<T>(entity).State = EntityState.Deleted;
            return true;
        }
        
        public bool Update(T entity)
        {
            objContext.Attach(entity);
            objContext.Entry(entity).State = EntityState.Modified;
            return true;
        }
        
        public bool Insert(T entity)
        {
            objContext.Entry(entity).State = EntityState.Added;
            return true;
        }
        
        public T Find(int id)
        {
            return TSet.Find(id);
        }
        
        public T Find(Expression<Func<T, bool>> filter, Expression<Func<T, object>> include = null)
        {
            if (include != null)
                TSet.Include(include);
            return TSet.FirstOrDefault(filter);
        }
        
        public IQueryable<T> Query(
            Expression<Func<T, object>> include = null, 
            Expression<Func<T, bool>> filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null)
        {
            if (include != null)
                TSet.Include(include);

            if (filter!=null)
                TSet.Where(filter);
            
            orderby?.Invoke(TSet);
            return TSet.AsQueryable();
        }
        
        public IQueryable<T> Query(
            int index, 
            int size, 
            out int total, 
            Expression<Func<T, bool>> filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null)
        {
            if (filter != null)
                TSet.Where(filter);
            orderby?.Invoke(TSet);
            total = TSet.Count();
            return TSet.Skip((index - 1) * size).Take(size).AsQueryable();
        }
        #endregion

        #region ##异步
        public Task<bool> InsertAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindAsync(Expression<Func<T, bool>> filter, Expression<Func<T, object>> include = null)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> QueryAsync(Expression<Func<T, object>> include = null, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> QueryAsync(int index, int size, out int total, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
