using GAM.Core.Models.MenuRoot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GAM.Core.Models.RoleRoot
{
    public class RoleMenu: BaseEntity
    {
        //导航属性
        public virtual Role Role { get; set; } = RoleFactory.ClassInstance();
        public virtual Menu Menu { get; set; } = MenuFactory.ClassInstance();
    }

    public class RoleMenuConfig : IEntityTypeConfiguration<RoleMenu>
    {
        public void Configure(EntityTypeBuilder<RoleMenu> builder)
        {
            builder.HasKey(a => a.ID);
            builder.HasOne(a => a.Role).WithMany(b => b.RoleMenus);
            builder.HasOne(a => a.Menu).WithMany(b => b.RoleMenus);
            builder.Property(a => a.Remarks).HasMaxLength(100);
        }
    }
}
