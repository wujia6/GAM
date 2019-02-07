using System;
using System.Linq;
using System.Linq.Expressions;
using GAM.Domain.Entities;
using GAM.Domain.SpecAgreement;
using Microsoft.EntityFrameworkCore;

namespace GAM.Domain.Repository
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : class, IEntity
    {
        public AbstractRepository(GamDbContext context)
        {
            ObjContext = context;
        }
        //数据上下文
        private GamDbContext ObjContext { get; }
        //表映射
        private DbSet<T> TSet => ObjContext.Set<T>();

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

        public T Find(ISpecification<T> spec)
        {
            return TSet.FirstOrDefault(spec.Expression);
        }

        public T Find(Expression<Func<T, bool>> filter, Expression<Func<T, object>> include = null)
        {
            if (include != null)
                TSet.Include(include);
            return TSet.FirstOrDefault(filter);
        }

        public IQueryable<T> Query(ISpecification<T> spec)
        {
            return TSet.Where(spec.Expression);
        }

        public IQueryable<T> Query(Expression<Func<T, object>> include = null, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null)
        {
            if (include != null)
                TSet.Include(include);

            if (filter != null)
                TSet.Where(filter);

            orderby?.Invoke(TSet);
            return TSet.AsQueryable();
        }

        public IQueryable<T> Query(int index, int size, out int total, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null)
        {
            if (filter != null)
                TSet.Where(filter);
            orderby?.Invoke(TSet);
            total = TSet.Count();
            return TSet.Skip((index - 1) * size).Take(size).AsQueryable();
        }

        
    }
}
