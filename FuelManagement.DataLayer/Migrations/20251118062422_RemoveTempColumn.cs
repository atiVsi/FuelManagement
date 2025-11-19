using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuelManagement.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTempColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempColumn",
                table: "FuelRates");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TempColumn",
                table: "FuelRates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
