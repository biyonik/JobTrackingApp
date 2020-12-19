using JobTrackingApp.BusinessLogic.Concrete;
using JobTrackingApp.BusinessLogic.Interfaces;
using JobTrackingApp.DataAccess.Concrete.EfCore.Contexts;
using JobTrackingApp.DataAccess.Concrete.EfCore.Repositories;
using JobTrackingApp.DataAccess.Interfaces;
using JobTrackingApp.Entities.Concrete;
using JobTrackingApp.WebUI.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JobTrackingApp.WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskManager>();
            services.AddScoped<IPriorityService, PriorityManager>();
            services.AddScoped<IReportService, ReportManager>();
            
            services.AddScoped<ITaskDAL, EfTaskRepository>();
            services.AddScoped<IPriorityDAL, EfPriorityRepository>();
            services.AddScoped<IReportDAL, EfReportRepository>();
            
            services.AddDbContext<JobTrackingContext>();
            services.AddIdentity<AppUser, AppRole>()
                    .AddEntityFrameworkStores<JobTrackingContext>();
            
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
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