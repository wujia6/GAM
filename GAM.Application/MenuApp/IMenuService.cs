using System.Linq;
using GAM.Core.IApi;
using GAM.Core.Models.MenuRoot;

namespace GAM.Application.MenuApp
{
    public interface IMenuService
    {
        bool AddOrEditAt(MenuDTO model);

        bool RemoveAt(ISpecification<Menu> ispec);

        MenuDTO FindBy(ISpecification<Menu> ispec);

        IQueryable<MenuDTO> QueryBy(ISpecification<Menu> ispec);
    }
}
