using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixFiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Activity",
                type: "nvarchar(26)",
                maxLength: 26,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activity_CreatedByUserId",
                table: "Activity",
                column: "CreatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Users_CreatedByUserId",
                table: "Activity",
                column: "CreatedByUserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Users_CreatedByUserId",
                table: "Activity");

            migrationBuilder.DropIndex(
                name: "IX_Activity_CreatedByUserId",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Activity");
        }
    }
}
