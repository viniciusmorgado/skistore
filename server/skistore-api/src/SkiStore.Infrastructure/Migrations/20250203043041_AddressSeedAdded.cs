using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkiStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddressSeedAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "Line1", "Line2", "PostalCode", "Reference", "State" },
                values: new object[,]
                {
                    { 1, "New York", "USA", "123 Main St", "Apt 4B", "10001", "Near Central Park", "NY" },
                    { 2, "Los Angeles", "USA", "456 Elm St", null, "90001", "Downtown LA", "CA" },
                    { 3, "Chicago", "USA", "789 Oak St", "Suite 100", "60601", "Near Willis Tower", "IL" },
                    { 4, "Houston", "USA", "101 Pine St", null, "77001", "Near Houston Zoo", "TX" },
                    { 5, "Phoenix", "USA", "202 Maple St", "Unit 5", "85001", "Near Phoenix Art Museum", "AZ" },
                    { 6, "Philadelphia", "USA", "303 Cedar St", null, "19019", "Near Liberty Bell", "PA" },
                    { 7, "San Antonio", "USA", "404 Birch St", "Apt 3C", "78201", "Near Alamo", "TX" },
                    { 8, "San Diego", "USA", "505 Walnut St", null, "92101", "Near San Diego Zoo", "CA" },
                    { 9, "Dallas", "USA", "606 Cherry St", "Suite 200", "75201", "Near Dallas World Aquarium", "TX" },
                    { 10, "San Jose", "USA", "707 Spruce St", null, "95101", "Near Tech Museum", "CA" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
