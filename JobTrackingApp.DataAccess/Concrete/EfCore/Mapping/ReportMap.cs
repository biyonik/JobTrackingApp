using JobTrackingApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobTrackingApp.DataAccess.Concrete.EfCore.Mapping
{
    public class ReportMap: IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("Reports");
            
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id)
                .UseIdentityColumn();
            
            builder.Property(i => i.Description)
                .HasMaxLength(100)
                .IsRequired();
            
            builder.Property(i => i.Detail)
                .HasColumnType("ntext");

            builder.HasOne(i => i.Task)
                .WithMany(i => i.Reports)
                .HasForeignKey(i => i.TaskId);

        }
    }
}