using System.Collections.Generic;
using System.Linq;

namespace GAM.Core.IApi.IManage
{
    public interface IRoleManage
    {
        IQueryable<T> GetRoleMenus<T>(int roleId);

        bool SetMenusToRole<T>(int roleId, List<T> roleMenus);

        //bool RoleMenuRemoveAt(RoleMenu roleMenu);

        //void ClearRoleMenus(Role role);
    }
}
