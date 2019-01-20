using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace GAM.Domain.Repository
{
    internal abstract class EFCore<T> : IRepository<T> where T: class
    {
        //数据上下文
        private readonly DbContext objContext;

        //构造函数
        public EFCore(DbContext context)
        {
            objContext = context;
        }

        /// <summary>
        /// 表映射对象
        /// </summary>
        private DbSet<T> TSet => objContext.Set<T>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Delete(T entity)
        {
            objContext.Entry<T>(entity).State = EntityState.Deleted;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Update(T entity)
        {
            objContext.Attach(entity);
            objContext.Entry<T>(entity).State = EntityState.Modified;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Insert(T entity)
        {
            objContext.Entry<T>(entity).State = EntityState.Added;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T Find(int id)
        {
            return TSet.Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public virtual T Find(Expression<Func<T, bool>> filter)
        {
            return TSet.FirstOrDefault(filter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="include"></param>
        /// <param name="filter"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public virtual IQueryable<T> Query(
            Func<DbSet<T>, IQueryable<T>> include = null, 
            Expression<Func<T, bool>> filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null)
        {
            include?.Invoke(TSet);
            if (filter!=null)
            {
                TSet.Where(filter);
            }
            orderby?.Invoke(TSet);
            return TSet.AsQueryable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <param name="total"></param>
        /// <param name="filter"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
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
    }
}
