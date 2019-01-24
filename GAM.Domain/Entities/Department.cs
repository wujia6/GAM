using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GAM.Domain.Entities
{
    /// <summary>
    /// 部门实体
    /// </summary>
    public class Department: IAggregareRoot
    {
        public int ID { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Manager { get; set; }
        public string ContactNumber { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreateTime { get; set; }
        public bool IsDeleted { get; set; }

        //导航属性
        public virtual IQueryable<User> Users { get; set; }
        public virtual User CreateUser { get; set; } = new User();
    }

    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> b)
        {
            b.HasKey(e => e.ID);
            b.Property(e => e.Name).IsRequired().HasMaxLength(30);
            b.Property(e => e.Code).IsRequired().HasMaxLength(20);
            b.Property(e => e.Manager).IsRequired().HasMaxLength(30);
            b.Property(e => e.ContactNumber).IsRequired().HasMaxLength(11);
            b.Property(e => e.Remarks).HasMaxLength(100);
            b.Property(e => e.CreateTime).HasDefaultValue(DateTime.Now);
            b.Property(e => e.IsDeleted).HasDefaultValue(false);
            b.HasMany(e => e.Users).WithOne(e => e.Department).HasForeignKey(e => e.ID);
            b.HasOne(e => e.CreateUser).WithOne(e => e.Department).HasForeignKey<Department>(e => e.CreateUser.ID);
        }
    }
}
