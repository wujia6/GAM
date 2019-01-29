using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GAM.Domain.Entities
{
    public class UserRole: BaseEntity
    {
        public virtual User User { get; set; } = new User();
        public virtual Role Role { get; set; } = new Role();
    }

    public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> b)
        {
            b.HasKey(e => e.ID);
            b.HasOne(e => e.User).WithMany(e => e.UserRoles).HasForeignKey(e => e.User.ID);
            b.HasOne(e => e.Role).WithMany(e => e.UserRoles).HasForeignKey(e => e.Role.ID);
            b.Property(e => e.Remarks).HasMaxLength(100);
        }
    }
}
