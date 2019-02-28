using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Autofac.Extensions.DependencyInjection;
using GAM.Core.Models.Context;
using System;

namespace GAM.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();

            //autofac集成到Asp.net Core中
            //添加Autofac.Extensions.DependencyInjection命名空间引用
            //挂载autofac到startup管道中
            var host = new WebHostBuilder()
                .UseKestrel()
                .ConfigureServices(services => services.AddAutofac())
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            IServiceProvider provide = (IServiceProvider)host.Services.GetService(typeof(SqlLocalContext));
            //添加初始化数据
            DbInitialize.Initialize(provide);
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
