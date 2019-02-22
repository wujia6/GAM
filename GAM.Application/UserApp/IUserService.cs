using GAM.Core.IApi;
using GAM.Core.Models.UserRoot;

namespace GAM.Application.UserApp
{
    public interface IUserService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="ispec">规约接口对象</param>
        /// <returns>UserDTO</returns>
        UserDTO UserLogin(ISpecification<User> ispec);

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="model">DTO</param>
        /// <returns>bool</returns>
        bool UserRegister(UserDTO model);
    }
}