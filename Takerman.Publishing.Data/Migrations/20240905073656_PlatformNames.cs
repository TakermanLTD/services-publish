using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Takerman.Publishing.Data.Migrations
{
    /// <inheritdoc />
    public partial class PlatformNames : Migration
    {
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTypes_Projects_ProjectId",
                table: "PostTypes");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_PostTypes_ProjectId",
                table: "PostTypes");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "PostTypes");

            migrationBuilder.DropColumn(
                name: "Platform",
                table: "PlatformConfigs");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PostTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PlatformConfigs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "PostTypes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PlatformConfigs");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "PostTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Platform",
                table: "PlatformConfigs",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_PostTypes_ProjectId",
                table: "PostTypes",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostTypes_Projects_ProjectId",
                table: "PostTypes",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}