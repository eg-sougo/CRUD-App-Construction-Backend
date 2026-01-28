using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionBackend1._0.Migrations
{
    /// <inheritdoc />
    public partial class NubiieMistakeCorrection20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_CreatorUserId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CreatedID",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "CreatorUserId",
                table: "Projects",
                newName: "CreatorID");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_CreatorUserId",
                table: "Projects",
                newName: "IX_Projects_CreatorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_CreatorID",
                table: "Projects",
                column: "CreatorID",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_CreatorID",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "CreatorID",
                table: "Projects",
                newName: "CreatorUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_CreatorID",
                table: "Projects",
                newName: "IX_Projects_CreatorUserId");

            migrationBuilder.AddColumn<int>(
                name: "CreatedID",
                table: "Projects",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_CreatorUserId",
                table: "Projects",
                column: "CreatorUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
