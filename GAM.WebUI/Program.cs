using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using GAM.Core.Models.Context;
using Autofac.Extensions.DependencyInjection;
using GAM.Core.IApi;
using System;

namespace GAM.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //autofac集成到Asp.net Core中
            //添加Autofac.Extensions.DependencyInjection命名空间引用
            //挂载autofac到startup管道中
            //var host = new WebHostBuilder()
            //    .UseKestrel()
            //    .ConfigureServices(services => services.AddAutofac())
            //    .UseContentRoot(System.IO.Directory.GetCurrentDirectory())
            //    .UseIISIntegration()
            //    .UseStartup<Startup>()
            //    .Build();
            //host.Run();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
