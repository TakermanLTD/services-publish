using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Takerman.Publishing.Data.Migrations
{
    /// <inheritdoc />
    public partial class Relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectPlatformId1",
                table: "ProjectPlatformSecrets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlatformId1",
                table: "PlatformLinks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPlatformSecrets_ProjectPlatformId1",
                table: "ProjectPlatformSecrets",
                column: "ProjectPlatformId1");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformLinks_PlatformId1",
                table: "PlatformLinks",
                column: "PlatformId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PlatformLinks_Platforms_PlatformId1",
                table: "PlatformLinks",
                column: "PlatformId1",
                principalTable: "Platforms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPlatformSecrets_ProjectPlatforms_ProjectPlatformId1",
                table: "ProjectPlatformSecrets",
                column: "ProjectPlatformId1",
                principalTable: "ProjectPlatforms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlatformLinks_Platforms_PlatformId1",
                table: "PlatformLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPlatformSecrets_ProjectPlatforms_ProjectPlatformId1",
                table: "ProjectPlatformSecrets");

            migrationBuilder.DropIndex(
                name: "IX_ProjectPlatformSecrets_ProjectPlatformId1",
                table: "ProjectPlatformSecrets");

            migrationBuilder.DropIndex(
                name: "IX_PlatformLinks_PlatformId1",
                table: "PlatformLinks");

            migrationBuilder.DropColumn(
                name: "ProjectPlatformId1",
                table: "ProjectPlatformSecrets");

            migrationBuilder.DropColumn(
                name: "PlatformId1",
                table: "PlatformLinks");
        }
    }
}
