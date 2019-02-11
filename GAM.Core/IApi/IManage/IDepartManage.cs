using System;
using System.Linq;
using System.Linq.Expressions;
using GAM.Core.Models.DepartRoot;
using GAM.Core.Models.UserRoot;

namespace GAM.Core.IApi.IManage
{
    public interface IDepartManage: ICoreManage<Depart>
    {
        IQueryable<User> GetDepartUsers(int departId);
    }
}
