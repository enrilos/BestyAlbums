﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BestyAlbums.Data.Migrations
{
    public partial class AddedCreatedOnPropertyInAlbumModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Albums",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Albums");
        }
    }
}
