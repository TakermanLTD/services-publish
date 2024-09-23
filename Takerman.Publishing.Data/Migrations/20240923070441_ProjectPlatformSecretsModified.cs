using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Takerman.Publishing.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProjectPlatformSecretsModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectPlatformId1",
                table: "ProjectPlatformSecrets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPlatformSecrets_PlatformSecretId",
                table: "ProjectPlatformSecrets",
                column: "PlatformSecretId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPlatformSecrets_ProjectPlatformId",
                table: "ProjectPlatformSecrets",
                column: "ProjectPlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPlatformSecrets_ProjectPlatformId1",
                table: "ProjectPlatformSecrets",
                column: "ProjectPlatformId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPlatformSecrets_PlatformSecrets_PlatformSecretId",
                table: "ProjectPlatformSecrets",
                column: "PlatformSecretId",
                principalTable: "PlatformSecrets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPlatformSecrets_ProjectPlatforms_ProjectPlatformId",
                table: "ProjectPlatformSecrets",
                column: "ProjectPlatformId",
                principalTable: "ProjectPlatforms",
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
                name: "FK_ProjectPlatformSecrets_PlatformSecrets_PlatformSecretId",
                table: "ProjectPlatformSecrets");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPlatformSecrets_ProjectPlatforms_ProjectPlatformId",
                table: "ProjectPlatformSecrets");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPlatformSecrets_ProjectPlatforms_ProjectPlatformId1",
                table: "ProjectPlatformSecrets");

            migrationBuilder.DropIndex(
                name: "IX_ProjectPlatformSecrets_PlatformSecretId",
                table: "ProjectPlatformSecrets");

            migrationBuilder.DropIndex(
                name: "IX_ProjectPlatformSecrets_ProjectPlatformId",
                table: "ProjectPlatformSecrets");

            migrationBuilder.DropIndex(
                name: "IX_ProjectPlatformSecrets_ProjectPlatformId1",
                table: "ProjectPlatformSecrets");

            migrationBuilder.DropColumn(
                name: "ProjectPlatformId1",
                table: "ProjectPlatformSecrets");
        }
    }
}
