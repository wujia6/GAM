using System.Linq;
using GAM.Core.Models.RoleRoot;

namespace GAM.Core.Models.MenuRoot
{
    public enum MenuType
    {
        menu = 1,
        module = 2,
        action = 3,
    }

    public class Menu: BaseEntity, IAggregateRoot
    {
        public int PID { get; set; }
        public MenuType Type { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Url { get; set; }
        //导航属性
        public virtual IQueryable<RoleMenu> RoleMenus { get; set; }
    }
}
