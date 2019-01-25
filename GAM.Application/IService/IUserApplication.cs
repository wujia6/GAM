using GAM.Domain.Entities;

namespace GAM.Application.IService
{
    public interface IUserApplication
    {
        User UserLogin(string account,string password);

        bool UserRegister(User entity);
    }
}