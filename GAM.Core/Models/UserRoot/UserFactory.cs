using System;

namespace GAM.Core.Models.UserRoot
{
    /// <summary>
    /// 聚合根工厂类，创建此聚合内所有对象
    /// </summary>
    public static class UserFactory
    {
        public static User GetInstance
        {
            get { return new User(); }
        }

        public static User ClassInstance(
            Guid Id,
            string acc,
            string pwd,
            string name,
            string email,
            string phone,
            DateTime time, 
            bool enable,
            string remarks = null)
        {
            User user = new User
            {
                ID = Id,
                Account = acc,
                Password = pwd,
                Name = name,
                Email = email,
                Phone = phone,
                LastLoginTime = time,
                IsEnable = enable,
                Remarks = string.IsNullOrEmpty(remarks) ? "暂无" : remarks
            };
            return user;
        }
    }
}
