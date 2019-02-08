using System.Collections.Generic;
using System.Linq;
using GAM.Domain.Entities;
using GAM.Domain.Entities.Aggregates.RoleAgg;
using GAM.Domain.Repository;
using GAM.Domain.SpecAgreement;
using Microsoft.EntityFrameworkCore;

namespace GAM.Domain.Service
{
    public class RoleService: AbstractRepository<Role>, IRoleService
    {
        public RoleService(GamDbContext cxt) : base(cxt) { }

        /// <summary>
        /// 清空角色菜单
        /// </summary>
        /// <param name="role">角色对象</param>
        /// <returns>bool</returns>
        public void ClearRoleMenus(Role role)
        {
            if (role.Menus.Count() > 0)
                role.Menus.ToList().RemoveAll(m => m.RoleID == role.ID);
        }

        /// <summary>
        /// 根据角色获取权限
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns>IQueryable</returns>
        public IQueryable<RoleMenu> GetRoleMenus(int roleId)
        {
            ISpecification<RoleMenu> ispce = Specification<RoleMenu>.Eval(e => e.RoleID == roleId);
            return DataContext.Set<RoleMenu>().Where(ispce.Expression);
        }

        /// <summary>
        /// 删除指定角色菜单
        /// </summary>
        /// <param name="roleMenu">角色菜单</param>
        /// <returns>bool</returns>
        public bool RoleMenuRemoveAt(RoleMenu roleMenu)
        {
            if (!DataContext.Set<RoleMenu>().Contains(roleMenu))
                return false;
            DataContext.Set<RoleMenu>().Remove(roleMenu);
            return true;
        }

        /// <summary>
        /// 设置角色权限
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <param name="roleMenus">角色权限集合</param>
        /// <returns>bool</returns>
        public bool SetMenusToRole(int roleId, List<RoleMenu> roleMenus)
        {
            try
            {
                ClearRoleMenus(new Role { ID = roleId });
                DataContext.Set<RoleMenu>().AddRange(roleMenus);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
