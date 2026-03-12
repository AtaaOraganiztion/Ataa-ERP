using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class fixsector : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sectors_Users_ManagerId",
                table: "Sectors");

            migrationBuilder.DropIndex(
                name: "IX_Sectors_ManagerId",
                table: "Sectors");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Sectors");

            migrationBuilder.CreateIndex(
                name: "IX_Sectors_ManagerUserId",
                table: "Sectors",
                column: "ManagerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sectors_Users_ManagerUserId",
                table: "Sectors",
                column: "ManagerUserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sectors_Users_ManagerUserId",
                table: "Sectors");

            migrationBuilder.DropIndex(
                name: "IX_Sectors_ManagerUserId",
                table: "Sectors");

            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "Sectors",
                type: "nvarchar(26)",
                maxLength: 26,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sectors_ManagerId",
                table: "Sectors",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sectors_Users_ManagerId",
                table: "Sectors",
                column: "ManagerId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
