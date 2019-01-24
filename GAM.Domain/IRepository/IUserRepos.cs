using System;
using System.Linq.Expressions;
using GAM.Domain.Entities;
using GAM.Domain.IComm;

namespace GAM.Domain.IRepository
{
    public interface IUserRepos: IRepository<User>, IAggregareRoot
    {
        //获取用户信息（包括外键数据）
        User UserComplete(Expression<Func<User,bool>> filter);

        //用户登录
        User UserSignIn(string account, string password);

        //用户注册
        bool UserRegister(User entity);

        //检查用户名是否存在
        bool IsExist(string account);
    }
}