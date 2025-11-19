using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuelManagement.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class FuelRate_FinalFix_addTemp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FuelRates",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuelType = table.Column<string>(nullable: false),
                    Amount = table.Column<string>(nullable: true),
                    FuelRateImage = table.Column<string>(nullable: false),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    PublishDateJalali = table.Column<string>(nullable: false),
                    UpdateDateJalali = table.Column<string>(nullable: false),
                    UserLog = table.Column<string>(nullable: true),
                    TempColumn = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelRates", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuelRates");
        }
    }
}
