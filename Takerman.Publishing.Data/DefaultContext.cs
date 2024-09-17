using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Takerman.Publishing.Data.Entities;

namespace Takerman.Publishing.Data
{
    public class DefaultContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Platform> Platforms { get; set; }

        public DbSet<PlatformLink> PlatformLinks { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PostType> PostTypes { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectPlatform> ProjectPlatforms { get; set; }

        public DbSet<ProjectPlatformRecord> ProjectPlatformRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<Platform>().HasData(
                    new Platform { Name = "Aliexpress", Id = 1 },
                    new Platform { Name = "Alobg", Id = 2 },
                    new Platform { Name = "Amazon", Id = 3 },
                    new Platform { Name = "Bazar", Id = 4 },
                    new Platform { Name = "Ebay", Id = 5 },
                    new Platform { Name = "Emag", Id = 6 },
                    new Platform { Name = "Facebook", Id = 7 },
                    new Platform { Name = "FreeMusicArchive", Id = 8 },
                    new Platform { Name = "Imdb", Id = 9 },
                    new Platform { Name = "Instagram", Id = 10 },
                    new Platform { Name = "Jamendo", Id = 11 },
                    new Platform { Name = "LinkedIn", Id = 12 },
                    new Platform { Name = "Olx", Id = 13 },
                    new Platform { Name = "Pexels", Id = 14 },
                    new Platform { Name = "Spotify", Id = 15 },
                    new Platform { Name = "TikTok", Id = 16 },
                    new Platform { Name = "Tmdb", Id = 17 },
                    new Platform { Name = "Vimeo", Id = 18 },
                    new Platform { Name = "X", Id = 19 },
                    new Platform { Name = "YouTube", Id = 20 },
                    new Platform { Name = "Wordpress", Id = 21 },
                    new Platform { Name = "Medium", Id = 22 },
                    new Platform { Name = "Blogger", Id = 23 }
                );

            builder.Entity<PostType>().HasData(
                new PostType() { Name = "Video", Id = 1 },
                new PostType() { Name = "Short", Id = 2 },
                new PostType() { Name = "Blogpost", Id = 3 },
                new PostType() { Name = "Tweet", Id = 4 },
                new PostType() { Name = "Selling", Id = 5 },
                new PostType() { Name = "Picture", Id = 6 }
                );

            builder.Entity<Project>().HasData(
                new Project() { Name = "takerprint", Id = 1 },
                new Project() { Name = "dating", Id = 2 },
                new Project() { Name = "takerman", Id = 3 },
                new Project() { Name = "tanyoProfessional", Id = 4 },
                new Project() { Name = "tanyoPersonal", Id = 5 }
                );
        }
    }
}