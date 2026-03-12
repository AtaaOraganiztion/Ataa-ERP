using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class fixsalary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Salaries_NetSalary",
                table: "Salaries");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_NetSalary",
                table: "Salaries",
                column: "NetSalary");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Salaries_NetSalary",
                table: "Salaries");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_NetSalary",
                table: "Salaries",
                column: "NetSalary",
                unique: true);
        }
    }
}
