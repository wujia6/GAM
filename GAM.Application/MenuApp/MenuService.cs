using System.Linq;
using GAM.Core.IApi;
using GAM.Core.Models.MenuRoot;
using GAM.Infrastructure.Utilities;

namespace GAM.Application.MenuApp
{
    public class MenuService : IMenuService
    {
        private readonly IMenuManage iManage;

        public MenuService(IMenuManage imge)
        {
            this.iManage = imge;
        }

        public bool AddOrEditAt(MenuDTO model)
        {
            var menu = AutoMapperHelper.MapTo<Menu>(model);
            return iManage.AddOrEditAt(menu);
        }

        public bool RemoveAt(ISpecification<Menu> ispec)
        {
            return iManage.RemoveAt(ispec);
        }

        public MenuDTO FindBy(ISpecification<Menu> ispec)
        {
            var menu = iManage.FindBy(ispec);
            return AutoMapperHelper.MapTo<MenuDTO>(menu);
        }

        public IQueryable<MenuDTO> QueryBy(ISpecification<Menu> ispec)
        {
            var querys = iManage.QueryBy(ispec);
            return AutoMapperHelper.MapTo<IQueryable<MenuDTO>>(querys);
        }
    }
}
