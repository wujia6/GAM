using GAM.Domain.Entities.Aggregates.MenuAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GAM.Domain.Entities.Aggregates.RoleAgg
{
    public class RoleMenu: IEntity
    {
        public int ID { get; set; }
        public int RoleID { get; set; }
        public int MenuID { get; set; }
        public string Remarks { get; set; }
        //导航属性
        public virtual Role Role { get; set; } = RoleFactory.Instance.Create();
        public virtual Menu Menu { get; set; } = MenuFactory.Instance.Create();
    }

    public class RoleMenuConfig : IEntityTypeConfiguration<RoleMenu>
    {
        public void Configure(EntityTypeBuilder<RoleMenu> builder)
        {
            builder.HasKey(a => a.ID);
            builder.HasOne(a => a.Role).WithMany(b => b.Menus).HasForeignKey(a => a.RoleID).IsRequired();
            builder.HasOne(a => a.Menu).WithMany(b => b.Roles).HasForeignKey(a => a.MenuID).IsRequired();
            builder.Property(a => a.Remarks).HasMaxLength(100);
        }
    }
}
