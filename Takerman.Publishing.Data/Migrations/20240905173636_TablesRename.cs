using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Takerman.Publishing.Data.Migrations
{
    /// <inheritdoc />
    public partial class TablesRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTypes_PlatformConfigs_PlatformConfigDataId",
                table: "PostTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTypes_Projects_ProjectId",
                table: "PostTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTypes",
                table: "PostTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlatformConfigs",
                table: "PlatformConfigs");

            migrationBuilder.RenameTable(
                name: "PostTypes",
                newName: "PlatformsMappings");

            migrationBuilder.RenameTable(
                name: "PlatformConfigs",
                newName: "PlatformsConfigData");

            migrationBuilder.RenameIndex(
                name: "IX_PostTypes_ProjectId",
                table: "PlatformsMappings",
                newName: "IX_PlatformsMappings_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_PostTypes_PlatformConfigDataId",
                table: "PlatformsMappings",
                newName: "IX_PlatformsMappings_PlatformConfigDataId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlatformsMappings",
                table: "PlatformsMappings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlatformsConfigData",
                table: "PlatformsConfigData",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlatformsMappings_PlatformsConfigData_PlatformConfigDataId",
                table: "PlatformsMappings",
                column: "PlatformConfigDataId",
                principalTable: "PlatformsConfigData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlatformsMappings_Projects_ProjectId",
                table: "PlatformsMappings",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlatformsMappings_PlatformsConfigData_PlatformConfigDataId",
                table: "PlatformsMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_PlatformsMappings_Projects_ProjectId",
                table: "PlatformsMappings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlatformsMappings",
                table: "PlatformsMappings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlatformsConfigData",
                table: "PlatformsConfigData");

            migrationBuilder.RenameTable(
                name: "PlatformsMappings",
                newName: "PostTypes");

            migrationBuilder.RenameTable(
                name: "PlatformsConfigData",
                newName: "PlatformConfigs");

            migrationBuilder.RenameIndex(
                name: "IX_PlatformsMappings_ProjectId",
                table: "PostTypes",
                newName: "IX_PostTypes_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_PlatformsMappings_PlatformConfigDataId",
                table: "PostTypes",
                newName: "IX_PostTypes_PlatformConfigDataId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTypes",
                table: "PostTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlatformConfigs",
                table: "PlatformConfigs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostTypes_PlatformConfigs_PlatformConfigDataId",
                table: "PostTypes",
                column: "PlatformConfigDataId",
                principalTable: "PlatformConfigs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
