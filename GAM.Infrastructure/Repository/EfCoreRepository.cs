using System.Linq;
using GAM.Core.Models;
using GAM.Core.IApi;
using Microsoft.EntityFrameworkCore;

namespace GAM.Infrastructure.Repository
{
    public class EfCoreRepository<T>: IEfCoreRepository<T> where T: BaseEntity, IAggregateRoot
    {
        //数据上下文接口
        protected readonly IModelContext iContext;

        //构造函数
        public EfCoreRepository(IModelContext icxt)
        {
            iContext = icxt;
        }

        //表映射
        public IQueryable<T> Model => iContext.Set<T>().AsQueryable();

        #region ##实现接口
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