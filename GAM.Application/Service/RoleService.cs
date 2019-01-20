using System;
using System.Collections.Generic;
using System.Text;
using GAM.Domain.Entities;
using GAM.Domain;

namespace GAM.Application.Service
{
    public class RoleService
    {
        public RoleService(EFCoreContext context, IService<Role> service)
        {
            UnitWork = context as IUnitOfWork;
            IRoleService = service;
        }

        /// <summary>
        /// 单元工作对象
        /// </summary>
        private IUnitOfWork UnitWork { get; }

        /// <summary>
        /// 领域服务
        /// </summary>
        private IService<Role> IRoleService { get; } 

        //public bool AddRole(Role entity)
        //{
        //    entity.RoleMenus=
        //    IRoleService.AddTo(entity);
        //}
    }
}
