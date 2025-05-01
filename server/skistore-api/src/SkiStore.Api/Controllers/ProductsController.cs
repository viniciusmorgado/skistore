#nullable enable
using Microsoft.AspNetCore.Mvc;
using SkiStore.Core.Entities;
using SkiStore.Core.Interfaces;
using SkiStore.Core.Specs;

namespace SkiStore.Api.Controllers;

public class ProductsController(IUnitOfWork worker) : BaseApiController
//public class ProductsController(IGenericRepository<Product> repository) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> Get([FromQuery] ProductSpecParams specParams)
    {
        return await CreatedPagedResult(
            worker.Repository<Product>(), 
            new ProductSpec(specParams),
            specParams.PageIndex,
            specParams.PageSize
        );
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var product = await worker.Repository<Product>().GetByIdAsync(id);

        // TODO: Move this to a validator class.
        if (!IsProductFound(product)) return NotFound();
        
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> Post(Product product)
    {
        if (!IsProductValid(product)) return BadRequest();
        
        worker.Repository<Product>().Post(product);

        if (!await IsSaveSuccessful()) return BadRequest();
        
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, Product product)
    {
        if (!IsProductValid(product)) return BadRequest("Product is not valid");
        if (!IsProductExisting(id)) return NotFound("Product do not exists");
        if (!IsIdMatchingProduct(id, product)) return BadRequest("Id do not match the product");
        
        product.Id = id;
        worker.Repository<Product>().Put(product);
        
        if (!await IsSaveSuccessful()) return BadRequest("Product do not successfully saved");
        
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var product = await worker.Repository<Product>().GetByIdAsync(id);
        
        // TODO: Move this to a validator class.
        if (!IsProductFound(product)) return NotFound();
        
        worker.Repository<Product>().Delete(product);
        
        if (!await IsSaveSuccessful()) return BadRequest();
        
        return NoContent();
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetBrands()
    {
        return Ok(await worker.Repository<Product>().GetAllWithSpec(new BrandSpec()));
    }

    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetTypes()
    {
        return Ok(await worker.Repository<Product>().GetAllWithSpec(new TypeSpec()));
    }

    // Validation Methods
    private static bool IsProductFound(Product? product)
    {
        return product is not null;
    }

    private bool IsProductExisting(int id)
    {
        return worker.Repository<Product>().Exists(id);
    }

    private static bool IsProductValid(Product product)
    {
        return product is not null && 
               !string.IsNullOrEmpty(product.Name) && 
               !string.IsNullOrEmpty(product.Description) &&
               !string.IsNullOrEmpty(product.PictureUrl) &&
               !string.IsNullOrEmpty(product.Type) &&
               !string.IsNullOrEmpty(product.Brand) &&
               product.Price > 0;
    }

    private static bool IsIdMatchingProduct(int id, Product product)
    {
        return product.Id == id;
    }

    private async Task<bool> IsSaveSuccessful()
    {
        return await worker.Repository<Product>().SaveChangesAsync();
    }
}
