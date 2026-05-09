using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGlobalActivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GlobalActivities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ActivityResult = table.Column<int>(type: "int", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    LeadId = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    DealId = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlobalActivities_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_GlobalActivities_Deal_DealId",
                        column: x => x.DealId,
                        principalTable: "Deal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_GlobalActivities_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_GlobalActivities_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GlobalActivityFiles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    GlobalActivityId = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    StoragePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileSizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    UploadedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalActivityFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlobalActivityFiles_GlobalActivities_GlobalActivityId",
                        column: x => x.GlobalActivityId,
                        principalTable: "GlobalActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GlobalActivityFiles_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GlobalActivities_CreatedByUserId",
                table: "GlobalActivities",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalActivities_CustomerId",
                table: "GlobalActivities",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalActivities_DealId",
                table: "GlobalActivities",
                column: "DealId");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalActivities_IsDeleted",
                table: "GlobalActivities",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalActivities_LeadId",
                table: "GlobalActivities",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalActivities_Type",
                table: "GlobalActivities",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalActivityFiles_CreatedByUserId",
                table: "GlobalActivityFiles",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalActivityFiles_GlobalActivityId",
                table: "GlobalActivityFiles",
                column: "GlobalActivityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlobalActivityFiles");

            migrationBuilder.DropTable(
                name: "GlobalActivities");
        }
    }
}
