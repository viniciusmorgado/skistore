using SkiStore.Core.Base.Specs;
using SkiStore.Core.Entities;

namespace SkiStore.Core.Specs;

public class ProductSpec : BaseSpec<Product>
{
    public ProductSpec(ProductSpecParams specParams) : base(x =>
        (specParams.Brands.Count == 0 || specParams.Brands.Select(b => b.ToLower()).Contains(x.Brand.ToLower())) &&
        (specParams.Types.Count == 0 || specParams.Types.Select(t => t.ToLower()).Contains(x.Type.ToLower()))
    )
    {
        ApplyPaging(specParams.PageSize * (specParams.PageIndex -1), specParams.PageSize);

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
