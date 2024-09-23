using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Takerman.Publishing.Data.Migrations
{
    /// <inheritdoc />
    public partial class PlatformSecrets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectPlatformSecrets");

            migrationBuilder.CreateTable(
                name: "PlatformSecrets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlatformId = table.Column<int>(type: "int", nullable: false),
                    ProjectPlatformId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformSecrets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlatformSecrets_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlatformSecrets_ProjectPlatforms_ProjectPlatformId",
                        column: x => x.ProjectPlatformId,
                        principalTable: "ProjectPlatforms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlatformSecrets_PlatformId",
                table: "PlatformSecrets",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformSecrets_ProjectPlatformId",
                table: "PlatformSecrets",
                column: "ProjectPlatformId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlatformSecrets");

            migrationBuilder.CreateTable(
                name: "ProjectPlatformSecrets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectPlatformId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectPlatformId1 = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPlatformSecrets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectPlatformSecrets_ProjectPlatforms_ProjectPlatformId",
                        column: x => x.ProjectPlatformId,
                        principalTable: "ProjectPlatforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectPlatformSecrets_ProjectPlatforms_ProjectPlatformId1",
                        column: x => x.ProjectPlatformId1,
                        principalTable: "ProjectPlatforms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPlatformSecrets_ProjectPlatformId",
                table: "ProjectPlatformSecrets",
                column: "ProjectPlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPlatformSecrets_ProjectPlatformId1",
                table: "ProjectPlatformSecrets",
                column: "ProjectPlatformId1");
        }
    }
}
