using System;
using System.Linq;
using System.Linq.Expressions;
using GAM.Domain.Entities;
using GAM.Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace GAM.Domain.Repository
{
    internal class UserRepository : EFCore<User>, IUserRepos
    {
        public UserRepository(EFCoreContext context) : base(context) { }

        public bool IsExist(string account)
        {
            return DbEntity.Contains(new User{ Account=account });
        }

        public User UserComplete(Expression<Func<User, bool>> filter)
        {
            if(filter == null)
                return null;
            return DbEntity.Include(e => e.Department).Include(e => e.UserRoles.Include(r => r.Role.RoleMenus.Where(x => x.Role.ID == r.Role.ID))).FirstOrDefault(filter);
        }

        public bool UserRegister(User entity)
        {
            if(entity == null)
                return false;
            else if(IsExist(entity.Account))
                return false;
            return Insert(entity);
        }

        public User UserSignIn(string account, string password)
        {
            return UserComplete(filter:e => e.Account == account && e.Password == password);
        }
    }
}