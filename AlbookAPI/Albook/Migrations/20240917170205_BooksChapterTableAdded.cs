using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Albook.Migrations
{
    /// <inheritdoc />
    public partial class BooksChapterTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BooksChapters",
                columns: table => new
                {
                    BooksChapterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    ChapterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksChapters", x => x.BooksChapterId);
                    table.ForeignKey(
                        name: "FK_BooksChapters_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId");
                    table.ForeignKey(
                        name: "FK_BooksChapters_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "ChapterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BooksChapters_BookId",
                table: "BooksChapters",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksChapters_ChapterId",
                table: "BooksChapters",
                column: "ChapterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksChapters");
        }
    }
}
