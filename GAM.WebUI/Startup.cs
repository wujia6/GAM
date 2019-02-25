using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using GAM.Application;
using GAM.Core.Models.Context;
using GAM.Repository.EFCore;
using GAM.Core.IApi;
using GAM.Core.Models.DepartRoot;
using GAM.Core.Models.RoleRoot;
using GAM.Core.Models.MenuRoot;
using GAM.Core.Models.UserRoot;
using GAM.Application.IServices;
using GAM.Application.Services;
using System.Reflection;

namespace GAM.WebUI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional:true, reloadOnChange:true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
            //RuleConfigs.Initialize();   //初始化映射器
        }

        public IContainer ApplicationContainer { get; private set;}

        public IConfigurationRoot Configuration { get; private set; }

        //DI注册容器组件服务
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //DI系统服务
            services.AddMvc();
            services.AddSession();
            services.AddAutoMapper();

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

            /// <summary>
            /// autofac方式注册
            /// 步骤说明：
            ///     新建autofac的ContainerBuilder对象builder
            ///     注册数据上下文组件服务
            ///     注册仓储层组件服务
            ///     注册领域层组件服务
            ///     注册应用层组件服务
            ///     将系统服务填充到builder对象
            /// </summary>
            var builder = new ContainerBuilder();
            builder.RegisterType<SqlLocalContext>().As<ISqlLocalContext>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EfCoreRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t=>t.Name.EndsWith("Manage")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t=>t.Name.EndsWith("Service")).AsImplementedInterfaces();
            builder.Populate(services);
            this.ApplicationContainer = builder.Build();
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
