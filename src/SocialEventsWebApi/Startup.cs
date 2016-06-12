using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using SocialEventsWebApi.models;
using Microsoft.Framework.Runtime;
using Microsoft.Framework.Configuration;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;


namespace SocialEventsWebApi
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            var configurationBuilder = new ConfigurationBuilder(appEnv.ApplicationBasePath);

            configurationBuilder.AddJsonFile("config.json");

            configurationBuilder.AddEnvironmentVariables();

            Configuration = configurationBuilder.Build();

        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services
                .AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<SocialEventsAppContext>(options => options.UseSqlServer(Configuration["Data:ConnectionString"]));
        }

        public void Configure(IApplicationBuilder app)
        {
            /*
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
            */
            app.UseMvc();
        }
    }
}
