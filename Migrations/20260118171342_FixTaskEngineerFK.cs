using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionBackend1._0.Migrations
{
    /// <inheritdoc />
    public partial class FixTaskEngineerFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_EngineerUserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_EngineerUserId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "EngineerUserId",
                table: "Tasks");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssignedTo",
                table: "Tasks",
                column: "AssignedTo");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_AssignedTo",
                table: "Tasks",
                column: "AssignedTo",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_AssignedTo",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AssignedTo",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "EngineerUserId",
                table: "Tasks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_EngineerUserId",
                table: "Tasks",
                column: "EngineerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_EngineerUserId",
                table: "Tasks",
                column: "EngineerUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
