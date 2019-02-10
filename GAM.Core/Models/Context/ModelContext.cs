using System.Reflection;
using GAM.Core.IApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GAM.Core.Models.Context
{
    public class ModelContext: DbContext, IModelContext
    {
        //方式1：创建数据连接配置
        public ModelContext(DbContextOptions<ModelContext> options): base(options) { }

        //方式2：重写父类OnConfiguring函数读取指定的配置文件
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var config = new ConfigurationBuilder().SetBasePath(System.IO.Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        //    optionsBuilder.UseSqlServer(config.GetConnectionString("GamDbConnection"));
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        #region ##表映射
        public DbSet<DepartRoot.Depart> Departs { get; set; }
        public DbSet<RoleRoot.Role> Roles { get; set; }
        public DbSet<MenuRoot.Menu> Menus { get; set; }
        public DbSet<UserRoot.User> Users { get; set; }
        public DbSet<RoleRoot.RoleMenu> RoleMenus { get; set; }
        public DbSet<UserRoot.UserRole> UserRoles { get; set; }
        #endregion
    }
}
