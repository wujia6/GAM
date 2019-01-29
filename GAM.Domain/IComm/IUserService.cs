using GAM.Domain.Entities;

namespace GAM.Domain.IComm
{
    public interface IUserService
    {
        User SignIn(string account, string password, string validatecode);

        bool Register(User entity);
    }
}