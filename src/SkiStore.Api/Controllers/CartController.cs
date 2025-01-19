using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using SkiStore.Core.Entities;
using SkiStore.Core.Interfaces;

namespace SkiStore.Api.Controllers;

public class CartController(ICartService service) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<ShoppingCart>> GetCartById(string id)
    {
        return Ok(
            await service.GetCartAsync(id) ?? new ShoppingCart{Id = id}
        );
    }

    [HttpPost]
    public async Task<ActionResult<ShoppingCart>> UpdateCart(ShoppingCart cart)
    {
        return await service.SeCartAsync(cart);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteCart(string id)
    {
        return Ok(
            await service.DeleteCartAsync(id)
        );
    }
}
