using GAM.Core.IManage;
using GAM.Core.IApi;
using GAM.Core.Models.RoleRoot;

namespace GAM.Core.Manage
{
    public class RoleService: IRoleManage
    {
        private readonly IEfCoreRepository<Role> iRepo;

        public RoleService(IEfCoreRepository<Role> irepo)
        {
            this.iRepo = irepo;
        }


    }
}
