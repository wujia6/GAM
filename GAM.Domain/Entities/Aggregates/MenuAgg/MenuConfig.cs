using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GAM.Domain.Entities.Aggregates.MenuAgg
{
    public class MenuConfig : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> b)
        {
            b.HasKey(e => e.ID);
            b.Property(e => e.PID).IsRequired();
            b.Property(e => e.SerialNo).IsRequired();
            b.Property(e => e.Name).IsRequired().HasMaxLength(30);
            b.Property(e => e.Code).IsRequired().HasMaxLength(30);
            b.Property(e => e.Url).IsRequired().HasMaxLength(50);
            b.Property(e => e.Type).HasDefaultValue(1).IsRequired();
            b.Property(e => e.Icon).HasMaxLength(50).HasDefaultValue("none");
            b.Property(e => e.Remarks).HasMaxLength(100);
        }
    }
}
