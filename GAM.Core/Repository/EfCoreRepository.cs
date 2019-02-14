using System.Linq;
using GAM.Core.Models;
using GAM.Core.IApi;
using Microsoft.EntityFrameworkCore;

namespace GAM.Core.Repository
{
    public class EfCoreRepository<T>: IEfCoreRepository<T> where T: BaseEntity, IAggregateRoot
    {
        //���캯��
        public EfCoreRepository(ISqlLocalContext icxt)
        {
            IContext = icxt;
        }

        #region ##ʵ�ֽӿ�
        public ISqlLocalContext IContext { get; }

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
        #endregion
    }
}