using System.Linq;
using GAM.Core.Models.UserRoot;

namespace GAM.Core.IApi.IManage
{
    public interface IDepartManage
    {
        IQueryable<User> GetDepartUsers(int departId);
    }
}
