using JobTrackingApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobTrackingApp.DataAccess.Concrete.EfCore.Mapping
{
    public class UserMap: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).UseIdentityColumn();
            
            builder.Property(u => u.Name)
                .HasMaxLength(100)
                .IsRequired();
            
            builder.Property(u => u.SurName)
                .HasMaxLength(100)
                .IsRequired(false);
            
            builder.Property(u => u.Email)
                .HasMaxLength(100)
                .IsRequired();
            
            builder.Property(u => u.Phone)
                .HasMaxLength(50);

            builder.HasMany(u => u.Jobs)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}