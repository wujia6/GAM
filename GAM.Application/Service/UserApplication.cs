using GAM.Application.IService;
using GAM.Domain.Entities;
using GAM.Domain.IComm;

namespace GAM.Application.Service
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserService iService;

        public UserApplication(IUserService iUser)
        {
            this.iService = iUser;
        }

        public User UserLogin(string account, string password)
        {
            throw new System.NotImplementedException();
        }

        public bool UserRegister(User entity)
        {
            throw new System.NotImplementedException();
        }
    }
}