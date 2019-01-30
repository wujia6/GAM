using GAM.Application.IService;
using GAM.Domain.Entities;
using GAM.Domain.IComm;

namespace GAM.Application.Service
{
    public class RoleApplication: IRoleApplication
    {
        private readonly IDomainService<Role> iService;

        public RoleApplication(IDomainService<Role> ids)
        {
            this.iService = ids;
        }

        
    }
}
