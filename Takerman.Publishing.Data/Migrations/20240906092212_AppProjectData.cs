using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Takerman.Publishing.Data.Migrations
{
    /// <inheritdoc />
    public partial class AppProjectData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlatformsMappings");

            migrationBuilder.DropTable(
                name: "PlatformsConfigData");

            migrationBuilder.CreateTable(
                name: "PlatformsData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Platform = table.Column<int>(type: "int", nullable: false),
                    ClientUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientSecret = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Limit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformsData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectPlatforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    PlatformDataId = table.Column<int>(type: "int", nullable: false),
                    PostType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPlatforms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectPlatforms_PlatformsData_PlatformDataId",
                        column: x => x.PlatformDataId,
                        principalTable: "PlatformsData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectPlatforms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPlatforms_PlatformDataId",
                table: "ProjectPlatforms",
                column: "PlatformDataId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPlatforms_ProjectId",
                table: "ProjectPlatforms",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectPlatforms");

            migrationBuilder.DropTable(
                name: "PlatformsData");

            migrationBuilder.CreateTable(
                name: "PlatformsConfigData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientSecret = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Limit = table.Column<int>(type: "int", nullable: false),
                    Platform = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformsConfigData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlatformsMappings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlatformConfigDataId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    PostType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformsMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlatformsMappings_PlatformsConfigData_PlatformConfigDataId",
                        column: x => x.PlatformConfigDataId,
                        principalTable: "PlatformsConfigData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlatformsMappings_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlatformsMappings_PlatformConfigDataId",
                table: "PlatformsMappings",
                column: "PlatformConfigDataId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformsMappings_ProjectId",
                table: "PlatformsMappings",
                column: "ProjectId");
        }
    }
}
