using System;
using System.Linq;
using System.Linq.Expressions;
using GAM.Core.IApi;
using GAM.Core.IApi.IManage;
using GAM.Core.Models.MenuRoot;

namespace GAM.Core.Services
{
    internal class MenuService: CoreService<Menu>, IMenuManage
    {
        public MenuService(IEfCoreRepository<Menu> irepo): base(irepo) { }
    }
}
