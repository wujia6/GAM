using System.Collections.Generic;
using System.Linq;
using GAM.Domain.Entities.Aggregates.RoleAgg;
using GAM.Domain.Repository;

namespace GAM.Domain.Service
{
    public interface IRoleService: IRepository<Role>
    {
        IQueryable<RoleMenu> GetRoleMenus(int roleId);

        bool SetMenusToRole(int roleId, List<RoleMenu> roleMenus);

        bool RoleMenuRemoveAt(RoleMenu roleMenu);

        void ClearRoleMenus(Role role);
    }
}
