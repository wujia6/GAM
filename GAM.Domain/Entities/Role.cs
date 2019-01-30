using System;
using System.Linq;
using GAM.Domain.IComm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GAM.Domain.Entities
{
    /// <summary>
    /// 角色领域模型
    /// </summary>
    public class Role: BaseEntity, IAggregareRoot
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime? CreateTime { get; set; }
        //导航属性
        public virtual IQueryable<UserRole> UserRoles { get; set; }
        public virtual IQueryable<RoleMenu> RoleMenus { get; set; }
    }

    //RoleConfig
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(e=>e.ID);
            builder.Property(e=>e.Code).IsRequired().HasMaxLength(50);
            builder.Property(e=>e.Name).IsRequired().HasMaxLength(20);
            builder.Property(e=>e.CreateTime).HasColumnType("DateTime").HasDefaultValue(DateTime.Now);
            builder.Property(e=>e.Remarks).HasMaxLength(100);
        }
    }
}
