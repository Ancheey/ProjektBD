using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektBD.Migrations
{
    public partial class publicationchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfPublication",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "PublicationYear",
                table: "Books",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicationYear",
                table: "Books");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfPublication",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
