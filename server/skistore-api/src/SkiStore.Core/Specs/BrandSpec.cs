using SkiStore.Core.Base.Specs;
using SkiStore.Core.Entities;

namespace SkiStore.Core.Specs;

public class BrandSpec : BaseSpec<Product, string>
{
    public BrandSpec()
    {
        AddSelect(x => x.Brand);
        ApplyDistinct();
    }
}
