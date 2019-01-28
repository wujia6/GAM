using System;
using System.Linq;
using System.Linq.Expressions;
using GAM.Domain.Entities;
using GAM.Domain.IComm;
using Microsoft.EntityFrameworkCore;

namespace GAM.Domain.Repository
{
    internal class UserRepository : IUserRepos
    {
        private readonly IRepository<User> iRepos;

        public UserRepository(IRepository<User> irepos)
        {
            this.iRepos = irepos;
        }

        public bool IsExist(string account)
        {
            return iRepos.DbEntity.Contains(new User{ Account = account });
        }

        public User CompleteUser(Expression<Func<User, bool>> filter)
        {
            if(filter == null)
                return null;
            return iRepos.Find(filter, include: u => u.UserRoles.Include(e => e.Role.RoleMenus.Where(x => x.Role.ID == e.Role.ID)));
            //return iRepos.DbEntity.Include(e => e.Department).Include(e => e.UserRoles.Include(r => r.Role.RoleMenus.Where(x => x.Role.ID == r.Role.ID))).FirstOrDefault(filter);
        }

        public bool Register(User entity)
        {
            if(entity == null)
                return false;
            else if(IsExist(entity.Account))
                return false;
            return iRepos.Insert(entity);
        }

        public User SignIn(string account, string password)
        {
            return CompleteUser(filter:e => e.Account == account && e.Password == password);
        }
    }
}