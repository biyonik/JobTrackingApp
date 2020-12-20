using JobTrackingApp.BusinessLogic.Concrete;
using JobTrackingApp.BusinessLogic.Interfaces;
using JobTrackingApp.DataAccess.Concrete.EfCore.Contexts;
using JobTrackingApp.DataAccess.Concrete.EfCore.Repositories;
using JobTrackingApp.DataAccess.Interfaces;
using JobTrackingApp.Entities.Concrete;
using JobTrackingApp.WebUI.Middlewares;
using JobTrackingApp.WebUI.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static JobTrackingApp.WebUI.IdentityInitializer;

namespace JobTrackingApp.WebUI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskManager>();
            services.AddScoped<IPriorityService, PriorityManager>();
            services.AddScoped<IReportService, ReportManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            
            services.AddScoped<ITaskDAL, EfTaskRepository>();
            services.AddScoped<IPriorityDAL, EfPriorityRepository>();
            services.AddScoped<IReportDAL, EfReportRepository>();
            services.AddScoped<IAppUserDAL, EfAppUserRepository>();
            
            services.AddDbContext<JobTrackingContext>();
            services.AddIdentity<AppUser, AppRole>(CustomIdentityOptions.GetIdentityOptions())
                    .AddEntityFrameworkStores<JobTrackingContext>();

            services.ConfigureApplicationCookie(CustomCookieAuthenticationOptions.GetCookieAuthOptions());
            services.AddControllersWithViews();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            SeedData(userManager, roleManager).Wait();
            app.UseDefaultFiles();
            app.UseStaticFiles(CustomStaticFileOptions.GetFileOptions(app, env, "node_modules"));
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"areas",
                    pattern:"{area}/{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name:"default",
                    pattern:"{controller=Home}/{action=Index}/{id?}"
                );
                
            });
        }
    }
}