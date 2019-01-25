using System;
using System.Linq.Expressions;
using GAM.Domain.Entities;

namespace GAM.Domain.IComm
{
    public interface IUserRepos
    {
        //获取用户信息（包括外键数据）
        User CompleteUser(Expression<Func<User,bool>> filter);

        //用户登录
        User SignIn(string account, string password);

        //用户注册
        bool Register(User entity);

        //检查用户名是否存在
        bool IsExist(string account);
    }
}