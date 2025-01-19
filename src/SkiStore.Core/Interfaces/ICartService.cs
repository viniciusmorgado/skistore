using SkiStore.Core.Entities;

namespace SkiStore.Core.Interfaces;

public interface ICartService
{
    Task<ShoppingCart?> GetCartAsync(string key);
    Task<ShoppingCart?> SeCartAsync(ShoppingCart cart);
    Task<bool> DeleteCartAsync(string key);
}
