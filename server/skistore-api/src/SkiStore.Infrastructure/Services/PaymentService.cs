#nullable disable
using Microsoft.Extensions.Configuration;
using SkiStore.Core.Base.Interfaces;
using SkiStore.Core.Entities;
using SkiStore.Core.Interfaces;
using Stripe;

namespace SkiStore.Infrastructure.Services;

public class PaymentService(IConfiguration configuration
                           , ICartService cartService
                           , IGenericRepository<Core.Entities.Product> productRepository
                           , IGenericRepository<DeliveryMethod> deliveryMethodRepository) : IPaymentService
{
    public async Task<ShoppingCart> CreateOrUpdatePaymentIntent(string cartId)
    {
        StripeConfiguration.ApiKey = configuration["StripeSettings:PrivateKey"];
        
        var cart = await cartService.GetCartAsync(cartId);

        decimal shippingPrice;

        if (cart.DeliveryMethodId.HasValue)
        {
            var deliveryMethod = await deliveryMethodRepository.GetByIdAsync((int)cart.DeliveryMethodId);
            shippingPrice = deliveryMethod.Price;
        }

        foreach (var item in cart.Items)
        {
            var productItem = await productRepository.GetByIdAsync(item.ProductId);

            if (item.Price != productItem.Price) item.Price = productItem.Price;
        }

        var service = new PaymentIntentService();

        PaymentIntent intent;

        if (string.IsNullOrEmpty(cart.PaymentIntentId))
        {
            shippingPrice = 0m;

            var options = new PaymentIntentCreateOptions
            {    
                Amount = (long)cart.Items.Sum(x => x.Quantity * (x.Price * 100)) + (long)shippingPrice * 100,
                // TODO: This can't be hardcoded.
                Currency = "usd",
                PaymentMethodTypes = ["card"]
            };
            intent = await service.CreateAsync(options);
            cart.PaymentIntentId = intent.Id;
            cart.ClientSecret = intent.ClientSecret;
        }
        else
        {
            shippingPrice = 0m;

            var options = new PaymentIntentUpdateOptions
            {
                Amount = (long)cart.Items.Sum(x => x.Quantity * (x.Price * 100)) + (long)shippingPrice * 100
            };
            intent = await service.UpdateAsync(cart.PaymentIntentId, options);
        }

        await cartService.SeCartAsync(cart);
        return cart;
    }
}
