using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrafficBackendAPI.UserAddressModule.Models;

namespace TrafficBackendAPI.UserAddressModule.ModelMappings
{
    internal class AddressModelMapping : IEntityTypeConfiguration<AddressModel>
    {
        public void Configure(EntityTypeBuilder<AddressModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.LotNo).HasMaxLength(10);
            builder.Property(x => x.Street).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Barangay).IsRequired().HasMaxLength(50);
            builder.Property(x => x.City).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Region).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Country).IsRequired().HasMaxLength(50);
            builder.Property(x => x.PostalCode).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired();
            builder.Property(x => x.DateCreated).IsRequired();
            builder.Property(x => x.UpdatedBy);
            builder.Property(x => x.DateUpdated);
            builder.Property(x => x.IsActive).IsRequired();

            builder.HasIndex(x => x.UserId)
                .IsUnique()
                .HasDatabaseName("Address_UserId");

            builder.ToTable("AddressTable");
        }
    }
}
