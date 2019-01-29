using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GAM.Domain.Entities
{
    public class RoleMenu: BaseEntity
    {
        public int RoleID { get; set; }
        public int MenuID { get; set; }
        //导航属性
        public virtual Role Role { get; set; } = new Role();
        public virtual Menu Menu { get; set; } = new Menu();
    }

    public class RoleMenuConfig : IEntityTypeConfiguration<RoleMenu>
    {
        public void Configure(EntityTypeBuilder<RoleMenu> builder)
        {
            builder.HasKey(e=>e.ID);
            builder.HasOne(a => a.Role).WithMany(b => b.RoleMenus).HasForeignKey(a => a.RoleID).IsRequired();
            builder.HasOne(a => a.Menu).WithOne(b => b.RoleMenu).HasForeignKey<RoleMenu>(a => a.MenuID).IsRequired();
            builder.Property(a => a.Remarks).HasMaxLength(100);
        }
    }
}
