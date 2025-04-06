using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrafficBackendAPI.UserContactModule.Models;

namespace TrafficBackendAPI.UserContactModule.ModelMappings
{
    internal class ContactModelMapping : IEntityTypeConfiguration<ContactModel>
    {
        public void Configure(EntityTypeBuilder<ContactModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.TelNo).HasMaxLength(15);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(30);
            builder.Property(x => x.MobileNo).IsRequired().HasMaxLength(15);
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired();
            builder.Property(x => x.DateCreated).IsRequired();
            builder.Property(x => x.UpdatedBy);
            builder.Property(x => x.DateUpdated);
            builder.Property(x => x.IsActive).IsRequired();

            builder.HasIndex(x => x.UserId)
                .IsUnique()
                .HasDatabaseName("Contact_UserId");

            builder.ToTable("ContactTable");
        }
    }
}
