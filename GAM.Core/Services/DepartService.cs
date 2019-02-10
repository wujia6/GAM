using System.Linq;
using GAM.Core.IApi;
using GAM.Core.IApi.IManage;
using GAM.Core.Models.DepartRoot;
using GAM.Core.Models.UserRoot;
using GAM.Core.Repository;

namespace GAM.Core.Services
{
    public class DepartService: IDepartManage
    {
        private readonly IEfCoreRepository<Depart> iRepo;

        public DepartService(IEfCoreRepository<Depart> irepo)
        {
            this.iRepo = irepo;
        }

        /// <summary>
        /// 获取部门用户集合
        /// </summary>
        /// <param name="departId">部门ID</param>
        /// <returns>IQueryable</returns>
        public IQueryable<User> GetDepartUsers(int departId)
        {
            ISpecification<User> ispec = Specification<User>.Eval(e => e.Depart.ID == departId);
            return iRepo.IContext.Set<User>().Where(ispec.Expression).AsQueryable();
        }
    }
}
