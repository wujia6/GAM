using System;
using System.Linq;
using System.Linq.Expressions;
using GAM.Core.IApi;
using GAM.Core.IApi.IManage;
using GAM.Core.Models;
using GAM.Core.Repository;

namespace GAM.Core.Services
{
    abstract class CoreService<T>: ICoreManage<T> where T: BaseEntity, IAggregateRoot
    {
        public CoreService(IEfCoreRepository<T> irepo)
        {
            IRepository = irepo;
        }

        protected IEfCoreRepository<T> IRepository{ get; }

        #region ##实现接口

        public bool AddOrEditAt(T model) => model.ID > 0 ? IRepository.UpdateAt(model) : IRepository.InsertAt(model);

        public bool RemoveAt(T model)
        {
            var entity = FindBy(express : e => e.ID == model.ID);
            if(model == null)
                return false;
            return IRepository.DeleteAt(model);
        }

        public IQueryable<T> QueryBy(Expression<Func<T, bool>> express)
        {
            ISpecification<T> ispec=Specification<T>.Eval(express);
            return IRepository.QueryBySpecification(ispec);
        }

        public T FindBy(Expression<Func<T, bool>> express)
        {
            ISpecification<T> ispec = Specification<T>.Eval(express);
            return IRepository.FindBySpecification(ispec);
        }

        #endregion
    }
}