using GAM.Domain.Entities;
using GAM.Domain.IComm;

namespace GAM.Domain.Service
{
    internal class UserService: IUserService
    {
        private readonly IRepository<User> iUserRepos;

        public UserService(IRepository<User> irepos)
        {
            this.iUserRepos = irepos;
        }

        public User SignIn(string account, string password, string inputcode)
        {
            throw new System.NotImplementedException();
            //��¼ҵ���߼�
        }

        public bool Register(User entity)
        {
            throw new System.NotImplementedException();
            //ע��ҵ���߼�
        }
    }
}