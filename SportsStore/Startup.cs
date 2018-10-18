using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SportsStore.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace SportsStore {

    public class Startup {

        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
           
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:Identity:ConnectionString"]));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();

            app.UseStaticFiles();
          
            app.UseAuthentication();
            app.UseMvc(routes => {
           

                routes.MapRoute(name: null, template: "{controller}/{action}",
                     defaults: new { controller = "Home", action = "Index", productPage = 1 });
            });

 
        }
    }
}
