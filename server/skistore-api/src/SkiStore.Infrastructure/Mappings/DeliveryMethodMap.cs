using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkiStore.Core.Entities;

namespace SkiStore.Infrastructure.Mappings;

public class DeliveryMethodMap : IEntityTypeConfiguration<DeliveryMethod>
{
    public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
    {
        builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
#if DEBUG
        builder.HasData(
            new DeliveryMethod
            {
                Id = 1,
                ShortName = "UPS1",
                Description = "Fastest delivery time",
                DeliveryTime = "1-2 Days",
                Price = 10
            },
            new DeliveryMethod
            {
                Id = 2,
                ShortName = "UPS2",
                Description = "Get it within 5 days",
                DeliveryTime = "2-5 Days",
                Price = 5
            },
            new DeliveryMethod
            {
                Id = 3,
                ShortName = "UPS3",
                Description = "Slower but cheap",
                DeliveryTime = "5-10 Days",
                Price = 2
            },
            new DeliveryMethod
            {
                Id = 4,
                ShortName = "FREE",
                Description = "Free! You get what you pay for",
                DeliveryTime = "1-2 Weeks",
                Price = 0
            }
        );
#endif
    }
}
