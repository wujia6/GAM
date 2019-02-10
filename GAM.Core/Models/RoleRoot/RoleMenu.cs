using GAM.Core.Models.MenuRoot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GAM.Core.Models.RoleRoot
{
    public class RoleMenu: BaseEntity
    {
        //导航属性
        public virtual Role Role { get; set; } = RootFactory<Role>.ClassInstance(typeof(Role));
        public virtual Menu Menu { get; set; } = RootFactory<Menu>.ClassInstance(typeof(Menu));
    }

    public class RoleMenuConfig : IEntityTypeConfiguration<RoleMenu>
    {
        public void Configure(EntityTypeBuilder<RoleMenu> builder)
        {
            builder.HasKey(a => a.ID);
            builder.HasOne(a => a.Role).WithMany(b => b.RoleMenus).HasForeignKey(a => a.Role.ID).IsRequired();
            builder.HasOne(a => a.Menu).WithOne(b => b.RoleMenu).HasForeignKey<Menu>(a=>a.ID).IsRequired();
            builder.Property(a => a.Remarks).HasMaxLength(100);
        }
    }
}
