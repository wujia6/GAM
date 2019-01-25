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
        private readonly IRepository<User> iUserRepos;

        public UserRepository(IRepository<User> irepos)
        {
            this.iUserRepos = irepos;
        }

        public bool IsExist(string account)
        {
            return iUserRepos.DbEntity.Contains(new User{ Account = account });
        }

        public User CompleteUser(Expression<Func<User, bool>> filter)
        {
            if(filter == null)
                return null;
            return iUserRepos.DbEntity.Include(e => e.Department).Include(e => e.UserRoles.Include(r => r.Role.RoleMenus.Where(x => x.Role.ID == r.Role.ID))).FirstOrDefault(filter);
        }

        public bool Register(User entity)
        {
            if(entity == null)
                return false;
            else if(IsExist(entity.Account))
                return false;
            return iUserRepos.Insert(entity);
        }

        public User SignIn(string account, string password)
        {
            return CompleteUser(filter:e => e.Account == account && e.Password == password);
        }
    }
}