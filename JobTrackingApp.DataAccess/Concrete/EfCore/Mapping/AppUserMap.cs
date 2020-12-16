using JobTrackingApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobTrackingApp.DataAccess.Concrete.EfCore.Mapping
{
    public class AppUserMap: IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(u => u.FirstName)
                    .HasMaxLength(100);
            builder.Property(u => u.SurName)
                    .HasMaxLength(100);

            builder.HasMany(u => u.Tasks)
                .WithOne(t => t.AppUser)
                .HasForeignKey(t => t.AppUserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}