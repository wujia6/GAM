using GAM.Core.IApi.IManage;
using GAM.Application.IService;

namespace GAM.Application.Services
{
    internal class RoleService: IRoleService
    {
        private readonly IRoleManage iManage;

        public RoleService(IRoleManage imge)
        {
            this.iManage = imge;
        }
    }
}
