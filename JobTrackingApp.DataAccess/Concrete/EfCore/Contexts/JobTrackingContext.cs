using JobTrackingApp.DataAccess.Concrete.EfCore.Mapping;
using JobTrackingApp.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobTrackingApp.DataAccess.Concrete.EfCore.Contexts
{
    public class JobTrackingContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-NOOAEV8\\SQLEXPRESS;Database=JobTrackingAppDb;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new PriorityMap());
            modelBuilder.ApplyConfiguration(new ReportMap());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}