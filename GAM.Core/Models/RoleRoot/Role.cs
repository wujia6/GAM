using System.Linq;
using GAM.Core.Models.UserRoot;

namespace GAM.Core.Models.RoleRoot
{
    public class Role: BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Code { get; set; }
        //导航属性
        public virtual IQueryable<UserRole> Users { get; set; }
        public virtual IQueryable<RoleMenu> RoleMenus { get; set; }
    }
}
