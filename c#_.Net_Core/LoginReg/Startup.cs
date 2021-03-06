using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LoginReg.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginReg
{
    public class Startup
    {
        public Startup (IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices (IServiceCollection services)
        {
            services.AddDbContext<MyContext>(dbCtxOptions =>
        {
            dbCtxOptions.UseMySql(Configuration["DBInfo:ConnectionString"], mySqlOptions => mySqlOptions.EnableRetryOnFailure());
        });
            services.AddHttpContextAccessor();
            services.AddSession();
            services.AddDbContext<MyContext>(options => options.UseMySql (Configuration["DBInfo:ConnectionString"]));
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
        {
        app.UseDeveloperExceptionPage();
        }
        else
        {
        app.UseExceptionHandler("/Home/Error");
        }

        // css, js, and image files can now be added to wwwroot folder
        app.UseStaticFiles();
        app.UseSession();
        app.UseMvc(routes =>
        {
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
        });
        }
    }
}
