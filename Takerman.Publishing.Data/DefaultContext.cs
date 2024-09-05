using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Takerman.Publishing.Data
{
    public class DefaultContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectPlatformsPosts> PlatformsMappings { get; set; }

        public DbSet<PlatformConfigData> PlatformsConfigData { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}