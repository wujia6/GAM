using System;
using System.Linq;
using System.Linq.Expressions;
using GAM.Domain.Entities;
using GAM.Domain.Entities.Aggregates;
using GAM.Domain.SpecAgreement;
using Microsoft.EntityFrameworkCore;

namespace GAM.Domain.Repository
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        //数据上下文
        protected readonly GamDbContext DataContext;
        //构造函数
        public AbstractRepository(GamDbContext context)
        {
            DataContext = context;
        }
        //表映射
        public DbSet<T> Maps => DataContext.Set<T>();

        #region ##实现接口
        public virtual bool Delete(T entity)
        {
            DataContext.Entry<T>(entity).State = EntityState.Deleted;
            return true;
        }

        public virtual bool Update(T entity)
        {
            DataContext.Attach(entity);
            DataContext.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public virtual bool Insert(T entity)
        {
            DataContext.Entry(entity).State = EntityState.Added;
            return true;
        }

        public virtual T Find(int id)
        {
            return Maps.Find(id);
        }

        public virtual T Find(ISpecification<T> spec)
        {
            return Maps.FirstOrDefault(spec.Expression);
        }

        public virtual T Find(Expression<Func<T, bool>> filter, Expression<Func<T, object>> include = null)
        {
            if (include != null)
                Maps.Include(include);
            return Maps.FirstOrDefault(filter);
        }

        public virtual IQueryable<T> Query(ISpecification<T> spec)
        {
            return Maps.Where(spec.Expression);
        }

        public virtual IQueryable<T> Query(Expression<Func<T, object>> include = null, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null)
        {
            if (include != null)
                Maps.Include(include);

            if (filter != null)
                Maps.Where(filter);

            orderby?.Invoke(Maps);
            return Maps.AsQueryable();
        }

        public virtual IQueryable<T> Query(int index, int size, out int total, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null)
        {
            if (filter != null)
                Maps.Where(filter);
            orderby?.Invoke(Maps);
            total = Maps.Count();
            return Maps.Skip((index - 1) * size).Take(size).AsQueryable();
        }
        #endregion
    }
}
