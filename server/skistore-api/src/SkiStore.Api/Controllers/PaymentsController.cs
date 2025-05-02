using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkiStore.Core.Base.Interfaces;
using SkiStore.Core.Entities;
using SkiStore.Core.Interfaces;

namespace SkiStore.Api.Controllers;

public class PaymentsController( IPaymentService service
                               , IUnitOfWork worker ) : BaseApiController
//public class PaymentsController( IPaymentService service
//                               , IGenericRepository<DeliveryMethod> deliveryMethodRepository ) : BaseApiController
{
    [Authorize]
    [HttpPost("{cardId}")]
    public async Task<ActionResult<ShoppingCart>> CreateOrUpdatePaymentIntent(string cardId)
    {
        return Ok(await service.CreateOrUpdatePaymentIntent(cardId));
    }

    [HttpGet("delivery-methods")]
    public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
    {
        return Ok(await worker.Repository<DeliveryMethod>().GetAllAsync());
    }
}
