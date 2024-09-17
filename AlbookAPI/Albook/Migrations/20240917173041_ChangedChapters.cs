using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Albook.Migrations
{
    /// <inheritdoc />
    public partial class ChangedChapters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapter_Books_BookId",
                table: "Chapter");

            migrationBuilder.DropIndex(
                name: "IX_Chapter_BookId",
                table: "Chapter");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Chapter");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookId",
                table: "Chapter",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_BookId",
                table: "Chapter",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapter_Books_BookId",
                table: "Chapter",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId");
        }
    }
}
