using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using GAM.Application.SourceMapper;
using GAM.Core.Models.Context;
using GAM.Repository.EFCore;
using GAM.Core.IApi;
using GAM.Core.Models.DepartRoot;
using GAM.Core.Models.RoleRoot;
using GAM.Core.Models.MenuRoot;
using GAM.Core.Models.UserRoot;
using GAM.Application.DepartApp;
using GAM.Application.RoleApp;
using GAM.Application.MenuApp;
using GAM.Application.UserApp;

namespace GAM.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            Configuration = config;
            //Mapping.Initialize();   //初始化映射关系
        }

        public IConfiguration Configuration { get; }

        //DI容器服务配置
        public void ConfigureServices(IServiceCollection services)
        {
            //DI系统服务
            services.AddMvc();
            services.AddSession();
            services.AddAutoMapper();

            //DI数据库连接服务
            services.AddDbContext<SqlLocalContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlConn")));
            services.AddScoped<ISqlLocalContext, SqlLocalContext>();

            //DI领域仓储
            services.AddScoped<IRepository<Depart>,EfCoreRepository<Depart>>();
            services.AddScoped<IRepository<Role>,EfCoreRepository<Role>>();
            services.AddScoped<IRepository<Menu>,EfCoreRepository<Menu>>();
            services.AddScoped<IRepository<User>,EfCoreRepository<User>>();

            //DI领域服务
            services.AddScoped<IDepartManage, DepartManage>();
            services.AddScoped<IRoleManage, RoleManage>();
            services.AddScoped<IMenuManage, MenuManage>();
            services.AddScoped<IUserManage, UserManage>();

            //DI应用服务
            services.AddScoped<IDepartService, DepartService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IUserService, UserService>();
        }

        //请求管道配置
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //开发环境与生产环境异常处理
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();    
            else
                app.UseExceptionHandler("/Shared/Error");

            //添加初始化数据
            DbInitialize.Initialize(app.ApplicationServices);
            //使用静态文件
            app.UseStaticFiles();
            //启用Session
            app.UseSession();
            //使用MVC，设置默认路由
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
