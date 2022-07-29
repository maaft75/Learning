using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookApi.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_AUTHORS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_AUTHORS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_BOOKS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_BOOKS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_BOOKS_TBL_AUTHORS_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "TBL_AUTHORS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_BOOKS_AuthorId",
                table: "TBL_BOOKS",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_BOOKS");

            migrationBuilder.DropTable(
                name: "TBL_AUTHORS");
        }
    }
}
