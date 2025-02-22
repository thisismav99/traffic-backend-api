using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrafficBackendAPI.ReportModule.Models;

namespace TrafficBackendAPI.ReportModule.ModelMappings
{
    internal class ReportModelMapping : IEntityTypeConfiguration<ReportModel>
    {
        public void Configure(EntityTypeBuilder<ReportModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Subject).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(3000);
            builder.Property(x => x.IsUrgent).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired();
            builder.Property(x => x.DateCreated).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();

            builder.ToTable("ReportTable");
        }
    }
}
