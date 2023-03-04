using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesOrderManagement.Api.DataAccessMigration.migration
{
    /// <inheritdoc />
    public partial class codeColumnAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "SalesOrder",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "SalesOrder");
        }
    }
}
