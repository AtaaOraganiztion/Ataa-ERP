using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFileParentForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdverismentFile_Adverisments_Id",
                table: "AdverismentFile");

            migrationBuilder.DropForeignKey(
                name: "FK_ForasFile_Foras_Id",
                table: "ForasFile");

            migrationBuilder.AddColumn<string>(
                name: "ForasId",
                table: "ForasFile",
                type: "nvarchar(26)",
                maxLength: 26,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AdverismentId",
                table: "AdverismentFile",
                type: "nvarchar(26)",
                maxLength: 26,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ForasFile_ForasId",
                table: "ForasFile",
                column: "ForasId");

            migrationBuilder.CreateIndex(
                name: "IX_AdverismentFile_AdverismentId",
                table: "AdverismentFile",
                column: "AdverismentId");

            // Backfill existing rows: the old (broken) FK used f.Id = parent.Id,
            // so each file's own Id IS the parent's Id for legacy data.
            migrationBuilder.Sql("UPDATE [AdverismentFile] SET [AdverismentId] = [Id] WHERE [AdverismentId] = ''");
            migrationBuilder.Sql("UPDATE [ForasFile] SET [ForasId] = [Id] WHERE [ForasId] = ''");

            // Remove orphaned file rows that still have no valid parent after backfill
            migrationBuilder.Sql("DELETE FROM [AdverismentFile] WHERE NOT EXISTS (SELECT 1 FROM [Adverisments] WHERE [Adverisments].[Id] = [AdverismentFile].[AdverismentId])");
            migrationBuilder.Sql("DELETE FROM [ForasFile] WHERE NOT EXISTS (SELECT 1 FROM [Foras] WHERE [Foras].[Id] = [ForasFile].[ForasId])");

            migrationBuilder.AddForeignKey(
                name: "FK_AdverismentFile_Adverisments_AdverismentId",
                table: "AdverismentFile",
                column: "AdverismentId",
                principalTable: "Adverisments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ForasFile_Foras_ForasId",
                table: "ForasFile",
                column: "ForasId",
                principalTable: "Foras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdverismentFile_Adverisments_AdverismentId",
                table: "AdverismentFile");

            migrationBuilder.DropForeignKey(
                name: "FK_ForasFile_Foras_ForasId",
                table: "ForasFile");

            migrationBuilder.DropIndex(
                name: "IX_ForasFile_ForasId",
                table: "ForasFile");

            migrationBuilder.DropIndex(
                name: "IX_AdverismentFile_AdverismentId",
                table: "AdverismentFile");

            migrationBuilder.DropColumn(
                name: "ForasId",
                table: "ForasFile");

            migrationBuilder.DropColumn(
                name: "AdverismentId",
                table: "AdverismentFile");

            migrationBuilder.AddForeignKey(
                name: "FK_AdverismentFile_Adverisments_Id",
                table: "AdverismentFile",
                column: "Id",
                principalTable: "Adverisments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ForasFile_Foras_Id",
                table: "ForasFile",
                column: "Id",
                principalTable: "Foras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
