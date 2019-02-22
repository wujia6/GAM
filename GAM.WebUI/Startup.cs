using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using GAM.Application.SourceMapper;
using GAM.Core.Models.Context;
using AutoMapper;

namespace GAM.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            Configuration = config;
            Mapping.Initialize();   //初始化映射关系
        }

        public IConfiguration Configuration { get; }

        //服务配置
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SqlLocalContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlConn")));
            //services.AddScoped(typeof(IRepository<T>),typeof(EFCore<T>))

            services.AddMvc();
            services.AddSession();
            services.AddAutoMapper();
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
