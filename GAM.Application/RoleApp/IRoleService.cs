using System.Collections.Generic;
using System.Linq;
using GAM.Core.IApi;
using GAM.Core.Models.RoleRoot;

namespace GAM.Application.RoleApp
{
    public interface IRoleService
    {
        #region ##聚合根
        bool AddOrEditAt(RoleDTO model);

        bool RemoveAt(ISpecification<Role> ispec);

        RoleDTO FindBy(ISpecification<Role> ispec);

        IQueryable<RoleDTO> QueryBy(ISpecification<Role> ispec);
        #endregion

        #region ##角色菜单聚合
        void ClearRoleMenus(ISpecification<RoleMenu> ispec);

        bool SetMenusToRole(ISpecification<RoleMenu> ispec, List<RoleMenuDTO> roleMenus);
        #endregion
    }
}