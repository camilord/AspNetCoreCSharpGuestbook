using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Guestbook.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Guestbook.Models;

namespace Guestbook
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
            services.AddDbContext<GuestbookDataContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("GuestbookDataContext");
                options.UseSqlServer(connectionString);
            });

            // load config from appsettings.json
            SystemConfig config = new SystemConfig {
                RecaptchaSiteKey = Configuration["Recaptcha:SiteKey"],
                RecaptchaSecretKey = Configuration["Recaptcha:SecretKey"]
            };
            services.AddTransient<SystemConfig>(options => config);

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "guestbook",
                    pattern: "{controller=Guestbook}/{action=Index}/{id?}");
            });
        }
    }
}
