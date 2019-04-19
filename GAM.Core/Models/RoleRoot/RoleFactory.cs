using System;

namespace GAM.Core.Models.RoleRoot
{
    /// <summary>
    /// 聚合根工厂类，创建此聚合内所有对象
    /// </summary>
    public static class RoleFactory
    {
        public static Role GetInstance
        {
            get { return new Role(); }
        }

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
