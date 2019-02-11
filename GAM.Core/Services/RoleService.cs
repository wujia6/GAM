﻿using System.Linq;
using System.Collections.Generic;
using GAM.Core.IApi;
using GAM.Core.IApi.IManage;
using GAM.Core.Models.RoleRoot;
using GAM.Core.Repository;
using System;
using System.Linq.Expressions;

namespace GAM.Core.Services
{
    internal class RoleService: CoreService<Role>, IRoleManage
    {
        public RoleService(IEfCoreRepository<Role> irepo): base(irepo) { }

        #region ##实现接口方法
        /// <summary>
        /// 清空角色菜单
        /// </summary>
        /// <param name="roleId">角色ID</param>
        public void ClearRoleMenus(int roleId)
        {
            ISpecification<RoleMenu> ispec = Specification<RoleMenu>.Eval(e => e.Role.ID == roleId);
            var range = IRepository.IContext.Set<RoleMenu>().Where(ispec.Expression);
            if (range.Count() > 0)
                IRepository.IContext.Set<RoleMenu>().RemoveRange(range);
        }

        /// <summary>
        /// 查询指定角色菜单
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns>IQueryable</returns>
        public IQueryable<RoleMenu> GetRoleMenus(int roleId)
        {
            ISpecification<RoleMenu> ispec = Specification<RoleMenu>.Eval(e => e.Role.ID == roleId);
            return IRepository.IContext.Set<RoleMenu>().Where(ispec.Expression).AsQueryable();
        }

        /// <summary>
        /// 设置角色菜单
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <param name="roleMenus">角色菜单</param>
        /// <returns>bool</returns>
        public bool SetMenusToRole(int roleId, List<RoleMenu> roleMenus)
        {
            ClearRoleMenus(roleId);
            IRepository.IContext.Set<RoleMenu>().AddRange(roleMenus);
            return true;
        }
        #endregion
    }
}