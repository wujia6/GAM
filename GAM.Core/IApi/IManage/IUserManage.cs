using System;
using System.Linq;
using System.Linq.Expressions;
using GAM.Core.Models.UserRoot;

namespace GAM.Core.IApi.IManage
{
    public interface IUserManage
    {
        bool AddOrEdit(User user);

        bool Remove(int userId);

        User FindBy(Expression<Func<User, bool>> express);

        IQueryable<User> QueryBy(Expression<Func<User, bool>> express);

        IQueryable<UserRole> GetRolesByUser(Expression<Func<UserRole, bool>> express);
    }
}