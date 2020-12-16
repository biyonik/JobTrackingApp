using JobTrackingApp.DataAccess.Concrete.EfCore.Mapping;
using JobTrackingApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace JobTrackingApp.DataAccess.Concrete.EfCore.Contexts
{
    public class JobTrackingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-NOOAEV8\\SQLEXPRESS;Database=JobTrackingAppDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new JobMap());
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<User> Users { get; set; }
    }
}