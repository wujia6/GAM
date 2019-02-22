using System.Linq;
using GAM.Core.IApi;
using GAM.Core.Models.MenuRoot;
using GAM.Core.Models.MenuRoot.Manage;

namespace GAM.Application.MenuApp
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
            var menu = global::AutoMapper.Mapper.Map<Menu>(model);
            return iManage.AddOrEditAt(menu);
        }

        public bool RemoveAt(ISpecification<Menu> ispec)
        {
            return iManage.RemoveAt(ispec);
        }

        public MenuDTO FindBy(ISpecification<Menu> ispec)
        {
            var menu = iManage.FindBy(ispec);
            return global::AutoMapper.Mapper.Map<MenuDTO>(menu);
        }

        public IQueryable<MenuDTO> QueryBy(ISpecification<Menu> ispec)
        {
            var querys = iManage.QueryBy(ispec);
            return global::AutoMapper.Mapper.Map<IQueryable<MenuDTO>>(querys);
        }
    }
}
