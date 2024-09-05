using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Takerman.Publishing.Data
{
    public class DefaultContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<PlatformPostType> PostTypes { get; set; }

        public DbSet<PlatformConfigData> PlatformConfigs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}