using System.Linq;
using GAM.Core.IApi;

namespace GAM.Core.Models.MenuRoot.Manage
{
    public interface IMenuManage
    {
        bool AddOrEditAt(Menu model);
        bool RemoveAt(ISpecification<Menu> ispec);
        Menu FindBy(ISpecification<Menu> ispec);
        IQueryable<Menu> QueryBy(ISpecification<Menu> ispec);
    }
}
