﻿using System.Linq;
using GAM.Core.Models.DepartRoot;
using GAM.Core.Models.UserRoot;

namespace GAM.Core.IApi.IManage
{
    public interface IDepartManage: ICoreManage<Depart>
    {
        IQueryable<User> GetDepartUsers(int departId);
    }
}
