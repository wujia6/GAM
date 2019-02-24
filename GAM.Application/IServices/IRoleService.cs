using System.Collections.Generic;
using System.Linq;
using GAM.Core.IApi;
using GAM.Core.Models.RoleRoot;
using GAM.Infrastructure.Dtos;

namespace GAM.Application.IServices
{
    public interface IRoleService : IDependency
    {
         #region
        bool AddOrEditAt(RoleDTO model);

        bool RemoveAt(ISpecification<Role> ispec);

        RoleDTO FindBy(ISpecification<Role> ispec);

        IQueryable<RoleDTO> QueryBy(ISpecification<Role> ispec);
        #endregion

        #region
        void ClearRoleMenus(ISpecification<RoleMenu> ispec);

        bool SetMenusToRole(ISpecification<RoleMenu> ispec, List<RoleMenuDTO> roleMenus);
        #endregion
    }
}