using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class salary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Users_ConfirmerId",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "ConfirmedBy",
                table: "Salaries");

            migrationBuilder.AlterColumn<string>(
                name: "ConfirmerId",
                table: "Salaries",
                type: "nvarchar(26)",
                maxLength: 26,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(26)",
                oldMaxLength: 26);

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_BaseSalary",
                table: "Salaries",
                column: "BaseSalary");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_NetSalary",
                table: "Salaries",
                column: "NetSalary",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Users_ConfirmerId",
                table: "Salaries",
                column: "ConfirmerId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Users_ConfirmerId",
                table: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_Salaries_BaseSalary",
                table: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_Salaries_NetSalary",
                table: "Salaries");

            migrationBuilder.AlterColumn<string>(
                name: "ConfirmerId",
                table: "Salaries",
                type: "nvarchar(26)",
                maxLength: 26,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(26)",
                oldMaxLength: 26,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConfirmedBy",
                table: "Salaries",
                type: "nvarchar(26)",
                maxLength: 26,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Users_ConfirmerId",
                table: "Salaries",
                column: "ConfirmerId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
