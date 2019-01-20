using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GAM.Domain.Entities
{
    /// <summary>
    /// 部门实体
    /// </summary>
    public class Department
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 父级部门ID
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 部门编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 部门负责人
        /// </summary>
        public string Manager { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 是否已删除
        /// </summary>
        public int IsDeleted { get; set; }

        /// <summary>
        /// 包含用户
        /// </summary>
        public virtual IQueryable<User> Users { get; set; }

        /// <summary>
        /// 创建人信息
        /// </summary>
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
