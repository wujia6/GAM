using GAM.Domain.Entities.Aggregates.UserAgg;

namespace GAM.Application.IService
{
    public interface IUserApplication
    {
        User UserLogin(string account, string password, string inputcode);

        bool UserRegister(User entity);
    }
}