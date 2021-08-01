using Microsoft.EntityFrameworkCore.Migrations;

namespace BestyAlbums.Data.Migrations
{
    public partial class AddedImageUrlPropertyToArtist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Members_ArtistId",
                table: "Members");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_Name_AlbumId",
                table: "Songs",
                columns: new[] { "Name", "AlbumId" },
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Members_ArtistId_FirstName_LastName",
                table: "Members",
                columns: new[] { "ArtistId", "FirstName", "LastName" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Songs_Name_AlbumId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Members_ArtistId_FirstName_LastName",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Artists");

            migrationBuilder.CreateIndex(
                name: "IX_Members_ArtistId",
                table: "Members",
                column: "ArtistId");
        }
    }
}
