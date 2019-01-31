using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GAM.Domain.MainContext.Entities.Aggregates.DepartmentAgg
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> b)
        {
            b.HasKey(e => e.ID);
            b.Property(e => e.Name).IsRequired().HasMaxLength(30);
            b.Property(e => e.Code).IsRequired().HasMaxLength(20);
            b.Property(e => e.Manager).IsRequired().HasMaxLength(30);
            b.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(11);
            b.Property(e => e.Remarks).HasMaxLength(100);
            b.Property(e => e.CreateTime).HasDefaultValue(DateTime.Now);
            b.Property(e => e.IsDeleted).HasDefaultValue(false);
            //b.HasMany(e => e.Users).WithOne(e => e.Department).HasForeignKey(e => e.ID);
            //b.HasOne(e => e.CreateUser).WithOne(e => e.Department).HasForeignKey<Department>(e => e.CreateUser.ID);
        }
    }
}
