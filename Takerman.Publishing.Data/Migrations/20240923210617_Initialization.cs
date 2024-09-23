using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Takerman.Publishing.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DatePublished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pictures = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Videos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlatformLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlatformId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlatformLinks_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlatformSecrets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlatformId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformSecrets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlatformSecrets_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlatformPostTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlatformId = table.Column<int>(type: "int", nullable: false),
                    PostTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformPostTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlatformPostTypes_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlatformPostTypes_PostTypes_PostTypeId",
                        column: x => x.PostTypeId,
                        principalTable: "PostTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectSecrets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlatformId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    PlatformSecretId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSecrets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectSecrets_PlatformSecrets_PlatformSecretId",
                        column: x => x.PlatformSecretId,
                        principalTable: "PlatformSecrets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectSecrets_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectSecrets_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Aliexpress" },
                    { 2, "Alobg" },
                    { 3, "Amazon" },
                    { 4, "Bazar" },
                    { 5, "Ebay" },
                    { 6, "Emag" },
                    { 7, "Facebook" },
                    { 8, "FreeMusicArchive" },
                    { 9, "Imdb" },
                    { 10, "Instagram" },
                    { 11, "Jamendo" },
                    { 12, "LinkedIn" },
                    { 13, "Olx" },
                    { 14, "Pexels" },
                    { 15, "Spotify" },
                    { 16, "TikTok" },
                    { 17, "Tmdb" },
                    { 18, "Vimeo" },
                    { 19, "X" },
                    { 20, "YouTube" },
                    { 21, "Wordpress" },
                    { 22, "Medium" },
                    { 23, "Blogger" }
                });

            migrationBuilder.InsertData(
                table: "PostTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Video" },
                    { 2, "Short" },
                    { 3, "Blogpost" },
                    { 4, "Tweet" },
                    { 5, "Selling" },
                    { 6, "Picture" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "takerprint", 0 },
                    { 2, "dating", 0 },
                    { 3, "takerman", 0 },
                    { 4, "tanyoProfessional", 0 },
                    { 5, "tanyoPersonal", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlatformLinks_PlatformId",
                table: "PlatformLinks",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformPostTypes_PlatformId",
                table: "PlatformPostTypes",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformPostTypes_PostTypeId",
                table: "PlatformPostTypes",
                column: "PostTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformSecrets_PlatformId",
                table: "PlatformSecrets",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSecrets_PlatformId",
                table: "ProjectSecrets",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSecrets_PlatformSecretId",
                table: "ProjectSecrets",
                column: "PlatformSecretId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSecrets_ProjectId",
                table: "ProjectSecrets",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlatformLinks");

            migrationBuilder.DropTable(
                name: "PlatformPostTypes");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "ProjectSecrets");

            migrationBuilder.DropTable(
                name: "PostTypes");

            migrationBuilder.DropTable(
                name: "PlatformSecrets");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Platforms");
        }
    }
}
