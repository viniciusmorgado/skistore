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
                Name = "Angular Speedster Board 2000",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                Price = 200,
                PictureUrl = "/images/products/sb-ang1.png",
                Type = "Boards",
                Brand = "Angular",
                QuantityInStock = 82
            },
            new Product
            {
                Id = 2,
                Name = "Green Angular Board 3000",
                Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                Price = 150,
                PictureUrl = "/images/products/sb-ang2.png",
                Type = "Boards",
                Brand = "Angular",
                QuantityInStock = 75
            },
            new Product
            {
                Id = 3,
                Name = "Core Board Speed Rush 3",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                Price = 180,
                PictureUrl = "/images/products/sb-core1.png",
                Type = "Boards",
                Brand = "NetCore",
                QuantityInStock = 3
            },
            new Product
            {
                Id = 4,
                Name = "Net Core Super Board",
                Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                Price = 300,
                PictureUrl = "/images/products/sb-core2.png",
                Type = "Boards",
                Brand = "NetCore",
                QuantityInStock = 52
            },
            new Product
            {
                Id = 5,
                Name = "React Board Super Whizzy Fast",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                Price = 250,
                PictureUrl = "/images/products/sb-react1.png",
                Type = "Boards",
                Brand = "React",
                QuantityInStock = 97
            },
            new Product
            {
                Id = 6,
                Name = "Typescript Entry Board",
                Description = "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.",
                Price = 120,
                PictureUrl = "/images/products/sb-ts1.png",
                Type = "Boards",
                Brand = "Typescript",
                QuantityInStock = 37
            },
            new Product
            {
                Id = 7,
                Name = "Core Blue Hat",
                Description = "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                Price = 10,
                PictureUrl = "/images/products/hat-core1.png",
                Type = "Hats",
                Brand = "NetCore",
                QuantityInStock = 32
            },
            new Product
            {
                Id = 8,
                Name = "Green React Woolen Hat",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                Price = 8,
                PictureUrl = "/images/products/hat-react1.png",
                Type = "Hats",
                Brand = "React",
                QuantityInStock = 6
            },
            new Product
            {
                Id = 9,
                Name = "Purple React Woolen Hat",
                Description = "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                Price = 15,
                PictureUrl = "/images/products/hat-react2.png",
                Type = "Hats",
                Brand = "React",
                QuantityInStock = 17
            },
            new Product
            {
                Id = 10,
                Name = "Blue Code Gloves",
                Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                Price = 18,
                PictureUrl = "/images/products/glove-code1.png",
                Type = "Gloves",
                Brand = "VS Code",
                QuantityInStock = 74
            },
            new Product
            {
                Id = 11,
                Name = "Green Code Gloves",
                Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                Price = 15,
                PictureUrl = "/images/products/glove-code2.png",
                Type = "Gloves",
                Brand = "VS Code",
                QuantityInStock = 19
            },
            new Product
            {
                Id = 12,
                Name = "Purple React Gloves",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa.",
                Price = 16,
                PictureUrl = "/images/products/glove-react1.png",
                Type = "Gloves",
                Brand = "React",
                QuantityInStock = 77
            },
            new Product
            {
                Id = 13,
                Name = "Green React Gloves",
                Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                Price = 14,
                PictureUrl = "/images/products/glove-react2.png",
                Type = "Gloves",
                Brand = "React",
                QuantityInStock = 45
            },
            new Product
            {
                Id = 14,
                Name = "Glacius Red and Black Boots",
                Description = "Engineered for performance and comfort, this ski boot delivers precise control on the slopes. With a durable outer shell, customizable fit, and responsive flex, it's built to handle everything from groomed runs to backcountry adventures. The insulated liner keeps your feet warm, while micro-adjustable buckles ensure a secure fit all day long.",
                Price = 250,
                PictureUrl = "/images/products/68164aa8-1e5c-800a-a02b-7d7093ce6f64.png",
                Type = "Boots",
                Brand = "Glacius",
                QuantityInStock = 49
            },
            new Product
            {
                Id = 15,
                Name = "Glacius Yellow and Black Boots",
                Description = "Engineered for performance and comfort, this ski boot delivers precise control on the slopes. With a durable outer shell, customizable fit, and responsive flex, it's built to handle everything from groomed runs to backcountry adventures. The insulated liner keeps your feet warm, while micro-adjustable buckles ensure a secure fit all day long.",
                Price = 189.99M,
                PictureUrl = "/images/products/68164aa8-1e5c-800a-a02b-7d7093ce6f65.png",
                Type = "Boots",
                Brand = "Glacius",
                QuantityInStock = 28
            },
            new Product
            {
                Id = 16,
                Name = "Glacius Red and White Boots",
                Description = "Engineered for performance and comfort, this ski boot delivers precise control on the slopes. With a durable outer shell, customizable fit, and responsive flex, it's built to handle everything from groomed runs to backcountry adventures. The insulated liner keeps your feet warm, while micro-adjustable buckles ensure a secure fit all day long.",
                Price = 199.99M,
                PictureUrl = "/images/products/68164aa8-1e5c-800a-a02b-7d7093ce6f66.png",
                Type = "Boots",
                Brand = "Glacius",
                QuantityInStock = 69
            },
            new Product
            {
                Id = 17,
                Name = "Glacius Purple and Black Boots",
                Description = "Engineered for performance and comfort, this ski boot delivers precise control on the slopes. With a durable outer shell, customizable fit, and responsive flex, it's built to handle everything from groomed runs to backcountry adventures. The insulated liner keeps your feet warm, while micro-adjustable buckles ensure a secure fit all day long.",
                Price = 150,
                PictureUrl = "/images/products/68164aa8-1e5c-800a-a02b-7d7093ce6f67.png",
                Type = "Boots",
                Brand = "Glacius",
                QuantityInStock = 35
            },
            new Product
            {
                Id = 18,
                Name = "Glacius Green and Yellow Boots",
                Description = "Engineered for performance and comfort, this ski boot delivers precise control on the slopes. With a durable outer shell, customizable fit, and responsive flex, it's built to handle everything from groomed runs to backcountry adventures. The insulated liner keeps your feet warm, while micro-adjustable buckles ensure a secure fit all day long.",
                Price = 180,
                PictureUrl = "/images/products/68164aa8-1e5c-800a-a02b-7d7093ce6f68.png",
                Type = "Boots",
                Brand = "Glacius",
                QuantityInStock = 27
            }
        );
#endif
    }
}