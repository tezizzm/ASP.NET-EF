using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Steeltoe.Extensions.Configuration.CloudFoundry;
using Steeltoe.Extensions.Logging;

namespace EntityFramework6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webHost = CreateWebHostBuilder(args).Build();
            using (var scope = webHost.Services.CreateScope())
            {
                var teamContext = scope.ServiceProvider.GetService<TeamContext>();
                teamContext.InitializeData();
            }
            webHost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseCloudFoundryHosting(5555)
                .AddCloudFoundry()
                .ConfigureLogging(
                    (builderContext, loggingBuilder) =>
                    {
                        loggingBuilder.ClearProviders();
                        loggingBuilder.AddConfiguration(builderContext.Configuration.GetSection("Logging"));
                        loggingBuilder.AddDynamicConsole();
                    })
                .UseStartup<Startup>();
    }
}
