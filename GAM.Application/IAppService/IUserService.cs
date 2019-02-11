using GAM.Core.Models.UserRoot;

namespace GAM.Core.IService
{
    public interface IUserService
    {
        User UserLogin(string account, string password, string inputcode);

        bool UserRegister(User entity);
    }
}