using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToAllFiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "ForasFile",
                type: "nvarchar(26)",
                maxLength: 26,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Files",
                type: "nvarchar(26)",
                maxLength: 26,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "AdverismentFile",
                type: "nvarchar(26)",
                maxLength: 26,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ForasFile_CreatedByUserId",
                table: "ForasFile",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_CreatedByUserId",
                table: "Files",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdverismentFile_CreatedByUserId",
                table: "AdverismentFile",
                column: "CreatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdverismentFile_Users_CreatedByUserId",
                table: "AdverismentFile",
                column: "CreatedByUserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Users_CreatedByUserId",
                table: "Files",
                column: "CreatedByUserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ForasFile_Users_CreatedByUserId",
                table: "ForasFile",
                column: "CreatedByUserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdverismentFile_Users_CreatedByUserId",
                table: "AdverismentFile");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Users_CreatedByUserId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_ForasFile_Users_CreatedByUserId",
                table: "ForasFile");

            migrationBuilder.DropIndex(
                name: "IX_ForasFile_CreatedByUserId",
                table: "ForasFile");

            migrationBuilder.DropIndex(
                name: "IX_Files_CreatedByUserId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_AdverismentFile_CreatedByUserId",
                table: "AdverismentFile");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "ForasFile");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "AdverismentFile");
        }
    }
}
