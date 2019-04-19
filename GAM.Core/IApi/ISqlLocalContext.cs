using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GAM.Core.IApi
{
    public interface ISqlLocalContext: IUnitOfWork
    {
        DbSet<T> Set<T>() where T : class;
        EntityEntry Entry(object entity);

        DbSet<Models.DepartRoot.Depart> Departs { get; set; }
        DbSet<Models.RoleRoot.Role> Roles { get; set; }
        DbSet<Models.MenuRoot.Menu> Menus { get; set; }
        DbSet<Models.UserRoot.User> Users { get; set; }
        DbSet<Models.RoleRoot.RoleMenu> RoleMenus { get; set; }
        DbSet<Models.UserRoot.UserRole> UserRoles { get; set; }
    }
}
