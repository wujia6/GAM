using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Autofac;
using AutoMapper;
using Autofac.Extensions.DependencyInjection;
using GAM.Application;
using GAM.Core.IApi;
using GAM.Infrastructure.Repos;
using GAM.Core.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace GAM.WebUI
{
    public class Startup
    {
        /// <summary>
        /// 应用程序启动
        /// 参数：系统变量对象
        ///     创建ConfigurationByuilder对象
        ///     指定配置文件路径
        ///     添加指定配置文件
        ///     添加为候补系统变量
        /// </summary>
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional:true, reloadOnChange:true)
                .AddEnvironmentVariables()
                .Build();
            RuleConfigs.Initialize();   //初始化映射器
        }

        public IContainer ApplicationContainer { get; private set;}

        public IConfiguration Configuration { get; private set; }

        //DI注册容器组件服务
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //添加系统服务到ServiceCollection的接口对象services
            services.AddMvc();
            services.AddSession();
            services.AddAutoMapper();
            //services.AddDbContext<SqlLocalContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlConn")));
            //services.AddScoped<SqlLocalContext>();

            #region 手动注册
            //DI数据库连接服务
            //services.AddDbContext<SqlLocalContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlConn")));
            //services.AddScoped<ISqlLocalContext, SqlLocalContext>();
            //DI领域仓储
            // services.AddScoped<IRepository<Depart>,EfCoreRepository<Depart>>();
            // services.AddScoped<IRepository<Role>,EfCoreRepository<Role>>();
            // services.AddScoped<IRepository<Menu>,EfCoreRepository<Menu>>();
            // services.AddScoped<IRepository<User>,EfCoreRepository<User>>();
            //DI领域服务
            // services.AddScoped<IDepartManage, DepartManage>();
            // services.AddScoped<IRoleManage, RoleManage>();
            // services.AddScoped<IMenuManage, MenuManage>();
            // services.AddScoped<IUserManage, UserManage>();
            //DI应用服务
            // services.AddScoped<IDepartService, DepartService>();
            // services.AddScoped<IRoleService, RoleService>();
            // services.AddScoped<IMenuService, MenuService>();
            // services.AddScoped<IUserService, UserService>();
            #endregion
 
            // autofac方式注册1
            // 注册方式2：可再program.cs的main()方法内配置WebHostBuilder的地方调用autofac并挂载到startup管道中
            // 说明：
            //     新建autofac的ContainerBuilder对象builder
            //     注册数据上下文:先注册options，供DbContext初始化使用
            //     注册仓储层组件服务
            //     注册领域层组件服务
            //     注册应用层组件服务
            //     将系统服务填充到builder对象
            //     builder编译IContainer接口对象并赋值ApplicationContainer属性
            //     创建IServiceProvider接口对象并返回
            var cb = new ContainerBuilder();
            cb.Register(options => 
                new DbContextOptionsBuilder<SqlLocalContext>()
                .UseSqlServer(Configuration.GetConnectionString("SqlConn"))
                .Options).InstancePerLifetimeScope();
            cb.RegisterType<SqlLocalContext>().As<ISqlLocalContext>().InstancePerLifetimeScope();
            cb.RegisterGeneric(typeof(EfCoreRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            cb.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t=>t.Name.EndsWith("Manage")).AsImplementedInterfaces();
            cb.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t=>t.Name.EndsWith("Service")).AsImplementedInterfaces();
            cb.Populate(services);
            this.ApplicationContainer = cb.Build();
            return new AutofacServiceProvider(ApplicationContainer);
        }

        //请求管道配置
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //开发环境与生产环境异常处理
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();    
            else
                app.UseExceptionHandler("/Shared/Error");

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

            using (var scope = ApplicationContainer.BeginLifetimeScope())
            {
                var iService = scope.Resolve<ISqlLocalContext>();
                DbInitialize.Seed(iService);
            }
        }
    }
}