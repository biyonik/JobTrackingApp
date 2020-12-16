using JobTrackingApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobTrackingApp.DataAccess.Concrete.EfCore.Mapping
{
    public class JobMap: IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.ToTable("Jobs");
            builder.HasKey(j => j.Id);
            builder.Property(j => j.Id).UseIdentityColumn();

            builder.Property(j => j.Name)
                .HasMaxLength(200);

            builder.Property(j => j.Description)
                .HasColumnName("ntext");
            
            
        }
    }
}