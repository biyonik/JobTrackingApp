using JobTrackingApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobTrackingApp.DataAccess.Concrete.EfCore.Mapping
{
    public class PriorityMap: IEntityTypeConfiguration<Priority>
    {
        public void Configure(EntityTypeBuilder<Priority> builder)
        {
            builder.ToTable("Priorities");
            builder.Property(p => p.Level).HasMaxLength(100);
        }
    }
}