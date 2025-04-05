using Microsoft.EntityFrameworkCore;
using TrafficBackendAPI.DatabaseModule.ModelMappings.UserModule;

namespace TrafficBackendAPI.DatabaseModule
{
    public class UserDbContext : DbContext
    {
        #region Constructor
        public UserDbContext(DbContextOptions<UserDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserModelMapping());
            modelBuilder.ApplyConfiguration(new AddressModelMapping());
            modelBuilder.ApplyConfiguration(new ContactModelMapping());
        }
        #endregion
    }
}
