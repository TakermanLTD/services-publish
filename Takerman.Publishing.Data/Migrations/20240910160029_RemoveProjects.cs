using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Takerman.Publishing.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveProjects : Migration
    {
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Project",
                table: "ProjectPlatforms",
                newName: "ProjectId");

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPlatforms_ProjectId",
                table: "ProjectPlatforms",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPlatforms_Projects_ProjectId",
                table: "ProjectPlatforms",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPlatforms_Projects_ProjectId",
                table: "ProjectPlatforms");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_ProjectPlatforms_ProjectId",
                table: "ProjectPlatforms");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "ProjectPlatforms",
                newName: "Project");
        }
    }
}