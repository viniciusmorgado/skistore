using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl" },
                values: new object[] { "Glacius", "Engineered for performance and comfort, this ski boot delivers precise control on the slopes. With a durable outer shell, customizable fit, and responsive flex, it's built to handle everything from groomed runs to backcountry adventures. The insulated liner keeps your feet warm, while micro-adjustable buckles ensure a secure fit all day long.", "Glacius Red and Black Boots", "/images/products/68164aa8-1e5c-800a-a02b-7d7093ce6f64.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl" },
                values: new object[] { "Glacius", "Engineered for performance and comfort, this ski boot delivers precise control on the slopes. With a durable outer shell, customizable fit, and responsive flex, it's built to handle everything from groomed runs to backcountry adventures. The insulated liner keeps your feet warm, while micro-adjustable buckles ensure a secure fit all day long.", "Glacius Yellow and Black Boots", "/images/products/68164aa8-1e5c-800a-a02b-7d7093ce6f65.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl" },
                values: new object[] { "Glacius", "Engineered for performance and comfort, this ski boot delivers precise control on the slopes. With a durable outer shell, customizable fit, and responsive flex, it's built to handle everything from groomed runs to backcountry adventures. The insulated liner keeps your feet warm, while micro-adjustable buckles ensure a secure fit all day long.", "Glacius Red and White Boots", "/images/products/68164aa8-1e5c-800a-a02b-7d7093ce6f66.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl" },
                values: new object[] { "Glacius", "Engineered for performance and comfort, this ski boot delivers precise control on the slopes. With a durable outer shell, customizable fit, and responsive flex, it's built to handle everything from groomed runs to backcountry adventures. The insulated liner keeps your feet warm, while micro-adjustable buckles ensure a secure fit all day long.", "Glacius Purple and Black Boots", "/images/products/68164aa8-1e5c-800a-a02b-7d7093ce6f67.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl" },
                values: new object[] { "Glacius", "Engineered for performance and comfort, this ski boot delivers precise control on the slopes. With a durable outer shell, customizable fit, and responsive flex, it's built to handle everything from groomed runs to backcountry adventures. The insulated liner keeps your feet warm, while micro-adjustable buckles ensure a secure fit all day long.", "Glacius Green and Yellow Boots", "/images/products/68164aa8-1e5c-800a-a02b-7d7093ce6f68.png" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl" },
                values: new object[] { "Redis", "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "Redis Red Boots", "/images/products/boot-redis1.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl" },
                values: new object[] { "NetCore", "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "Core Red Boots", "/images/products/boot-core2.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl" },
                values: new object[] { "NetCore", "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.", "Core Purple Boots", "/images/products/boot-core1.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl" },
                values: new object[] { "Angular", "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.", "Angular Purple Boots", "/images/products/boot-ang2.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl" },
                values: new object[] { "Angular", "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "Angular Blue Boots", "/images/products/boot-ang1.png" });
        }
    }
}
