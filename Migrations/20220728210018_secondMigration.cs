using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookApi.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_BOOKS_TBL_AUTHORS_AuthorId",
                table: "TBL_BOOKS");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "TBL_BOOKS",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "TBL_BOOKS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_BOOKS_TBL_AUTHORS_AuthorId",
                table: "TBL_BOOKS",
                column: "AuthorId",
                principalTable: "TBL_AUTHORS",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_BOOKS_TBL_AUTHORS_AuthorId",
                table: "TBL_BOOKS");

            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "TBL_BOOKS");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "TBL_BOOKS",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_BOOKS_TBL_AUTHORS_AuthorId",
                table: "TBL_BOOKS",
                column: "AuthorId",
                principalTable: "TBL_AUTHORS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
