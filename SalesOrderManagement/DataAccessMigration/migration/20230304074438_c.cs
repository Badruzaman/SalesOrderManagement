using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesOrderManagement.Api.DataAccessMigration.migration
{
    /// <inheritdoc />
    public partial class c : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "QuantityOfWindows",
                table: "SalesOrderDetail",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "QuantityOfWindows",
                table: "SalesOrderDetail",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
