using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkiStore.Core.Entities;

namespace SkiStore.Infrastructure.Mappings;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
#if DEBUG
        builder.HasData(
            new Product
            {
                Id = 1,
                Name = "Blue Avalanche Boot",
                Description = "Engineered for all-terrain skiing with superior control and comfort.",
                Price = 199.99M,
                PictureUrl = "/images/products/blue-boot.png",
                Type = "Boots",
                Brand = "Avalanche",
                QuantityInStock = 50
            },
            new Product
            {
                Id = 2,
                Name = "Purple Frostbite Boot",
                Description = "Cold-resistant and precision-fitted boot for expert-level skiing.",
                Price = 189.99M,
                PictureUrl = "/images/products/purple-boot-1.png",
                Type = "Boots",
                Brand = "Avalanche",
                QuantityInStock = 35
            },
            new Product
            {
                Id = 3,
                Name = "Purple Frostbite Boot",
                Description = "Identical model for testing duplicate filter behavior.",
                Price = 189.99M,
                PictureUrl = "/images/products/purple-boot-2.png",
                Type = "Boots",
                Brand = "IceClaw",
                QuantityInStock = 30
            },
            new Product
            {
                Id = 4,
                Name = "Red IceClaw Boot",
                Description = "Aggressive design for high-speed downhill skiing.",
                Price = 209.99M,
                PictureUrl = "/images/products/red-boot-1.png",
                Type = "Boots",
                Brand = "IceClaw",
                QuantityInStock = 40
            },
            new Product
            {
                Id = 5,
                Name = "Red Inferna Boot",
                Description = "Thermal-insulated boot for enhanced warmth and performance.",
                Price = 219.99M,
                PictureUrl = "/images/products/red-boot-2.png",
                Type = "Boots",
                Brand = "Inferna",
                QuantityInStock = 42
            },
            new Product
            {
                Id = 6,
                Name = "Blue Avalanche Gloves",
                Description = "Waterproof gloves with reinforced grip and thermal lining.",
                Price = 29.99M,
                PictureUrl = "/images/products/blue-gloves.png",
                Type = "Gloves",
                Brand = "Inferna",
                QuantityInStock = 60
            },
            new Product
            {
                Id = 7,
                Name = "Green Stormrider Gloves",
                Description = "All-weather gloves designed for intense mountain use.",
                Price = 24.99M,
                PictureUrl = "/images/products/green-gloves-1.png",
                Type = "Gloves",
                Brand = "Stormrider",
                QuantityInStock = 55
            },
            new Product
            {
                Id = 8,
                Name = "Green Frostborn Gloves",
                Description = "Breathable and warm gloves for mid-range temperatures.",
                Price = 22.99M,
                PictureUrl = "/images/products/green-gloves-2.png",
                Type = "Gloves",
                Brand = "Stormrider",
                QuantityInStock = 48
            },
            new Product
            {
                Id = 9,
                Name = "Purple Nightshade Gloves",
                Description = "Sleek insulated gloves for comfortable long sessions.",
                Price = 26.99M,
                PictureUrl = "/images/products/purple-gloves.png",
                Type = "Gloves",
                Brand = "Nightshade",
                QuantityInStock = 52
            },
            new Product
            {
                Id = 10,
                Name = "Blue Alpine Hat",
                Description = "Lightweight and stylish winter hat for ski season.",
                Price = 19.99M,
                PictureUrl = "/images/products/blue-hat.png",
                Type = "Hats",
                Brand = "Nightshade",
                QuantityInStock = 33
            },
            new Product
            {
                Id = 11,
                Name = "Green Windhowl Hat",
                Description = "Windproof and breathable hat for alpine weather.",
                Price = 17.99M,
                PictureUrl = "/images/products/green-hat.png",
                Type = "Hats",
                Brand = "Windhowl",
                QuantityInStock = 38
            },
            new Product
            {
                Id = 12,
                Name = "Purple Eclipse Hat",
                Description = "Comfortable and thermal-retentive ski hat.",
                Price = 18.99M,
                PictureUrl = "/images/products/purple-hat.png",
                Type = "Hats",
                Brand = "Windhowl",
                QuantityInStock = 29
            },
            new Product
            {
                Id = 13,
                Name = "Midnight Hawk Ski Board",
                Description = "High-speed carving board with carbon core.",
                Price = 320.00M,
                PictureUrl = "/images/products/ski-board-1.png",
                Type = "Boards",
                Brand = "Hawk",
                QuantityInStock = 15
            },
            new Product
            {
                Id = 14,
                Name = "Crimson Talon Ski Board",
                Description = "Freestyle board with reinforced bindings.",
                Price = 299.99M,
                PictureUrl = "/images/products/ski-board-2.png",
                Type = "Boards",
                Brand = "Hawk",
                QuantityInStock = 21
            },
            new Product
            {
                Id = 15,
                Name = "Frost Serpent Ski Board",
                Description = "Lightweight and flexible board for tricks.",
                Price = 289.99M,
                PictureUrl = "/images/products/ski-board-3.png",
                Type = "Boards",
                Brand = "Serpent",
                QuantityInStock = 25
            },
            new Product
            {
                Id = 16,
                Name = "Shadowline Drift Ski Board",
                Description = "Wide profile board for backcountry powder.",
                Price = 310.00M,
                PictureUrl = "/images/products/ski-board-4.png",
                Type = "Boards",
                Brand = "Serpent",
                QuantityInStock = 18
            },
            new Product
            {
                Id = 17,
                Name = "Glacier Edge Ski Board",
                Description = "Edge-controlled board for slalom skiing.",
                Price = 305.00M,
                PictureUrl = "/images/products/ski-board-5.png",
                Type = "Boards",
                Brand = "Glacier",
                QuantityInStock = 17
            },
            new Product
            {
                Id = 18,
                Name = "Volt Striker Ski Board",
                Description = "Stiff board for experienced riders and high-speed descent.",
                Price = 315.00M,
                PictureUrl = "/images/products/ski-board-6.png",
                Type = "Boards",
                Brand = "Glacier",
                QuantityInStock = 22
            }
        );
#endif
    }
}