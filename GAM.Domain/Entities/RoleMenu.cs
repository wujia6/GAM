using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GAM.Domain.Entities
{
    public class RoleMenu: BaseEntity
    {
        public virtual Role Role { get; set; } = new Role();
        public virtual Menu Menu { get; set; } = new Menu();
    }

    public class RoleMenuConfig : IEntityTypeConfiguration<RoleMenu>
    {
        public void Configure(EntityTypeBuilder<RoleMenu> b)
        {
            b.HasKey(e=>new object[] {e.Role.ID, e.Menu.ID});
            b.HasOne(e=>e.Role).WithMany(e=>e.RoleMenus).HasForeignKey(e=>e.Role.ID);
            b.HasOne(e=>e.Menu).WithOne(e=>e.RoleMenu).HasForeignKey<RoleMenu>(e=>e.Menu.ID);
        }
    }
}
