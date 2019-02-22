using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using GAM.Application.AutoMapperExtend;
using GAM.Core.Models.Context;
using AutoMapper;

namespace GAM.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            Configuration = config;
            Configs.Initialize();   //初始化DTO映射关系
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                //  options.CheckConsentNeeded = context => false;实现session,默认是true
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSession();
            services.AddMvc();
            services.AddAutoMapper();
            services.AddDbContext<SqlLocalContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlConn")));
            //services.AddScoped(typeof(IRepository<T>),typeof(EFCore<T>))
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
