using SkiStore.Core.Entities;

namespace SkiStore.Core.Interfaces;

public interface IProductRepository
{
    Task<IReadOnlyList<Product>> GetAsync();
    Task<Product> GetByIdAsync(int id);
    void Post(Product product);
    void Put(Product product);
    void Delete(Product product);
    bool ProductExists(int id);
    Task<bool> SaveChangesAsync();
}
