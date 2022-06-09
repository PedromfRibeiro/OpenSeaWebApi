using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenSeaWebApi.Migrations
{
    public partial class eventrefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnimationOriginalUrl",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "AnimationUrl",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "BackgroundColor",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "Decimals",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "ExternalLink",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "ImageOriginalUrl",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "ImagePreviewUrl",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "ImageThumbnailUrl",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "IsNsfw",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "NumSales",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "Permalink",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "TokenMetadata",
                table: "Asset");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnimationOriginalUrl",
                table: "Asset",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnimationUrl",
                table: "Asset",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BackgroundColor",
                table: "Asset",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Decimals",
                table: "Asset",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Asset",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExternalLink",
                table: "Asset",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageOriginalUrl",
                table: "Asset",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePreviewUrl",
                table: "Asset",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageThumbnailUrl",
                table: "Asset",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Asset",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsNsfw",
                table: "Asset",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Asset",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumSales",
                table: "Asset",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Permalink",
                table: "Asset",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TokenMetadata",
                table: "Asset",
                type: "text",
                nullable: true);
        }
    }
}
