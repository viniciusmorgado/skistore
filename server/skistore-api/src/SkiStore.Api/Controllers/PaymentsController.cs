using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkiStore.Core.Base.Interfaces;
using SkiStore.Core.Entities;
using SkiStore.Core.Interfaces;

namespace SkiStore.Api.Controllers;

public class PaymentsController( IPaymentService service
                               , IGenericRepository<DeliveryMethod> deliveryMethodRepository) : BaseApiController
{
    [Authorize]
    [HttpPost("{cardId}")]
    public async Task<ActionResult<ShoppingCart>> CreateOrUpdatePaymentIntent(string cardId)
    {
        var cart = await service.CreateOrUpdatePaymentIntent(cardId);
        if (cart == null) return BadRequest("Problem with your cart");
        return Ok(cart);
    } 

    [HttpGet("delivery-methods")]
    public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
    {
        return Ok(await deliveryMethodRepository.GetAllAsync());
    }
}