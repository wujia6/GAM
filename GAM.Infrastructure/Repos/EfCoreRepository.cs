using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using GAM.Core.IApi;
using GAM.Core.Models;

namespace GAM.Infrastructure.Repos
{
    public class EfCoreRepository<T> : IRepository<T> where T : BaseEntity, IAggregateRoot
    {
        public ISqlLocalContext IContext { get; }

        public EfCoreRepository(ISqlLocalContext iSqlcontext)
        {
            this.IContext = iSqlcontext;
        }

        public IQueryable<T> ModelSet => IContext.Set<T>().AsQueryable();

        public bool InsertAt(T model)
        {
            IContext.Entry(model).State = EntityState.Added;
            return true;
        }

        public bool DeleteAt(T model)
        {
            IContext.Entry(model).State = EntityState.Deleted;
            return true;
        }

        public bool UpdateAt(T model)
        {
            IContext.Entry(model).State = EntityState.Modified;
            return true;
        }

        public T FindBySpecification(ISpecification<T> ispec)
        {
            return ModelSet.FirstOrDefault(ispec.Expression);
        }

        public IQueryable<T> QueryBySpecification(ISpecification<T> ispec)
        {
            return ModelSet.Where(ispec.Expression);
        }
    }
}