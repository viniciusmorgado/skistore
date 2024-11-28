using SkiStore.Core.Base.Specs;
using SkiStore.Core.Entities;

namespace SkiStore.Core.Specs;

public class ProductSpec : BaseSpec<Product>
{
    public ProductSpec(ProductSpecParams specParams) : base(x => 
        (specParams.Brands.Count == 0 || specParams.Brands.Contains(x.Brand)) &&
        (specParams.Types.Count == 0 || specParams.Brands.Contains(x.Type))
    ) // !specParams.Types.Any()
    { 
        switch (specParams.Sort)
        {
            case "priceAsc":
                AddOrderBy(x => x.Price);
                break;
            case "priceDesc":
                AddOrderByDescending(x => x.Price);
                break;
            default:
                AddOrderBy(x => x.Name);
                break;
        }
    }
}
