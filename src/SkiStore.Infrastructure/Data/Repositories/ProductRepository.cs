using Microsoft.EntityFrameworkCore;
using SkiStore.Core.Entities;
using SkiStore.Core.Interfaces;

namespace SkiStore.Infrastructure.Data.Repositories;

public class ProductRepository(StoreContext context) : IProductRepository
{
    public async Task<IReadOnlyList<Product>> GetAsync(string? brand, string? type, string? sort)
    {
        var query = context.Products.AsQueryable();
        
        // TODO: ToLower all the names of brands and types
        if (!string.IsNullOrWhiteSpace(brand))
            query = query.Where(p => p.Brand.Contains(brand));
        
        if (!string.IsNullOrWhiteSpace(type)) 
            query = query.Where(p => p.Type.Contains(type));

        query = sort switch
        { 
            "priceAsc" => query.OrderBy(p => p.Price),
            "priceDesc" => query.OrderByDescending(p => p.Price),
            _ => query.OrderBy(p => p.Name)
        };
        
        return await query.ToListAsync();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return await context.Products.FindAsync(id);
#pragma warning restore CS8603 // Possible null reference return.
    }

    public void Post(Product product)
    {
        context.Products.Add(product);
    }

    public void Put(Product product)
    {
        context.Entry(product).State = EntityState.Modified;
    }

    public void Delete(Product product)
    {
        context.Products.Remove(product);
    }

    public bool ProductExists(int id)
    {
        return context.Products.Any(e => e.Id == id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<IReadOnlyList<string>> GetTypeAsync()
    {
        return await context.Products.Select(p => p.Type).Distinct().ToListAsync();
    }

    public async Task<IReadOnlyList<string>> GetBrandAsync()
    {
        return await context.Products.Select(p => p.Brand).Distinct().ToListAsync();
    }
}
