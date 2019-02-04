using GAM.Domain.Entities.Aggregates.RoleAgg;
using GAM.Domain.Repository;

namespace GAM.Domain.Service
{
    public interface IRoleService: IRepository<Role>
    {
    }
}
