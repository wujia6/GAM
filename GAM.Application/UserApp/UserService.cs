using GAM.Core.IApi;
using GAM.Core.Models.UserRoot;
using GAM.Core.Models.UserRoot.Manage;
using AutoMapper;

namespace GAM.Application.UserApp
{
    public class UserService : IUserService
    {
        //领域服务接口对象
        private readonly IUserManage iUserManage;
        //构造函数（容器注入）
        public UserService(IUserManage iManage)
        {
            this.iUserManage = iManage;
        }

        #region ##接口实现
        public UserDTO UserLogin(ISpecification<User> ispec)
        {
            var user = iUserManage.FindBy(ispec);
            return user == null ? null : Mapper.Map<UserDTO>(user);
        }

        public bool UserRegister(UserDTO model)
        {
            var user = Mapper.Map<User>(model);
            return iUserManage.AddOrEditAt(user);
        }
        #endregion
    }
}