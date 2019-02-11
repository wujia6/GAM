using GAM.Core.IApi.IManage;
using GAM.Core.IService;

namespace GAM.Application.AppServices
{
    public class RoleService: IRoleService
    {
        private readonly IRoleManage iManage;

        public RoleService(IRoleManage iser)
        {
            this.iManage = iser;
        }
    }
}
