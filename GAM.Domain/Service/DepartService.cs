using GAM.Domain.Entities;
using GAM.Domain.Entities.Aggregates.DepartAgg;
using GAM.Domain.Repository;
using GAM.Domain.SpecAgreement;
using GAM.Application.IManage;

namespace GAM.Domain.Service
{
    public class DepartService: IDepartManage
    {
        private readonly IRepository<Depart> iRepos;

        public DepartService(GamDbContext cxt, IRepository<Depart> repos)
        {
            this.iRepos = repos;
        }

        #region ##实现接口
        public Depart FindByID(int departId)
        {
            ISpecification<Depart> spec = Specification<Depart>.Eval(d => d.ID == departId);
            return iRepos.Find(spec);
        }
        #endregion
    }
}
