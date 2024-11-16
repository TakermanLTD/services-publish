﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Takerman.Publishing.Data;

#nullable disable

namespace Takerman.Publishing.Data.Migrations
{
    [DbContext(typeof(DefaultContext))]
    [Migration("20241116220408_Attachments")]
    partial class Attachments
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Takerman.Publishing.Data.Entities.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("Takerman.Publishing.Data.Entities.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Platforms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Aliexpress"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Alobg"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Amazon"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Bazar"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Ebay"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Emag"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Facebook"
                        },
                        new
                        {
                            Id = 8,
                            Name = "FreeMusicArchive"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Imdb"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Instagram"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Jamendo"
                        },
                        new
                        {
                            Id = 12,
                            Name = "LinkedIn"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Olx"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Pexels"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Spotify"
                        },
                        new
                        {
                            Id = 16,
                            Name = "TikTok"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Tmdb"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Vimeo"
                        },
                        new
                        {
                            Id = 19,
                            Name = "X"
                        },
                        new
                        {
                            Id = 20,
                            Name = "YouTube"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Wordpress"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Medium"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Blogger"
                        });
                });

            modelBuilder.Entity("Takerman.Publishing.Data.Entities.PlatformLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlatformId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlatformId");

                    b.ToTable("PlatformLinks");
                });

            modelBuilder.Entity("Takerman.Publishing.Data.Entities.PlatformPostType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PlatformId")
                        .HasColumnType("int");

                    b.Property<int>("PostTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlatformId");

                    b.HasIndex("PostTypeId");

                    b.ToTable("PlatformPostTypes");
                });

            modelBuilder.Entity("Takerman.Publishing.Data.Entities.PlatformSecret", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlatformId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlatformId");

                    b.ToTable("PlatformSecrets");
                });

            modelBuilder.Entity("Takerman.Publishing.Data.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatePublished")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Takerman.Publishing.Data.Entities.PostType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PostTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Video"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Short"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Blogpost"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Tweet"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Selling"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Picture"
                        });
                });

            modelBuilder.Entity("Takerman.Publishing.Data.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "takerprint",
                            UserId = 0
                        },
                        new
                        {
                            Id = 2,
                            Name = "dating",
                            UserId = 0
                        },
                        new
                        {
                            Id = 3,
                            Name = "takerman",
                            UserId = 0
                        },
                        new
                        {
                            Id = 4,
                            Name = "tanyoProfessional",
                            UserId = 0
                        },
                        new
                        {
                            Id = 5,
                            Name = "tanyoPersonal",
                            UserId = 0
                        });
                });

            modelBuilder.Entity("Takerman.Publishing.Data.Entities.ProjectSecret", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PlatformId")
                        .HasColumnType("int");

                    b.Property<int>("PlatformSecretId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlatformId");

                    b.HasIndex("PlatformSecretId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectSecrets");
                });

            modelBuilder.Entity("Takerman.Publishing.Data.Entities.Attachment", b =>
                {
                    b.HasOne("Takerman.Publishing.Data.Entities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Takerman.Publishing.Data.Entities.PlatformLink", b =>
                {
                    b.HasOne("Takerman.Publishing.Data.Entities.Platform", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("Takerman.Publishing.Data.Entities.PlatformPostType", b =>
                {
                    b.HasOne("Takerman.Publishing.Data.Entities.Platform", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Takerman.Publishing.Data.Entities.PostType", "PostType")
                        .WithMany()
                        .HasForeignKey("PostTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Platform");

                    b.Navigation("PostType");
                });

            modelBuilder.Entity("Takerman.Publishing.Data.Entities.PlatformSecret", b =>
                {
                    b.HasOne("Takerman.Publishing.Data.Entities.Platform", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("Takerman.Publishing.Data.Entities.ProjectSecret", b =>
                {
                    b.HasOne("Takerman.Publishing.Data.Entities.Platform", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Takerman.Publishing.Data.Entities.PlatformSecret", "PlatformSecret")
                        .WithMany()
                        .HasForeignKey("PlatformSecretId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Takerman.Publishing.Data.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Platform");

                    b.Navigation("PlatformSecret");

                    b.Navigation("Project");
                });
#pragma warning restore 612, 618
        }
    }
}
