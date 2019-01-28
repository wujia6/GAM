using GAM.Application.IService;
using GAM.Domain.Entities;
using GAM.Domain.IComm;

namespace GAM.Application.Service
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserService iService;

        private readonly IUnitOfWork iUnitWork;

        public UserApplication(EFCoreContext context, IUserService iUser)
        {
            this.iService = iUser;
            this.iUnitWork = context as IUnitOfWork;
        }

        public User UserLogin(string account, string password)
        {
            return iService.UserLogin(account,password);
        }

        public bool UserRegister(User entity)
        {
            try
            {
                if(!iService.UserRegister(entity))
                    return false;
                iUnitWork.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}