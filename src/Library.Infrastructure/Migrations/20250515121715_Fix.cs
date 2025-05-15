using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReaderInfo");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Books",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Books");

            migrationBuilder.CreateTable(
                name: "ReaderInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    BorrowedBooksCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentCountOfBorrowedBooks = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReaderInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReaderInfo_Readers_UserId",
                        column: x => x.UserId,
                        principalTable: "Readers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReaderInfo_UserId",
                table: "ReaderInfo",
                column: "UserId",
                unique: true);
        }
    }
}
