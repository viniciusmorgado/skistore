using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkiStore.Core.Entities;
using SkiStore.Infrastructure.Data;

namespace SkiStore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly StoreContext _context;
    
    public ProductsController(StoreContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> Get()
    {
        return await _context.Products.ToListAsync();
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return NotFound();
        return product;
    }
    
    [HttpPost]
    public async Task<ActionResult<Product>> Post(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        // TODO: Don't return anything beyond the 200 HTTTP response if frontend don't need.
        return product;
    }
}
