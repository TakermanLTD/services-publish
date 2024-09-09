using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Takerman.Publishing.Data.Entities;

namespace Takerman.Publishing.Data
{
    public class DefaultContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectPlatform> ProjectPlatforms { get; set; }

        public DbSet<PublicationBlogpost> PublicationBlogposts { get; set; }

        public DbSet<PublicationPicture> PublicationPictures { get; set; }

        public DbSet<PublicationSelling> PublicationSellings { get; set; }

        public DbSet<PublicationShort> PublicationShorts { get; set; }

        public DbSet<PublicationTweet> PublicationTweets { get; set; }

        public DbSet<PublicationVideo> PublicationVideos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}