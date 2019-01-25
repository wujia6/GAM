using GAM.Domain.Entities;
using GAM.Domain.IComm;

namespace GAM.Domain.Service
{
    internal class UserService: IUserService
    {
        private readonly IUserRepos iUserRepos;

        public UserService(IUserRepos irepos)
        {
            this.iUserRepos = irepos;
        }

        public User UserLogin(string account, string password)
        {
            return iUserRepos.SignIn(account,password);
        }

        public bool UserRegister(User entity)
        {
            throw new System.NotImplementedException();
        }
    }
}