using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projebridgeapi.Migrations
{
    /// <inheritdoc />
    public partial class AddApiSampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Kolye", "Gold, silver ve taşlı kolye modelleri" },
                    { 2, "Yüzük", "Minimal, taşlı ve günlük yüzük modelleri" },
                    { 3, "Bileklik", "Çelik, rose ve zincir bileklik modelleri" },
                    { 4, "Küpe", "İnci, halka ve minimal küpe modelleri" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "FullName", "Phone" },
                values: new object[,]
                {
                    { 1, "ayse@mail.com", "Ayşe Yılmaz", "0555 111 22 33" },
                    { 2, "elif@mail.com", "Elif Demir", "0555 222 33 44" },
                    { 3, "merve@mail.com", "Merve Kaya", "0555 333 44 55" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "City", "Phone", "SupplierName" },
                values: new object[,]
                {
                    { 1, "İstanbul", "0532 111 22 33", "Parıltı Takı Tedarik" },
                    { 2, "İzmir", "0533 222 44 55", "GoldLine Aksesuar" },
                    { 3, "Ankara", "0534 333 55 66", "Rose Bijuteri" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 3);
        }
    }
}
