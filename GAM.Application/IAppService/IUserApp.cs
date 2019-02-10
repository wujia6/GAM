using GAM.Domain.Entities.Aggregates.UserAgg;

namespace GAM.Core.IService
{
    public interface IUserApp
    {
        User UserLogin(string account, string password, string inputcode);

        bool UserRegister(User entity);
    }
}