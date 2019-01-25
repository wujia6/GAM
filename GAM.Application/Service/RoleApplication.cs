using GAM.Application.IService;
using GAM.Domain.IComm;

namespace GAM.Application.Service
{
    public class RoleApplication: IRoleApplication
    {
        private readonly IRoleService iRoleService;

        public RoleApplication(IRoleService service)
        {
            this.iRoleService = service;
        }

        
    }
}
