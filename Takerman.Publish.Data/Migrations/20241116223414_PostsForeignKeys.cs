using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Takerman.Publish.Data.Migrations
{
    /// <inheritdoc />
    public partial class PostsForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostTypeId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostTypeId",
                table: "Posts",
                column: "PostTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ProjectId",
                table: "Posts",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_PostTypes_PostTypeId",
                table: "Posts",
                column: "PostTypeId",
                principalTable: "PostTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Projects_ProjectId",
                table: "Posts",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PostTypes_PostTypeId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Projects_ProjectId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PostTypeId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ProjectId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostTypeId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Posts");
        }
    }
}
