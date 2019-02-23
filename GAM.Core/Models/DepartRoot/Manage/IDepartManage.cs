using System.Linq;
using GAM.Core.IApi;
using GAM.Core.Models.UserRoot;

namespace GAM.Core.Models.DepartRoot
{
    public interface IDepartManage
    {
        bool AddOrEditAt(Depart model);
        bool RemoveAt(Depart model);
        Depart FindBy(ISpecification<Depart> ispec);
        IQueryable<Depart> QueryBy(ISpecification<Depart> ispec);

        IQueryable<User> GetDepartUsers(ISpecification<User> ispec);
    }
}
