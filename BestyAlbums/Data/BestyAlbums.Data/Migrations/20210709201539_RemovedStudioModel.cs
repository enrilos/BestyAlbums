using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BestyAlbums.Data.Migrations
{
    public partial class RemovedStudioModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Studios_StudioId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Singles_Studios_StudioId",
                table: "Singles");

            migrationBuilder.DropTable(
                name: "Studios");

            migrationBuilder.DropIndex(
                name: "IX_Singles_StudioId",
                table: "Singles");

            migrationBuilder.DropIndex(
                name: "IX_Albums_StudioId",
                table: "Albums");

            migrationBuilder.RenameColumn(
                name: "StudioId",
                table: "Singles",
                newName: "StudioType");

            migrationBuilder.RenameColumn(
                name: "StudioId",
                table: "Albums",
                newName: "StudioType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudioType",
                table: "Singles",
                newName: "StudioId");

            migrationBuilder.RenameColumn(
                name: "StudioType",
                table: "Albums",
                newName: "StudioId");

            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discontinued = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Founded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Headquarters = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    StudioType = table.Column<int>(type: "int", nullable: false),
                    WebsiteURL = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Singles_StudioId",
                table: "Singles",
                column: "StudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_StudioId",
                table: "Albums",
                column: "StudioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Studios_StudioId",
                table: "Albums",
                column: "StudioId",
                principalTable: "Studios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Singles_Studios_StudioId",
                table: "Singles",
                column: "StudioId",
                principalTable: "Studios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
