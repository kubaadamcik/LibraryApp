using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReadInfoId",
                table: "Readers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ReaderInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentCountOfBorrowedBooks = table.Column<int>(type: "INTEGER", nullable: false),
                    BorrowedBooksCount = table.Column<int>(type: "INTEGER", nullable: false)
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
                name: "IX_Readers_ReadInfoId",
                table: "Readers",
                column: "ReadInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReaderInfo_UserId",
                table: "ReaderInfo",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Readers_ReaderInfo_ReadInfoId",
                table: "Readers",
                column: "ReadInfoId",
                principalTable: "ReaderInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Readers_ReaderInfo_ReadInfoId",
                table: "Readers");

            migrationBuilder.DropTable(
                name: "ReaderInfo");

            migrationBuilder.DropIndex(
                name: "IX_Readers_ReadInfoId",
                table: "Readers");

            migrationBuilder.DropColumn(
                name: "ReadInfoId",
                table: "Readers");
        }
    }
}
