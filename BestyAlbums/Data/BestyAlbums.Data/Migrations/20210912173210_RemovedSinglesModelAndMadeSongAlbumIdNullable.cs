using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BestyAlbums.Data.Migrations
{
    public partial class RemovedSinglesModelAndMadeSongAlbumIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Singles");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Singles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    ProductionTimeInDays = table.Column<int>(type: "int", nullable: true),
                    Released = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudioType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Singles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Singles_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Songs_Name_AlbumId",
                table: "Songs",
                columns: new[] { "Name", "AlbumId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Singles_ArtistId",
                table: "Singles",
                column: "ArtistId");
        }
    }
}
