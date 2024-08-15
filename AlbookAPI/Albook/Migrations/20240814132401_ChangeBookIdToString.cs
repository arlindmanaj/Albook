using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Albook.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBookIdToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Books_BookId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Books_BookId",
                table: "Translations");

            migrationBuilder.DropIndex(
                name: "IX_Translations_BookId",
                table: "Translations");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_BookId",
                table: "Transactions");

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "Translations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ContentUrl",
                table: "Translations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "BookId1",
                table: "Translations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "BookId1",
                table: "Transactions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CoverUrl",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BookId",
                table: "Books",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "BookId",
                table: "BookReviews",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_BookId1",
                table: "Translations",
                column: "BookId1");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BookId1",
                table: "Transactions",
                column: "BookId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Books_BookId1",
                table: "Transactions",
                column: "BookId1",
                principalTable: "Books",
                principalColumn: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Books_BookId1",
                table: "Translations",
                column: "BookId1",
                principalTable: "Books",
                principalColumn: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Books_BookId1",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Books_BookId1",
                table: "Translations");

            migrationBuilder.DropIndex(
                name: "IX_Translations_BookId1",
                table: "Translations");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_BookId1",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "BookId1",
                table: "Translations");

            migrationBuilder.DropColumn(
                name: "BookId1",
                table: "Transactions");

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "Translations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContentUrl",
                table: "Translations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CoverUrl",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Books",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "BookReviews",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_BookId",
                table: "Translations",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BookId",
                table: "Transactions",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Books_BookId",
                table: "Transactions",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Books_BookId",
                table: "Translations",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
