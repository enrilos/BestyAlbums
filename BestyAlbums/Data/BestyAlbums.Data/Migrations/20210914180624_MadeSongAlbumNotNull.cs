using Microsoft.EntityFrameworkCore.Migrations;

namespace BestyAlbums.Data.Migrations
{
    public partial class MadeSongAlbumNotNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Songs_Name_AlbumId",
                table: "Songs");

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_Name_AlbumId",
                table: "Songs",
                columns: new[] { "Name", "AlbumId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Songs_Name_AlbumId",
                table: "Songs");

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "Songs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_Name_AlbumId",
                table: "Songs",
                columns: new[] { "Name", "AlbumId" },
                unique: true,
                filter: "[AlbumId] IS NOT NULL");
        }
    }
}
