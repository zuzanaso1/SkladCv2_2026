using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataEntity.Migrations
{
    /// <inheritdoc />
    public partial class SeedMernaJednotka : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MernaJednotka",
                keyColumn: "MernaJednotkaID",
                keyValue: 1,
                column: "DatumVytvoreni",
                value: new DateTime(2026, 10, 21, 10, 29, 52, 405, DateTimeKind.Local).AddTicks(8500));

            migrationBuilder.UpdateData(
                table: "MernaJednotka",
                keyColumn: "MernaJednotkaID",
                keyValue: 2,
                column: "DatumVytvoreni",
                value: new DateTime(2026, 10, 21, 10, 29, 52, 407, DateTimeKind.Local).AddTicks(3185));

            migrationBuilder.UpdateData(
                table: "MernaJednotka",
                keyColumn: "MernaJednotkaID",
                keyValue: 3,
                column: "DatumVytvoreni",
                value: new DateTime(2026, 10, 21, 10, 29, 52, 407, DateTimeKind.Local).AddTicks(3204));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MernaJednotka",
                keyColumn: "MernaJednotkaID",
                keyValue: 1,
                column: "DatumVytvoreni",
                value: new DateTime(2026, 10, 21, 10, 27, 29, 350, DateTimeKind.Local).AddTicks(4108));

            migrationBuilder.UpdateData(
                table: "MernaJednotka",
                keyColumn: "MernaJednotkaID",
                keyValue: 2,
                column: "DatumVytvoreni",
                value: new DateTime(2026, 10, 21, 10, 27, 29, 351, DateTimeKind.Local).AddTicks(8722));

            migrationBuilder.UpdateData(
                table: "MernaJednotka",
                keyColumn: "MernaJednotkaID",
                keyValue: 3,
                column: "DatumVytvoreni",
                value: new DateTime(2026, 10, 21, 10, 27, 29, 351, DateTimeKind.Local).AddTicks(8738));
        }
    }
}
