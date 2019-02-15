using System.Linq;
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
    }
}
