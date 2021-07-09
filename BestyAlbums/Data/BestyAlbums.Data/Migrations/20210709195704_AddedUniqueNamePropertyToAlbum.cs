using Microsoft.EntityFrameworkCore.Migrations;

namespace BestyAlbums.Data.Migrations
{
    public partial class AddedUniqueNamePropertyToAlbum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Albums",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Albums_Name",
                table: "Albums",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Albums_Name",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Albums");
        }
    }
}
