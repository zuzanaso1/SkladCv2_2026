using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataEntity.Migrations
{
    /// <inheritdoc />
    public partial class _004Sklad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MernaJednotka",
                columns: new[] { "MernaJednotkaID", "Popis" },
                values: new object[,]
                {
                    { 1, "ks" },
                    { 2, "kg" },
                    { 3, "m3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MernaJednotka",
                keyColumn: "MernaJednotkaID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MernaJednotka",
                keyColumn: "MernaJednotkaID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MernaJednotka",
                keyColumn: "MernaJednotkaID",
                keyValue: 3);
        }
    }
}
