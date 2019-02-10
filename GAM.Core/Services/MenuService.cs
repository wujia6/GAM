using GAM.Core.IApi;
using GAM.Core.IApi.IManage;
using GAM.Core.Models.MenuRoot;

namespace GAM.Core.Services
{
    public class MenuService: IMenuManage
    {
        private readonly IEfCoreRepository<Menu> iRepo;

        public MenuService(IEfCoreRepository<Menu> irepo)
        {
            this.iRepo = irepo;
        }


    }
}
