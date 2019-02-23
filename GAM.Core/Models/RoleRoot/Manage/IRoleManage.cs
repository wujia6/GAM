using System.Collections.Generic;
using System.Linq;
using GAM.Core.IApi;

namespace GAM.Core.Models.RoleRoot
{
    public interface IRoleManage
    {
        bool AddOrEditAt(Role model);
        bool RemoveAt(ISpecification<Role> ispec);
        Role FindBy(ISpecification<Role> ispec);
        IQueryable<Role> QueryBy(ISpecification<Role> ispec = null);
        
        //IQueryable<RoleMenu> GetRoleMenus(ISpecification<RoleMenu> ispec);
        bool SetMenusToRole(ISpecification<RoleMenu> ispec, IList<RoleMenu> roleMenus);
        void ClearRoleMenus(ISpecification<RoleMenu> ispec);
    }
}
