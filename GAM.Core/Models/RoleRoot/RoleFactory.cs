namespace GAM.Core.Models.RoleRoot
{
    public class RoleFactory
    {
        public static Role ClassInstance(string name = null, string code = null, string remarks = null)
        {
            var role = new Role();
            if (name != null)
                role.Name = name;
            else if (code != null)
                role.Code = code;
            else if (remarks != null)
                role.Remarks = remarks;
            return role;
        }
    }
}
