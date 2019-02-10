using System.Linq;
using GAM.Core.Models;
using GAM.Core.IApi;
using Microsoft.EntityFrameworkCore;

namespace GAM.Infrastructure.Repository
{
    public class EfCoreRepository<T>: IEfCoreRepository<T> where T: BaseEntity, IAggregateRoot
    {
        //���������Ľӿ�
        protected readonly IModelContext iContext;

        //���캯��
        public EfCoreRepository(IModelContext icxt)
        {
            iContext = icxt;
        }

        //��ӳ��
        public IQueryable<T> Model => iContext.Set<T>().AsQueryable();

        #region ##ʵ�ֽӿ�
        public bool Add(T model)
        {
            iContext.Entry(model).State = EntityState.Added;
            return true;
        }

        public bool Remove(T model)
        {
            iContext.Entry(model).State = EntityState.Deleted;
            return true;
        }

        public bool Edit(T model)
        {
            iContext.Entry(model).State = EntityState.Modified;
            return true;
        }

        public T FindBySpecification(ISpecification<T> ispec)
        {
            return Model.FirstOrDefault(ispec.Expression);
        }

        public IQueryable<T> QueryBySpecification(ISpecification<T> ispec)
        {
            return Model.Where(ispec.Expression);
        }
        #endregion
    }
}