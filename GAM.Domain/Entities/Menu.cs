using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GAM.Domain.Entities
{
    /// <summary>
    /// 功能菜单实体
    /// </summary>
    public class Menu
    {
        public int ID { get; set; }
        public Guid ParentId { get; set; }
        public int SerialNumber { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Url { get; set; }
        public int Type { get; set; }
        public string Icon { get; set; }
        public string Remarks { get; set; }
        
        //导航属性
        public virtual RoleMenu RoleMenu { get; set; } = new RoleMenu();
    }

    public enum MenuType
    {
        
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
            b.Property(e => e.Type).IsRequired();
            b.Property(e => e.Icon).IsRequired().HasMaxLength(50);
            b.Property(e => e.Remarks).IsRequired().HasMaxLength(100);
        }
    }
}
