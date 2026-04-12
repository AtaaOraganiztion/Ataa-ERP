using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBudgetUniqueConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetAllocation_Budget_BudgetId",
                table: "BudgetAllocation");

            migrationBuilder.DropIndex(
                name: "IX_BudgetAllocation_AllocatedAmount",
                table: "BudgetAllocation");

            migrationBuilder.DropIndex(
                name: "IX_BudgetAllocation_BudgetId",
                table: "BudgetAllocation");

            migrationBuilder.DropIndex(
                name: "IX_BudgetAllocation_Category",
                table: "BudgetAllocation");

            migrationBuilder.DropIndex(
                name: "IX_BudgetAllocation_Description",
                table: "BudgetAllocation");

            migrationBuilder.DropIndex(
                name: "IX_BudgetAllocation_SpentAmount",
                table: "BudgetAllocation");

            migrationBuilder.DropIndex(
                name: "IX_Budget_IsDeleted",
                table: "Budget");

            migrationBuilder.DropIndex(
                name: "IX_Budget_SectorId",
                table: "Budget");

            migrationBuilder.AlterColumn<string>(
                name: "RejectionReason",
                table: "Expense",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ReceiptNumber",
                table: "Expense",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Expense",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Expense",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "BudgetAllocation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "BudgetAllocation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetAllocation_BudgetId",
                table: "BudgetAllocation",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Budget_SectorId",
                table: "Budget",
                column: "SectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetAllocation_Budget_BudgetId",
                table: "BudgetAllocation",
                column: "BudgetId",
                principalTable: "Budget",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetAllocation_Budget_BudgetId",
                table: "BudgetAllocation");

            migrationBuilder.DropIndex(
                name: "IX_BudgetAllocation_BudgetId",
                table: "BudgetAllocation");

            migrationBuilder.DropIndex(
                name: "IX_Budget_SectorId",
                table: "Budget");

            migrationBuilder.AlterColumn<string>(
                name: "RejectionReason",
                table: "Expense",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiptNumber",
                table: "Expense",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Expense",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Expense",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "BudgetAllocation",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "BudgetAllocation",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetAllocation_AllocatedAmount",
                table: "BudgetAllocation",
                column: "AllocatedAmount");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetAllocation_BudgetId",
                table: "BudgetAllocation",
                column: "BudgetId",
                unique: true,
                filter: "[BudgetId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetAllocation_Category",
                table: "BudgetAllocation",
                column: "Category",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BudgetAllocation_Description",
                table: "BudgetAllocation",
                column: "Description");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetAllocation_SpentAmount",
                table: "BudgetAllocation",
                column: "SpentAmount");

            migrationBuilder.CreateIndex(
                name: "IX_Budget_IsDeleted",
                table: "Budget",
                column: "IsDeleted",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Budget_SectorId",
                table: "Budget",
                column: "SectorId",
                unique: true,
                filter: "[SectorId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetAllocation_Budget_BudgetId",
                table: "BudgetAllocation",
                column: "BudgetId",
                principalTable: "Budget",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
