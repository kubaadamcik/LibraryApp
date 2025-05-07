using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixReaderInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Readers_ReaderInfo_ReadInfoId",
                table: "Readers");

            migrationBuilder.DropIndex(
                name: "IX_Readers_ReadInfoId",
                table: "Readers");

            migrationBuilder.DropIndex(
                name: "IX_ReaderInfo_UserId",
                table: "ReaderInfo");

            migrationBuilder.DropColumn(
                name: "ReadInfoId",
                table: "Readers");

            migrationBuilder.CreateIndex(
                name: "IX_ReaderInfo_UserId",
                table: "ReaderInfo",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ReaderInfo_UserId",
                table: "ReaderInfo");

            migrationBuilder.AddColumn<int>(
                name: "ReadInfoId",
                table: "Readers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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
    }
}
