using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGlobalActivityy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GlobalActivities_Users_UserId",
                table: "GlobalActivities");

            migrationBuilder.DropIndex(
                name: "IX_GlobalActivities_UserId",
                table: "GlobalActivities");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GlobalActivities");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "GlobalActivities",
                type: "nvarchar(26)",
                maxLength: 26,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GlobalActivities_UserId",
                table: "GlobalActivities",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GlobalActivities_Users_UserId",
                table: "GlobalActivities",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
