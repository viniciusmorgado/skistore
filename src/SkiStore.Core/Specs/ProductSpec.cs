using SkiStore.Core.Base.Specs;
using SkiStore.Core.Entities;

namespace SkiStore.Core.Specs;

public class ProductSpec : BaseSpec<Product>
{
    public ProductSpec(string? brand, string? type) : base(x => 
        (string.IsNullOrWhiteSpace(brand) || x.Brand == brand) &&
        (string.IsNullOrWhiteSpace(type) || x.Type == type)
    ) { }
}
