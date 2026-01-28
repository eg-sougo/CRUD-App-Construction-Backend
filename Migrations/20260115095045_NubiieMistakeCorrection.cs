using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionBackend1._0.Migrations
{
    /// <inheritdoc />
    public partial class NubiieMistakeCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedBy_UserID",
                table: "Projects",
                newName: "CreatedID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedID",
                table: "Projects",
                newName: "CreatedBy_UserID");
        }
    }
}
