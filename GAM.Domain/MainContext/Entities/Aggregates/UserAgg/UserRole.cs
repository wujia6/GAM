using GAM.Domain.MainContext.Entities.Aggregates.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GAM.Domain.MainContext.Entities.Aggregates.UserAgg
{
    public class UserRole : BaseEntity
    {
        public virtual User User { get; set; } = UserFactory.Instance.Create();
        public virtual Role Role { get; set; } = RoleFactory.Instance.Create();
    }

    public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> b)
        {
            b.HasKey(e => e.ID);
            b.HasOne(e => e.User).WithMany(e => e.Roles).HasForeignKey(e => e.User.ID);
            b.HasOne(e => e.Role).WithMany(e => e.Users).HasForeignKey(e => e.Role.ID);
            b.Property(e => e.Remarks).HasMaxLength(100);
        }
    }
}
