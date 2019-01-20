using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GAM.Domain.Entities
{
    public class EFCoreContext: DbContext, IUnitOfWork
    {
        //方式1
        //public EFCoreContext(DbContextOptions<EFCoreContext> options) : base(options) { }

        //方式2
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer(builder.GetConnectionString("SqlConn"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOne(e => e.Department).WithMany(e => e.Users);
            modelBuilder.Entity<UserRole>().HasKey(e => new object[] { e.Role.ID, e.User.ID });
            modelBuilder.Entity<UserRole>().HasOne(e => e.Role).WithMany(e => e.UserRoles).HasForeignKey(e=>e.Role.ID);
            modelBuilder.Entity<UserRole>().HasOne(e => e.User).WithMany(e => e.UserRoles).HasForeignKey(e=>e.User.ID);
            modelBuilder.Entity<RoleMenu>().HasOne(e => e.Role).WithMany(e => e.RoleMenus).HasForeignKey(e => e.Role.ID);
            modelBuilder.Entity<RoleMenu>().HasOne(e => e.Menu).WithOne(e => e.RoleMenu).HasForeignKey<RoleMenu>(e => e.Menu.ID);
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<RoleMenu> RoleMenus { get; set; }
    }
}
