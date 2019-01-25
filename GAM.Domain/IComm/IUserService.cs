using GAM.Domain.Entities;

namespace GAM.Domain.IComm
{
    public interface IUserService
    {
        User UserLogin(string account,string password);

        bool UserRegister(User entity);
    }
}