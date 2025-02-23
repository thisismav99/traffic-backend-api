using Microsoft.EntityFrameworkCore;
using TrafficBackendAPI.UserModule.ModelMappings;

namespace TrafficBackendAPI.UserModule
{
    internal class UserDbContext : DbContext
    {
        #region Constructor
        public UserDbContext()
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
