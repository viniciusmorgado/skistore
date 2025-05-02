using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkiStore.Core.Aggregates.Order;

namespace SkiStore.Infrastructure.Mappings;

public class OrderMap : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.OwnsOne(x => x.ShippingAddress, o => o.WithOwner());
        builder.OwnsOne(x => x.PaymentSummary, o => o.WithOwner());
        builder.Property(x => x.OrderStatus).HasConversion(
            o => o.ToString(),
            o => Enum.Parse<OrderStatus>(o)
        );
        builder.Property(x => x.SubTotal).HasColumnType("decimal(18,2)");
        builder.HasMany(x => x.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);
        builder.Property(x => x.OrderDate).HasConversion(
            d => d.ToUniversalTime(),
            d => DateTime.SpecifyKind(d, DateTimeKind.Utc)
        );
    }
}
