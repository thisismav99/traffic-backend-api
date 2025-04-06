using Microsoft.EntityFrameworkCore;
using TrafficBackendAPI.UserModule.ModelMappings;

namespace TrafficBackendAPI.UserModule
{
    public class UserDbContext : DbContext
    {
        #region Constructor
        public UserDbContext(DbContextOptions<UserDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        #endregion

        #region Method
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserModelMapping());
        }
        #endregion
    }
}
