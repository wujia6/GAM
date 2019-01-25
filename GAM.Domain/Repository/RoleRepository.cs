using System;
using System.Linq;
using System.Linq.Expressions;
using GAM.Domain.Entities;
using GAM.Domain.IComm;
using Microsoft.EntityFrameworkCore;

namespace GAM.Domain.Repository
{
    internal class RoleRepository: IRoleRepos
    {
        private readonly IRepository<Role> iRepos;

        public RoleRepository(IRepository<Role> irepos)
        {
            this.iRepos = irepos;
        }

        public Role Find(int roleId)
        {
            return iRepos.DbEntity.Include("RoleMenus").Include("UserRoles").FirstOrDefault(e => e.ID == roleId);
        }

        public Role Find(Expression<Func<Role, bool>> filter)
        {
            if(filter==null)
                return null;
            return iRepos.DbEntity.Include(e => e.UserRoles).Include(e => e.RoleMenus).FirstOrDefault(filter);
        }
    }
}
