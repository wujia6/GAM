using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GAM.Core.Models.DepartRoot
{
    public class DepartConfig : IEntityTypeConfiguration<Depart>
    {
        public void Configure(EntityTypeBuilder<Depart> b)
        {
            b.HasKey(e => e.ID);
            b.Property(e => e.Name).IsRequired().HasMaxLength(30);
            b.Property(e => e.Manager).IsRequired().HasMaxLength(30);
            b.Property(e => e.Remarks).HasMaxLength(100);
        }
    }
}
