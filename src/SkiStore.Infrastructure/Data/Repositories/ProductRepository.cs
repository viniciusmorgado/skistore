#nullable disable
using Microsoft.EntityFrameworkCore;
using SkiStore.Core.Entities;
using SkiStore.Core.Interfaces;

namespace SkiStore.Infrastructure.Data.Repositories;

public class ProductRepository(StoreContext context) : IProductRepository
{
    public async Task<IReadOnlyList<Product>> GetAsync()
    {
        return await context.Products.ToListAsync();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await context.Products.FindAsync(id);
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
}
