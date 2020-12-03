using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.IO;

namespace Gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("ocelot.json");
            });

        //public static void Main(string[] args)
        //{
        //    new WebHostBuilder()
        //    .UseKestrel()
        //    .UseContentRoot(Directory.GetCurrentDirectory())
        //    .ConfigureAppConfiguration((hostingContext, config) =>
        //    {
        //        config
        //            .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
        //            .AddJsonFile("appsettings.json", true, true)
        //            .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
        //            .AddJsonFile("ocelot.json")
        //            .AddEnvironmentVariables();
        //    })
        //    .ConfigureServices(s =>
        //    {
        //        s.AddOcelot();
        //    })
        //    .ConfigureLogging((hostingContext, logging) =>
        //    {
        //        //add your logging
        //    })
        //    .UseIISIntegration()
        //    .Configure(app =>
        //    {
        //        app.UseOcelot().Wait();
        //    })
        //    .Build()
        //    .Run();
        //}

    }
}
