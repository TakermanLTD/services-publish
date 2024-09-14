using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Takerman.Publishing.Data.Migrations
{
    /// <inheritdoc />
    public partial class PublicationsProjectId : Migration
    {
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "PublicationVideos");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "PublicationTweets");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "PublicationShorts");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "PublicationSellings");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "PublicationPictures");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "PublicationBlogposts");
        }

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "PublicationVideos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "PublicationTweets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "PublicationShorts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "PublicationSellings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "PublicationPictures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "PublicationBlogposts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}