using SkiStore.Core.Entities;

namespace SkiStore.Core.Interfaces;

public interface IPaymentService
{
    Task<ShoppingCart> CreateOrUpdatePaymentIntent(string cartId);    
}