using GAM.Domain.MainContext.Entities.Aggregates.MenuAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GAM.Domain.MainContext.Entities.Aggregates.RoleAgg
{
    public class RoleMenu: BaseEntity
    {
        // public int RoleID { get; set; }
        // public int MenuID { get; set; }

        public virtual Role Role { get; set; } = RoleFactory.Instance.Create();
        public virtual Menu Menu { get; set; } = MenuFactory.Instance.Create();
    }

    public class RoleMenuConfig : IEntityTypeConfiguration<RoleMenu>
    {
        public void Configure(EntityTypeBuilder<RoleMenu> builder)
        {
            builder.HasKey(a => a.ID);
            builder.HasOne(a => a.Role).WithMany(b => b.Menus).HasForeignKey(a => a.Role.ID).IsRequired();
            builder.HasOne(a => a.Menu).WithMany(b => b.Roles).HasForeignKey(a => a.Menu.ID).IsRequired();
            builder.Property(a => a.Remarks).HasMaxLength(100);
        }
    }
}
