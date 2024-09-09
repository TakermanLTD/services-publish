using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Takerman.Publishing.Data.Migrations
{
    /// <inheritdoc />
    public partial class PublicationsChangeStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "PublicationVideos");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "PublicationTweets");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "PublicationShorts");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "PublicationSellings");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "PublicationPictures");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "PublicationBlogposts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "PublicationVideos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "PublicationTweets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "PublicationShorts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "PublicationSellings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "PublicationPictures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "PublicationBlogposts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
