using SkiStore.Core.Base.Specs;
using SkiStore.Core.Entities;

namespace SkiStore.Core.Specs;

public class TypeSpec : BaseSpec<Product, string>
{
    public TypeSpec()
    {
        AddSelect(x => x.Type);
        ApplyDistinct();
    }
}
