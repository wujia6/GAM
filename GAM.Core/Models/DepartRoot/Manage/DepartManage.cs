using System.Linq;
using GAM.Core.IApi;
using GAM.Core.Models.UserRoot;

namespace GAM.Core.Models.DepartRoot
{
    internal class DepartManage: IDepartManage
    {
        private readonly IRepository<Depart> iRepos;

        public DepartManage(IRepository<Depart> irepo)
        {
            this.iRepos = irepo;
        }

        public bool AddOrEditAt(Depart model)
        {
            if (model == null)
                return false;
            return model.ID == null? iRepos.UpdateAt(model) : iRepos.InsertAt(model);
        }

        public bool RemoveAt(ISpecification<Depart> ispec)
        {
            var model = FindBy(ispec);
            return model != null ? iRepos.DeleteAt(model) : false;
        }

        public Depart FindBy(ISpecification<Depart> ispec)
        {
            return iRepos.FindBySpecification(ispec);
        }

        public IQueryable<Depart> QueryBy(ISpecification<Depart> ispec)
        {
            return iRepos.QueryBySpecification(ispec);
        }

        public IQueryable<User> GetDepartUsers(ISpecification<User> ispec)
        {
            return iRepos.IContext.Set<User>().Where(ispec.Expression).AsQueryable();
        }
    }
}
