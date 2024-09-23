using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Takerman.Publishing.Data.Migrations
{
    /// <inheritdoc />
    public partial class SecretValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "ProjectPlatformSecrets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "ProjectPlatformSecrets");
        }
    }
}
