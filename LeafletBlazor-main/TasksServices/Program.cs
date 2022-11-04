using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using TasksServices.Model;
using static TasksServices.Model.ServerData;

namespace TasksServices
{

    public class Program
    {


    public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            /*var host = CreateHostBuilder(args).Build();
            CreateDbIfNotExists(host);
            host.Run();*/
            
        }
/*         private static void CreateDbIfNotExists(IHost host)
         {
             using (var scope = host.Services.CreateScope())
             {
                 var services = scope.ServiceProvider;
                 try
                 {
                     var context = services.GetRequiredService<ServerData>();
                     DbInitializer.Initialize(context);
                 }
                 catch (Exception ex)
                 {
                     var logger = services.GetRequiredService<ILogger<Program>>();
                     logger.LogError(ex, "An error occurred creating the DB.");
                 }
             }
         }
*/

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        /* public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args);*/
    }
}

