using System;
using System.Linq;
using System.Linq.Expressions;
using GAM.Core.IApi;
using GAM.Core.IApi.IManage;
using GAM.Core.Models.DepartRoot;
using GAM.Core.Models.UserRoot;
using GAM.Core.Repository;

namespace GAM.Core.Services
{
    internal class DepartService: CoreService<Depart>, IDepartManage
    {
        public DepartService(IEfCoreRepository<Depart> irepo): base(irepo) { }

        public IQueryable<User> GetDepartUsers(int departId)
        {
            ISpecification<User> ispec = Specification<User>.Eval(e => e.Depart.ID == departId);
            return IRepository.IContext.Set<User>().Where(ispec.Expression).AsQueryable();
        }

        // public override bool AddOrEditAt(Depart model) => model.ID > 0 ? IRepository.UpdateAt(model) : IRepository.InsertAt(model);

        // public override bool RemoveAt(Depart model)
        // {
        //     var entity = FindBy(express : e => e.ID == model.ID);
        //     if(model == null)
        //         return false;
        //     return IRepository.DeleteAt(model);
        // }

        // public override Depart FindBy(Expression<Func<Depart, bool>> express)
        // {
        //     ISpecification<Depart> ispec = Specification<Depart>.Eval(express);
        //     return IRepository.FindBySpecification(ispec);
        // }

        // public override IQueryable<Depart> QueryBy(Expression<Func<Depart, bool>> express)
        // {
        //     ISpecification<Depart> ispec=Specification<Depart>.Eval(express);
        //     return IRepository.QueryBySpecification(ispec);
        // }
    }
}
