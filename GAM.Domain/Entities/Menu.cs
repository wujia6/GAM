using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GAM.Domain.Entities
{
    /// <summary>
    /// 功能菜单实体
    /// </summary>
    public class Menu: BaseEntity
    {
        public int ParentId { get; set; }
        public int SerialNumber { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Url { get; set; }
        public MenuType Type { get; set; }
        public string Icon { get; set; }
        
        //导航属性
        public virtual RoleMenu RoleMenu { get; set; } = new RoleMenu();
    }

    public enum MenuType
    {
        menu = 1,
        action = 2,
        button = 3
    }

    /// <summary>
    /// Menu表映射类
    /// </summary>
    public class MenuConfig : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> b)
        {
            b.HasKey(e => e.ID);
            b.Property(e => e.ParentId).IsRequired();
            b.Property(e => e.SerialNumber).IsRequired();
            b.Property(e => e.Name).IsRequired().HasMaxLength(30);
            b.Property(e => e.Code).IsRequired().HasMaxLength(30);
            b.Property(e => e.Url).IsRequired().HasMaxLength(50);
            b.Property(e => e.Type).HasDefaultValue(1).IsRequired();
            b.Property(e => e.Icon).HasMaxLength(50).HasDefaultValue("none");
            b.Property(e => e.Remarks).HasMaxLength(100);
        }
    }
}
