using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GAM.Domain.Entities.Aggregates.RoleAgg
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.Code).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(20);
            builder.Property(e => e.CreateTime).HasColumnType("DateTime").HasDefaultValue(DateTime.Now);
            builder.Property(e => e.Remarks).HasMaxLength(100);
        }
    }
}
