using System;
using System.Linq;
using System.Linq.Expressions;
using GAM.Core.Models.UserRoot;

namespace GAM.Core.IApi.IManage
{
    public interface IUserManage: ICoreManage<User>
    {
        IQueryable<UserRole> GetRolesByUser(Expression<Func<UserRole, bool>> express);
    }
}