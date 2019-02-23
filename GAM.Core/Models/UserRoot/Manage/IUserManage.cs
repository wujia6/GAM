using System.Linq;
using GAM.Core.IApi;

namespace GAM.Core.Models.UserRoot
{
    public interface IUserManage
    {
        bool AddOrEditAt(User model);
        bool RemoveAt(ISpecification<User> ispec);
        User FindBy(ISpecification<User> ispec);
        IQueryable<User> QueryBy(ISpecification<User> ispec = null);

        IQueryable<UserRole> GetRolesByUser(ISpecification<UserRole> ispec);
    }
}
