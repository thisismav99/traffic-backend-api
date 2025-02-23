using Microsoft.EntityFrameworkCore;
using TrafficBackendAPI.UserModule.ModelMappings;

namespace TrafficBackendAPI.UserModule
{
    public class UserDbContext : DbContext
    {
        #region Constructor
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            
        }
        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserModelMapping());
            modelBuilder.ApplyConfiguration(new AddressModelMapping());
        }
        #endregion
    }
}
