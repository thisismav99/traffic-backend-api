using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrafficBackendAPI.UserModule.Models;

namespace TrafficBackendAPI.UserModule.ModelMappings
{
    internal class UserModelMapping : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.MiddleName).HasMaxLength(30);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.IsAnonymous).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired();
            builder.Property(x => x.DateCreated).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();

            builder.ToTable("UserTable");
        }
    }
}
