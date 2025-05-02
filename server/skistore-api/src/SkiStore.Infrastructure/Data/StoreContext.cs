using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkiStore.Core.Aggregates.Order;
using SkiStore.Core.Entities;

namespace SkiStore.Infrastructure.Data;

public class StoreContext(DbContextOptions options) : IdentityDbContext<AppUser>(options)
{
    public DbSet<Product> Products { get; init; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
    // TODO: Check about the aggregation design here
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreContext).Assembly);
    }
}
