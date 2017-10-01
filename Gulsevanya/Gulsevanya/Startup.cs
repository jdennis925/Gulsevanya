using Gulsevanya.Hubs;
using Gulsevanya.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Gulsevanya
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors(config => config.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseSignalR(routes =>
            {
                routes.MapHub<LobbyHub>("LobbyHub");
            });
            app.UseMvc();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            // Setup options with DI
            services.AddOptions();


            services.AddSignalR();

            services.AddSingleton<ILobbyRepository, LobbyRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();

            

            services.AddMvc();
        }
    }
}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Options;
//using Gulsevanya.Repositories;
//using Gulsevanya.Hubs;
//using Microsoft.AspNetCore.Sockets;

//namespace Gulsevanya
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }

//            app.UseCors(config => config.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

//            app.UseDefaultFiles();
//            app.UseStaticFiles();


//            app.UseSignalR(routes =>
//            {
//                routes.MapHub<LobbyHub>("LobbyHub");
//            });

//            app.UseMvc();
//        }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.AddCors();

//            services.AddOptions();

//            services.AddSingleton<ILobbyRepository, LobbyRepository>();

//            services.AddMvc();
//        }
//    }
//}
