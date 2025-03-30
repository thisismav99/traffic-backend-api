using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrafficBackendAPI.UserModule.Models;

namespace TrafficBackendAPI.UserModule.ModelMappings
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
            builder.Property(x => x.IsActive).IsRequired();

            builder.HasOne(x => x.User)
                   .WithMany()
                   .HasForeignKey(f => f.UserId)
                   .OnDelete(DeleteBehavior.ClientCascade);

            builder.ToTable("AddressTable");
        }
    }
}
