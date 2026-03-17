using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class finnance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Attendances",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.CreateTable(
                name: "Budget",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    SectorId = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    EstimatedBudget = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Limit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalBudget = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AllocatedAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SpentAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    RemainingAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BudgetLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ConfirmedBy = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    ConfirmedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budget", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Budget_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Budget_Users_ConfirmedBy",
                        column: x => x.ConfirmedBy,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SectorNumber = table.Column<int>(type: "int", nullable: false),
                    SectorId = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProcureToPay",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    ProcureAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UpdateBudget = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SectorId = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcureToPay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcureToPay_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectorId = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    ProjectManagerId = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    EstimatedBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ActualCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CompletionPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Users_ProjectManagerId",
                        column: x => x.ProjectManagerId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BudgetAllocation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    BudgetId = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AllocatedAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    SpentAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetAllocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetAllocation_Budget_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expense",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    SectorId = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    ExpenseAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SectorNumber = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ExpenseType = table.Column<int>(type: "int", nullable: false),
                    ExpenseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RequestedBy = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiptNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    ConfirmedBy = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    ConfirmedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    PaidDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoursWorked = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Confirm = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expense_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expense_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expense_Users_ApprovedBy",
                        column: x => x.ApprovedBy,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expense_Users_ConfirmedBy",
                        column: x => x.ConfirmedBy,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expense_Users_RequestedBy",
                        column: x => x.RequestedBy,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Budget_ConfirmedBy",
                table: "Budget",
                column: "ConfirmedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Budget_CreatedBy",
                table: "Budget",
                column: "CreatedBy");

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

            migrationBuilder.CreateIndex(
                name: "IX_Budget_Status",
                table: "Budget",
                column: "Status");

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
                name: "IX_Expense_ApprovedBy",
                table: "Expense",
                column: "ApprovedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_ConfirmedBy",
                table: "Expense",
                column: "ConfirmedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_ProjectId",
                table: "Expense",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_RequestedBy",
                table: "Expense",
                column: "RequestedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_SectorId",
                table: "Expense",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_SectorId",
                table: "Order",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcureToPay_SectorId",
                table: "ProcureToPay",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectManagerId",
                table: "Project",
                column: "ProjectManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_SectorId",
                table: "Project",
                column: "SectorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetAllocation");

            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "ProcureToPay");

            migrationBuilder.DropTable(
                name: "Budget");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Attendances",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);
        }
    }
}
