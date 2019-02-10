using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GAM.Core.Models.MenuRoot
{
    public class MenuConfig : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.PID).IsRequired();
            builder.Property(e => e.Type).HasDefaultValue(1).IsRequired();
            builder.Property(e => e.Name).IsRequired().HasMaxLength(30);
            builder.Property(e => e.Code).IsRequired().HasMaxLength(30);
            builder.Property(e => e.Url).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Remarks).HasMaxLength(100);
        }
    }
}
