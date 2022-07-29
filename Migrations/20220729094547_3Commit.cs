using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookApi.Migrations
{
    public partial class _3Commit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "TBL_BOOKS",
                newName: "DateUpdated");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "TBL_BOOKS",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "TBL_BOOKS");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "TBL_BOOKS",
                newName: "Date");
        }
    }
}
