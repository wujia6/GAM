using GAM.Domain.Entities.Aggregates.RoleAgg;
using GAM.Domain.Service;
using GAM.Application.IService;

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
