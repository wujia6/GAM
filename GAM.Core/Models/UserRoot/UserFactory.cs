using System;

namespace GAM.Core.Models.UserRoot
{
    public class UserFactory
    {
        public static User ClassInstance(
            string acc = null,
            string pwd = null,
            string name = null,
            string email = null,
            string phone = null,
            DateTime? time = null, 
            bool enable = false,
            string remarks = null)
        {
            User user = new User();
            if (acc != null)
                user.Account = acc;
            if (pwd != null)
                user.Password = pwd;
            if (name != null)
                user.Name = name;
            if (email != null)
                user.Email = email;
            if (phone != null)
                user.Phone = phone;
            if (time != null)
                user.LastLoginTime = time.Value;
            if (enable)
                user.IsEnable = enable;
            if (remarks != null)
                user.Remarks = remarks;
            return user;
        }
    }
}
