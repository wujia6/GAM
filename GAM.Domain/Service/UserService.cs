using GAM.Domain.IRepository;

namespace GAM.Domain.Service
{
    internal class UserService
    {
        private readonly IUserRepos iUserRepos;

        public UserService(IUserRepos irepos)
        {
            this.iUserRepos = irepos;
        }
    }
}