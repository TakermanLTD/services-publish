using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Takerman.Publishing.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameProjectPlatformSecrets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectPlatformRecords");

            migrationBuilder.CreateTable(
                name: "ProjectPlatformSecrets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectPlatformId = table.Column<int>(type: "int", nullable: false)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPlatformSecrets_ProjectPlatformId",
                table: "ProjectPlatformSecrets",
                column: "ProjectPlatformId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectPlatformSecrets");

            migrationBuilder.CreateTable(
                name: "ProjectPlatformRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectPlatformId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPlatformRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectPlatformRecords_ProjectPlatforms_ProjectPlatformId",
                        column: x => x.ProjectPlatformId,
                        principalTable: "ProjectPlatforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPlatformRecords_ProjectPlatformId",
                table: "ProjectPlatformRecords",
                column: "ProjectPlatformId");
        }
    }
}
