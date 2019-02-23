using System.Collections.Generic;
using System.Linq;
using GAM.Core.IApi;

namespace GAM.Core.Models.RoleRoot
{
    public class RoleManage: IRoleManage
    {
        private readonly IRepository<Role> iRepos;

        public RoleManage(IRepository<Role> irepos)
        {
            this.iRepos = irepos;
        }

        #region ##聚合根操作
        public bool AddOrEditAt(Role model)
        {
            return model.ID > 0 ? iRepos.UpdateAt(model) : iRepos.InsertAt(model);
        }

        public bool RemoveAt(ISpecification<Role> ispec)
        {
            var entity = iRepos.ModelSet.FirstOrDefault(ispec.Expression);
            return entity == null ? false : iRepos.DeleteAt(entity);
        }

        public Role FindBy(ISpecification<Role> ispec)
        {
            return iRepos.FindBySpecification(ispec);
        }

        public IQueryable<Role> QueryBy(ISpecification<Role> ispec = null)
        {
            return ispec == null ? iRepos.ModelSet : iRepos.QueryBySpecification(ispec);
        }
        #endregion

        #region ##聚合操作
        public void ClearRoleMenus(ISpecification<RoleMenu> ispec)
        {
            var range = iRepos.IContext.Set<RoleMenu>().Where(ispec.Expression);
            if (range.Count() > 0)
                iRepos.IContext.Set<RoleMenu>().RemoveRange(range);
        }

        public bool SetMenusToRole(ISpecification<RoleMenu> ispec, IList<RoleMenu> roleMenus)
        {
            ClearRoleMenus(ispec);
            iRepos.IContext.Set<RoleMenu>().AddRange(roleMenus);
            return true;
        }
        #endregion
    }
}
