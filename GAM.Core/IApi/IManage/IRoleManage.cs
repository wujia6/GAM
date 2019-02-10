using System.Collections.Generic;
using System.Linq;
using GAM.Core.Models.RoleRoot;

namespace GAM.Core.IApi.IManage
{
    public interface IRoleManage
    {
        IQueryable<RoleMenu> GetRoleMenus(int roleId);

        bool SetMenusToRole(int roleId, List<RoleMenu> roleMenus);

        //bool RoleMenuRemoveAt(RoleMenu roleMenu);

        void ClearRoleMenus(int roleId);
    }
}
