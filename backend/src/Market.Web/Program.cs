using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;

namespace Market.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseSerilog((context, logger) =>
                {
                    logger.Enrich
                        .FromLogContext()
                        .Enrich.WithProperty("Environment",
                            context.HostingEnvironment.EnvironmentName)
                        .WriteTo.Console()
                        .WriteTo.File("logs/logs.txt", rollingInterval: RollingInterval.Day)
                        .WriteTo.Seq("http://localhost:5341", apiKey: "secret");
                })
                .UseStartup<Startup>();
    }
}
