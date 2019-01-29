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
        //public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime? CreateTime { get; set; }
        //public string Remarks { get; set; }

        //导航属性
        public virtual IQueryable<UserRole> UserRoles { get; set; }
        public virtual IQueryable<RoleMenu> RoleMenus { get; set; }
    }

    //RoleConfig
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> b)
        {
            b.HasKey(e=>e.ID);
            b.Property(e=>e.Code).IsRequired().HasMaxLength(50);
            b.Property(e=>e.Name).IsRequired().HasMaxLength(20);
            b.Property(e=>e.CreateTime).HasColumnType("DateTime").HasDefaultValue(DateTime.Now);
            b.Property(e=>e.Remarks).HasMaxLength(100);
        }
    }
}
