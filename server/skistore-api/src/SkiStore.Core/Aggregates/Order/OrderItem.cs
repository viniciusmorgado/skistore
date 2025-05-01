using SkiStore.Core.Base.Entities;

namespace SkiStore.Core.Aggregates.Order;

public class OrderItem : BaseEntity
{
    public ProductItemOrdered ItemOrdered { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
