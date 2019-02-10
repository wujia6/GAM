using GAM.Core.Models.RoleRoot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GAM.Core.Models.UserRoot
{
    public class UserRole: BaseEntity
    {
        public virtual User User { get; set; } = RootFactory<User>.ClassInstance(typeof(User));

        public virtual Role Role { get; set; } = RootFactory<Role>.ClassInstance(typeof(Role));
    }

    public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(e => e.ID);
            builder.HasOne(e => e.User).WithMany(e => e.Roles).HasForeignKey(e => e.User.ID).IsRequired();
            builder.HasOne(e => e.Role).WithMany(e => e.Users).HasForeignKey(e => e.Role.ID).IsRequired();
            builder.Property(e => e.Remarks).HasMaxLength(100);
        }
    }
}
