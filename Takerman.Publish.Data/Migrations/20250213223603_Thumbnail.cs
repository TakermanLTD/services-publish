using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Takerman.Publish.Data.Migrations
{
    /// <inheritdoc />
    public partial class Thumbnail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Thumbnail",
                table: "Posts",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Thumbnail",
                table: "Posts");
        }
    }
}
