using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GAM.Domain.Entities
{
    public class GamDbContext: DbContext, IUnitOfWork
    {
        //public GamDbContext(DbContextOptions<GamDbContext> options) : base(options) { }

        #region ##表映射
        public DbSet<Aggregates.DepartAgg.Depart> Departs { get; set; }
        public DbSet<Aggregates.RoleAgg.Role> Roles { get; set; }
        public DbSet<Aggregates.MenuAgg.Menu> Menus { get; set; }
        public DbSet<Aggregates.UserAgg.User> Users { get; set; }
        public DbSet<Aggregates.RoleAgg.RoleMenu> RoleMenus { get; set; }
        public DbSet<Aggregates.UserAgg.UserRole> UserRoles { get; set; }
        #endregion

        /// <summary>
        /// 重写父函数，设置数据库连接配置文件
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var config = new ConfigurationBuilder().SetBasePath(System.IO.Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            options.UseSqlServer(config.GetConnectionString("GamDbConnection"));
            base.OnConfiguring(options);
        }

        /// <summary>
        /// 重写父函数，映射模型表属性、关系
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
