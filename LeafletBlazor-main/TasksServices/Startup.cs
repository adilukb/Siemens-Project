using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PinPoints;
using Repository;
using System.IO;
using System.Reflection;


namespace TasksServices
{

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<RepositoryContext>(opts =>
                           opts.UseSqlServer(Configuration.GetConnectionString("sqlConnection")));

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        //Add the Client application URLs (enable: Cross-origin resource sharing (CORS))
                        policy.WithOrigins("https://localhost:44357",
                                           "https://localhost:44397");
                    });
            });

            /*  services.Configure<IISOptions>(options =>
              {

              });*/

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //var assembly = typeof(PinPoints.Presentation.AssemblyReference).Assembly;
            //services.AddMvc().AddApplicationPart(assembly).AddControllersAsServices();

            services.AddScoped<IRepositoryManager, RepositoryManager>();

            //services.AddScoped<IServiceManager, ServiceManager>();


           
 
            //services.AddController.AddApplicationPart(typeof(PinPoints.Presentation.AssemblyReference).Assembly);
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();

            app.UseMvc();


        }
        
    }
}
