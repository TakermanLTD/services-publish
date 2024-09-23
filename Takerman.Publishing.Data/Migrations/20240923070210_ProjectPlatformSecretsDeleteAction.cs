using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Takerman.Publishing.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProjectPlatformSecretsDeleteAction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlatformLinks_Platforms_PlatformId",
                table: "PlatformLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_PlatformSecrets_Platforms_PlatformId",
                table: "PlatformSecrets");

            migrationBuilder.DropForeignKey(
                name: "FK_PlatformSecrets_ProjectPlatforms_ProjectPlatformId",
                table: "PlatformSecrets");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_ProjectPlatforms_ProjectPlatfromId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPlatforms_Platforms_PlatformId",
                table: "ProjectPlatforms");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPlatforms_PostTypes_PostTypeId",
                table: "ProjectPlatforms");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPlatforms_Projects_ProjectId",
                table: "ProjectPlatforms");

            migrationBuilder.DropIndex(
                name: "IX_PlatformSecrets_ProjectPlatformId",
                table: "PlatformSecrets");

            migrationBuilder.DropColumn(
                name: "ProjectPlatformId",
                table: "PlatformSecrets");

            migrationBuilder.AlterColumn<int>(
                name: "PlatformId1",
                table: "PlatformLinks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlatformId2",
                table: "PlatformLinks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProjectPlatformSecrets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectPlatformId = table.Column<int>(type: "int", nullable: false),
                    PlatformSecretId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPlatformSecrets", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PlatformLinks_Platforms_PlatformId",
                table: "PlatformLinks",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlatformSecrets_Platforms_PlatformId",
                table: "PlatformSecrets",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_ProjectPlatforms_ProjectPlatfromId",
                table: "Posts",
                column: "ProjectPlatfromId",
                principalTable: "ProjectPlatforms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPlatforms_Platforms_PlatformId",
                table: "ProjectPlatforms",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPlatforms_PostTypes_PostTypeId",
                table: "ProjectPlatforms",
                column: "PostTypeId",
                principalTable: "PostTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPlatforms_Projects_ProjectId",
                table: "ProjectPlatforms",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlatformLinks_Platforms_PlatformId",
                table: "PlatformLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_PlatformSecrets_Platforms_PlatformId",
                table: "PlatformSecrets");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_ProjectPlatforms_ProjectPlatfromId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPlatforms_Platforms_PlatformId",
                table: "ProjectPlatforms");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPlatforms_PostTypes_PostTypeId",
                table: "ProjectPlatforms");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPlatforms_Projects_ProjectId",
                table: "ProjectPlatforms");

            migrationBuilder.DropTable(
                name: "ProjectPlatformSecrets");

            migrationBuilder.DropColumn(
                name: "PlatformId2",
                table: "PlatformLinks");

            migrationBuilder.AddColumn<int>(
                name: "ProjectPlatformId",
                table: "PlatformSecrets",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlatformId1",
                table: "PlatformLinks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformSecrets_ProjectPlatformId",
                table: "PlatformSecrets",
                column: "ProjectPlatformId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlatformLinks_Platforms_PlatformId",
                table: "PlatformLinks",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlatformSecrets_Platforms_PlatformId",
                table: "PlatformSecrets",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlatformSecrets_ProjectPlatforms_ProjectPlatformId",
                table: "PlatformSecrets",
                column: "ProjectPlatformId",
                principalTable: "ProjectPlatforms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_ProjectPlatforms_ProjectPlatfromId",
                table: "Posts",
                column: "ProjectPlatfromId",
                principalTable: "ProjectPlatforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPlatforms_Platforms_PlatformId",
                table: "ProjectPlatforms",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPlatforms_PostTypes_PostTypeId",
                table: "ProjectPlatforms",
                column: "PostTypeId",
                principalTable: "PostTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPlatforms_Projects_ProjectId",
                table: "ProjectPlatforms",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
