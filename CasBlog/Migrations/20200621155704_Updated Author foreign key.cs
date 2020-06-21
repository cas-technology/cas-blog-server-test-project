using Microsoft.EntityFrameworkCore.Migrations;

namespace CasBlog.Migrations
{
    public partial class UpdatedAuthorforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_User_AuthorId",
                table: "Article");

            migrationBuilder.DropIndex(
                name: "IX_Article_AuthorId",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Article");

            migrationBuilder.AddColumn<int>(
                name: "Author.Id",
                table: "Article",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Article_Author.Id",
                table: "Article",
                column: "Author.Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_User_Author.Id",
                table: "Article",
                column: "Author.Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_User_Author.Id",
                table: "Article");

            migrationBuilder.DropIndex(
                name: "IX_Article_Author.Id",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "Author.Id",
                table: "Article");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Article_AuthorId",
                table: "Article",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_User_AuthorId",
                table: "Article",
                column: "AuthorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
