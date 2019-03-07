namespace GAM.Core.Models.RoleRoot
{
    public class RoleFactory
    {
        public static Role ClassInstance(string name, string code, string remarks = null)
        {
            var role = new Role
            {
                Name = name,
                Code = code,
                Remarks = string.IsNullOrEmpty(remarks) ? "暂无" : remarks
            };
            return role;
        }
    }
}
