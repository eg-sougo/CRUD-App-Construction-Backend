using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionBackend1._0.Migrations
{
    /// <inheritdoc />
    public partial class paaswordverification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HashedPassword",
                table: "Users",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HashedPassword",
                table: "Users");
        }
    }
}
