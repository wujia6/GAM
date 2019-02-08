using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using GAM.Domain.Entities;
using GAM.Domain.SpecAgreement;
using GAM.Domain.Entities.Aggregates;

namespace GAM.Domain.Repository
{
    public class EFCoreRepository<T> : IRepository<T> where T: class, IAggregateRoot
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
        public bool Delete(T entity)
        {
            ObjContext.Entry<T>(entity).State = EntityState.Deleted;
            return true;
        }
        
        public bool Update(T entity)
        {
            ObjContext.Attach(entity);
            ObjContext.Entry(entity).State = EntityState.Modified;
            return true;
        }
        
        public bool Insert(T entity)
        {
            ObjContext.Entry(entity).State = EntityState.Added;
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

        public T Find(ISpecification<T> spec)
        {
            return TSet.FirstOrDefault(spec.Expression);
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

        public IQueryable<T> Query(ISpecification<T> spec)
        {
            return TSet.Where(spec.Expression);
        }
        #endregion
    }
}
