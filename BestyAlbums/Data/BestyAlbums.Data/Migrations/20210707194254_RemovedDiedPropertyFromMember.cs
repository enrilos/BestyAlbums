using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BestyAlbums.Data.Migrations
{
    public partial class RemovedDiedPropertyFromMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Died",
                table: "Members");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_Name",
                table: "Artists",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Artists_Name",
                table: "Artists");

            migrationBuilder.AddColumn<DateTime>(
                name: "Died",
                table: "Members",
                type: "datetime2",
                nullable: true);
        }
    }
}
