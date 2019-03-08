using System;

namespace GAM.Core.Models.RoleRoot
{
    public class RoleFactory
    {
        public static Role ClassInstance(Guid roleId, string name, string code, string remarks = null)
        {
            var role = new Role
            {
                ID = roleId,
                Name = name,
                Code = code,
                Remarks = string.IsNullOrEmpty(remarks) ? "暂无" : remarks
            };
            return role;
        }
    }
}
