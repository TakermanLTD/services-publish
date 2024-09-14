using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Takerman.Publishing.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProjectPlatforms : Migration
    {
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "ProjectPlatforms");

            migrationBuilder.DropColumn(
                name: "ClientSecret",
                table: "ProjectPlatforms");

            migrationBuilder.DropColumn(
                name: "ClientUrl",
                table: "ProjectPlatforms");

            migrationBuilder.RenameColumn(
                name: "Platform",
                table: "ProjectPlatforms",
                newName: "PlatformDataId");

            migrationBuilder.CreateTable(
                name: "PlatformsData",
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
                    table.PrimaryKey("PK_PlatformsData", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPlatforms_PlatformDataId",
                table: "ProjectPlatforms",
                column: "PlatformDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPlatforms_PlatformsData_PlatformDataId",
                table: "ProjectPlatforms",
                column: "PlatformDataId",
                principalTable: "PlatformsData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPlatforms_PlatformsData_PlatformDataId",
                table: "ProjectPlatforms");

            migrationBuilder.DropTable(
                name: "PlatformsData");

            migrationBuilder.DropIndex(
                name: "IX_ProjectPlatforms_PlatformDataId",
                table: "ProjectPlatforms");

            migrationBuilder.RenameColumn(
                name: "PlatformDataId",
                table: "ProjectPlatforms",
                newName: "Platform");

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "ProjectPlatforms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientSecret",
                table: "ProjectPlatforms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientUrl",
                table: "ProjectPlatforms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}