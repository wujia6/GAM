using System.Collections.Generic;
using System.Linq;
using GAM.Application.IServices;
using GAM.Core.IApi;
using GAM.Core.Models.RoleRoot;
using GAM.Infrastructure.Dtos;
using GAM.Infrastructure.Utilities;

namespace GAM.Application.Services
{
    internal class RoleService: IRoleService
    {
        private readonly IRoleManage iManage;

        public RoleService(IRoleManage imge)
        {
            this.iManage = imge;
        }

        public bool AddOrEditAt(RoleDTO model)
        {
            var role = MapperSupport.MapTo<Role>(model);
            return iManage.AddOrEditAt(role);
        }

        public bool RemoveAt(ISpecification<Role> ispec)
        {
            return iManage.RemoveAt(ispec);
        }

        public RoleDTO FindBy(ISpecification<Role> ispec)
        {
            var role = iManage.FindBy(ispec);
            return MapperSupport.MapTo<RoleDTO>(role);
        }

        public IQueryable<RoleDTO> QueryBy(ISpecification<Role> ispec)
        {
            var querys = iManage.QueryBy(ispec);
            return MapperSupport.MapTo<IQueryable<RoleDTO>>(querys);
        }

        public void ClearRoleMenus(ISpecification<RoleMenu> ispec)
        {
            iManage.ClearRoleMenus(ispec);
        }

        public bool SetMenusToRole(ISpecification<RoleMenu> ispec, List<RoleMenuDTO> roleMenus)
        {
            var menus = MapperSupport.MapTo<List<RoleMenu>>(roleMenus);
            return iManage.SetMenusToRole(ispec, menus);
        }
    }
}
