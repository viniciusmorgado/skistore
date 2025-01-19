namespace SkiStore.Core.Entities;

public class ShoppingCart
{
    public required int Id { get; set; }
    public List<CartItem> Items { get; set; } = [];
}
