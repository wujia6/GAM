using System;
using System.Linq;
using GAM.Domain.IComm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GAM.Domain.Entities
{
    public class User : BaseEntity, IAggregareRoot
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public string MobileNumber { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime LastLoginTime { get; set; }
        public bool IsDeleted { get; set; }
        //导航属性
        public virtual Department Department { get; set; } = new Department();
        public virtual IQueryable<UserRole> UserRoles { get; set; }
    }

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e=>e.ID);
            builder.Property(e=>e.Account).IsRequired().HasMaxLength(30);
            builder.Property(e=>e.Password).IsRequired().HasMaxLength(30);
            builder.Property(e=>e.Name).IsRequired().HasMaxLength(10);
            builder.Property(e=>e.EMail).IsRequired().HasMaxLength(80);
            builder.Property(e=>e.MobileNumber).IsRequired().HasMaxLength(11);
            builder.Property(e=>e.Remarks).HasMaxLength(100);
            builder.Property(e=>e.CreateTime).HasDefaultValue(DateTime.Now);
            builder.Property(e=>e.LastLoginTime).IsRequired().HasColumnType("DateTime");
            builder.Property(e=>e.IsDeleted).HasDefaultValue(false);
            //一对多关系设置
            builder.HasOne(e => e.Department).WithMany().HasForeignKey(e => e.Department.ID);
        }
    }
}
