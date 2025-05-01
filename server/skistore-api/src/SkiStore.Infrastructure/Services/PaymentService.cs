#nullable disable
using Microsoft.Extensions.Configuration;
using SkiStore.Core.Base.Interfaces;
using SkiStore.Core.Entities;
using SkiStore.Core.Interfaces;
using Stripe;
using Product = SkiStore.Core.Entities.Product;

namespace SkiStore.Infrastructure.Services;

public class PaymentService(IConfiguration configuration
                           , ICartService cartService
                           , IUnitOfWork worker ) : IPaymentService
{
    public async Task<ShoppingCart> CreateOrUpdatePaymentIntent(string cartId)
    {
        StripeConfiguration.ApiKey = configuration["StripeSettings:PrivateKey"];
        
        var currency = configuration["StripeSettings:Currency"];

        List<string> paymentMethods = configuration.GetSection("StripeSettings:PaymentMethodTypes")
                                                   .GetChildren()
                                                   .Select(x => x.Value)
                                                   .ToList();

        var cart = await cartService.GetCartAsync(cartId);

        decimal shippingPrice;

        if (cart.DeliveryMethodId.HasValue)
        {
            var deliveryMethod = await worker.Repository<DeliveryMethod>().GetByIdAsync((int)cart.DeliveryMethodId);
            shippingPrice = deliveryMethod.Price;
        }

        foreach (var item in cart.Items)
        {
            var productItem = await worker.Repository<Product>().GetByIdAsync(item.ProductId);

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
                Currency = currency,
                PaymentMethodTypes = paymentMethods
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
