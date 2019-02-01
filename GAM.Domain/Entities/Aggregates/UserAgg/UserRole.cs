using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GAM.Domain.Entities.Aggregates.RoleAgg;

namespace GAM.Domain.Entities.Aggregates.UserAgg
{
    public class UserRole : IEntity
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string Remarks { get; set; }
        //导航属性
        public virtual User User { get; set; } = UserFactory.Instance.Create();
        public virtual Role Role { get; set; } = RoleFactory.Instance.Create();
        
    }

    public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> b)
        {
            b.HasKey(e => e.ID);
            b.HasOne(e => e.User).WithMany(e => e.Roles).HasForeignKey(e => e.UserID).IsRequired();
            b.HasOne(e => e.Role).WithMany(e => e.Users).HasForeignKey(e => e.RoleID).IsRequired();
            b.Property(e => e.Remarks).HasMaxLength(100);
        }
    }
}
