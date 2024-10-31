using Microsoft.AspNetCore.Mvc;
using SkiStore.Core.Entities;
using SkiStore.Core.Interfaces;

namespace SkiStore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> Get()
    {
        return Ok(await repository.GetAsync());
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        return await repository.GetByIdAsync(id);
    }
    
    [HttpPost]
    public async Task<ActionResult<Product>> Post(Product product)
    {
        repository.Post(product);

        if (await repository.SaveChangesAsync())
        {
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        return BadRequest();
    }
    
    // TODO: This method is requiring the id in both body and URL, just URL should be necessary
    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, Product product)
    {
        if (product.Id != id || !ProductExists(id)) return BadRequest();
        
        repository.Put(product);
        
        if(await repository.SaveChangesAsync()) return NoContent();
        return BadRequest();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var product = await repository.GetByIdAsync(id);
        repository.Delete(product);
        
        if(await repository.SaveChangesAsync()) return NoContent();
        return BadRequest();
    }
    
    private bool ProductExists(int id)
    {
        return repository.ProductExists(id);
    }
}
