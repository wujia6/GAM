using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace GAM.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region ##autofac集成
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
            #endregion

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
