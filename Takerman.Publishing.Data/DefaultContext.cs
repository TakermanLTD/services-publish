using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Takerman.Publishing.Data.Entities;

namespace Takerman.Publishing.Data
{
    public class DefaultContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Platform> Platforms { get; set; }

        public DbSet<PlatformLink> PlatformLinks { get; set; }

        public DbSet<PlatformSecret> PlatformSecrets { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PostType> PostTypes { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectPlatform> ProjectPlatforms { get; set; }

        public DbSet<ProjectPlatformSecret> ProjectPlatformSecrets { get; set; }

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

            builder.Entity<Platform>()
                .HasMany(x => x.PlatformLinks).WithOne().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Platform>()
                .Navigation(x => x.PlatformLinks)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Entity<Platform>()
                .HasMany(x => x.PlatformSecrets).WithOne().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Platform>()
                .Navigation(x => x.PlatformSecrets)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Entity<PlatformLink>()
                .HasOne(x => x.Platform).WithMany().HasForeignKey(x => x.PlatformId).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Post>()
                .HasOne(x => x.ProjectPlatform).WithMany().HasForeignKey(x => x.ProjectPlatfromId);

            builder.Entity<Post>()
                .Navigation(x => x.ProjectPlatform)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Entity<ProjectPlatform>()
                .HasOne(x => x.Platform).WithMany().HasForeignKey(x => x.PlatformId).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ProjectPlatform>()
                .Navigation(x => x.Platform)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Entity<ProjectPlatform>()
                .HasOne(x => x.PostType).WithMany().HasForeignKey(x => x.PostTypeId).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ProjectPlatform>()
                .Navigation(x => x.PostType)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Entity<ProjectPlatform>()
                .HasOne(x => x.Project).WithMany().HasForeignKey(x => x.ProjectId).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ProjectPlatform>()
                .HasMany(x => x.PlatformSecrets).WithOne().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProjectPlatform>()
                .Navigation(x => x.PlatformSecrets)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Entity<PlatformSecret>()
                .HasOne(x => x.Platform).WithMany().HasForeignKey(x => x.PlatformId);

            builder.Entity<PlatformSecret>()
                .Navigation(x => x.Platform)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Entity<ProjectPlatformSecret>()
                .HasOne(x => x.PlatformSecret).WithMany().HasForeignKey(x => x.PlatformSecretId).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ProjectPlatformSecret>()
                .Navigation(x => x.PlatformSecret)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Entity<ProjectPlatformSecret>()
                .HasOne(x => x.ProjectPlatform).WithMany().HasForeignKey(x => x.ProjectPlatformId).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ProjectPlatformSecret>()
                .Navigation(x => x.ProjectPlatform)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}