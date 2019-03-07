using System;

namespace GAM.Core.Models.UserRoot
{
    public class UserFactory
    {
        public static User ClassInstance(
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
