using System.Linq;
using GAM.Application.IServices;
using GAM.Core.IApi;
using GAM.Core.Models.MenuRoot;
using GAM.Infrastructure.Dtos;
using GAM.Infrastructure.Utilities;

namespace GAM.Application.Services
{
    internal class MenuService : IMenuService
    {
        private readonly IMenuManage iManage;

        public MenuService(IMenuManage imge)
        {
            this.iManage = imge;
        }

        public bool AddOrEditAt(MenuDTO model)
        {
            var menu = MapperSupport.MapTo<Menu>(model);
            return iManage.AddOrEditAt(menu);
        }

        public bool RemoveAt(ISpecification<Menu> ispec)
        {
            return iManage.RemoveAt(ispec);
        }

        public MenuDTO FindBy(ISpecification<Menu> ispec)
        {
            var menu = iManage.FindBy(ispec);
            return MapperSupport.MapTo<MenuDTO>(menu);
        }

        public IQueryable<MenuDTO> QueryBy(ISpecification<Menu> ispec)
        {
            var querys = iManage.QueryBy(ispec);
            return MapperSupport.MapTo<IQueryable<MenuDTO>>(querys);
        }
    }
}
