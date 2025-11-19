using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuelManagement.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class SeedPermissions2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2025, 11, 12, 10, 57, 2, 77, DateTimeKind.Local).AddTicks(4118));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2025, 11, 12, 10, 57, 2, 78, DateTimeKind.Local).AddTicks(1330));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2025, 11, 12, 10, 57, 2, 78, DateTimeKind.Local).AddTicks(1340));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2025, 11, 12, 10, 57, 2, 78, DateTimeKind.Local).AddTicks(1342));

            //migrationBuilder.InsertData(
            //    table: "Permissions",
            //    columns: new[] { "Id", "CreationDate", "IsDelete", "ParentId", "PermissionTitle", "UserLog" },
            //    values: new object[] { 5L, new DateTime(2025, 11, 12, 10, 57, 2, 78, DateTimeKind.Local).AddTicks(1343), false, 3L, "حذف گزارش", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2025, 11, 12, 10, 52, 42, 352, DateTimeKind.Local).AddTicks(4921));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2025, 11, 12, 10, 52, 42, 353, DateTimeKind.Local).AddTicks(1806));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2025, 11, 12, 10, 52, 42, 353, DateTimeKind.Local).AddTicks(1817));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2025, 11, 12, 10, 52, 42, 353, DateTimeKind.Local).AddTicks(1819));
        }
    }
}
