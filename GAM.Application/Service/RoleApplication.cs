using GAM.Core.IManage;
using GAM.Core.IService;

namespace GAM.Core.Service
{
    public class RoleApplication: IRoleApp
    {
        private readonly IRoleManage iService;

        public RoleApplication(IRoleManage iser)
        {
            this.iService = iser;
        }

        
    }
}
