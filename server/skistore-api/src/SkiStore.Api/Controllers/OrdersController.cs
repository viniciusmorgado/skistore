using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkiStore.Api.DTOs;
using SkiStore.Api.Extensions;
using SkiStore.Core.Aggregates.Order;
using SkiStore.Core.Entities;
using SkiStore.Core.Interfaces;
using SkiStore.Core.Specs;

namespace SkiStore.Api.Controllers;

[Authorize]
public class OrdersController(ICartService cartService, IUnitOfWork worker) : BaseApiController
{
    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder(CreateOrderDto createOrderDto)
    {
        var email = User.GetEmail();
        var cart = await cartService.GetCartAsync(createOrderDto.CartId);

        if (cart == null) return BadRequest("Order can't be created.");

        var items = new List<OrderItem>();

        foreach (var item in cart.Items)
        {
            var productItem = await worker.Repository<Product>().GetByIdAsync(item.ProductId);
            var itemOrdered = new ProductItemOrdered
            {
                ProductId = item.ProductId,
                ProductName = item.ProductName,
                PictureUrl = item.PictureUrl
            };
            var orderItem = new OrderItem
            {
                ItemOrdered = itemOrdered,
                Price = productItem.Price,
                Quantity = item.Quantity,
            };
            items.Add(orderItem);
        }
        
        var deliveryMethod = await worker.Repository<DeliveryMethod>().GetByIdAsync(createOrderDto.DeliveryMethodId);

        var order = new Order
        {
            OrderItems = items,
            DeliveryMethod = deliveryMethod,
            ShippingAddress = createOrderDto.ShippingAddress,
            SubTotal = items.Sum(x => x.Price * x.Quantity),
            PaymentSummary = createOrderDto.PaymentSummary,
            PaymentIntentId = cart.PaymentIntentId,
            BuyerEmail = email,
        };

        worker.Repository<Order>().Post(order);

        if (await worker.Complete()) return order;
        
        return BadRequest("Problem creating order");
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<OrderDto>>> GetOrdersForUser(int id)
    {
        var spec = new OrderSpec(User.GetEmail());
        var orders = await worker.Repository<Order>().GetAllWithSpec(spec);
        var ordersToReturn = orders.Select(o => o.ToDto()).ToList();
        return Ok(ordersToReturn);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<OrderDto>> GetOrderById(int id)
    {
        var spec = new OrderSpec(User.GetEmail(), id);
        var order = await worker.Repository<Order>().GetEntityWithSpec(spec);        
        return order.ToDto();
    }
}
