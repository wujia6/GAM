using System.Collections.Generic;
using System.Linq;
using GAM.Core.Models.RoleRoot;

namespace GAM.Core.IApi.IManage
{
    public interface IRoleManage: ICoreManage<Role>
    {
        IQueryable<RoleMenu> GetRoleMenus(int roleId);

        bool SetMenusToRole(int roleId, List<RoleMenu> roleMenus);

        void ClearRoleMenus(int roleId);
    }
}
