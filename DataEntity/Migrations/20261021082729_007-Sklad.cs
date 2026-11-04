using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataEntity.Migrations
{
    /// <inheritdoc />
    public partial class _007Sklad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MernaJednotka",
                keyColumn: "MernaJednotkaID",
                keyValue: 1,
                column: "DatumVytvoreni",
                value: new DateTime(2026, 10, 21, 10, 23, 50, 65, DateTimeKind.Local).AddTicks(5570));

            migrationBuilder.UpdateData(
                table: "MernaJednotka",
                keyColumn: "MernaJednotkaID",
                keyValue: 2,
                column: "DatumVytvoreni",
                value: new DateTime(2026, 10, 21, 10, 23, 50, 66, DateTimeKind.Local).AddTicks(9693));

            migrationBuilder.UpdateData(
                table: "MernaJednotka",
                keyColumn: "MernaJednotkaID",
                keyValue: 3,
                column: "DatumVytvoreni",
                value: new DateTime(2026, 10, 21, 10, 23, 50, 66, DateTimeKind.Local).AddTicks(9708));
        }
    }
}
