using JobTrackingApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobTrackingApp.DataAccess.Concrete.EfCore.Mapping
{
    public class TaskMap: IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable("Tasks");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).UseIdentityColumn();

            builder.Property(t => t.Name)
                .HasMaxLength(200);

            builder.Property(t => t.Description)
                .HasColumnType("ntext");

            builder.HasOne(t => t.Priority)
                .WithMany(t => t.Tasks)
                .HasForeignKey(t => t.PriorityId);
        }
    }
}