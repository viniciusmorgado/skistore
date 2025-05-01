namespace SkiStore.Core.Aggregates.Order;

public enum OrderStatus
{
    Pending,
    PaymentReceived,
    PaymentFailed,
    Shipped,
}
