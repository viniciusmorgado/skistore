#nullable disable
using SkiStore.Core.Base.Entities;
using SkiStore.Core.Entities;

namespace SkiStore.Core.Aggregates.Order;

public class Order : BaseEntity
{
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public required string BuyerEmail { get; set; }
    public ShippingAddress ShippingAddress { get; set; }
    public DeliveryMethod DeliveryMethod { get; set; }
    public PaymentSummary PaymentSummary { get; set; }
    public IReadOnlyList<OrderItem> OrderItems { get; set; }
    public decimal SubTotal { get; set; }
    public OrderStatus OrderStatus { get; init; } = OrderStatus.Pending;
    public required string PaymentIntentId { get; set; }
    
}
