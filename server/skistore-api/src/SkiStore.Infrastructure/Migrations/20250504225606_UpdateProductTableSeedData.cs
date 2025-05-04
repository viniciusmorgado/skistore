using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductTableSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "Avalanche", "Engineered for all-terrain skiing with superior control and comfort.", "Blue Avalanche Boot", "/images/products/blue-boot.png", 199.99m, 50, "Boots" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "Frostbite", "Cold-resistant and precision-fitted boot for expert-level skiing.", "Purple Frostbite Boot", "/images/products/purple-boot-1.png", 189.99m, 35, "Boots" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "Frostbite", "Identical model for testing duplicate filter behavior.", "Purple Frostbite Boot", "/images/products/purple-boot-2.png", 189.99m, 30, "Boots" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "IceClaw", "Aggressive design for high-speed downhill skiing.", "Red IceClaw Boot", "/images/products/red-boot-1.png", 209.99m, 40, "Boots" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "Inferna", "Thermal-insulated boot for enhanced warmth and performance.", "Red Inferna Boot", "/images/products/red-boot-2.png", 219.99m, 42, "Boots" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "Avalanche", "Waterproof gloves with reinforced grip and thermal lining.", "Blue Avalanche Gloves", "/images/products/blue-gloves.png", 29.99m, 60, "Gloves" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "Stormrider", "All-weather gloves designed for intense mountain use.", "Green Stormrider Gloves", "/images/products/green-gloves-1.png", 24.99m, 55, "Gloves" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "Frostborn", "Breathable and warm gloves for mid-range temperatures.", "Green Frostborn Gloves", "/images/products/green-gloves-2.png", 22.99m, 48, "Gloves" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "Nightshade", "Sleek insulated gloves for comfortable long sessions.", "Purple Nightshade Gloves", "/images/products/purple-gloves.png", 26.99m, 52, "Gloves" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "Alpine", "Lightweight and stylish winter hat for ski season.", "Blue Alpine Hat", "/images/products/blue-hat.png", 19.99m, 33, "Hats" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "Windhowl", "Windproof and breathable hat for alpine weather.", "Green Windhowl Hat", "/images/products/green-hat.png", 17.99m, 38, "Hats" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "Eclipse", "Comfortable and thermal-retentive ski hat.", "Purple Eclipse Hat", "/images/products/purple-hat.png", 18.99m, 29, "Hats" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "Hawk", "High-speed carving board with carbon core.", "Midnight Hawk Ski Board", "/images/products/ski-board-1.png", 320.00m, 15, "Boards" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "Talon", "Freestyle board with reinforced bindings.", "Crimson Talon Ski Board", "/images/products/ski-board-2.png", 299.99m, 21, "Boards" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "Serpent", "Lightweight and flexible board for tricks.", "Frost Serpent Ski Board", "/images/products/ski-board-3.png", 289.99m, 25, "Boards" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "Shadowline", "Wide profile board for backcountry powder.", "Shadowline Drift Ski Board", "/images/products/ski-board-4.png", 310.00m, 18, "Boards" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "Glacier", "Edge-controlled board for slalom skiing.", "Glacier Edge Ski Board", "/images/products/ski-board-5.png", 305.00m, 17, "Boards" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "Volt", "Stiff board for experienced riders and high-speed descent.", "Volt Striker Ski Board", "/images/products/ski-board-6.png", 315.00m, 22, "Boards" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "Angular", "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "Angular Speedster Board 2000", "/images/products/sb-ang1.png", 200m, 82, "Boards" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "Angular", "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.", "Green Angular Board 3000", "/images/products/sb-ang2.png", 150m, 75, "Boards" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "NetCore", "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "Core Board Speed Rush 3", "/images/products/sb-core1.png", 180m, 3, "Boards" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "NetCore", "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.", "Net Core Super Board", "/images/products/sb-core2.png", 300m, 52, "Boards" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "React", "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "React Board Super Whizzy Fast", "/images/products/sb-react1.png", 250m, 97, "Boards" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "Typescript", "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.", "Typescript Entry Board", "/images/products/sb-ts1.png", 120m, 37, "Boards" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "NetCore", "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "Core Blue Hat", "/images/products/hat-core1.png", 10m, 32, "Hats" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "React", "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "Green React Woolen Hat", "/images/products/hat-react1.png", 8m, 6, "Hats" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "React", "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "Purple React Woolen Hat", "/images/products/hat-react2.png", 15m, 17, "Hats" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "VS Code", "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.", "Blue Code Gloves", "/images/products/glove-code1.png", 18m, 74, "Gloves" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "VS Code", "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.", "Green Code Gloves", "/images/products/glove-code2.png", 15m, 19, "Gloves" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "React", "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa.", "Purple React Gloves", "/images/products/glove-react1.png", 16m, 77, "Gloves" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "React", "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.", "Green React Gloves", "/images/products/glove-react2.png", 14m, 45, "Gloves" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "Glacius", "Engineered for performance and comfort, this ski boot delivers precise control on the slopes. With a durable outer shell, customizable fit, and responsive flex, it's built to handle everything from groomed runs to backcountry adventures. The insulated liner keeps your feet warm, while micro-adjustable buckles ensure a secure fit all day long.", "Glacius Red and Black Boots", "/images/products/68164aa8-1e5c-800a-a02b-7d7093ce6f64.png", 250m, 49, "Boots" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "Glacius", "Engineered for performance and comfort, this ski boot delivers precise control on the slopes. With a durable outer shell, customizable fit, and responsive flex, it's built to handle everything from groomed runs to backcountry adventures. The insulated liner keeps your feet warm, while micro-adjustable buckles ensure a secure fit all day long.", "Glacius Yellow and Black Boots", "/images/products/68164aa8-1e5c-800a-a02b-7d7093ce6f65.png", 189.99m, 28, "Boots" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "Glacius", "Engineered for performance and comfort, this ski boot delivers precise control on the slopes. With a durable outer shell, customizable fit, and responsive flex, it's built to handle everything from groomed runs to backcountry adventures. The insulated liner keeps your feet warm, while micro-adjustable buckles ensure a secure fit all day long.", "Glacius Red and White Boots", "/images/products/68164aa8-1e5c-800a-a02b-7d7093ce6f66.png", 199.99m, 69, "Boots" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "Glacius", "Engineered for performance and comfort, this ski boot delivers precise control on the slopes. With a durable outer shell, customizable fit, and responsive flex, it's built to handle everything from groomed runs to backcountry adventures. The insulated liner keeps your feet warm, while micro-adjustable buckles ensure a secure fit all day long.", "Glacius Purple and Black Boots", "/images/products/68164aa8-1e5c-800a-a02b-7d7093ce6f67.png", 150m, 35, "Boots" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Brand", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[] { "Glacius", "Engineered for performance and comfort, this ski boot delivers precise control on the slopes. With a durable outer shell, customizable fit, and responsive flex, it's built to handle everything from groomed runs to backcountry adventures. The insulated liner keeps your feet warm, while micro-adjustable buckles ensure a secure fit all day long.", "Glacius Green and Yellow Boots", "/images/products/68164aa8-1e5c-800a-a02b-7d7093ce6f68.png", 180m, 27, "Boots" });
        }
    }
}
