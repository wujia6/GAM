using System.Linq;
using GAM.Core.IApi;
using GAM.Core.Models.MenuRoot;
using GAM.Infrastructure.Dtos;

namespace GAM.Application.IServices
{
    public interface IMenuService : IDependency
    {
         bool AddOrEditAt(MenuDTO model);

        bool RemoveAt(ISpecification<Menu> ispec);

        MenuDTO FindBy(ISpecification<Menu> ispec);

        IQueryable<MenuDTO> QueryBy(ISpecification<Menu> ispec);
    }
}