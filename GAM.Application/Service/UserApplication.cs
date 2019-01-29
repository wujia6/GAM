using Microsoft.EntityFrameworkCore;
using GAM.Application.IService;
using GAM.Domain.Entities;
using GAM.Domain.IComm;

namespace GAM.Application.Service
{
    public class UserApplication : IUserApplication
    {
        //领域服务对象
        private readonly IDomainService<User> iService;
        //工作单元对象
        private readonly IUnitOfWork iUnitWork;
        //构造函数
        public UserApplication(EFCoreContext context, IDomainService<User> ids)
        {
            this.iService = ids;
            this.iUnitWork = context as IUnitOfWork;
        }

        /// <summary>
        /// 登录校验
        /// </summary>
        /// <param name="account">登录账号</param>
        /// <param name="password">登录密码</param>
        /// <param name="inputcode">验证码</param>
        /// <returns>User</returns>
        public User UserLogin(string account, string password, string inputcode)
        {
            return iService.Single(
                filter: u => u.Account == account && u.Password == password,
                include: u => u.UserRoles.Include(r => r.Role.RoleMenus.Include(x => x.Menu)));
        }

        /// <summary>
        /// 注册校验
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>bool</returns>
        public bool UserRegister(User entity)
        {
            if (entity == null)
                return false;
            if (!iService.Add(entity))
                return false;
            return iUnitWork.SaveChanges() > 0;
        }
    }
}