using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using GAM.Domain.Entities;

namespace GAM.Domain.Repository
{
    public abstract class EFCoreRepository<T> : IRepository<T> where T: class, IEntity
    {
        #region ##EFCoreRepository成员
        //构造函数
        public EFCoreRepository(GamDbContext context)
        {
            ObjContext = context;
        }
        //数据上下文
        private GamDbContext ObjContext { get; }
        //表映射
        private DbSet<T> TSet => ObjContext.Set<T>();
        #endregion

        #region ##IRepository接口实现
        public virtual bool Delete(T entity)
        {
            ObjContext.Entry<T>(entity).State = EntityState.Deleted;
            return true;
        }
        
        public virtual bool Update(T entity)
        {
            ObjContext.Attach(entity);
            ObjContext.Entry(entity).State = EntityState.Modified;
            return true;
        }
        
        public virtual bool Insert(T entity)
        {
            ObjContext.Entry(entity).State = EntityState.Added;
            return true;
        }
        
        public virtual T Find(int id)
        {
            return TSet.Find(id);
        }
        
        public virtual T Find(Expression<Func<T, bool>> filter, Expression<Func<T, object>> include = null)
        {
            if (include != null)
                TSet.Include(include);
            return TSet.FirstOrDefault(filter);
        }
        
        public virtual IQueryable<T> Query(
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
        
        public virtual IQueryable<T> Query(
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
    }
}
