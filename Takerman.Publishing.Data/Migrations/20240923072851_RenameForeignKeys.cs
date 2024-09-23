using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Takerman.Publishing.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlatformSecrets_Platforms_PlatformId",
                table: "PlatformSecrets");

            migrationBuilder.DropColumn(
                name: "PlatformId2",
                table: "PlatformLinks");

            migrationBuilder.AddColumn<int>(
                name: "PlatformId1",
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
                name: "IX_PlatformSecrets_PlatformId1",
                table: "PlatformSecrets",
                column: "PlatformId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PlatformSecrets_Platforms_PlatformId",
                table: "PlatformSecrets",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlatformSecrets_Platforms_PlatformId1",
                table: "PlatformSecrets",
                column: "PlatformId1",
                principalTable: "Platforms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlatformSecrets_Platforms_PlatformId",
                table: "PlatformSecrets");

            migrationBuilder.DropForeignKey(
                name: "FK_PlatformSecrets_Platforms_PlatformId1",
                table: "PlatformSecrets");

            migrationBuilder.DropIndex(
                name: "IX_PlatformSecrets_PlatformId1",
                table: "PlatformSecrets");

            migrationBuilder.DropColumn(
                name: "PlatformId1",
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

            migrationBuilder.AddForeignKey(
                name: "FK_PlatformSecrets_Platforms_PlatformId",
                table: "PlatformSecrets",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id");
        }
    }
}
