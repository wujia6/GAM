using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GAM.Core.Models.DepartRoot
{
    public class DepartConfig : IEntityTypeConfiguration<Depart>
    {
        public void Configure(EntityTypeBuilder<Depart> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(30);
            builder.Property(e => e.Manager).IsRequired().HasMaxLength(30);
            builder.Property(e => e.Remarks).HasMaxLength(100);
        }
    }
}
