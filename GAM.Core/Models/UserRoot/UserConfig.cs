using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GAM.Core.Models.UserRoot
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.Account).IsRequired().HasMaxLength(30);
            builder.Property(e => e.Password).IsRequired().HasMaxLength(30);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(10);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(80);
            builder.Property(e => e.Phone).IsRequired().HasMaxLength(11);
            builder.Property(e => e.Remarks).HasMaxLength(100);
            builder.Property(e => e.LastLoginTime).IsRequired();
            builder.Property(e => e.IsEnable).HasDefaultValue(false);
            //一对多关系
            builder.HasOne(e => e.Depart).WithMany(e => e.Users).HasForeignKey(e => e.Depart.ID);
        }
    }
}
